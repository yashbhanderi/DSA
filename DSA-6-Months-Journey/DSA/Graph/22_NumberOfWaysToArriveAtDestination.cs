namespace DSA.Graph
{
    public class NumberOfWaysToArriveAtDestination
    {

        public static void Main()
        {
            int n = 7;
            int[][] roads = [[0, 6, 7], [0, 1, 2], [1, 2, 3], [1, 3, 3], [6, 3, 3], [3, 5, 1], [6, 5, 1], [2, 5, 1], [0, 4, 5], [4, 6, 2]];

            System.Console.WriteLine(CountPaths(n, roads));
        }

        public static int CountPaths(int n, int[][] roads)
        {
            const int MOD = 1_000_000_007;
            var adjList = new List<(int, int)>[n];

            for (int i = 0; i < n; i++)
            {
                adjList[i] = [];
            }

            foreach (var e in roads)
            {
                var source = e[0];
                var destination = e[1];
                var time = e[2];

                adjList[source].Add((destination, time));
                adjList[destination].Add((source, time));
            }

            var shortestTime = new long[n];
            var ways = new long[n];
            for (int i = 0; i < n; i++)
            {
                shortestTime[i] = long.MaxValue;
                ways[i] = 0;
            }
            shortestTime[0] = 0;
            ways[0] = 1;
            var pq = new PriorityQueue<(int, long), long>();

            pq.Enqueue((0, 0), 0);

            while (pq.Count > 0)
            {
                var top = pq.Dequeue();
                var currentNode = top.Item1;
                var timeTillNow = top.Item2;

                if (timeTillNow > shortestTime[currentNode])
                {
                    continue;
                }

                foreach (var e in adjList[currentNode])
                {
                    var newNode = e.Item1;
                    var newTime = e.Item2;
                    var totalTime = timeTillNow + newTime;

                    if (totalTime < shortestTime[newNode])
                    {
                        ways[newNode] = (ways[currentNode] % MOD);
                        shortestTime[newNode] = totalTime;
                        pq.Enqueue((newNode, totalTime), totalTime);
                    }
                    else if (totalTime == shortestTime[newNode])
                    {
                        ways[newNode] = (ways[newNode] + ways[currentNode]) % MOD;
                    }
                }
            }

            return (int)ways[n - 1];
        }
    }
}