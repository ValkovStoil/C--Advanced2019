using System;

namespace CustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new CustomList();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(2);
        }
    }
}
