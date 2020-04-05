using System;
using System.Linq;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var predicate = new Func<int, int, bool>(NamePredicate);

            var output = names.Where(x => predicate(x.Length, n));

            Console.WriteLine(string.Join(Environment.NewLine,output));
        }

        private static bool NamePredicate(int nameLength, int n)
        {
            return nameLength <= n;
        }
    }
}
