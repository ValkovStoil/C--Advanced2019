using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;

        public int Count => this.list.Count;

        public Box()
        {
            this.list = new List<T>();
        }
        public void Add(T element)
        {
            this.list.Add(element);
        }

        public T Remove()
        {
            if(this.list.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove from empty Box!");
            }

            var element = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);

            return element;
        }
    }
}
