namespace CSharp.Topics.Recursion
{
    public class Basics
    {
        public static Dictionary<int, int> map = [];
        public static int Fibonacci(int n)
        {
            if (n <= 1) return n;

            if (map.TryGetValue(n, out var val))
            {
                return val;
            }

            val = Fibonacci(n - 1) + Fibonacci(n - 2);

            map.Add(n, val);

            return val;
        }

        public static void Run()
        {
            System.Console.WriteLine(Fibonacci(20));
        }
    }
}