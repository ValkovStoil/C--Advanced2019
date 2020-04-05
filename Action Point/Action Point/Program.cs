using System;

namespace Action_Point
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
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
