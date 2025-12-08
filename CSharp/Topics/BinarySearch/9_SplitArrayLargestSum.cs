namespace CSharp.Topics.BinarySearch
{
    public class SplitArrayLargestSum
    {
        // 3. How to check if a given X is possible(Greedy)

        // Take some X(guess).
        // Now try to split the array from left to right:

        // Algorithm:

        // currentSum = 0, parts = 1 (we start with first part)

        // For each number num in array:

        // If num > X → impossible(because even single element > X)

        // If currentSum + num > X:

        // Start a new part
        // parts++
        // currentSum = num

        // Else:

        // Just add to current part
        // currentSum += num

        // At the end:

        // If parts <= k → X is possible

        // If parts > k → X is too small(we needed too many parts)

        // This is the “can we do it with max sum = X ?” check.

        public static bool IsSumPossible(int[] nums, int k, int sum)
        {
            int partsNeeded = 1, currentSum = 0;
            foreach (var num in nums)
            {
                if (num > sum) return false;

                if (currentSum + num > sum)
                {
                    partsNeeded++;
                    currentSum = num;
                }
                else
                {
                    currentSum += num;
                }
            }

            return partsNeeded <= k;
        }

        public static int SplitArray(int[] nums, int k)
        {
            int left = 0, right = nums.Sum(), minimizedLargestSum = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (IsSumPossible(nums, k, mid))
                {
                    minimizedLargestSum = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return minimizedLargestSum;
        }

        public static void Run()
        {
            var nums = new int[] { 10, 5, 13, 4, 8, 4, 5, 11, 14, 9, 16, 10, 20, 8 };
            var k = 8;

            System.Console.WriteLine(SplitArray(nums, k));
        }
    }
}