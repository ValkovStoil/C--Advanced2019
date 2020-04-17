using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public Box()
        {
            this.Text = new List<T>();
        }

        public List<T> Text { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Text)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            var tempElement = this.Text[firstIndex];
            this.Text[firstIndex] = this.Text[secondIndex];
            this.Text[secondIndex] = tempElement;
        }
    }
}
