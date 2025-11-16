namespace CSharp.Topics.Hashing
{
    public class HappyNumber
    {

        public static bool IsHappy(int n)
        {
            int num = n;
            var numMapping = new HashSet<int>();

            while (true)
            {
                int val = num;
                int sum = 0;
                while (val > 0)
                {
                    sum += (int)Math.Pow(val % 10, 2);
                    val /= 10;
                }

                if (sum == 1) return true;

                if (numMapping.Contains(sum)) return false;

                numMapping.Add(sum);
                num = sum;
            }
        }

        public static void Run()
        {
            int n = 19;
            System.Console.WriteLine(IsHappy(n));
        }
    }
}