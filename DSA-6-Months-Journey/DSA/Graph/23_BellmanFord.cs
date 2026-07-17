namespace DSA.Graph
{
    public class BellmanFord
    {

        public static void Main()
        {
            int V = 4;
            List<List<int>> edges = [[0, 1, 4], [1, 2, -6], [2, 3, 5], [3, 1, -2]];
            int src = 0;

            System.Console.WriteLine(string.Join(",", BellmanFordAlgorithm(V, edges, src)));
        }

        public static List<int> BellmanFordAlgorithm(int V, List<List<int>> edges, int src)
        {
            int[] shortestDistance = new int[V];
            for (int i = 0; i < V; i++)
            {
                shortestDistance[i] = int.MaxValue;
            }
            shortestDistance[src] = 0;

            for (int i = 0; i < V; i++)
            {
                foreach (var e in edges)
                {
                    var source = e[0];
                    var destination = e[1];
                    var dist = e[2];

                    if (shortestDistance[source] == int.MaxValue)
                    {
                        continue;
                    }

                    var newCalculatedDistance = shortestDistance[source] + dist;
                    if (shortestDistance[destination] > newCalculatedDistance)
                    {
                        shortestDistance[destination] = newCalculatedDistance;
                    }
                }
            }

            for (int i = 0; i < edges.Count; i++)
            {
                var source = edges[i][0];
                var destination = edges[i][1];
                var dist = edges[i][2];

                if (shortestDistance[source] == int.MaxValue)
                {
                    continue;
                }

                var newCalculatedDistance = shortestDistance[source] + dist;
                // Negative weight cycle detected!!
                if (newCalculatedDistance < shortestDistance[destination])
                {
                    return [-1];
                }
            }

            for (int i = 0; i < V; i++)
            {
                if (shortestDistance[i] == int.MaxValue)
                {
                    shortestDistance[i] = 100000000;
                }
            }

            return [.. shortestDistance];
        }
    }
}