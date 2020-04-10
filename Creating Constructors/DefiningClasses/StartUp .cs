using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person();
            //Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            var person2 = new Person(20);
            //Console.WriteLine($"Name: {person2.Name}, Age: {person2.Age}");
            var person3 = new Person("Pesho", 15);
            //Console.WriteLine($"Name: {person3.Name}, Age: {person3.Age}");


        }
    }
}
