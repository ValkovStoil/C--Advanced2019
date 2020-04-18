using System;

namespace Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var personInfo = Console.ReadLine()
                .Split();

            var person = $"{personInfo[0]} {personInfo[1]}";
            var addres = personInfo[2];
            var town = string.Empty;

            ;
            if(personInfo.Length > 4)
            {
                town = $"{personInfo[3]} {personInfo[4]}";
            }
            else
            {
                town = personInfo[3];
            }

            var personBeerInfo = Console.ReadLine()
                .Split();

            var name = personBeerInfo[0];
            var litersOfbear = int.Parse(personBeerInfo[1]);
            var drunk = false;

            if(personBeerInfo[2] == "drunk")
            {
                drunk = true;
            }

            var personBankInfo = Console.ReadLine()
                .Split();

            var userAccaunt = personBankInfo[0];
            var accauntBalance = double.Parse(personBankInfo[1]);
            var bankName = personBankInfo[2];

            var personAddres = new MyThreeuple<string, string, string>(person, addres, town);
            var personDrunkOrNot = new MyThreeuple<string, int, bool>(name, litersOfbear, drunk);
            var personBankAccount = new MyThreeuple<string, double, string>(userAccaunt, accauntBalance, bankName);


            Console.WriteLine(personAddres);
            Console.WriteLine(personDrunkOrNot);
            Console.WriteLine(personBankAccount);
        }
    }
}
