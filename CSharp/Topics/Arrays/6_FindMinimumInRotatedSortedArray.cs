namespace CSharp.Topics.Arrays
{
    public class FindMinimumInRotatedSortedArray
    {
        public static int FindMin(int[] arr)    // Must find in log(n) time
        {
            int n = arr.Length;

            int left = 0, right = n - 1;
            int mid = left + ((right - left) / 2);

            while (true)
            {
                mid = left + ((right - left) / 2);

                int nextIndex = (mid + 1) % n;
                int prevIndex = (mid - 1 + n) % n;

                if (nextIndex == prevIndex ||
                (arr[mid] < arr[nextIndex] && arr[mid] < arr[prevIndex])
                || (arr[mid] > arr[nextIndex] && arr[mid] > arr[prevIndex])
                )
                {
                    break;
                }

                if (arr[mid] < arr[nextIndex])
                {
                    left = nextIndex;
                }
                else
                {
                    right = prevIndex;
                }

                if (left == n - 1)
                {
                    left = 0;
                    // right = 
                }
            }

            return arr[mid];
        }

        public static void Run()
        {
            // var arr = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            // var arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            // var arr = new int[] { 7, 6, 5, 4, 3, 2, 1, 0 };
            var arr = new int[] { 2, 3, 4, 5, 1 };
            System.Console.WriteLine(FindMin(arr));
        }
    }
}