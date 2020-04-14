using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomList
    {

        private int[] items;

        private const int InitialCapacity = 2;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }


        public int Count { get; private set; }

        public int this[int index]
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

        public void Add(int element)
        {
            Resize();
            this.items[this.Count] = element;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            ValidateIndex(index);
            var element = this.items[index];
            ShiftToLeft(index);
            this.Count--;
            Shrink();
            return element;
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException;
            }
        }
        private void Resize()
        {
            if (this.items.Length > this.Count)
            {
                return;
            }

            var tempArray = new int[2 * this.items.Length];
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

            var tempArray = new int[this.items.Length / 2];

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
    }
}
