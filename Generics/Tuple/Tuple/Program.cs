using System;
using System.Collections.Generic;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine()
                .Split();
            var person = firstLine[0] + " " + firstLine[1];
            var addres = firstLine[2];

            var secondLine = Console.ReadLine()
                .Split();
            var name = secondLine[0];
            var litersOfBeer = int.Parse(secondLine[1]);

            var thirdLine = Console.ReadLine()
                .Split();

            var intInput = int.Parse(thirdLine[0]);
            var doubleInput = double.Parse(thirdLine[1]);

            var firstTp = new TupleClass<string, string>(person, addres);
            var secondTp = new TupleClass<string, int>(name, litersOfBeer);
            var thirdTp = new TupleClass<int, double>(intInput, doubleInput);

            Console.WriteLine(firstTp);
            Console.WriteLine(secondTp);
            Console.WriteLine(thirdTp);
        }
    }
}
