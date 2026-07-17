namespace DSA.Graph
{
    public class FindCityWithSmallestNumberOfNeighbors
    {

        public static void Main()
        {
            int n = 5;
            int[][] edges = [[0, 1, 2], [0, 4, 8], [1, 2, 3], [1, 4, 2], [2, 3, 1], [3, 4, 1]];
            int distanceThreshold = 2;

            System.Console.WriteLine(FindTheCity(n, edges, distanceThreshold));
        }

        public static int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            const int INF = 100000000;
            var graph = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        graph[i, j] = 0;
                    }
                    else if (i != j)
                    {
                        graph[i, j] = INF;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    System.Console.Write(graph[i, j] + ",");
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine();

            foreach (var e in edges)
            {
                var src = e[0];
                var dest = e[1];
                var dist = e[2];

                graph[src, dest] = dist;
                graph[dest, src] = dist;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    System.Console.Write(graph[i, j] + ",");
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine();

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i != k && j != k && i != j)
                        {
                            graph[i, j] = Math.Min(graph[i, j], graph[i, k] + graph[k, j]);
                        }
                    }
                }
            }

            int city = 0;
            int minNeighbors = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int neighbors = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j && graph[i, j] <= distanceThreshold)
                    {
                        neighbors++;
                    }
                }
                if (neighbors <= minNeighbors)
                {
                    minNeighbors = neighbors;
                    city = i;
                }
            }

            System.Console.WriteLine(minNeighbors);

            return city;
        }
    }
}