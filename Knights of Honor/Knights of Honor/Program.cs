using System;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var print = new Action<string[]>(Print);

            print(names);
        }

        private static void Print(string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
