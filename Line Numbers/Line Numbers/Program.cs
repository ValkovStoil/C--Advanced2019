using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 1;
            using (var reader = new StreamReader("Line Numbers.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        writer.WriteLine($"{counter}. {line}", false);
                        //Console.WriteLine($"{counter}. {line}");

                        counter++;
                    }
                }
            }
        }
    }
}
