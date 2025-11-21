namespace CSharp.Topics.Matrix
{
    public class RotateImage
    {
        public static void Rotate(int[][] matrix)
        {
            int N = matrix.Length;

            // 1. Transpose the Matrix (Swap M[i][j] with M[j][i])
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++) // Start j from i+1 to only process the upper triangle
                {
                    // Simple swap operation
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            // 2. Reverse Each Row
            for (int i = 0; i < N; i++)
            {
                // Use the built-in C# Array.Reverse method on the inner array (the row)
                Array.Reverse(matrix[i]);
            }
        }

        public static void Run()
        {
            var matrix = new int[][] { [1, 2, 3], [4, 5, 6], [7, 8, 9] };
            Rotate(matrix);

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    System.Console.Write(matrix[i][j] + ",");
                }
                System.Console.WriteLine();
            }
        }
    }
}