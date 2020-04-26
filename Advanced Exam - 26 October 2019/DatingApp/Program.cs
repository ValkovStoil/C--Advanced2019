using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var maleInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(m => m > 0)
                .ToArray();

            var fmaleInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(f => f > 0)
                .ToArray();

            var male = new Stack<int>(maleInfo);
            var fmale = new Queue<int>(fmaleInfo);

            var matchesCount = 0;

            while (male.Count != 0 && fmale.Count != 0)
            {
                var maleValue = male.Peek();
                var fmaleValue = fmale.Peek();

                if (maleValue <= 0)
                {
                    male.Pop();

                    continue;
                }

                if (maleValue % 25 == 0)
                {
                    if (male.Count > 1)
                    {
                        male.Pop();
                        male.Pop();
                    }
                    else
                    {
                        male.Pop();
                    }
                    continue;
                }

                if (fmaleValue % 25 == 0)
                {
                    if (fmale.Count > 1)
                    {
                        fmale.Dequeue();
                        fmale.Dequeue();
                    }
                    else
                    {
                        fmale.Dequeue();
                    }
                    continue;
                }


                if (maleValue == fmaleValue)
                {
                    male.Pop();
                    fmale.Dequeue();
                    matchesCount++;
                }
                else
                {
                    var decreaseMaleValue = male.Pop() - 2;
                    fmale.Dequeue();

                    male.Push(decreaseMaleValue);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (male.Count == 0 && fmale.Count != 0)
            {
                Console.WriteLine($"Males left: none");
                Console.WriteLine($"Females left: {string.Join(", ", fmale)}");
            }
            else if (fmale.Count == 0 && male.Count != 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", male)}");
                Console.WriteLine($"Females left: none");
            }
            else
            {
                Console.WriteLine($"Males left: none");
                Console.WriteLine($"Females left: none");
            }
        }
    }
}
