namespace neetcode.TwoPointers
{
    public class TwoSum2
    {
        public static int[] TwoSum(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];

                if (sum == target)
                {
                    return [left + 1, right + 1];
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return [];
        }

        public static void Main()
        {
            var arr = new int[] { 2, 7, 11, 15 };
            var target = 9;
            System.Console.WriteLine(string.Join(",", TwoSum(arr, target)));
        }
    }
}