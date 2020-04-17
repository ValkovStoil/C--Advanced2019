using System;
using System.Collections.Generic;

namespace GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var inputData = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var stringInput = Console.ReadLine();

                inputData.Add(new Box<string>(stringInput));
            }

            foreach (var text in inputData)
            {
                Console.WriteLine(text.ToString());
            }
        }
    }
}
