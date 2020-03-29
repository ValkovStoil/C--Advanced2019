using System;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            using (var reader = new StreamReader("Lines.txt"))
            {
                using (var output = new StreamWriter("Output.txt"))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (count % 2 == 1)
                        {
                            output.WriteLine(line, false);
                        }
                        count++;
                    }
                }
            }
        }
    }
}
