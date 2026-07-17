namespace DSA.Graph
{
    public class FloydWarshall
    {

        public static void Main()
        {
            int[,] dist = { { 0, 1, 43 }, { 1, 0, 6 }, { -1, -1, 0 } };

            FloydWarshallAlgorithm(dist);
        }

        public static void FloydWarshallAlgorithm(int[,] dist)
        {
            var N = dist.GetLength(0);

            // Initial setup for pre-computed value
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                        dist[i, j] = 0;
                    }
                    else if (dist[i, j] == -1)
                    {
                        dist[i, j] = int.MaxValue;
                    }
                }
            }

            // Actual computation
            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (i != k && j != k && i != j)
                        {
                            dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                        }
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (dist[i, j] == int.MaxValue)
                    {
                        dist[i, j] = -1;
                    }
                }
            }
        }
    }
}