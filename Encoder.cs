using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace UnderwaterVideo2
{
    public class Encoder
    {
        #region Properties

        int sampleRate = 96000;
        public int SampleRate
        {
            get { return sampleRate; }
            set 
            {
                if (value > 0)
                {
                    sampleRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("SampleRate", "Value must be greater than zero");
                }
            }
        }

        Size frameSize = new Size(120, 120);
        public Size FrameSize
        {
            get { return frameSize; }
            set 
            {
                frameSize = value;
                resizer.NewWidth = frameSize.Width;
                resizer.NewHeight = frameSize.Height;                
            }
        }

        ResizeBilinear resizer;

        int chipSize = 1;
        public int ChipSize
        {
            get { return chipSize; }
            set { chipSize = value; }
        }



        #endregion

        #region Constructor

        public Encoder(int sampleRate, Size frameSize, int chipSize)
        {            
            this.ChipSize = chipSize;
            this.SampleRate = sampleRate;
            resizer = new ResizeBilinear(frameSize.Width, frameSize.Height);
            this.FrameSize = frameSize;
        }
        
        #endregion

        #region Methods

        public int SamplesPerFrame(double carrier)
        {
            double samplesPerChip = chipSize * (SampleRate / carrier);
            return Convert.ToInt32(Math.Round(frameSize.Width * frameSize.Height * samplesPerChip));
        }

        public double[] Encode(Bitmap source, double carrier, int pSize, int interframePauseMs)
        {
            Bitmap frame;

            if (source.PixelFormat != System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                frame = Grayscale.CommonAlgorithms.RMY.Apply(source);
            else
                frame = source;
            
            if (!frame.Size.Equals(frameSize))
                frame = resizer.Apply(frame);

            int cols = frameSize.Width;
            int rows = frameSize.Height;

            int col = 0;
            int row = 0;

            double delta = Math.PI * 2 * carrier / sampleRate;
            double alpha = 0;
            double phase = 0;

            double pxAmplitude = 0;
            double chipLimit = Math.PI * 2 * chipSize;
            double pLimit = Math.PI * 2;

            List<double> samples = new List<double>();            

            bool isFinished = false;

            for (int i = 0; i < pSize; i++)
            {
                alpha = Math.Sin(phase);
                phase += delta;

                if (phase >= pLimit)
                {
                    phase -= pLimit;                    
                }

                samples.Add(alpha * short.MaxValue);
            }

            while (!isFinished)
            {
                alpha = Math.Sin(phase);
                phase += delta;

                if (phase >= chipLimit)
                {
                    phase -= chipLimit;
                    pxAmplitude = (((double)frame.GetPixel(col, row).R) / 255.0) * short.MaxValue;

                    if (++col >= cols)
                    {
                        if (++row >= rows)
                            isFinished = true;
                        else
                            col = 0;
                    }
                }

                samples.Add(alpha * pxAmplitude);                
            }

            if (interframePauseMs > 0)
            {
                samples.AddRange(new double[(int)((((double)interframePauseMs) / 1000.0) * (double)sampleRate)]);
            }

            return samples.ToArray();
        }

        public Bitmap Decode(double[] samples, double carrier, int pSize)
        {
            int cols = frameSize.Width;
            int rows = frameSize.Height;

            int col = 0;
            int row = 0;

            Bitmap result = new Bitmap(cols, rows);
           
            double delta = Math.PI * 2 * carrier / sampleRate;
            double alpha = 0;
            double phase = 0;
                        
            double chipLimit = Math.PI * 2 * chipSize;            
            double chipAmplitude = 0;
            double maxAmplitude = WaveUtils.GetMaxAmplitude(samples);
            double pxMax = -maxAmplitude;
            double pxMin = maxAmplitude;            

            double smp;

            for (int i = pSize; (i < samples.Length) && (row < rows); i++)
            {
                alpha = Math.Sin(phase);                
                phase += delta;
                
                if (phase >= chipLimit)
                {
                    phase -= chipLimit;
                    chipAmplitude = (Math.Max(Math.Abs(pxMax), Math.Abs(pxMin)) / maxAmplitude);
                    pxMin = maxAmplitude;
                    pxMax = -maxAmplitude;
                    var gs = Convert.ToByte(chipAmplitude * 255);

                    result.SetPixel(col, row, Color.FromArgb(255, gs, gs, gs));

                    if (++col >= cols)
                    {
                        col = 0;
                        row++;
                    }                   
                }
                else
                {
                    smp = samples[i] * alpha;
                    if (smp > pxMax)
                        pxMax = smp;
                    if (smp < pxMin)
                        pxMin = smp;
                }
            }

            return result;
        }

        #endregion
    }
}
