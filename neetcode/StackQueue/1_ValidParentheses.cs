using System.Collections.Generic;

namespace neetcode.StackQueue
{
    public class ValidParentheses
    {
        public static bool IsValid(string s)
        {
            var bracketsMapping = new Dictionary<char, char>()
            {
                {'(', ')'},
                {'{', '}'},
                {'[', ']'}
            };
            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (IsOpenBracket(c)) stack.Push(c);
                else
                {
                    if (stack.Count > 0 && bracketsMapping[stack.Pop()] == c) continue;

                    return false;
                }
            }

            if (stack.Count != 0) return false;

            return true;

            // Local helper functions
            bool IsOpenBracket(char c)
            {
                if (c == '(' || c == '{' || c == '[') return true;
                return false;
            }
        }

        public static void Main()
        {
            string s = "";
            System.Console.WriteLine(IsValid(s));
        }
    }
}