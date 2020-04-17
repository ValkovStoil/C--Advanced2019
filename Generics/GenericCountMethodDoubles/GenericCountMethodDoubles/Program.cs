using System;

namespace GenericCountMethodDoubles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var counter = int.Parse(Console.ReadLine());
            var elements = new Box<double>();

            for (int i = 0; i < counter; i++)
            {
                var inputData = double.Parse(Console.ReadLine());

                elements.Value.Add(inputData);
            }

            var comparisonValue = double.Parse(Console.ReadLine());

            var result = elements.Compare(comparisonValue);

            Console.WriteLine(result);
        }
    }
}
