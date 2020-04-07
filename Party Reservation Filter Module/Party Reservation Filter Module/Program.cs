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

            var filters = new List<string>();

            while (input != "Print")
            {
                var filterCommnads = input
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                var commnad = filterCommnads[0];
                var filterType = filterCommnads[1];
                var parameter = filterType[2];

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

            //TODO Filter the guests
        }
    }
}
