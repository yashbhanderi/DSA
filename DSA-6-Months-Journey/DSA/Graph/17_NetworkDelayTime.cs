namespace DSA.Graph
{
    public class NetworkDelayTime
    {

        public static void Main()
        {
            int[][] times = [[2, 1, 1], [2, 3, 1], [3, 4, 1]];
            int n = 4;
            int k = 2;

            System.Console.WriteLine(NetworkDelay(times, n, k));
        }

        public static int NetworkDelay(int[][] times, int n, int k)
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
            }

            var shortestDistance = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                shortestDistance[i] = int.MaxValue;
            }

            shortestDistance[k] = 0;

            var set = new SortedSet<(int, int)>
            {
                (0, k)
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
                        set.Add((currentCalculatedDistance, nodeVal));
                    }
                }

                set.Remove(root);
            }

            var minTime = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                if (shortestDistance[i] == int.MaxValue)
                {
                    return -1;
                }

                minTime = Math.Max(shortestDistance[i], minTime);
            }

            return minTime;
        }
    }
}