namespace DSA.Graph
{
    public class MakingALargeIsland
    {

        public static void Main()
        {
            int[][] grid = [[1, 1], [1, 0]];

            System.Console.WriteLine(LargestIsland(grid));
        }

        public static int LargestIsland(int[][] grid)
        {
            var N = grid.Length;
            var dsu = new DisjointSet(N * N);

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        var currentIndex = r * N + c;
                        var neighbourIndex = -1;

                        // Neighbour Index
                        if (r + 1 < N && grid[r + 1][c] == 1)
                        {
                            neighbourIndex = (r + 1) * N + c;
                            dsu.Union(currentIndex, neighbourIndex);
                        }

                        if (r - 1 >= 0 && grid[r - 1][c] == 1)
                        {
                            neighbourIndex = (r - 1) * N + c;
                            dsu.Union(currentIndex, neighbourIndex);
                        }

                        if (c + 1 < N && grid[r][c + 1] == 1)
                        {
                            neighbourIndex = r * N + (c + 1);
                            dsu.Union(currentIndex, neighbourIndex);
                        }

                        if (c - 1 >= 0 && grid[r][c - 1] == 1)
                        {
                            neighbourIndex = r * N + (c - 1);
                            dsu.Union(currentIndex, neighbourIndex);
                        }
                    }
                }
            }

            var largestIsland = int.MinValue;

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    if (grid[r][c] == 0)
                    {
                        var neighbourIndex = -1;
                        var totalArea = 1;
                        var neighbourArea = 0;
                        var visitedComponent = new HashSet<int>();

                        // Neighbour Index
                        if (r + 1 < N && grid[r + 1][c] == 1)
                        {
                            neighbourIndex = (r + 1) * N + c;
                            var parent = dsu.FindParent(neighbourIndex);
                            if (!visitedComponent.Contains(parent))
                            {
                                neighbourArea = dsu.GetSize(parent);
                                totalArea += neighbourArea;
                                visitedComponent.Add(parent);
                            }
                        }

                        if (r - 1 >= 0 && grid[r - 1][c] == 1)
                        {
                            neighbourIndex = (r - 1) * N + c;
                            var parent = dsu.FindParent(neighbourIndex);
                            if (!visitedComponent.Contains(parent))
                            {
                                neighbourArea = dsu.GetSize(parent);
                                totalArea += neighbourArea;
                                visitedComponent.Add(parent);
                            }
                        }

                        if (c + 1 < N && grid[r][c + 1] == 1)
                        {
                            neighbourIndex = r * N + (c + 1);
                            var parent = dsu.FindParent(neighbourIndex);
                            if (!visitedComponent.Contains(parent))
                            {
                                neighbourArea = dsu.GetSize(parent);
                                totalArea += neighbourArea;
                                visitedComponent.Add(parent);
                            }
                        }

                        if (c - 1 >= 0 && grid[r][c - 1] == 1)
                        {
                            neighbourIndex = r * N + (c - 1);
                            var parent = dsu.FindParent(neighbourIndex);
                            if (!visitedComponent.Contains(parent))
                            {
                                neighbourArea = dsu.GetSize(parent);
                                totalArea += neighbourArea;
                                visitedComponent.Add(parent);
                            }
                        }

                        largestIsland = Math.Max(totalArea, largestIsland);
                    }
                }
            }

            if (largestIsland == int.MinValue)
            {
                largestIsland = N * N;
            }

            return largestIsland;
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

            public int GetSize(int node)
            {
                return size[node];
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