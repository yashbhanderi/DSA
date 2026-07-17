namespace DSA.Graph
{
    public class ShortestPathInUndirectedGraph
    {

        public static void Main()
        {
            int V = 9;
            int[][] edges = [[0, 1], [0, 3], [1, 2], [3, 4], [4, 5], [2, 6], [5, 6], [6, 7], [6, 8], [7, 8]];
            int src = 0;

            System.Console.WriteLine(string.Join(",", ShortestPath(V, edges, src)));
        }

        public static int[] ShortestPath(int V, int[][] edges, int src)
        {
            var adjList = new List<int>[V];

            for (int i = 0; i < V; i++)
            {
                adjList[i] = [];
            }

            foreach (var e in edges)
            {
                adjList[e[0]].Add(e[1]);
                adjList[e[1]].Add(e[0]);
            }

            var visited = new bool[V];
            var queue = new Queue<int>();
            var shortestDistance = new int[V];

            for (int i = 0; i < V; i++)
            {
                shortestDistance[i] = int.MaxValue;
            }

            shortestDistance[src] = 0;
            queue.Enqueue(src);

            while (queue.Count > 0)
            {
                var top = queue.Dequeue();
                visited[top] = true;

                if (shortestDistance[top] == int.MaxValue)
                {
                    continue;
                }

                foreach (var e in adjList[top])
                {
                    if (!visited[e])
                    {
                        var calculatedDistance = shortestDistance[top] + 1;
                        shortestDistance[e] = Math.Min(calculatedDistance, shortestDistance[e]);
                        queue.Enqueue(e);
                    }
                }
            }

            for (int i = 0; i < V; i++)
            {
                if (shortestDistance[i] == int.MaxValue)
                    shortestDistance[i] = -1;
            }

            return shortestDistance;
        }
    }
}