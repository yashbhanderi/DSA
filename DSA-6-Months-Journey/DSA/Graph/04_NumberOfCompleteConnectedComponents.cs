namespace DSA.Graph
{
    public class NumberOfCompleteConnectedComponents
    {
        static List<int>[] BuildAdjList(int n, int[][] edges)
        {
            var adj = Enumerable.Range(0, n)
                                .Select(_ => new List<int>())
                                .ToArray();

            foreach (var e in edges)
            {
                adj[e[0]].Add(e[1]);
                adj[e[1]].Add(e[0]); // Undirected graph
            }

            return adj;
        }

        public static int DFS(List<int>[] edges, bool[] visited, int node, int totalCount)
        {
            visited[node] = true;

            foreach (var e in edges[node])
            {
                if (!visited[e])
                {
                    totalCount += edges[e].Count;
                    DFS(edges, visited, e, totalCount);
                }
            }

            return totalCount;
        }

        public static int CountCompleteComponents(int n, int[][] edges)
        {
            var adjList = BuildAdjList(n, edges);
            var visited = new bool[n];
            var count = 0;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    var nodesCount = adjList[i].Count;
                    var totalCount = DFS(adjList, visited, i, 0);
                    if (totalCount == nodesCount * nodesCount)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static void Main()
        {
            var n = 6;
            int[][] edges = [[0, 1], [0, 2], [1, 2], [3, 4], [3, 5]];

            System.Console.WriteLine(CountCompleteComponents(n, edges));
        }
    }
}