namespace DSA.Graph
{
    public class SwimInRisingWater
    {

        public static void Main()
        {
            int[][] grid = [[0, 2], [1, 3]];

            System.Console.WriteLine(SwimInWater(grid));
        }

        public static int SwimInWater(int[][] grid)
        {
            var N = grid.Length;
            var time = 0;
            (int, int)[] position = new (int, int)[N * N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    position[grid[i][j]] = (i, j);
                }
            }

            var dsu = new DisjointSet(N * N);

            while (time < N * N)
            {
                var currentIndex = position[time];
                var i = currentIndex.Item1;
                var j = currentIndex.Item2;

                // Right
                if (j + 1 < N && grid[i][j + 1] <= time)
                {
                    dsu.Union(grid[i][j], grid[i][j + 1]);
                }

                // Down
                if (i + 1 < N && grid[i + 1][j] <= time)
                {
                    dsu.Union(grid[i][j], grid[i + 1][j]);
                }

                // Up
                if (i - 1 >= 0 && grid[i - 1][j] <= time)
                {
                    dsu.Union(grid[i][j], grid[i - 1][j]);
                }

                // Left
                if (j - 1 >= 0 && grid[i][j - 1] <= time)
                {
                    dsu.Union(grid[i][j], grid[i][j - 1]);
                }

                if (dsu.FindParent(grid[0][0]) == dsu.FindParent(grid[N - 1][N - 1]))
                {
                    return time;
                }

                time++;
            }

            return time;
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