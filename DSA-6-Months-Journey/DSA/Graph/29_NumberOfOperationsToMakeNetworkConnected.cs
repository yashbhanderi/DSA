namespace DSA.Graph
{
    public class NumberOfOperationsToMakeNetworkConnected
    {

        public static void Main()
        {
            var n = 6;
            int[][] connections = [[0, 1], [0, 2], [0, 3], [1, 2], [1, 3]];

            System.Console.WriteLine(MakeConnected(n, connections));
        }

        public static int MakeConnected(int n, int[][] connections)
        {
            var dsu = new DisjointSet(n);
            var cables = 0;

            for (int i = 0; i < connections.Length; i++)
            {
                if (dsu.FindParent(connections[i][0]) == dsu.FindParent(connections[i][1])) cables++;
                dsu.Union(connections[i][0], connections[i][1]);
            }

            var parents = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                parents.Add(dsu.FindParent(i));
            }

            System.Console.WriteLine(string.Join(",", parents));

            return (parents.Count - 1) <= cables ? (parents.Count - 1) : -1;
        }
    }

    // public class DisjointSet
    // {
    //     private int[] parent;
    //     public DisjointSet(int N)
    //     {
    //         parent = new int[N + 1];
    //         for (int i = 0; i <= N; i++)
    //         {
    //             parent[i] = i;
    //         }
    //     }

    //     public void Union(int a, int b)
    //     {
    //         var parentA = FindParent(a);
    //         var parentB = FindParent(b);

    //         if (parentA != parentB)
    //         {
    //             parent[parentA] = parentB;
    //         }
    //     }

    //     public int FindParent(int node)
    //     {
    //         if (parent[node] == node) return node;

    //         return FindParent(parent[node]);
    //     }
    // }
}