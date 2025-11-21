namespace CSharp.Topics.Matrix
{
    public class SetMatrixZeroes
    {
        public static void SetZeroes(int[][] matrix)
        {
            int n = matrix.Length, m = matrix[0].Length;

            bool isZeroInAnyRow = false, isZeroInAnyColumn = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;

                        if (i == 0) isZeroInAnyRow = true;
                        if (j == 0) isZeroInAnyColumn = true;
                        break;
                    }
                }
            }

            // Set zeros in indexes without headers
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[0][j] == 0 || matrix[i][0] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // Set zeros in headers indexes - First Row 
            if (isZeroInAnyRow)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            // Set zeros in headers indexes - First Column
            if (isZeroInAnyColumn)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }

        public static void Run()
        {
            // var matrix = new int[][] { [0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5] };
            var matrix = new int[][] { [1, 0, 3] };
            SetZeroes(matrix);
        }
    }
}