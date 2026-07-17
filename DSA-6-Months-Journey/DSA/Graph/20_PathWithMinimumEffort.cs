namespace DSA.Graph
{
    public class PathWithMinimumEffort
    {

        public static void Main()
        {
            int[][] heights = [[1, 10, 6, 7, 9, 10, 4, 9]];

            System.Console.WriteLine(MinimumEffortPath(heights));
        }

        public static int MinimumEffortPath(int[][] heights)
        {
            var N = heights.Length;
            var M = heights[0].Length;
            int[,] shortestDistance = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    shortestDistance[i, j] = int.MaxValue;
                }
            }

            shortestDistance[0, 0] = 0;

            var pq = new PriorityQueue<(int, (int, int)), int>();
            pq.Enqueue((0, (0, 0)), 0);

            while (pq.Count > 0)
            {
                var root = pq.Dequeue();
                var rootDist = root.Item1;
                int[] rootCord = [root.Item2.Item1, root.Item2.Item2];

                // left
                if (rootCord[1] - 1 >= 0)
                {
                    var currentCalculatedDistance = Math.Max(rootDist, Math.Abs(heights[rootCord[0]][rootCord[1] - 1] - heights[rootCord[0]][rootCord[1]]));
                    if (shortestDistance[rootCord[0], rootCord[1] - 1] > currentCalculatedDistance)
                    {
                        shortestDistance[rootCord[0], rootCord[1] - 1] = currentCalculatedDistance;
                        pq.Enqueue((currentCalculatedDistance, (rootCord[0], rootCord[1] - 1)), currentCalculatedDistance);
                    }
                }

                // right
                if (rootCord[1] + 1 < M)
                {
                    var currentCalculatedDistance = Math.Max(rootDist, Math.Abs(heights[rootCord[0]][rootCord[1] + 1] - heights[rootCord[0]][rootCord[1]]));
                    if (shortestDistance[rootCord[0], rootCord[1] + 1] > currentCalculatedDistance)
                    {
                        shortestDistance[rootCord[0], rootCord[1] + 1] = currentCalculatedDistance;
                        pq.Enqueue((currentCalculatedDistance, (rootCord[0], rootCord[1] + 1)), currentCalculatedDistance);
                    }
                }

                // Up
                if (rootCord[0] - 1 >= 0)
                {
                    var currentCalculatedDistance = Math.Max(rootDist, Math.Abs(heights[rootCord[0] - 1][rootCord[1]] - heights[rootCord[0]][rootCord[1]]));
                    if (shortestDistance[rootCord[0] - 1, rootCord[1]] > currentCalculatedDistance)
                    {
                        shortestDistance[rootCord[0] - 1, rootCord[1]] = currentCalculatedDistance;
                        pq.Enqueue((currentCalculatedDistance, (rootCord[0] - 1, rootCord[1])), currentCalculatedDistance);
                    }
                }

                // Down
                if (rootCord[0] + 1 < N)
                {
                    var currentCalculatedDistance = Math.Max(rootDist, Math.Abs(heights[rootCord[0] + 1][rootCord[1]] - heights[rootCord[0]][rootCord[1]]));
                    if (shortestDistance[rootCord[0] + 1, rootCord[1]] > currentCalculatedDistance)
                    {
                        shortestDistance[rootCord[0] + 1, rootCord[1]] = currentCalculatedDistance;
                        pq.Enqueue((currentCalculatedDistance, (rootCord[0] + 1, rootCord[1])), currentCalculatedDistance);
                    }
                }
            }

            if (shortestDistance[N - 1, M - 1] == int.MaxValue) return -1;

            return shortestDistance[N - 1, M - 1];
        }
    }
}