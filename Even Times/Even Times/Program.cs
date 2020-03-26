using System;
using System.Collections.Generic;
using System.Linq;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Dictionary<int, int>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }
                numbers[num]++;
            }

            numbers = numbers.Where(x => x.Value % 2 == 0)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var num in numbers)
            {
                Console.WriteLine(num.Key);
            }
        }
    }
}
