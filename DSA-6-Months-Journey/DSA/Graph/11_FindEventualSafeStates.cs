namespace DSA.Graph
{
    public class FindEventualSafeStates
    {

        public static void Main()
        {
            int[][] graph = [[1, 2], [2, 3], [5], [0], [5], [], []];
            System.Console.WriteLine(string.Join(",", EventualSafeNodes(graph)));

        }

        public static IList<int> EventualSafeNodes(int[][] graph)
        {
            var status = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                if (status[i] == 0)
                {
                    DetectCycle(graph, status, i);
                }
            }

            var result = new List<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                if (status[i] == 2) result.Add(i);
            }

            return result;
        }

        public static bool DetectCycle(int[][] graph, int[] status, int node)
        {
            status[node] = 1;

            foreach (var e in graph[node])
            {
                if (status[e] == 1) return true;

                if (status[e] == 0 && DetectCycle(graph, status, e)) return true;
            }

            status[node] = 2;
            return false;
        }
    }
}