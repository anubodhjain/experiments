using System;
using System.Threading;

namespace VariousSnippets
{
    class Program
    {
        static int offset = 1;
        static int gap = 0;
        public static int[] sharedData;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            sharedData = new int[4 * offset + gap * offset];
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();
            offset = 1;
            gap = 0;
            
            DoFalseSharingTest(4);
            s.Stop();
            Console.WriteLine($"offset-{offset}, gap-{gap}, time taken (in ms)-{s.ElapsedMilliseconds}");
            s.Reset();
            s.Start();
            offset = 16;
            gap = 0;
            sharedData = null;
            sharedData = new int[4 * offset + gap * offset];
            DoFalseSharingTest(4);
            s.Stop();
            Console.WriteLine($"offset-{offset}, gap-{gap}, time taken (in ms)-{s.ElapsedMilliseconds}");
            s.Reset();
            s.Start();
            offset = 16;
            gap = 16;
            sharedData = null;
            sharedData = new int[4 * offset + gap * offset];
            DoFalseSharingTest(4);
            s.Stop();
            Console.WriteLine($"offset-{offset}, gap-{gap}, time taken (in ms)-{s.ElapsedMilliseconds}");
        }

        public static long DoFalseSharingTest(int threadsCount, int size =
        100_000_000)
        {
            Thread[] workers = new Thread[threadsCount];
            for (int i = 0; i < threadsCount; ++i)
            {
                workers[i] = new Thread(new ParameterizedThreadStart(idx =>
                {
                    int index = (int)idx + gap;
                    for (int j = 0; j < size; ++j)
                    {
                        sharedData[index * offset] = sharedData[index * offset] + 1;
                    }
                }));
            }
            for (int i = 0; i < threadsCount; ++i)
                workers[i].Start(i);
            for (int i = 0; i < threadsCount; ++i)
                workers[i].Join();
            return 0;
        }
    
    }
}
