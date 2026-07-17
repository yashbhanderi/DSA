namespace DSA.Graph
{
    public class ZeroOneMatrix
    {

        public static void Main()
        {
            int[][] mat = [[0, 0, 0], [0, 1, 0], [1, 1, 1]];
            var result = UpdateMatrix(mat);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    System.Console.Write(result[i][j] + ", ");
                }
                System.Console.WriteLine();
            }
        }

        public static int[][] UpdateMatrix(int[][] mat)
        {
            var queue = new Queue<(int, int)>();
            var visited = new HashSet<(int, int)>();

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                    }
                }
            }

            var distance = 1;

            while (queue.Count > 0)
            {
                var tempQueue = new Queue<(int, int)>();

                while (queue.Count > 0)
                {
                    var currentCell = queue.Dequeue();
                    var row = currentCell.Item1;
                    var col = currentCell.Item2;

                    if (row - 1 >= 0 && !visited.Contains((row - 1, col)))
                    {
                        mat[row - 1][col] = distance;
                        visited.Add((row - 1, col));
                        tempQueue.Enqueue((row - 1, col));
                    }
                    if (row + 1 < mat.Length && !visited.Contains((row + 1, col)))
                    {
                        mat[row + 1][col] = distance;
                        visited.Add((row + 1, col));
                        tempQueue.Enqueue((row + 1, col));
                    }
                    if (col - 1 >= 0 && !visited.Contains((row, col - 1)))
                    {
                        mat[row][col - 1] = distance;
                        visited.Add((row, col - 1));
                        tempQueue.Enqueue((row, col - 1));
                    }
                    if (col + 1 < mat[0].Length && !visited.Contains((row, col + 1)))
                    {
                        mat[row][col + 1] = distance;
                        visited.Add((row, col + 1));
                        tempQueue.Enqueue((row, col + 1));
                    }
                }

                while (tempQueue.Count > 0)
                {
                    queue.Enqueue(tempQueue.Dequeue());
                }

                distance++;
            }

            return mat;
        }
    }
}