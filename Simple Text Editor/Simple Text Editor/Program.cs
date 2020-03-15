using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var lastOperations = new Stack<int>();
            var lastTextAppendet = new Stack<string>();
            var lastTextRemoved = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(" ");
                var command = int.Parse(commands[0]);

                switch (command)
                {
                    case 1: // append text
                        var tx = commands[1];
                        text.Append(tx);
                        lastOperations.Push(command); // sotre operation
                        lastTextAppendet.Push(tx); // store appendet text
                        break;
                    case 2: // ereses the count elements from text
                        var elements = int.Parse(commands[1]);
                        var removed = RemoveLastNChars(text, elements);
                        //TODO Remove the elements from the text

                        lastTextRemoved.Push(removed); // store removed text
                        lastOperations.Push(command); // store operations
                        break;
                    case 3: // returns the elemnt from position index, print each returned element
                        var index = int.Parse(commands[1]) -1;
                        Console.WriteLine(text[index]);
                        break;
                    case 4: // undo the last command of type 1 or 2
                        //TODO Logic for undo the commands
                        break;
                }

            }
        }

        private static string RemoveLastNChars(StringBuilder text, int elements)
        {
            var startIndex = text.Length - elements;
            var removed = text.ToString().Substring(startIndex);

            return removed;
        }
    }
}
