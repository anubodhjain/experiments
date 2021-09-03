using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SampleCode
{
    public class FileRead
    {
        public void FileReadUsingStreamReader_WithContains(string fPath)
        {
            List<string> values = new List<string>();
            using var stream = new StreamReader(fPath);
            while (!stream.EndOfStream)
            {
                var data = stream.ReadLine();
                if (data.Contains("setTodayTotalDetailSteps"))
                {
                    //find steps for day.
                    var value=data.Split('#')[2];
                    values.Add(value);
                }
            }
            Console.WriteLine($"total values={values.Count}");

        }

        public void FileReadUsingStreamReader_WithIndexOf(string fPath)
        {
            List<string> values = new List<string>();
            using var stream = new StreamReader(fPath);
            while (!stream.EndOfStream)
            {
                var data = stream.ReadLine();
                if (data.IndexOf("setTodayTotalDetailSteps")>0)
                {
                    //find steps for day.
                    var value = data.Split('#')[2];
                    values.Add(value);
                }
            }
            Console.WriteLine($"total values={values.Count}");

        }

        public void FileReadUsingStreamReader_JustRead(string fPath)
        {
            List<string> values = new List<string>();
            using var stream = new StreamReader(fPath);
            ReadOnlySpan<char> data;
            while (!stream.EndOfStream)
            {
                data = stream.ReadLine().AsSpan();
            }
            Console.WriteLine($"total values={values.Count}");
        }

        public void FileReadUsingBufferedStream_JustRead(string fPath)
        {
            List<string> values = new List<string>();
            using FileStream fs = File.OpenRead(fPath);
            using var bs = new BufferedStream(fs,256);
            using var stream = new StreamReader(bs);
            string s;
            while ((s = stream.ReadLine()) != null)
            {
                //we're just testing read speeds    
            }
            Console.WriteLine($"total values={values.Count}");
        }

        public void FileReadUsingReadAllText_JustRead(string fPath)
        {
            List<string> values = new List<string>();
            var stream = File.ReadAllText(fPath);
            
            Console.WriteLine($"total values={values.Count}");
        }

        public void FileReadUsingReadLines_JustRead(string fPath)
        {
            List<string> values = new List<string>();
            Console.WriteLine($"reading lines");
            foreach(var line in File.ReadLines(fPath))
            {

            }

            Console.WriteLine($"total values={values.Count}");
        }

        public void FileReadUsingStreamReader_WithContains_WithoutSplit(string fPath)
        {
            List<string> values = new List<string>();
            using var stream = new StreamReader(fPath);
            while (!stream.EndOfStream)
            {
                var data = stream.ReadLine();
                if (data.Contains("setTodayTotalDetailSteps"))
                {
                    //find steps for day.
                    var hashIndex = data.IndexOf('#',StringComparison.Ordinal);
                    var upto = data.IndexOf('#', hashIndex + 2);
                    var value = data.Substring(hashIndex + 2, upto-(hashIndex+2));
                    values.Add(value);
                }
            }
            Console.WriteLine($"total values={values.Count}");

        }
    }
}
