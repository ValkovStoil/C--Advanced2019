using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var pokemons = new List<Pokemon>();
            var trainers = new Dictionary<string, Trainer>();

            var inputLine = Console.ReadLine();

            while (inputLine != "Tournament")
            {
                var inputInfo = inputLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var trainerName = inputInfo[0];
                var pokemonName = inputInfo[1];
                var pokemonElement = inputInfo[2];
                var pokemonHealth = int.Parse(inputInfo[3]);


                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }
                trainers[trainerName].Pokemons.Add(pokemon);

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                var pokemonElement = inputLine;


                foreach (var (currentTrainer,trainerStats) in trainers)
                {
                    if(trainerStats.Pokemons.Any(p=>p.Element == pokemonElement))
                    {
                        trainerStats.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainerStats.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainerStats.Pokemons.RemoveAll(h => h.Health <= 0);
                    }
                }
                
                inputLine = Console.ReadLine();
            }

            trainers = trainers
                .OrderByDescending(v => v.Value.NumberOfBadges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
