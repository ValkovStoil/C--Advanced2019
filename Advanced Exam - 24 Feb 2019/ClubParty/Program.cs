using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var halls = new List<string>();
            var hallsFreeSpace = new List<int>();

            var hallCapacity = int.Parse(Console.ReadLine());

            var inputReservationInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            for (int i = 0; i < inputReservationInfo.Count; i++)
            {
                var ch = inputReservationInfo[i];
                var isChar = ch.Any(ch => char.IsLetter(ch));

                if (isChar)
                {
                    halls.Add(ch);
                }
                else if (!isChar && halls.Count != 0)
                {
                    var filledSpace = hallsFreeSpace.Sum();
                    var reservation = int.Parse(ch);

                    var hasFreeSpace = filledSpace + reservation <= hallCapacity;

                    if (hasFreeSpace)
                    {
                        hallsFreeSpace.Add(reservation);
                    }
                    else
                    {
                        var hall = halls.First();
                        halls.Remove(hall);

                        Console.WriteLine($"{hall} -> {string.Join(", ", hallsFreeSpace)}");

                        hallsFreeSpace.Clear();
                        hallsFreeSpace.Add(reservation);
                    }
                }
            }
        }
    }
}
