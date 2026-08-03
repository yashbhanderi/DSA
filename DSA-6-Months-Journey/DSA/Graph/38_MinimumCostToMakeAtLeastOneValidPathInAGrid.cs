namespace DSA.Graph
{
    public class MinimumCostToMakeAtLeastOneValidPathInAGrid
    {

        public static void Main()
        {
            int[][] grid = [[1, 1, 1, 1], [2, 2, 2, 2], [1, 1, 1, 1], [2, 2, 2, 2]];
            System.Console.WriteLine(MinCost(grid));
        }


        public static int MinCost(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            var queue = new LinkedList<((int, int), int)>();
            var distance = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    distance[i, j] = int.MaxValue;
                }
            }
            queue.AddLast(((0, 0), 0));
            distance[0, 0] = 0;

            while (queue.Count > 0)
            {
                var top = queue.First();
                queue.RemoveFirst();
                var row = top.Item1.Item1;
                var col = top.Item1.Item2;
                var costTillNow = top.Item2;

                if (row == n - 1 && col == m - 1)
                {
                    return costTillNow;
                }

                // Up check
                if (row - 1 >= 0)
                {
                    if (grid[row][col] == 4)
                    {
                        if (costTillNow < distance[row - 1, col])
                        {
                            distance[row - 1, col] = costTillNow;
                            queue.AddFirst(((row - 1, col), costTillNow));
                        }
                    }
                    else
                    {
                        if (costTillNow + 1 < distance[row - 1, col])
                        {
                            distance[row - 1, col] = costTillNow + 1;
                            queue.AddLast(((row - 1, col), costTillNow + 1));
                        }
                    }
                }

                // Left check
                if (col - 1 >= 0)
                {
                    if (grid[row][col] == 2)
                    {
                        if (costTillNow < distance[row, col - 1])
                        {
                            distance[row, col - 1] = costTillNow;
                            queue.AddFirst(((row, col - 1), costTillNow));
                        }
                    }
                    else
                    {
                        if (costTillNow + 1 < distance[row, col - 1])
                        {
                            distance[row, col - 1] = costTillNow + 1;
                            queue.AddLast(((row, col - 1), costTillNow + 1));
                        }
                    }
                }

                // Right check
                if (col + 1 < m)
                {
                    if (grid[row][col] == 1)
                    {
                        if (costTillNow < distance[row, col + 1])
                        {
                            distance[row, col + 1] = costTillNow;
                            queue.AddFirst(((row, col + 1), costTillNow));
                        }
                    }
                    else
                    {
                        if (costTillNow + 1 < distance[row, col + 1])
                        {
                            distance[row, col + 1] = costTillNow + 1;
                            queue.AddLast(((row, col + 1), costTillNow + 1));
                        }
                    }
                }

                // Down check
                if (row + 1 < n)
                {
                    if (grid[row][col] == 3)
                    {
                        if (costTillNow < distance[row + 1, col])
                        {
                            distance[row + 1, col] = costTillNow;
                            queue.AddFirst(((row + 1, col), costTillNow));
                        }
                    }
                    else
                    {
                        if (costTillNow + 1 < distance[row + 1, col])
                        {
                            distance[row + 1, col] = costTillNow + 1;
                            queue.AddLast(((row + 1, col), costTillNow + 1));
                        }
                    }
                }
            }

            return 0;
        }
    }
}