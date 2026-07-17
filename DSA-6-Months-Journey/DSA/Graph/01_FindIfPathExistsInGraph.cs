namespace DSA.Graph
{
    public static class FindIfPathExistsInGraph
    {
        public static bool ValidPath(int n, int[][] edge, int source, int destination)
        {
            if (source == destination) return true;

            var graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                graph[i] = [];
            }

            for (int i = 0; i < edge.Length; i++)
            {
                graph[edge[i][0]].Add(edge[i][1]);
                graph[edge[i][1]].Add(edge[i][0]);
            }

            // BFS
            var queue = new Queue<int>();
            var visited = new HashSet<int>();

            queue.Enqueue(source);
            visited.Add(source);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var e in graph[currentNode])
                {
                    if (e == destination) return true;

                    if (!visited.Contains(e))
                    {
                        visited.Add(e);
                        queue.Enqueue(e);
                    }
                }
            }

            return false;
        }


        public static void Main()
        {
            var n = 3;
            var edges = new int[][] { [0, 1], [1, 2], [2, 0] };
            var source = 0;
            var destination = 2;

            System.Console.WriteLine(ValidPath(n, edges, source, destination));
        }
    }
}