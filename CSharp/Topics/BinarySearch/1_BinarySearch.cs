namespace CSharp.Topics.BinarySearch
{
    public class BinarySearch
    {
        public static int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1; // We look at the ENTIRE array

            // Use <= because if left == right, we still need to check that one element
            while (left <= right)
            {
                // Calculate mid safely
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid; // FOUND IT!
                }
                else if (nums[mid] < target)
                {
                    // Target is in the right half
                    left = mid + 1;
                }
                else
                {
                    // Target is in the left half
                    right = mid - 1;
                }
            }

            return -1; // Target does not exist
        }

        public static void Run()
        {
            var nums = new int[] { -1, 0, 3, 5, 9, 12 };
            var target = 9;

            System.Console.WriteLine(Search(nums, target));
        }
    }
}