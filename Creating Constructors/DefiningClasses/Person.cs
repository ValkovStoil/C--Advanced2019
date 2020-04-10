using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name = "No name";
        private int age = 1;

        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            this.Name = this.name;
            this.Age = this.age;
        }

        public Person(int age)
        {
            this.Name = this.name;
            this.Age = age;
        }
        public Person(string name, int age) : this(age)
        {
            this.Name = name;
        }

    }
}
