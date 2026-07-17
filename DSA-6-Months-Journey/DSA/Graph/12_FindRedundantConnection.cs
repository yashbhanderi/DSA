namespace DSA.Graph
{
    public class FindRedundantConnection
    {

        public static void Main()
        {
            int[][] edges = [[2, 7], [7, 8], [3, 6], [2, 5], [6, 8], [4, 8], [2, 8], [1, 8], [7, 10], [3, 9]];
            System.Console.WriteLine(string.Join(",", FindRedundantConnectionInGraph(edges)));
        }

        public static int[] FindRedundantConnectionInGraph(int[][] edges)
        {
            var dsu = new DSU(edges.Length);

            for (int i = 0; i < edges.Length; i++)
            {
                var node1 = edges[i][0];
                var node2 = edges[i][1];

                var parentNode1 = dsu.Find(node1);
                var parentNode2 = dsu.Find(node2);

                if (parentNode1 != parentNode2)
                {
                    dsu.Union(node1, node2);
                }
                else
                {
                    return edges[i];
                }
            }

            return [];
        }
    }

    public class DSU
    {
        int[] parent;

        public DSU(int n)
        {
            parent = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] == x)
                return x;

            return Find(parent[x]);
        }

        public void Union(int a, int b)
        {
            int pa = Find(a);
            int pb = Find(b);

            if (pa != pb)
            {
                parent[pb] = pa;
            }
        }
    }

}