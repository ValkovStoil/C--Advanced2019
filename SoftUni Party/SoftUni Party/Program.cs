using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Party
{
    class Program
    {


        /*
         7IK9Yo0h
9NoBUajQ
Ce8vwPmE
SVQXQCbc
tSzE5t0p
PARTY
9NoBUajQ
Ce8vwPmE
SVQXQCbc
END
*/
        static void Main(string[] args)
        {
            var partyNumber = Console.ReadLine();
            var vip = new HashSet<string>();
            var regular = new HashSet<string>();
            var isVip = false;

            while (partyNumber != "PARTY")
            {
                isVip = IsVip(partyNumber);

                if (!isVip)
                {
                    regular.Add(partyNumber);
                }
                else
                {
                    vip.Add(partyNumber);
                }


                partyNumber = Console.ReadLine();
            }


            while (partyNumber != "END")
            {
                isVip = IsVip(partyNumber);

                if (isVip && vip.Contains(partyNumber))
                {
                    vip.Remove(partyNumber);
                }
                else if (!isVip && regular.Contains(partyNumber))
                {
                    regular.Remove(partyNumber);
                }

                partyNumber = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + regular.Count);

            foreach (var gues in vip)
            {
                Console.WriteLine(gues);
            }

            foreach (var gues in regular)
            {
                Console.WriteLine(gues);
            }

        }

        private static bool IsVip(string partyNumber)
        {
            var number = 0;
            return int.TryParse(partyNumber[0].ToString(), out number);
        }
    }
}
