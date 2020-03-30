using System;
using System.IO;

namespace Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 5;

            var totalSize = new FileInfo("input.txt").Length;
            var fileSize = (int)Math.Ceiling(totalSize / 5.0);

            using (var sr = new FileStream("input.txt", FileMode.Open))
            {
                for (int i = 1; i <= n; i++)
                {
                    var buffer = new byte[fileSize];
                    var read = sr.Read(buffer, 0, fileSize);

                    using (var wr = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        wr.Write(buffer, 0, read);
                    }
                }
            }
        }
    }
}
