namespace CSharp.Topics.BinarySearch
{
    public class SearchIn2DMatrix
    {
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int n = matrix.Length, m = matrix[0].Length;
            int left = 0, right = n * m;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int row = mid / m; // to check element lies on which row
                int column = mid % m; // to check element lies on which column

                if (target == matrix[row][column])
                {
                    return true;
                }
                else if (target > matrix[row][column])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }

        public static void Run()
        {
            var matrix = new int[][] { [1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60] };
            var target = 7;

            System.Console.WriteLine(SearchMatrix(matrix, target));
        }
    }
}