using System;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var presentsCount = int.Parse(Console.ReadLine());
            var neighbourhoodSize = int.Parse(Console.ReadLine());
            var neighbourhood = new string[neighbourhoodSize, neighbourhoodSize];
            var niceCidsCount = 0;


            var santa = new Possition("S");

            var isInside = true;


            FillUpTheNeighbourhood(neighbourhood, santa, ref niceCidsCount);

            var commands = Console.ReadLine();

            while (commands != "Christmas morning")
            {
                

                neighbourhood[santa.Row, santa.Column] = "-";

                switch (commands)
                {
                    case "left":
                        santa.Column--;
                        break;
                    case "right":
                        santa.Column++;
                        break;
                    case "up":
                        santa.Row--;
                        break;
                    case "down":
                        santa.Row++;
                        break;
                }

                isInside = IsInside(santa, neighbourhood);

                if (!isInside)
                {
                    break;
                }

                if (neighbourhood[santa.Row, santa.Column] == "V")
                {
                    presentsCount--;
                    neighbourhood[santa.Row, santa.Column] = santa.Sign;
                }
                else if (neighbourhood[santa.Row, santa.Column] == "X")
                {
                    neighbourhood[santa.Row, santa.Column] = santa.Sign;
                }
                else if (neighbourhood[santa.Row, santa.Column] == "C")
                {
                    if (neighbourhood[santa.Row, santa.Column + 1] != "-" && neighbourhood[santa.Row, santa.Column + 1] != "C")
                    {
                        if (presentsCount > 0)
                        {
                            neighbourhood[santa.Row, santa.Column + 1] = "-";
                            presentsCount--;
                        }
                    }

                    if (neighbourhood[santa.Row, santa.Column - 1] != "-" && neighbourhood[santa.Row, santa.Column - 1] != "C")
                    {
                        if (presentsCount > 0)
                        {
                            neighbourhood[santa.Row, santa.Column - 1] = "-";
                            presentsCount--;
                        }
                    }

                    if (neighbourhood[santa.Row + 1, santa.Column] != "-" && neighbourhood[santa.Row + 1, santa.Column] != "C")
                    {
                        if (presentsCount > 0)
                        {
                            neighbourhood[santa.Row + 1, santa.Column] = "-";
                            presentsCount--;
                        }
                    }

                    if (neighbourhood[santa.Row - 1, santa.Column] != "-" && neighbourhood[santa.Row - 1, santa.Column] != "C")
                    {
                        if (presentsCount > 0)
                        {
                            neighbourhood[santa.Row - 1, santa.Column] = "-";
                            presentsCount--;

                        }
                    }

                }

                if(!isInside || presentsCount <= 0)
                {
                    break;
                }

                commands = Console.ReadLine();
            }
            
            if(presentsCount <= 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            if (isInside)
            {
                neighbourhood[santa.Row, santa.Column] = santa.Sign;
            }

            PrintMatrix(neighbourhood);


           var niceCidsWithNoPressents = NiceCidsLeftWihtNoPresents(neighbourhood);

            if(niceCidsWithNoPressents != 0)
            {
                Console.WriteLine($"No presents for {niceCidsWithNoPressents} nice kid/s.");
            }
            else
            {
                Console.WriteLine($"Good job, Santa! {niceCidsCount} happy nice kid/s.");
            }


        }

        private static int NiceCidsLeftWihtNoPresents(string[,] neighbourhood)
        {
            var kids = 0;
            for (int row = 0; row < neighbourhood.GetLength(0); row++)
            {

                for (int col = 0; col < neighbourhood.GetLength(1); col++)
                {
                    if (neighbourhood[row,col] == "V")
                    {
                        kids++;
                    }
                }
            }

            return kids;
        }

        private static bool IsInside(Possition santa, string[,] neighbourhood)
        {
            return santa.Column >= 0 && santa.Row >= 0 &&
                santa.Column < neighbourhood.GetLength(1)
                && santa.Row < neighbourhood.GetLength(0);
        }

        private static void PrintMatrix(string[,] neighbourhood)
        {
            for (int row = 0; row < neighbourhood.GetLength(0); row++)
            {
                for (int col = 0; col < neighbourhood.GetLength(1); col++)
                {
                    Console.Write(neighbourhood[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillUpTheNeighbourhood(string[,] neighbourhood, Possition santa, ref int happyCidsCount)
        {
            for (int row = 0; row < neighbourhood.GetLength(0); row++)
            {
                var neighbourhoodInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < neighbourhood.GetLength(1); col++)
                {
                    if (neighbourhoodInfo[col] == "S")
                    {
                        santa.Row = row;
                        santa.Column = col;
                    }
                    else if (neighbourhoodInfo[col] == "V")
                    {
                        happyCidsCount++;
                    }

                    neighbourhood[row, col] = neighbourhoodInfo[col];
                }
            }
        }

    }
    public class Possition
    {
        public Possition(string sign)
        {
            this.Sign = sign;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public string Sign { get; set; }
    }
}
