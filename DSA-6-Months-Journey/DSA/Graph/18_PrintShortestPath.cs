namespace DSA.Graph
{
    public class PrintShortestPath
    {

        public static void Main()
        {
            int n = 2;
            int m = 0;
            int[][] edges = [];

            System.Console.WriteLine(string.Join(",", PrintPath(edges, n, m)));
        }

        public static List<int> PrintPath(int[][] times, int n, int m)
        {
            var adjList = new List<(int, int)>[n + 1];

            for (int i = 0; i <= n; i++)
            {
                adjList[i] = [];
            }

            foreach (var e in times)
            {
                var src = e[0];
                var dest = e[1];
                var distance = e[2];

                adjList[src].Add((dest, distance));
                adjList[dest].Add((src, distance));
            }

            var shortestDistance = new int[n + 1];
            var parent = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                shortestDistance[i] = int.MaxValue;
            }

            shortestDistance[1] = 0;
            parent[1] = 1;

            var set = new SortedSet<(int, int)>
            {
                (0, 1)
            };

            while (set.Count > 0)
            {
                var root = set.First();
                var rootDist = root.Item1;
                var rootVal = root.Item2;

                if (shortestDistance[rootVal] == int.MaxValue)
                {
                    continue;
                }

                foreach (var node in adjList[rootVal])
                {
                    var nodeVal = node.Item1;
                    var nodeDist = node.Item2;
                    var currentCalculatedDistance = rootDist + nodeDist;

                    if (shortestDistance[nodeVal] > currentCalculatedDistance)
                    {
                        shortestDistance[nodeVal] = currentCalculatedDistance;
                        parent[nodeVal] = rootVal;

                        set.Add((currentCalculatedDistance, nodeVal));
                    }
                }

                set.Remove(root);
            }

            var shortestPath = new List<int>();
            int ele = n;
            shortestPath.Add(n);

            while (parent[ele] != ele)
            {
                if (shortestDistance[ele] == int.MaxValue) return [-1];

                shortestPath.Add(parent[ele]);

                ele = parent[ele];
            }

            shortestPath.Reverse();

            return shortestPath;
        }
    }
}