using System;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            /*
•	"add"->add 1 to each number
•	"multiply"->multiply each number by 2
•	"subtract"->subtract 1 from each number
•	"print"->print the collection
•	"end"
                */

            var commnad = Console.ReadLine();

            while (commnad != "end")
            {
                switch (commnad)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1);
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => n * 2);
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }

                commnad = Console.ReadLine();
            }
        }
    }
}
