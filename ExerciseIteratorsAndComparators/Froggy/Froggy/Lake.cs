using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        public Lake(List<T> elements)
        {
            this.MyLake = new List<T>(elements);
        }

        public List<T> MyLake { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.MyLake.Count; i++)
            {
                if(i % 2 == 0)
                {
                    yield return this.MyLake[i];
                }
            }

            for (int i = this.MyLake.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.MyLake[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
