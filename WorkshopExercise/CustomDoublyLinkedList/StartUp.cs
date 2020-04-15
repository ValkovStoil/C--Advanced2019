using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var doubleLinkedList = new DoubleLinkedList();

            doubleLinkedList.AddFirst(1);
            doubleLinkedList.AddFirst(2);
            doubleLinkedList.AddFirst(3);
            doubleLinkedList.AddFirst(4);
            doubleLinkedList.AddFirst(5);

            var arr = doubleLinkedList.ToArray();

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
