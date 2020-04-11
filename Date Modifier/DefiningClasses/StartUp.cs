using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dateOne = Console.ReadLine();
            var dateTwo = Console.ReadLine();

            var dateModifire = new DateModifier(dateOne, dateTwo);

            var differcen = dateModifire.CalculateDayDifference();

            Console.WriteLine(differcen);
        }
    }
}
