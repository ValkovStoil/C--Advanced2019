using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var halls = new Queue<string>();
            var hallsFreeSpace = new List<int>();

            var hallCapacity = int.Parse(Console.ReadLine());

            var inputReservationInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var elements = new Stack<string>(inputReservationInfo);

            var curentCapacity = 0;

            while (elements.Count != 0)
            {
                var curentElement = elements.Pop();

                var isChar = curentElement.Any(ch => char.IsLetter(ch));

                if (isChar)
                {
                    halls.Enqueue(curentElement);
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    var reservation = int.Parse(curentElement);

                    if (curentCapacity + reservation > hallCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hallsFreeSpace)}");
                        curentCapacity = 0;
                        hallsFreeSpace.Clear();
                    }

                    if (halls.Count != 0)
                    {
                        hallsFreeSpace.Add(reservation);
                        curentCapacity += reservation;
                    }

                }
            }
        }
    }
}
