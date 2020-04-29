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
            var happyCidsCount = 0;

            var santa = new Santa(0, 0);
            FillUpTheNeighbourhood(neighbourhood, santa, ref happyCidsCount);

            var commands = Console.ReadLine();
            //TODO logic for presents giving
            while (commands != "Christmas morning" || presentsCount != 0)
            {

                switch (commands)
                {
                    case "left":
                        break;
                    case "right":
                        break;
                    case "up":
                        break;
                    case "down":
                        break;
                }

                commands = Console.ReadLine();
            }

        }

        private static void FillUpTheNeighbourhood(string[,] neighbourhood, Santa santa, ref int happyCidsCount)
        {
            for (int row = 0; row < neighbourhood.GetLength(0); row++)
            {
                var neighbourhoodInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < neighbourhood.GetLength(1); col++)
                {
                    if(neighbourhoodInfo[col] == "S")
                    {
                        santa.Row = row;
                        santa.Column = col;
                    }
                    else if( neighbourhoodInfo[col] == "V")
                    {
                        happyCidsCount++;
                    }

                    neighbourhood[row, col] = neighbourhoodInfo[col];
                }
            }
        }

    }
    public class Santa
    {
        public Santa(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.Sign = "S";
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public string Sign { get; set; }
    }
}
