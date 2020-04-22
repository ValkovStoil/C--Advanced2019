using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class DoubleLinkedList<T>: IEnumerable<T>
    {
        private class ListNode
        {

            public ListNode(T value)
            {
                this.Value = value;
            }

            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }

            public T Value { get; set; }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var newHead = new ListNode(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            var newTail = new ListNode(element);

            if (this.Count == 0)
            {
                this.tail = this.head = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty!");
            }

            var removedElement = this.head.Value;

            var newHead = this.head.NextNode;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                newHead.PreviousNode = null;
                this.head = newHead;
            }

            this.Count--;

            return removedElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty!");
            }

            var removedElement = this.tail.Value;

            var newTail = this.tail.PreviousNode;

            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                newTail.NextNode = null;
                this.tail = newTail;
            }

            this.Count--;

            return removedElement;
        }

        public void ForEach(Action<T> action, bool shodStratFromHead = true)
        {
            var currentNode = this.head;

            if (!shodStratFromHead)
            {
                currentNode = this.tail;
            }

            while (currentNode != null)
            {
                action(currentNode.Value);

                if (!shodStratFromHead)
                {
                    currentNode = currentNode.PreviousNode;
                }
                else
                {
                    currentNode = currentNode.NextNode;
                }
            }
        }

        public void Clrear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public T[] ToArray()
        {
            var newArray = new T[this.Count];
            
            var currentNode = this.head;

            int counter = 0;

            while (currentNode != null)
            {
                newArray[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
