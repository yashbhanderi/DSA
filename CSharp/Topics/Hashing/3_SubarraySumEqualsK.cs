namespace CSharp.Topics.Hashing
{
    public class SubarraySumEqualsK
    {

        public static int SubarraySum(int[] nums, int k)
        {
            var n = nums.Length;
            var frequencyMapping = new Dictionary<int, int>();
            var prefixSum = new int[n];
            var subarraySumCount = 0;

            frequencyMapping.Add(0, 1);

            for (int i = 0; i < n; i++)
            {
                var sum = nums[i] + (i == 0 ? 0 : prefixSum[i - 1]);
                prefixSum[i] = sum;

                int targetSum = sum - k;
                subarraySumCount += frequencyMapping.GetValueOrDefault(targetSum);

                frequencyMapping[sum] = frequencyMapping.GetValueOrDefault(sum) + 1;
            }

            return subarraySumCount;
        }

        public static void Run()
        {
            var arr = new int[] { -1, -1, 1 };
            var k = 0;

            System.Console.WriteLine(SubarraySum(arr, k));
        }
    }
}