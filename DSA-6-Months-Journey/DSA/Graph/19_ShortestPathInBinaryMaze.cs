namespace DSA.Graph
{
    public class ShortestPathInBinaryMaze
    {

        public static void Main()
        {
            int[][] mat = [[1, 1, 1, 1], [1, 1, 0, 1], [1, 1, 1, 1], [1, 1, 0, 0], [1, 0, 0, 1]];
            int[] src = [0, 1], dest = [2, 2];

            System.Console.WriteLine(ShortestPath(mat, src, dest));
        }

        public static int ShortestPath(int[][] mat, int[] src, int[] dest)
        {
            if (mat[src[0]][src[1]] == 0 || mat[dest[0]][dest[1]] == 0)
                return -1;

            var N = mat.Length;
            var M = mat[0].Length;
            int[,] shortestDistance = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    shortestDistance[i, j] = int.MaxValue;
                }
            }

            shortestDistance[src[0], src[1]] = 0;

            var queue = new Queue<(int, (int, int))>();
            queue.Enqueue((0, (src[0], src[1])));

            while (queue.Count > 0)
            {
                var root = queue.Dequeue();
                var rootDist = root.Item1;
                int[] rootCord = [root.Item2.Item1, root.Item2.Item2];

                if (shortestDistance[rootCord[0], rootCord[1]] == int.MaxValue)
                {
                    continue;
                }

                if (rootCord[0] == dest[0] && rootCord[1] == dest[1])
                {
                    return rootDist;
                }

                // left
                if (rootCord[1] - 1 >= 0 && mat[rootCord[0]][rootCord[1] - 1] == 1)
                {
                    var currentCalculatedDistance = rootDist + 1;


                    if (shortestDistance[rootCord[0], rootCord[1] - 1] > currentCalculatedDistance)
                    {
                        shortestDistance[rootCord[0], rootCord[1] - 1] = currentCalculatedDistance;
                        queue.Enqueue((currentCalculatedDistance, (rootCord[0], rootCord[1] - 1)));
                    }
                }

                // right
                if (rootCord[1] + 1 < M && mat[rootCord[0]][rootCord[1] + 1] == 1)
                {
                    var currentCalculatedDistance = rootDist + 1;


                    if (shortestDistance[rootCord[0], rootCord[1] + 1] > currentCalculatedDistance)
                    {
                        shortestDistance[rootCord[0], rootCord[1] + 1] = currentCalculatedDistance;
                        queue.Enqueue((currentCalculatedDistance, (rootCord[0], rootCord[1] + 1)));
                    }
                }

                // Up
                if (rootCord[0] - 1 >= 0 && mat[rootCord[0] - 1][rootCord[1]] == 1)
                {
                    var currentCalculatedDistance = rootDist + 1;


                    if (shortestDistance[rootCord[0] - 1, rootCord[1]] > currentCalculatedDistance)
                    {
                        shortestDistance[rootCord[0] - 1, rootCord[1]] = currentCalculatedDistance;
                        queue.Enqueue((currentCalculatedDistance, (rootCord[0] - 1, rootCord[1])));
                    }
                }

                // Down
                if (rootCord[0] + 1 < N && mat[rootCord[0] + 1][rootCord[1]] == 1)
                {
                    var currentCalculatedDistance = rootDist + 1;


                    if (shortestDistance[rootCord[0] + 1, rootCord[1]] > currentCalculatedDistance)
                    {
                        shortestDistance[rootCord[0] + 1, rootCord[1]] = currentCalculatedDistance;
                        queue.Enqueue((currentCalculatedDistance, (rootCord[0] + 1, rootCord[1])));
                    }
                }
            }

            return -1;
        }
    }
}