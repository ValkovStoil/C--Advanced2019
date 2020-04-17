using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box<T>
        where T: IComparable
    {
        public Box()
        {
            this.Value = new List<T>();
        }

        public List<T> Value { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Value)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            var tempElement = this.Value[firstIndex];
            this.Value[firstIndex] = this.Value[secondIndex];
            this.Value[secondIndex] = tempElement;
        }

        public int Compare(T element)
        {
            var count = 0;
            foreach (var item in this.Value)
            {
                if(item.CompareTo(element) == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
