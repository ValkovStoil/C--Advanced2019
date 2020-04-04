using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_by_Age
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person()
            {

            }

            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }

        static void Main(string[] args)
        {
            var people = new List<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);

                people.Add(person);
                
            }


            var condituionString = Console.ReadLine();
            var conditionInt = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<Person, bool> predicate = x => true;

            switch (condituionString)
            {
                case "older":
                    predicate = p => p.Age >= conditionInt;
                    break;
                case "younger":
                    predicate = p => p.Age < conditionInt;
                    break;
            }

            var filteredPeoples = people.Where(predicate);

            foreach (var person in filteredPeoples)
            {
                switch (format)
                {
                    case "name":
                        Console.WriteLine(person.Name);
                        break;
                    case "age":
                        Console.WriteLine(person.Age);
                        break;
                    case "name age":
                        Console.WriteLine($"{person.Name} - {person.Age}");
                        break;
                }

            }
        }


    }
}
