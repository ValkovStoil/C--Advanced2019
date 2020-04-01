using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Word_Count_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsDcit = new Dictionary<string, int>();
            var splitArray = new char[] { '-', ',', '.', '!', '?', ' ' };

            using (var reader = new StreamReader("../../../words.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var word = reader.ReadLine();

                    if (!wordsDcit.ContainsKey(word))
                    {
                        wordsDcit[word] = 0;
                    }
                }
            }


            using (var reader = new StreamReader("../../../text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var words = reader.ReadLine()
                        .Split(splitArray, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();


                    foreach (var word in words)
                    {
                        if (wordsDcit.ContainsKey(word.ToLower()))
                        {
                            wordsDcit[word.ToLower()]++;
                        }
                    }
                }
            }

            var sb = new StringBuilder();

            foreach (var (word, count) in wordsDcit)
            {
                sb.AppendLine($"{word} - {count} {Environment.NewLine}");
            }

            File.WriteAllText("../../../actualResult.txt",sb.ToString());


            wordsDcit = wordsDcit
                .OrderByDescending(v => v.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            sb.Clear();

            foreach (var (word, count) in wordsDcit)
            {
                sb.AppendLine($"{word} - {count} {Environment.NewLine}");
            }

            File.WriteAllText("../../../epectedResult.txt", sb.ToString());
        }
    }
}
