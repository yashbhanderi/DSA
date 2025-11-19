namespace CSharp.Topics.SlidingWindow
{
    public class MaximumSizeSubarraySum
    {
        public static int MinSubArrayLen(int target, int[] nums)
        {
            int n = nums.Length;
            int start = 0, end = 1;
            int currentWindowSum = nums[0];
            int minSubarray = int.MaxValue;

            while (end < n)
            {
                if (currentWindowSum == target)
                {
                    minSubarray = Math.Min(end - start, minSubarray);
                    currentWindowSum += nums[end++];
                    currentWindowSum -= nums[start++];
                }
                else if (currentWindowSum < target)
                {
                    currentWindowSum += nums[end++];
                }
                else
                {
                    minSubarray = Math.Min(end - start, minSubarray);
                    currentWindowSum -= nums[start++];
                }
            }

            while (start < n)
            {
                if (currentWindowSum >= target)
                {
                    minSubarray = Math.Min(end - start, minSubarray);
                }

                currentWindowSum -= nums[start++];
            }

            if (minSubarray == int.MaxValue)
            {
                minSubarray = 0;
            }

            return minSubarray;
        }

        public static void Run()
        {
            var target = 11;
            var nums = new int[] { 1, 2, 3, 4, 5 };

            System.Console.WriteLine(MinSubArrayLen(target, nums));
        }
    }
}

// Optimized

// public int minSubArrayLen(int target, int[] nums)
// {
//     int n = nums.length;
//     int minLength = int.MaxValue;
//     int sum = 0;
//     int left = 0;

//     for (int right = 0; right < n; right++)
//     {
//         sum += nums[right];

//         while (sum >= target)
//         {
//             minLength = Math.min(minLength, right - left + 1);
//             sum -= nums[left];
//             left++;
//         }
//     }
//     return minLength == int.MaxValue ? 0 : minLength;
// }