using System;
using System.Collections.Generic;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var firstName = firstLine[0];
            var secondName = firstLine[1];
            var addres = firstLine[2];
            var person = $"{firstName} {secondName}";

            var firstTp = new TupleClass<string,string>(person, addres);

            var secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = secondLine[0];
            var litersOfBeer = int.Parse(secondLine[1]);

            var secondTp = new TupleClass<string, int>(name, litersOfBeer);

            var thirdLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var intInput = int.Parse(thirdLine[0]);
            var doubleInput = double.Parse(thirdLine[1]);

            var thirdTp = new TupleClass<int, double>(intInput, doubleInput);

            Console.WriteLine(firstTp.ToString());
            Console.WriteLine(secondTp.ToString());
            Console.WriteLine(thirdTp.ToString());
        }
    }
}
