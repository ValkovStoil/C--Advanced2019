using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T elemnet)
        {
            this.Text = elemnet;
        }

        public T Text { get; set; }


        public override string ToString()
        {
            return $"{this.Text.GetType()}: {this.Text}";
        }
    }
}
