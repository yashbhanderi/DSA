namespace CSharp.Topics.StackQueue
{
    public class ValidParentheses
    {
        public static bool IsValid(string s)
        {
            var openBrackets = new HashSet<char>() { '(', '{', '[' };
            var bracketsMapping = new Dictionary<char, char>()
            {
                {'(', ')'},
                {'{', '}'},
                {'[', ']'}
            };
            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (openBrackets.Contains(c))
                {
                    stack.Push(c);
                }
                else
                {
                    // current closed bracket is not equal to last open bracket's equivalent closed bracket
                    if (stack.Count == 0 || bracketsMapping.GetValueOrDefault(stack.Pop()) != c)
                    {
                        return false;
                    }
                }
            }

            if (stack.Count > 0) return false;

            return true;
        }

        public static void Run()
        {
            string str = "()[]{}";
            System.Console.WriteLine(IsValid(str));
        }
    }
}