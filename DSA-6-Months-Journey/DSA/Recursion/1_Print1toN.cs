namespace DSA.Recursion
{
    public class Print1toN
    {

        public static void Main()
        {
            int n = 8;
            Print(n);
        }

        public static void Print(int n)
        {
            if (n == 1)
            {
                System.Console.WriteLine(n);
                return;
            }

            System.Console.WriteLine(n);
            Print(n - 1);
        }
    }
}