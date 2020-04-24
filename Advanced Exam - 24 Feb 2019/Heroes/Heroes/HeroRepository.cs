using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    class HeroRepository : IEnumerable<Hero>
    {
        List<Hero> dataCollection;

        public HeroRepository()
        {
            dataCollection = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            this.dataCollection.Add(hero);
        }

        public int Count => this.dataCollection.Count;

        public void Remove(string name)
        {
            this.dataCollection = this.dataCollection
                .Where(x => x.Name != name)
                .ToList();
        }

         public Hero GetHeroWithHighestStrength()
        {
            var hero = this.dataCollection
                .OrderByDescending(x => x.Item.Strength)
                .FirstOrDefault();

            return hero;
        }
        
        public Hero GetHeroWithHighestAbility()
        {

            var hero = this.dataCollection
                .OrderByDescending(x => x.Item.Ability)
                .FirstOrDefault();

            return hero;
        }
        
        public Hero GetHeroWithHighestIntelligence()
        {

            var hero = this.dataCollection
                .OrderByDescending(x => x.Item.Intelligence)
                .FirstOrDefault();

            return hero;
        }

        public IEnumerator<Hero> GetEnumerator()
        {
            foreach (var hero in this.dataCollection)
            {
                yield return hero;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var hero in this.dataCollection)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
