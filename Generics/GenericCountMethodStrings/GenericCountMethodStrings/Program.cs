using System;

namespace GenericCountMethodStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var counter = int.Parse(Console.ReadLine());
            var elements = new Box<string>();

            for (int i = 0; i < counter; i++)
            {
                var inputData = Console.ReadLine();

                elements.Value.Add(inputData);
            }

            var comparisonValue = Console.ReadLine();

            var result = elements.Compare(comparisonValue);

            Console.WriteLine(result);
        }
    }
}
