namespace CSharp.Topics.Arrays
{
    public class FindFirstAndLastPositionOfElementInSortedArray
    {

        public static int[] FirstAndLastPositionOfTargetElement(int[] arr, int target)
        {
            int n = arr.Length;
            var positions = new int[2] { -1, -1 };

            // Lower Bound
            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    positions[0] = mid;
                    right = mid;
                }

                else if (arr[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            // Upper Bound
            left = 0; right = n - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    positions[1] = mid;
                    left = mid + 1;
                }

                else if (arr[mid] > target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return positions;
        }

        public static void Run()
        {
            var arr = new int[] { 5, 7, 7, 8, 8, 10 };
            var target = 1;

            System.Console.WriteLine(string.Join(",", FirstAndLastPositionOfTargetElement(arr, target)));
        }
    }
}