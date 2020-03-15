using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parentheses
{
    class Program
    {
        // {{[[(())]]}} YES
        static void Main(string[] args)
        {
            var parentheses = Console.ReadLine().ToCharArray();
            var openParent = new Stack<char>();
            var result = "YES";
            var balanced = true;

            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (var @char in parentheses)
            {
                switch (@char)
                {
                    case '(':
                        openParent.Push(@char);
                        break;
                    case '{':
                        openParent.Push(@char);
                        break;
                    case '[':
                        openParent.Push(@char);
                        break;
                    case ')':
                        balanced = CheckForMatch(openParent.Pop(), @char);
                        break;
                    case '}':
                        balanced = CheckForMatch(openParent.Pop(), @char);
                        break;
                    case ']':
                        balanced = CheckForMatch(openParent.Pop(), @char);
                        break;
                }

                if (!balanced)
                {
                    result = "NO";
                    break;
                }
            }

            Console.WriteLine(result);
        }

        private static bool CheckForMatch(char open, char close)
        {
            var match = false;

            switch (open)
            {
                case '(':
                    if (close == ')') match = true;
                    break;
                case '{':
                    if (close == '}') match = true;
                    break;
                case '[':
                    if (close == ']') match = true;
                    break;
            }

            return match;
        }
    }
}
