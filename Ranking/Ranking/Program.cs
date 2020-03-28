using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var contestAndPassword = new Dictionary<string, string>();
            var ussersContesting = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end of contests")
            {
                var contestPassword = input.
                    Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var contest = contestPassword[0];
                var password = contestPassword[1];

                if (!contestAndPassword.ContainsKey(contest))
                {
                    contestAndPassword.Add(contest, password);
                }

                input = Console.ReadLine();
            }

            //Part One Interview => success => Nikola => 120
            //Java Basics Exam => pesho => Petkan => 400


            var secondInput = Console.ReadLine();


            while (secondInput != "end of submissions")
            {
                var splitInput = secondInput
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var contest = splitInput[0];
                var password = splitInput[1];
                var usserName = splitInput[2];
                var points = int.Parse(splitInput[3]);

                if (!contestAndPassword.ContainsKey(contest))
                {
                    secondInput = Console.ReadLine();
                    continue;
                }

                if (!contestAndPassword[contest].Equals(password))
                {
                    secondInput = Console.ReadLine();
                    continue;
                }

                if (!ussersContesting.ContainsKey(usserName))
                {
                    ussersContesting[usserName] = new Dictionary<string, int>();
                }

                if (!ussersContesting[usserName].ContainsKey(contest))
                {
                    ussersContesting[usserName][contest] = points;
                }

                if (ussersContesting[usserName][contest] < points)
                {
                    ussersContesting[usserName][contest] = points;
                }

                secondInput = Console.ReadLine();
            }

            var bestCandidate = ussersContesting
                .OrderByDescending(x => x.Value.Sum(s => s.Value))
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Sum(s => s.Value)} points.");

            Console.WriteLine("Ranking:");

            foreach (var (usser, contest) in ussersContesting)
            {
                Console.WriteLine(usser);

                foreach (var (contestName, points) in contest.OrderByDescending(v=>v.Value))
                {
                    Console.WriteLine($"#  {contestName} -> {points}");
                }
            }
        }
    }

    class contestAndPoints
    {
        public string contestName { get; set; }
        public int points { get; set; }

        public contestAndPoints()
        {

        }

        public contestAndPoints(string contest, int points)
        {
            this.contestName = contest;
            this.points = points;
        }
    }
}
