namespace DSA.Graph
{
    public class ShortestPathInDAG
    {

        public static void Main()
        {
            int V = 6;
            int E = 7;
            List<List<int>> edges = [[0, 1, 2], [0, 4, 1], [4, 5, 4], [4, 2, 2], [1, 2, 3], [2, 3, 6], [5, 3, 1]];

            System.Console.WriteLine(string.Join(",", ShortestPath(V, E, edges)));
        }

        public static List<int> ShortestPath(int V, int E, List<List<int>> edges)
        {
            var adjList = new List<(int, int)>[V];

            for (int i = 0; i < V; i++)
            {
                adjList[i] = [];
            }

            foreach (var e in edges)
            {
                var src = e[0];
                var dest = e[1];
                var distance = e[2];

                adjList[src].Add((dest, distance));
            }

            var visited = new int[V];
            var stack = new Stack<int>();

            for (int i = 0; i < V; i++)
            {
                if (visited[i] == 0)
                {
                    DFS(adjList, visited, stack, i);
                }
            }

            var shortestDistance = new int[V];
            for (int i = 0; i < V; i++)
            {
                shortestDistance[i] = int.MaxValue;
            }

            shortestDistance[0] = 0;

            while (stack.Count > 0)
            {
                var top = stack.Pop();

                if (shortestDistance[top] == int.MaxValue)
                {
                    continue;
                }

                foreach (var e in adjList[top])
                {
                    var element = e.Item1;
                    var dist = e.Item2;

                    var calculatedDistance = shortestDistance[top] + dist;

                    shortestDistance[element] = Math.Min(calculatedDistance, shortestDistance[element]);
                }
            }

            for (int i = 0; i < V; i++)
            {
                if (shortestDistance[i] == int.MaxValue)
                    shortestDistance[i] = -1;
            }

            return shortestDistance.ToList();
        }

        public static void DFS(List<(int, int)>[] adjList, int[] visited, Stack<int> stack, int node)
        {
            if (visited[node] == 1) return;

            visited[node] = 1;

            foreach (var e in adjList[node])
            {
                if (visited[e.Item1] == 0)
                {
                    DFS(adjList, visited, stack, e.Item1);
                }
            }

            stack.Push(node);
        }
    }
}