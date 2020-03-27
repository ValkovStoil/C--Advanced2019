using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            // vloger -- following---followed
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var follow = "follow";
            var followers = "followers";

            //fill up the vlogger DB and the followers/following
            while (input[0] != "Statistics")
            {
                var vloggerName = input[0];
                var command = input[1];
                var followedVloger = input[2];

                switch (command)
                {
                    case "followed":

                        //check if the vloger and the follower exist in the vloggers
                        if (vloggers.ContainsKey(vloggerName) &&
                            vloggers.ContainsKey(followedVloger) &&
                            !vloggerName.Equals(followedVloger)) //add follow and following to the current vlogers
                        {
                            vloggers[vloggerName][follow].Add(followedVloger);
                            vloggers[followedVloger][followers].Add(vloggerName);
                        }

                        break;
                    case "joined":

                        if (!vloggers.ContainsKey(vloggerName))
                        {
                            vloggers[vloggerName] = new Dictionary<string, HashSet<string>>();

                            vloggers[vloggerName][follow] = new HashSet<string>();
                            vloggers[vloggerName][followers] = new HashSet<string>();
                        }

                        break;
                }


                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }


            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");


            var sortedVLoggers = vloggers
                .OrderByDescending(x => x.Value[followers].Count)
                .ThenBy(x => x.Value[follow].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            var count = 1;

            foreach (var name in sortedVLoggers)
            {
                var vloggerName = name.Key;
                var vloggerFollows = name.Value[follow].Count;
                var vloggerFollowers = name.Value[followers].Count;

                Console.WriteLine($"{count}. {vloggerName} : {vloggerFollowers} followers, {vloggerFollows} following");
                if (count == 1)
                {
                    foreach (var userName in name.Value[followers].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {userName}");
                    }
                }

                count++;
            }

        }
    }
}
