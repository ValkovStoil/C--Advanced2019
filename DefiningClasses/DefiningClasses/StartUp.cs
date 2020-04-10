using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();

            persons.Add(new Person("Pesho", 20));
            var person = new Person();
            person.Name = "Gosho";
            person.Age = 18;
            persons.Add(person);
            persons.Add(new Person("Stamat", 43));
        }
    }
}
