using System;
using System.IO;
using System.Linq;

namespace Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var allFiles = Directory.GetFiles("../../../TestFolder").ToArray();

            var sum = 0.0;
            foreach (var file in allFiles)
            {
                var fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            using (var sr = new StreamWriter("output.txt",false))
            {
                sr.Write(sum / 1024 / 1024);
            }

        }
    }
}
