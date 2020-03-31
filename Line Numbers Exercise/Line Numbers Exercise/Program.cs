using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Line_Numbers_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {

            var symbols = new string[] { "-", ",", ".", "!", "?", "'" };
            var lines = new List<string>(File.ReadAllLines("text.txt"));


            for (var  i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var symbolCount = 0;
                var charCount = 0;

                foreach (var word in words)
                {
                    var countSymbol = 0;
                    foreach (var symbol in symbols)
                    {
                        if (word.Contains(symbol))
                        {
                            countSymbol++;
                        }
                    }
                    charCount += word.Length - countSymbol;

                    symbolCount += countSymbol;
                }

                var sb = new StringBuilder();

                sb.Append($"Line {i + 1}: {line} ({charCount})({symbolCount})");

                lines[i] = sb.ToString();
            }

            File.WriteAllLines("output.txt", lines);
        }
    }
}
