namespace DSA.Graph
{
    public class MaxAreaOfIsland
    {

        public static void Main()
        {
            int[][] grid = [[0, 0, 0, 0, 0, 0, 0, 0]];

            Console.WriteLine(FindMaxArea(grid));
        }

        public static int FindMaxArea(int[][] grid)
        {
            var maxArea = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        var area = DFS(grid, i, j);
                        maxArea = Math.Max(area, maxArea);
                    }
                }
            }

            return maxArea;
        }

        public static int DFS(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0) return 0;

            grid[i][j] = 0;

            var left = DFS(grid, i, j - 1);
            var right = DFS(grid, i, j + 1);
            var up = DFS(grid, i - 1, j);
            var down = DFS(grid, i + 1, j);

            return 1 + left + right + up + down;
        }
    }
}