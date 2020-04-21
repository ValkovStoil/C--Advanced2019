using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomStack
{
    public class MyCustomStack<T> : IEnumerable<T>
    {
        public MyCustomStack()
        {
            this.myStack = new List<T>();
        }

        public List<T> myStack { get; set; }

        public void Push(T element)
        {
            this.myStack.Add(element);
        }

        public T Pop()
        {
            T element;

            element = this.myStack.Last();
            this.myStack.RemoveAt(this.myStack.Count - 1);

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.myStack.Count -1; i >=0; i--)
            {
                yield return this.myStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
