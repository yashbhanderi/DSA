namespace CSharp.Topics.Arrays
{
    public class FindMinimumInRotatedSortedArray
    {
        public static int FindMin(int[] arr)    // Must find in log(n) time
        {
            int n = arr.Length;

            int left = 0, right = n - 1;
            int mid = 0;
            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (left == right
                || ((mid - 1 >= 0 && arr[mid - 1] > arr[mid]) && (mid + 1 < n && arr[mid + 1] > arr[mid]))
                )
                {
                    break;
                }

                if (arr[left] < arr[right])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return arr[mid];
        }

        public static void Run()
        {
            // var arr = new int[] { 4, 5, 6, 7, 1, 2, 3 };
            // var arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            // var arr = new int[] { 7, 6, 5, 4, 3, 2, 1, 0 };
            // var arr = new int[] { 2, 3, 4, 5, 1 };
            var arr = new int[] { 1, 2 };
            System.Console.WriteLine(FindMin(arr));
        }
    }
}