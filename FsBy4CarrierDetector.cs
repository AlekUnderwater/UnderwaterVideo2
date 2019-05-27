using System;

namespace UnderwaterVideo2
{
    public class FsBy4CarrierDetector
    {
        #region Properties

        int[] ring1;
        int[] ring2;

        int ringHead;
        int ringTail;

        int ringSize;

        double s1;
        double s2;
        double s;
        double sPrev;

        int cycle;
        int smpCount;

        public double Threshold { get; set; }      

        #endregion

        #region Constructor

        public FsBy4CarrierDetector(int rSize, double threshold)
        {
            if (rSize < 4) throw new ArgumentOutOfRangeException("rSize should be greater or equal 4");

            ringSize = rSize;

            ring1 = new int[ringSize];
            ring2 = new int[ringSize];

            Threshold = threshold;

            Init();
        }

        #endregion

        #region Methods

        public void Init()
        {
            s1 = 0;
            s2 = 0;
            s = 0;
            sPrev = -1;
            Array.Clear(ring1, 0, ringSize);
            Array.Clear(ring2, 0, ringSize);
            ringHead = ringSize - 1;
            ringTail = 0;
            cycle = 0;
            smpCount = 0;
        }

        public bool ProcessSample(short a)
        {
            bool result = false;

            if (smpCount == 0)
            {
                ring1[ringHead] = a;
                ring2[ringHead] = a;
                s1 += a - ring1[ringTail];
                s2 += a - ring2[ringTail];
            }
            else if (smpCount == 1)
            {
                ring1[ringHead] = a;
                ring2[ringHead] = -a;
                s1 += a - ring1[ringTail];
                s2 += - a - ring2[ringTail];
            }
            else if (smpCount == 2)
            {
                ring1[ringHead] = -a;
                ring2[ringHead] = -a;
                s1 += -a - ring1[ringTail];
                s2 += -a - ring2[ringTail];
            }
            else if (smpCount == 3)
            {
                ring1[ringHead] = -a;
                ring2[ringHead] = a;
                s1 += -a - ring1[ringTail];
                s2 += a - ring2[ringTail];
            }
                                                        
            ringHead = (ringHead + 1) % ringSize;
            ringTail = (ringTail + 1) % ringSize;

            if (++smpCount >= 4)
            {
                smpCount = 0;
                if (++cycle >= ringSize)
                {
                    s = Math.Sqrt(s1 * s1 + s2 * s2) / ringSize;                  
                    cycle = 0;                    
                    result = (s - sPrev) >= Threshold;                    
                    sPrev = s;
                }
            }

            return result;
        }
        
        #endregion
    }
}
