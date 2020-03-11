using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < num; i++)
            {
                var students = Console.ReadLine().Split().ToArray();
                var name = students[0];
                var grade = double.Parse(students[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<double>();
                }
                studentsGrades[name].Add(grade);
            }

            foreach (var kvp in studentsGrades)
            {
                var avrageSum = kvp.Value.Average();

                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", kvp.Value.Select( x=> x.ToString("F2")))} (avg: {avrageSum:f})");
            }
        }
    }
}
