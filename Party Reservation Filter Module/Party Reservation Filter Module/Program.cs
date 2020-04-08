using System;
using System.Collections.Generic;
using System.Linq;

namespace Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var input = Console.ReadLine();

            Func<string, string, bool> startsWithFunc = (a, b) => a.StartsWith(b);
            Func<string, string, bool> endsWithFunc = (a, b) => a.EndsWith(b);
            Func<string, string, bool> containsFunc = (a, b) => a.Contains(b);
            Func<string, int, bool> lengthFunc = (a, b) => a.Length == b;


            var filters = new List<string>();

            while (input != "Print")
            {
                var filterCommnads = input
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                var commnad = filterCommnads[0];
                var filterType = filterCommnads[1];
                var parameter = filterCommnads[2];

                var filterString = $"{filterType}/{parameter}";

                if (commnad == "Add filter")
                {
                    filters.Add(filterString);
                }
                else if (commnad == "Remove filter")
                {
                    if (filters.Contains(filterString))
                    {
                        filters.Remove(filterString);
                    }
                }

                input = Console.ReadLine();
            }

            
            foreach (var filter in filters)
            {
                var commnads = filter.Split("/");
                var filterTyper = commnads[0];
                var filterParam = commnads[1];


                if(filterTyper == "Starts with")
                {
                    guests = guests.Where(g => !startsWithFunc(g, filterParam)).ToList();
                }
                else if(filterTyper == "Ends with")
                {
                    guests = guests.Where(g => !endsWithFunc(g, filterParam)).ToList();
                }
                else if (filterTyper == "Length")
                {
                    guests = guests.Where(g => !lengthFunc(g, int.Parse(filterParam))).ToList();
                }
                else if(filterTyper == "Contains")
                {
                    guests = guests.Where(g => !containsFunc(g, filterParam)).ToList();
                }
            }

            Console.WriteLine(string.Join(" ",guests));
        }
    }
}
