using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomStack<T>
    {
        private const int inistialCapacity = 4;

        private T[] items;
        private int count;
        public CustomStack()
        {
            this.count = 0;
            this.items = new T[inistialCapacity];
        }

        public int Count => this.count;

        public void Push(T element)
        {
            Resize();
            this.items[this.count] = element;
            count++;
        }

        public T Pop()
        {
            ThrowWhenEmpty();
            var element = this.items[this.Count - 1];
            this.count--;
            return element;
        }

        public T Peek()
        {
            ThrowWhenEmpty();
            return this.items[this.count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void ThrowWhenEmpty()
        {
            if (this.count == 0)
            {
                throw new Exception("Stack is empty.");
            }
        }

        private void Resize()
        {
            if (this.items.Length > this.Count)
            {
                return;
            }

            var tempArray = new T[2 * this.items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }
    }
}
