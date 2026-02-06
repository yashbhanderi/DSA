namespace neetcode.Arrays
{
    public class ProductOfArrayExceptSelf
    {
        public static int[] ProductExceptSelf(int[] nums)
        {
            var n = nums.Length;
            var prefixArray = new int[n];
            var suffixArray = new int[n];
            var resultArray = new int[n];

            for (int i = 0, j = n - 1; i < n && j >= 0; i++, j--)
            {
                prefixArray[i] = i == 0 ? nums[i] : nums[i] * prefixArray[i - 1];
                suffixArray[j] = j == n - 1 ? nums[j] : nums[j] * suffixArray[j + 1];
            }

            for (int i = 0; i < n; i++)
            {
                var prevProductTillNow = i == 0 ? 1 : prefixArray[i - 1];
                var nextProductTillNow = i == (n - 1) ? 1 : suffixArray[i + 1];

                resultArray[i] = prevProductTillNow * nextProductTillNow;
            }

            return resultArray;
        }

        public static void Main()
        {
            var arr = new int[] { 1, 2, 3, 4 };
            System.Console.WriteLine(string.Join(",", ProductExceptSelf(arr)));
        }
    }
}