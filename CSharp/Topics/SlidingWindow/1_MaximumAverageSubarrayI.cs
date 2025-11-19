namespace CSharp.Topics.SlidingWindow
{
    public class MaximumAverageSubarrayI
    {
        public static double FindMaxAverage(int[] nums, int k)
        {
            int n = nums.Length;

            double maxAvarage = double.MinValue;
            double sum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }

            var currentWindowAverage = (double)(sum / (double)k);
            maxAvarage = Math.Max(maxAvarage, currentWindowAverage);

            int start = 0, end = k;
            while (end < n)
            {
                sum += nums[end++];
                sum -= nums[start++];

                currentWindowAverage = (double)(sum / (double)k);
                maxAvarage = Math.Max(maxAvarage, currentWindowAverage);
            }

            return maxAvarage;
        }

        public static void Run()
        {
            var nums = new int[] { 1, 12, -5, -6, 50, 3 };
            var k = 4;

            System.Console.WriteLine(FindMaxAverage(nums, k));
        }
    }
}