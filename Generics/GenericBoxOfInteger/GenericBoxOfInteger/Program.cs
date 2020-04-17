using System;
using System.Collections.Generic;

namespace GenericBoxOfInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var inputData = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                var stringInput = int.Parse(Console.ReadLine());

                inputData.Add(new Box<int>(stringInput));
            }

            foreach (var text in inputData)
            {
                Console.WriteLine(text.ToString());
            }
        }
    }
}
