using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var sortedSetPersons = new SortedSet<Person>();
            var sortetHashSet = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                var person = new Person(name, age);

                sortedSetPersons.Add(person);
                sortetHashSet.Add(person);
            }

            Console.WriteLine(sortedSetPersons.Count);
            Console.WriteLine(sortetHashSet.Count);
        }
    }
}
