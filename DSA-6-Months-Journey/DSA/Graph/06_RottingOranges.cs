namespace DSA.Graph
{
    public class RottingOranges
    {

        public static void Main()
        {
            int[][] grid = [[2, 1, 1], [0, 1, 1], [1, 0, 1]];
            System.Console.WriteLine(OrangesRotting(grid));
        }

        public static int OrangesRotting(int[][] grid)
        {
            var minutes = 0;
            var queue = new Queue<(int, int)>();
            var freshOranges = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshOranges++;
                    }
                }
            }

            if (freshOranges == 0)
            {
                return 0;
            }

            while (queue.Count != 0)
            {
                var tempQueue = new Queue<(int, int)>();
                while (queue.Count != 0)
                {
                    var currentIndex = queue.Dequeue();
                    var row = currentIndex.Item1;
                    var col = currentIndex.Item2;

                    if (row - 1 >= 0 && grid[row - 1][col] == 1)
                    {
                        grid[row - 1][col] = 2;
                        freshOranges--;
                        tempQueue.Enqueue((row - 1, col));
                    }
                    if (row + 1 < grid.Length && grid[row + 1][col] == 1)
                    {
                        grid[row + 1][col] = 2;
                        freshOranges--;
                        tempQueue.Enqueue((row + 1, col));
                    }
                    if (col - 1 >= 0 && grid[row][col - 1] == 1)
                    {
                        grid[row][col - 1] = 2;
                        freshOranges--;
                        tempQueue.Enqueue((row, col - 1));
                    }
                    if (col + 1 < grid[0].Length && grid[row][col + 1] == 1)
                    {
                        grid[row][col + 1] = 2;
                        freshOranges--;
                        tempQueue.Enqueue((row, col + 1));
                    }
                }

                if (tempQueue.Count > 0)
                {
                    minutes++;

                    while (tempQueue.Count > 0)
                    {
                        queue.Enqueue(tempQueue.Dequeue());
                    }
                }
            }

            return freshOranges > 0 ? -1 : minutes;
        }
    }
}