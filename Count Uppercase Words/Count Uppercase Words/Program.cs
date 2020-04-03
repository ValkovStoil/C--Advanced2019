using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, bool> predicate = StartWithUpper;

            foreach (var word in words)
            {
                if (predicate(word))
                {
                    Console.WriteLine(word);
                }
            }
        }

        private static bool StartWithUpper(string word)
        {
            if(word[0] >= 65 && word[0] <= 90)
            {
                return true;
            }

            return false;
        }
    }
}
