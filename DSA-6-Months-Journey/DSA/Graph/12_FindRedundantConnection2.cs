namespace DSA.Graph
{
    public class FindRedundantConnection2
    {

        public static void Main()
        {
            int[][] edges = [[1, 2], [1, 3], [2, 3]];
            System.Console.WriteLine(string.Join(",", FindRedundantConnectionInGraph(edges)));
        }

        public static int[] FindRedundantConnectionInGraph(int[][] edges)
        {
            var adjList = new List<int>[edges.Length + 1];
            var status = new int[edges.Length + 1];

            for (int i = 0; i < adjList.Length; i++)
            {
                adjList[i] = [];
            }

            foreach (var e in edges)
            {
                adjList[e[0]].Add(e[1]);
            }

            for (int i = 1; i < adjList.Length; i++)
            {
                if (status[i] == 0)
                {
                    var cycleNodes = HasCycle(adjList, status, i);
                    if (cycleNodes.Length > 0)
                    {
                        System.Console.WriteLine("Cycle");
                        return cycleNodes;
                    }
                }
            }

            return NoCycleNodes;
        }

        public static int[] NoCycleNodes = [];

        public static int[] HasCycle(List<int>[] adjList, int[] status, int node)
        {
            status[node] = 1;

            foreach (var e in adjList[node])
            {
                if (status[e] == 1)
                {
                    return [node, e];
                }

                else if (status[e] == 0)
                {
                    var cycleNodes = HasCycle(adjList, status, e);
                    if (cycleNodes.Length > 0)
                    {
                        return cycleNodes;
                    }
                }

                if (NoCycleNodes.Length == 0)
                {
                    NoCycleNodes = [node, e];
                }
            }

            status[node] = 2;
            return [];
        }
    }
}