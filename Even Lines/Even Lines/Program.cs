using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {

            var counter = 0;
            var symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };

            using (var sr = new StreamReader("text.txt"))
            {
                while (!sr.EndOfStream)
                {

                    var words = sr.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (counter % 2 == 0)
                    {

                        for (int i = 0; i < words.Length; i++)
                        {
                            var word = words[i];

                            foreach (var symbol in symbolsToReplace)
                            {
                                word = word.Replace(symbol, '@');
                            }

                            words[i] = word;
                        }

                        ;
                        Console.WriteLine(string.Join(" ", words.Reverse()));
                    }

                    counter++;
                }
            }
        }
    }
}
