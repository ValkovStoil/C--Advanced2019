using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic

{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Age.CompareTo(other.Age);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Person);
        }

        public bool Equals(Person other)
        {

            return (this.Name.Equals(other.Name) && this.Age.Equals(other.Age));
        }

        public override int GetHashCode()
        {
            var hashCode = 1283719237;
            hashCode = hashCode * -2187361 + this.Age + this.Name.Length;
            hashCode = hashCode * -123123 + this.Age.GetHashCode();

            return hashCode;
        }
    }
}
