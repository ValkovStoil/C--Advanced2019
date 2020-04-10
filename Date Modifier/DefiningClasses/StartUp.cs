using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dateOne = Console.ReadLine();
            var dateTwo = Console.ReadLine();

            var dateModifire = new DateModifier(dateOne, dateTwo);

            var differcen = dateModifire.CalculateDayDifference();

            Console.WriteLine(differcen);
        }
    }
}
