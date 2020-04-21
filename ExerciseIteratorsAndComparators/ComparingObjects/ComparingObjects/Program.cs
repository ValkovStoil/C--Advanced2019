using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();

            var inputCommands = Console.ReadLine();

            while (inputCommands != "END")
            {
                var personData = inputCommands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personData[0];
                var age = int.Parse(personData[1]);
                var town = personData[2];

                people.Add(new Person(name, age, town));

                inputCommands = Console.ReadLine();
            }

            var nthPerson = int.Parse(Console.ReadLine()) - 1; //starting from 1

            var person = people[nthPerson];

            var coutOfEqualPeople = 1;

            for (int i = 0; i < people.Count; i++)
            {
                if (i != nthPerson)
                {
                    if (person.CompareTo(people[i]) == 0)
                    {
                        coutOfEqualPeople++;
                    }
                }
            }

            if (coutOfEqualPeople == 1)
            {
                Console.WriteLine("No matches");
                return;
            }

            Console.WriteLine($"{coutOfEqualPeople} {people.Count - coutOfEqualPeople} {people.Count}");
        }
    }
}
