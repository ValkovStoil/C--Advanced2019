using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = File.ReadAllLines("input1.txt").ToList();
            output.AddRange(File.ReadAllLines("input2.txt"));
            output.Sort();
            File.WriteAllLines("output.txt", output);
            
        }
    }
}
