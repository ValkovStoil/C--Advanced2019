using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordCount = new Dictionary<string, int>();
            using (var reader = new StreamReader("words.txt"))
            {
                var words = reader.ReadLine().Split(" ");

                foreach (var word in words)
                {
                    wordCount[word] = 0;
                }
            }

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine()
                        .Split(" ,-?!.".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    foreach (var word in line)
                    {
                        if (wordCount.ContainsKey(word.ToLower()))
                        {
                            wordCount[word.ToLower()] += 1;
                        }
                    }
                }
            }

            wordCount = wordCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            using (var writer = new StreamWriter("output.txt", false))
            {
                foreach (var word in wordCount)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
