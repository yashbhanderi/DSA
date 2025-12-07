namespace CSharp.Topics.BinarySearch
{
    public class FirstBadVersion
    {
        public static bool IsBadVersion(int version) => version >= 1;

        public static int FirstBadVersionIndex(int n)
        {
            int left = 1, right = n;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (IsBadVersion(mid))
                {
                    right = mid - 1;
                }

                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        public static void Run()
        {
            int n = 1;
            System.Console.WriteLine(FirstBadVersionIndex(n));
        }
    }
}