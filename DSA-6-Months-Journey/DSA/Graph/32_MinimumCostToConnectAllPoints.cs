namespace DSA.Graph
{
    public class MinimumCostToConnectAllPoints
    {

        public static void Main()
        {
            int[][] points = [[0, 0], [2, 2], [3, 10], [5, 2], [7, 0]];

            System.Console.WriteLine(MinCostConnectPoints(points));
        }

        public static int MinCostConnectPoints(int[][] points)
        {
            var N = points.Length;
            var visited = new bool[N];
            var minCost = 0;
            var currentNode = 0;
            var currentCost = 0;
            int[] minDist = new int[N];
            Array.Fill(minDist, int.MaxValue);

            minDist[0] = 0;

            while (currentNode != -1)
            {
                visited[currentNode] = true;
                minCost += currentCost;

                for (int node = 0; node < N; node++)
                {
                    if (!visited[node])
                    {
                        var newCost = Math.Abs(points[currentNode][0] - points[node][0]) + Math.Abs(points[currentNode][1] - points[node][1]);
                        minDist[node] = Math.Min(
                            minDist[node],
                            newCost
                        );
                    }
                }
                currentNode = -1;
                currentCost = int.MaxValue;
                for (int i = 0; i < N; i++)
                {
                    if (!visited[i] && minDist[i] < currentCost)
                    {
                        currentCost = minDist[i];
                        currentNode = i;
                    }
                }
            }

            return minCost;
        }
    }
}