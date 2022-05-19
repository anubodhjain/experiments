using System;
using System.Collections.Generic;
using System.Text;

namespace algo.DP
{
    class fibonacchi
    {
        public int GetFibonachiByRecursion_BAD(int num)
        {
            if (num <= 2) return 1;
            return GetFibonachiByRecursion_BAD(num - 1) + GetFibonachiByRecursion_BAD(num - 2);
        }

        private Dictionary<int, double> memoryFib = new Dictionary<int, double>();

        public double GetFibonachiByRecursion_Memoization(int num, Dictionary<int, double> mf = null)
        {
            if (mf == null) mf = memoryFib;
            if (mf.ContainsKey(num)) return mf[num];
            if (num <= 2) return 1;
            double val = GetFibonachiByRecursion_Memoization(num - 1, memoryFib) + GetFibonachiByRecursion_Memoization(num - 2, memoryFib);
            memoryFib.Add(num, val);
            return val;
        }

        public double GetFibonachiNaive(int num)
        {
            double last = 0;
            double sl = 0;
            double sum = 0;
            for (int i = 0; i <= num; i++)
            {
                sum = last + sl;
                if (i <= 2)
                    sum = 1;
                sl = last;
                last = sum;
            }

            return sum;
        }
    }
}
