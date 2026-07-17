namespace DSA.Graph
{
    public class NumberOfProvinces
    {

        public static void Main()
        {
            int[][] isConnected = [[1, 1, 0], [1, 1, 0], [0, 0, 1]];

            System.Console.WriteLine(FindCircleNum(isConnected));
        }

        public static int FindCircleNum(int[][] isConnected)
        {
            var N = isConnected.Length;
            var dsu = new DisjointSet(N);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j && isConnected[i][j] == 1)
                    {
                        dsu.Union(i + 1, j + 1);
                    }
                }
            }

            var result = new HashSet<int>();
            for (int i = 1; i <= N; i++)
            {
                result.Add(dsu.FindParent(i));
            }

            return result.Count;
        }
    }


}

public class DisjointSet
{
    private int[] parent;
    public DisjointSet(int N)
    {
        parent = new int[N + 1];
        for (int i = 0; i <= N; i++)
        {
            parent[i] = i;
        }
    }

    public void Union(int a, int b)
    {
        var parentA = FindParent(a);
        var parentB = FindParent(b);

        if (parentA != parentB)
        {
            parent[parentA] = parentB;
        }
    }

    public int FindParent(int node)
    {
        if (parent[node] == node) return node;

        return FindParent(parent[node]);
    }
}