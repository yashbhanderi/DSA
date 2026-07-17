namespace DSA.Graph
{
    public class NumberOfIslands
    {
        public static HashSet<(int, int)> Visited = [];
        public static int Islands = 0;

        public static void Sink(char[][] grid, int row, int col)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length) return;

            if (Visited.Contains((row, col)) || grid[row][col] == '0') return;

            Visited.Add((row, col));

            Sink(grid, row + 1, col);
            Sink(grid, row - 1, col);
            Sink(grid, row, col + 1);
            Sink(grid, row, col - 1);
        }


        public static void DFS(char[][] grid)
        {
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1' && !Visited.Contains((i, j)))
                    {
                        Islands++;
                        Sink(grid, i, j);
                    }
                    else
                    {
                        Visited.Add((i, j));
                    }
                }
            }
        }

        public static void Main()
        {
            char[][] grid = [
['1','1','0','0','0'],
  ['1','1','0','0','0'],
  ['0','0','1','0','0'],
  ['0','0','0','1','1']
            ];

            DFS(grid);
            System.Console.WriteLine(Islands);
        }
    }
}