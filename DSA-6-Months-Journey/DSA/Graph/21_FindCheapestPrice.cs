namespace DSA.Graph
{
    public class FindCheapestPrice
    {

        public static void Main()
        {
            int n = 11;
            int[][] flights = [[0, 3, 3], [3, 4, 3], [4, 1, 3], [0, 5, 1], [5, 1, 100], [0, 6, 2], [6, 1, 100], [0, 7, 1], [7, 8, 1], [8, 9, 1], [9, 1, 1], [1, 10, 1], [10, 2, 1], [1, 2, 100]];
            int src = 0;
            int dst = 2;
            int k = 4;

            System.Console.WriteLine(FindCheapest(n, flights, src, dst, k));
        }

        public static int FindCheapest(int n, int[][] flights, int src, int dst, int k)
        {
            var adjList = new List<(int, int)>[n];

            for (int i = 0; i < n; i++)
            {
                adjList[i] = [];
            }

            foreach (var e in flights)
            {
                var source = e[0];
                var destination = e[1];
                var price = e[2];

                adjList[source].Add((destination, price));
            }

            int[,] cheapestPrice = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cheapestPrice[i, j] = int.MaxValue;
                }
            }
            cheapestPrice[src, 0] = 0;

            var pq = new PriorityQueue<(int, int, int), int>();
            pq.Enqueue((src, 0, 0), 0);

            while (pq.Count > 0)
            {
                var top = pq.Dequeue();
                int sourceNode = top.Item1, priceTillNow = top.Item2, stops = top.Item3;

                foreach (var e in adjList[sourceNode])
                {
                    int destNode = e.Item1, currentNodePrice = e.Item2;
                    int newPrice = priceTillNow + currentNodePrice;

                    if (stops <= k && cheapestPrice[destNode, stops] > newPrice)
                    {
                        cheapestPrice[destNode, stops] = newPrice;
                        if (stops < k) pq.Enqueue((destNode, newPrice, stops + 1), newPrice);
                    }
                }
            }

            int resultPrice = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                resultPrice = Math.Min(resultPrice, cheapestPrice[dst, i]);
            }

            return resultPrice == int.MaxValue ? -1 : resultPrice;
        }
    }
}