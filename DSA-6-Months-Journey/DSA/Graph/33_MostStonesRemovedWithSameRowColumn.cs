namespace DSA.Graph
{
    public class MostStonesRemovedWithSameRowColumn
    {

        public static void Main()
        {
            int[][] stones = [[0, 0], [0, 1], [1, 0], [1, 2], [2, 1], [2, 2]];
            System.Console.WriteLine(RemoveStones(stones));
        }

        public static int RemoveStones(int[][] stones)
        {
            var dsu = new DisjointSet(20002); // rows: 0-10000, cols: 10001-20001
            var nodes = new HashSet<int>();

            foreach (var stone in stones)
            {
                int row = stone[0];
                int col = stone[1] + 10001;

                dsu.Union(row, col);

                nodes.Add(row);
                nodes.Add(col);
            }

            var parents = new HashSet<int>();

            foreach (var node in nodes)
            {
                parents.Add(dsu.FindParent(node));
            }

            return stones.Length - parents.Count;
        }

        public class DisjointSet
        {
            private readonly int[] parent;
            private readonly int[] size;

            public DisjointSet(int n)
            {
                parent = new int[n];
                size = new int[n];

                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    size[i] = 1;
                }
            }

            public int FindParent(int node)
            {
                if (parent[node] != node)
                {
                    parent[node] = FindParent(parent[node]); // Path Compression
                }

                return parent[node];
            }

            public void Union(int a, int b)
            {
                int parentA = FindParent(a);
                int parentB = FindParent(b);

                if (parentA == parentB)
                    return;

                // Union by Size
                if (size[parentA] < size[parentB])
                {
                    parent[parentA] = parentB;
                    size[parentB] += size[parentA];
                }
                else
                {
                    parent[parentB] = parentA;
                    size[parentA] += size[parentB];
                }
            }
        }
    }
}