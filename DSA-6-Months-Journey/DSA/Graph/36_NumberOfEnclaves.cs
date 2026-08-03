namespace DSA.Graph
{
    public class NumberOfEnclaves
    {

        public static void Main()
        {
            int[][] grid = [[0, 0, 0, 0], [1, 0, 1, 0], [0, 1, 1, 0], [0, 0, 0, 0]];

            System.Console.WriteLine(NumEnclaves(grid));
        }

        public static int NumEnclaves(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            int answer = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        int count = 0;
                        bool touchesBoundary = false;

                        DFS(r, c, ref count, ref touchesBoundary);

                        if (!touchesBoundary)
                            answer += count;
                    }
                }
            }

            return answer;

            void DFS(int r, int c, ref int count, ref bool touchesBoundary)
            {
                grid[r][c] = 0;
                count++;

                if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)
                    touchesBoundary = true;

                for (int i = 0; i < 4; i++)
                {
                    int nr = r + dr[i];
                    int nc = c + dc[i];

                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                        continue;

                    if (grid[nr][nc] == 0)
                        continue;

                    DFS(nr, nc, ref count, ref touchesBoundary);
                }
            }
        }
    }
}