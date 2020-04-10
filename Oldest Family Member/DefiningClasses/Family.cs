using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> familyMembers = new List<Person>();


        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            return familyMembers
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
        }
    }
}
