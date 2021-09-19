using System;
using System.Collections.Generic;

namespace _08._BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parentheses = new Stack<char>();
            bool isBalanced = true;

            foreach (var symbol in input)
            {
                if (symbol == '(' || symbol == '[' || symbol == '{')
                {
                    parentheses.Push(symbol);
                }
                else
                {
                    if (parentheses.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    if (symbol == ')' && parentheses.Peek() == '(')
                    {
                        parentheses.Pop();
                    }
                    else if (symbol == ']' && parentheses.Peek() == '[')
                    {
                        parentheses.Pop();
                    }
                    else if (symbol == '}' && parentheses.Peek() == '{')
                    {
                        parentheses.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
