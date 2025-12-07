namespace CSharp.Topics.BinarySearch
{
    public class SearchInsertPosition
    {
        public static int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return left;
        }

        public static void Run()
        {
            var nums = new int[] { 1, 3 };
            var target = 0;

            System.Console.WriteLine(SearchInsert(nums, target));
        }
    }
}