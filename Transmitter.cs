
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using Waves;

namespace UnderwaterVideo2
{
    public class NextFrameEventArgs : EventArgs
    {
        public long Milliseconds { get; private set; }
        public double[] FrameSamples { get; private set; }

        public NextFrameEventArgs(long mSec, double[] frameSamples)
        {
            Milliseconds = mSec;
            FrameSamples = frameSamples;
        }
    }


    public class Transmitter
    {
        #region Properties

        ConcurrentQueue<Bitmap> frameQueue;
        Encoder encoder;

        BackgroundWorker backPlayer;

        public bool IsRunning
        {
            get
            {
                return backPlayer.IsBusy;
            }
        }

        int framesPerHalfBank = 4;
        public int FramesPerHalfBank
        {
            get { return framesPerHalfBank; }
        }
    
        double carrierHz = 24000;
        public double CarrierHz
        {
            get { return carrierHz; }
            set
            {
                carrierHz = value;
            }            
        }

        public int InterframePauseMs = 0;        

        int pSize = 0;

        #endregion

        #region Constructor

        public Transmitter(Encoder encoder, int maxQueueSize, int framesPerHalfBank, int pfxSize)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }
            else
            {
                this.encoder = encoder;
                frameQueue = new ConcurrentQueue<Bitmap>(maxQueueSize);
                backPlayer = new BackgroundWorker();
                backPlayer.DoWork += new DoWorkEventHandler(backPlayer_DoWork);
                backPlayer.WorkerSupportsCancellation = true;
                backPlayer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backPlayer_RunWorkerCompleted);

                this.framesPerHalfBank = framesPerHalfBank;
                pSize = pfxSize;
            }
        }

        #endregion

        #region Methods

        public void Start()
        {
            if (!IsRunning)
            {
                backPlayer.RunWorkerAsync();
                TransmissionStarted.Rise(this, new EventArgs());
            }
            else
            {
                throw new ApplicationException("Transmission in process");
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                backPlayer.CancelAsync();
            }
            else
            {
                throw new ApplicationException("Transmission not in running mode");
            }
        }

        public void ProcessNextFrame(Bitmap nextFrame)
        {
            frameQueue.Enqueue(nextFrame);
        }

        #endregion

        #region Handlers

        #region backPlayer

        private void backPlayer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TransmissionStopped.Rise(this, new EventArgs());
        }

        private void backPlayer_DoWork(object sender, DoWorkEventArgs e)
        {
            short[] samples;
            double[] fSamples;
            MemoryStream stream;
            SoundPlayer player;
            WaveWriter writer;
            Bitmap nextFrame;

            Stopwatch sw = new Stopwatch();

            player = new SoundPlayer();

            while (!backPlayer.CancellationPending)
            {
                if (frameQueue.TryDequeue(out nextFrame))
                {
                    sw.Reset();
                    sw.Start();

                    stream = new MemoryStream();
                    writer = new WaveWriter(stream, new WaveFormat(encoder.SampleRate, 16, 1));

                    fSamples = encoder.Encode(nextFrame, carrierHz, pSize, InterframePauseMs);
                    samples = WaveUtils.NormalizeToInt16(fSamples);
                    writer.WriteData(samples, 0, samples.Length);
                    writer.UpDateWaveHeader();
                    stream.Seek(0, SeekOrigin.Begin);

                    player.Stream = stream;

                    player.PlaySync();
                    stream.Close();

                    sw.Stop();
                    
                    FrameTransmitted.RiseInvoke(this, new NextFrameEventArgs(sw.ElapsedMilliseconds, fSamples));
                }
            }
        }

        #endregion

        #endregion

        #region Events

        public EventHandler TransmissionStarted;
        public EventHandler TransmissionStopped;
        public EventHandler<NextFrameEventArgs> FrameTransmitted;

        #endregion
    }

}
