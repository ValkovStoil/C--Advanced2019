using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stones = Console.ReadLine()
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var lake = new Lake<int>(stones);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
