using System;

namespace Car_Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var make = Console.ReadLine();
            var model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double feulConsumntion = double.Parse(Console.ReadLine());

            var firstCar = new Car();
            var secondCar = new Car(make, model, year);
            var thirdCard = new Car(make, model, year, fuelQuantity, feulConsumntion);

            Console.WriteLine(firstCar.WhoAmI());
            Console.WriteLine(secondCar.WhoAmI());
            Console.WriteLine(thirdCard.WhoAmI());
        }
    }
}
