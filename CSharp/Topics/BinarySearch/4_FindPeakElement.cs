namespace CSharp.Topics.BinarySearch
{
    public class FindPeakElement
    {

        /*
        🎯 The Fundamental Insight

        At any index mid, compare:

        nums[mid]  vs  nums[mid + 1]


        There are only two possibilities:

        ✅ Case 1: nums[mid] < nums[mid + 1]

        This means the slope is going upward when moving right.

            increasing slope →
        ...  4   6   9   12   ?
                    mid  mid+1


        If the array is rising at mid, then the right side must contain a peak.

        Why is this guaranteed?

        Because:

        If it keeps going up, it must eventually stop (since array ends).

        Where it stops rising is a peak.

        Even if the array keeps increasing, the last element becomes a peak.

        Example:

        [1, 3, 5, 7] → 7 is a peak


        Example with dips later:

        [1, 3, 5, 7, 6, 4] → 7 is a peak


        No matter what, peak is guaranteed on the rising side.

        Therefore:

        if nums[mid] < nums[mid + 1]:
            search right half

        ✅ Case 2: nums[mid] > nums[mid + 1]

        This means the slope is going downward when moving right.

        decreasing slope →
        ...   10   7   3   1
                mid mid+1


        This indicates the peak lies to the left, because:

        Right side is going down

        This means somewhere before mid, we must have reached the top

        Even if it continues falling all the way to 0:

        [9, 7, 5, 3, 1] → 9 is the peak


        If there's a rise earlier:

        [1, 3, 8, 6, 4, 2] → 8 is the peak


        Again, the peak lies somewhere in the falling direction, i.e., left.

        So:

        else:
            search left half

        🎉 Why can’t a peak be on both sides?

        Because the definition of a peak is:

        nums[i] > nums[i-1] AND nums[i] > nums[i+1]


        You can’t have peaks on both sides while analyzing a strict slope direction.

        Binary search uses the fact that the array behaves like a "mountain-ish" shape locally.
        */

        public static int PeakElement(int[] nums, int left, int right)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                bool isGreaterThanLeft = mid == 0 || nums[mid - 1] < nums[mid];
                bool isGreaterThanRight = mid == nums.Length - 1 || nums[mid + 1] < nums[mid];

                if (isGreaterThanLeft && isGreaterThanRight) return mid;

                var isPeakElementFoundLeftSide = PeakElement(nums, left, mid - 1);

                if (isPeakElementFoundLeftSide != -1) return isPeakElementFoundLeftSide;

                var isPeakElementFoundRightSide = PeakElement(nums, mid + 1, right);

                if (isPeakElementFoundRightSide != -1) return isPeakElementFoundRightSide;

                return -1;
            }

            return -1;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            System.Console.WriteLine(PeakElement(arr, 0, arr.Length - 1));
        }
    }
}