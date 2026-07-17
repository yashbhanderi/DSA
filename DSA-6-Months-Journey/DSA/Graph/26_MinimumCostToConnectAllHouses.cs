namespace DSA.Graph
{
    public class MinimumCostToConnectAllHouses
    {

        public static void Main()
        {
            int[,] houses = { { 0, 0 }, { 1, 1 }, { 1, 3 }, { 3, 0 } };

            System.Console.WriteLine(MinCost(houses));
        }

        public static int MinCost(int[,] houses)
        {
            var N = houses.GetLength(0);
            var adjList = new List<(int, int)>[N];
            var pq = new PriorityQueue<int, int>();
            var minCost = int.MaxValue;
            var minCostHouse = (-1, -1);
            var visited = new HashSet<int>();
            var totalCost = 0;

            for (int i = 0; i < N; i++)
            {
                adjList[i] = [];
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j)
                    {
                        var srcX = houses[i, 0];
                        var destX = houses[j, 0];
                        var srcY = houses[i, 1];
                        var destY = houses[j, 1];
                        var cost = Math.Abs(srcX - destX) + Math.Abs(srcY - destY);

                        if (cost < minCost)
                        {
                            minCost = cost;
                            minCostHouse = (i, j);
                        }
                        adjList[i].Add((j, cost));
                    }
                }
            }

            pq.Enqueue(minCostHouse.Item1, minCost);
            pq.Enqueue(minCostHouse.Item2, minCost);
            visited.Add(minCostHouse.Item1);

            totalCost += minCost;

            while (pq.Count > 0)
            {
                var top = pq.Dequeue();
                var minCostQueueNode = -1;
                var minCostQueueCost = int.MaxValue;
                foreach (var e in adjList[top])
                {
                    if (!visited.Contains(e.Item1) && e.Item2 < minCostQueueCost)
                    {
                        minCostQueueNode = e.Item1;
                        minCostQueueCost = e.Item2;
                    }
                }
                if (minCostQueueNode != -1)
                {
                    pq.Enqueue(minCostQueueNode, minCostQueueCost);
                    visited.Add(minCostQueueNode);
                    totalCost += minCostQueueCost;
                }
            }

            return totalCost;
        }
    }
}