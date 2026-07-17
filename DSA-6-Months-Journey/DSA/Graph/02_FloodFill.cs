namespace DSA.Graph
{
    public static class FloodFillProgram
    {
        public static void Main()
        {
            int[][] image = [
                [1, 1, 1],
                [1, 1, 0],
                [1, 0, 1]
            ];
            int sr = 1;
            int sc = 1;
            int color = 2;

            int[][] result = FloodFill(image, sr, sc, color);

            // Print result
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Console.Write(result[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            var originalColor = image[sr][sc];

            if (originalColor == color) return image;

            // DFS(image, sr, sc, originalColor, color);
            BFS(image, sr, sc, originalColor, color);

            return image;
        }

        public static void DFS(int[][] image, int sr, int sc, int originalColor, int newColor)
        {
            if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length) return;

            int currentColor = image[sr][sc];

            if (currentColor != originalColor) return;

            image[sr][sc] = newColor;

            DFS(image, sr, sc + 1, originalColor, newColor);
            DFS(image, sr, sc - 1, originalColor, newColor);
            DFS(image, sr + 1, sc, originalColor, newColor);
            DFS(image, sr - 1, sc, originalColor, newColor);
        }

        public static void BFS(int[][] image, int sr, int sc, int originalColor, int newColor)
        {
            // Version: 1
            // 
            // var queue = new Queue<(int, int)>();
            // var visited = new HashSet<(int, int)>();

            // queue.Enqueue((sr, sc));
            // visited.Add((sr, sc));

            // while (queue.Count != 0)
            // {
            //     var currentNode = queue.Dequeue();
            //     var row = currentNode.Item1;
            //     var col = currentNode.Item2;
            //     visited.Add(currentNode);

            //     var currentColor = image[row][col];

            //     if (currentColor != originalColor) continue;
            //     else image[row][col] = newColor;

            //     if (row + 1 < image.Length)
            //     {
            //         queue.Enqueue((row + 1, col));
            //     }
            //     if (row - 1 >= 0)
            //     {
            //         queue.Enqueue((row - 1, col));
            //     }
            //     if (col + 1 < image[0].Length)
            //     {
            //         queue.Enqueue((row, col + 1));
            //     }
            //     if (col - 1 >= 0)
            //     {
            //         queue.Enqueue((row, col - 1));
            //     }
            // }

            // Better Version
            var queue = new Queue<(int, int)>();
            int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];

            queue.Enqueue((sr, sc));

            while (queue.Count != 0)
            {
                var (r, c) = queue.Dequeue();

                foreach (var d in dirs)
                {
                    int nr = r + d[0], nc = c + d[1];
                    if (nr < 0 || nr >= image.Length || nc < 0 || nc >= image[0].Length) continue;
                    if (image[nr][nc] != originalColor) continue;

                    image[nr][nc] = newColor;
                    queue.Enqueue((nr, nc));
                }
            }
        }
    }
}