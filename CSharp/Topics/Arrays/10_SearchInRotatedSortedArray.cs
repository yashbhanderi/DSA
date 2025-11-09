namespace CSharp.Topics.Arrays
{
    public class SearchInRotatedSortedArray
    {

        public static int Search(int[] arr, int target)
        {
            int n = arr.Length;
            int left = 0, right = n - 1;
            int targetIndex = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    targetIndex = mid;
                    break;
                }

                if (left == right) break;

                // left side sorted
                if (arr[left] <= arr[mid])
                {
                    if (arr[left] <= target && arr[mid] >= target)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                // right side sorted
                else
                {
                    if (arr[mid + 1] <= target && arr[right] >= target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return targetIndex;
        }

        public static void Run()
        {
            // var arr = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            var arr = new int[] { 1, 3 };
            var target = 3;

            System.Console.WriteLine(Search(arr, target));
        }
    }
}