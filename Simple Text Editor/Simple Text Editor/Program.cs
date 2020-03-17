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
            var oldVersionText = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split();
                var command = int.Parse(commands[0]);

                switch (command)
                {
                    case 1: // append text
                        oldVersionText.Push(text.ToString());
                        var tx = commands[1];
                        text.Append(tx);
                        break;
                    case 2: // ereses the count elements from text
                        var elementsCount = int.Parse(commands[1]);
                        oldVersionText.Push(text.ToString());
                        //TODO Remove the elements from the text
                        text.Remove(text.Length - elementsCount, elementsCount);
                        break;
                    case 3: // returns the elemnt from position index, print each returned element
                        var index = int.Parse(commands[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case 4: // undo the last command of type 1 or 2
                        //TODO Logic for undo the commands
                        text.Clear();
                        text.Append(oldVersionText.Pop());
                        break;
                }

            }
        }
    }
}
