using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Waves;

namespace UnderwaterVideo2
{
    public class FrameReceivedEventArgs : EventArgs
    {
        public Bitmap receivedFrame { get; private set; }

        public FrameReceivedEventArgs(Bitmap frame)
        {
            receivedFrame = frame;
        }
    }

    public class Receiver
    {
        #region Properties

        Encoder encoder;
        WaveIn waveIn;

        bool isRunning = false;
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
        }

        #region Buffers

        short[] buffer;
        int count = 0;
        int writePosition = 0;
        int readPosition = 0;
        int isSearching = 0;        

        #endregion

        int samplesPerFrame = 0;
        double carrier = 0;

        FsBy4CarrierDetector cDetector;       

        public double Threshold
        {
            get { return cDetector.Threshold; }
            set { cDetector.Threshold = value; }
        }

        bool isRise = false;

        double[] frame;
        int frameCnt = 0;

        int pSync = 0;
        public int PSync
        {
            get
            {
                return pSync;
            }
            set
            {
                pSync = value;
            }            
        }
        
        #endregion

        #region Constructor

        public Receiver(Encoder encoder, int waveInDeviceNumber, int bufferMultiplier, double carrier, int chipSize)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }
            else
            {
                this.encoder = encoder;
                waveIn = new WaveIn();
                waveIn.WaveFormat = new WaveFormat(encoder.SampleRate, 1);
                waveIn.DeviceNumber = waveInDeviceNumber;
                waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
                waveIn.RecordingStopped += new EventHandler(waveIn_RecordingStopped);

                int samplesPerPx = Convert.ToInt32(chipSize * encoder.SampleRate / carrier);
                buffer = new short[encoder.FrameSize.Width * encoder.FrameSize.Height * samplesPerPx * bufferMultiplier];

                this.carrier = carrier;
                samplesPerFrame = encoder.SamplesPerFrame(carrier);

                cDetector = new FsBy4CarrierDetector(120,  500);
            }
        }

        #endregion

        #region Methods

        public void Start()
        {
            if (!isRunning)
            {
                waveIn.StartRecording();
                isRunning = true;

                cDetector.Init();
                frame = new double[samplesPerFrame * 2];
                
                ReceivingStarted.Rise(this, new EventArgs());
            }
            else
            {
                throw new ApplicationException("Transmitter is running");
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                waveIn.StopRecording();
            }
            else
            {
                throw new ApplicationException("Transmitter is not in running mode");
            }
        }


        public void EmulInit()
        {
            cDetector.Init();
            frame = new double[samplesPerFrame * 2];
        }

        public void AddSamplesEmul(double[] samples)
        {
            for (int i = 0; i < samples.Length; i++)
            {
                buffer[writePosition] = Convert.ToInt16(samples[i]);
                count++;

                if (++writePosition >= buffer.Length)
                    writePosition = 0;
            }
          
            if (Interlocked.CompareExchange(ref isSearching, 1, 0) == 0)
                Search();
        }

        private void Search()
        {
            short a;

            while (count > 0)
            {
                a = buffer[readPosition];
                readPosition = (readPosition + 1) % buffer.Length;
                count--;

                if (isRise)
                {
                    frame[frameCnt] = a;

                    if (++frameCnt >= samplesPerFrame * 1.1)
                    {
                        cDetector.Init();
                        isRise = false;
                        FrameReceived.Rise(this, new FrameReceivedEventArgs(encoder.Decode(frame, carrier, pSync)));
                    }
                }
                else
                {
                    if (cDetector.ProcessSample(a))
                    {
                        isRise = true;
                        frameCnt = 0;
                    }
                }    
            }

            Interlocked.Decrement(ref isSearching);
        }

        #endregion

        #region Handlers

        #region WaveIn

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            int samplesLength = e.BytesRecorded / 2;

            for (int i = 0; i < samplesLength; i++)
            {
                buffer[writePosition] = BitConverter.ToInt16(e.Buffer, i * 2);
                count++;

                if (++writePosition >= buffer.Length)
                    writePosition = 0;
            }   

            if (isRunning)
                if (Interlocked.CompareExchange(ref isSearching, 1, 0) == 0)
                    Search();
        }

        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            isRunning = false;
            ReceivingStopped.Rise(this, new EventArgs());
        }

        #endregion

        #endregion

        #region Events

        public EventHandler ReceivingStarted;
        public EventHandler ReceivingStopped;
        public EventHandler<FrameReceivedEventArgs> FrameReceived;

        #endregion
    }

}
