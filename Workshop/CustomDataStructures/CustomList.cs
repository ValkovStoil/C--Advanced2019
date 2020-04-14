using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomList<T>
    {

        private T[] items;

        private const int InitialCapacity = 2;

        public CustomList()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }


        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public void Add(T element)
        {
            Resize();
            this.items[this.Count] = element;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            ValidateIndex(index);
            var element = this.items[index];
            ShiftToLeft(index);
            this.Count--;
            Shrink();
            return element;
        }

        public void InsertAt(int index,T element)
        {
            ValidateIndex(index);
            Resize();
            this.Count++;
            ShiftToRight(index);
            this.items[index] = element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(this.items[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex,int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;

        }

        public void Reverse()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                Swap(i, this.Count - 1 - 1);
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                stringBuilder.Append($"{this.items[i]}, ");

            }

            return stringBuilder.ToString().TrimEnd(',', ' ');
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException();
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

        private void Shrink()
        {
            if (this.Count * 4 >= this.items.Length)
            {
                return;
            }

            var tempArray = new T[this.items.Length / 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count - 1] = default;
        }

        private void ShiftToRight(int index)
        {

            for (int i = this.Count - 1; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
