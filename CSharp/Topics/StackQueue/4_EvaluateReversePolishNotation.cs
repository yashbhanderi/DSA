namespace CSharp.Topics.StackQueue
{
    public class EvaluateReversePolishNotation
    {
        private static int EvaluateExpression(string token, int num1, int num2)
        {
            return token switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                _ => num1 / num2,
            };
        }

        public static int EvalRPN(string[] tokens)
        {
            var numStack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out var num))
                {
                    numStack.Push(num);
                }
                else
                {
                    var num2 = numStack.Pop();
                    var num1 = numStack.Pop();
                    var result = EvaluateExpression(token, num1, num2);

                    numStack.Push(result);
                }
            }

            return numStack.Peek();
        }

        public static void Run()
        {
            // var tokens = new string[] { "2", "1", "+", "3", "*" };
            // var tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            var tokens = new string[] { "4", "13", "5", "/", "+" };
            System.Console.WriteLine(EvalRPN(tokens));
        }
    }
}