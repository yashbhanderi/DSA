using System.Text;

namespace DSA.Graph
{
    public class SmallestStringWithSwaps
    {

        public static void Main()
        {
            var s = "dcab";
            int[][] pairs = [[0, 3], [1, 2], [0, 2]];
            System.Console.WriteLine(SmallestString(s, pairs));
        }

        public static string SmallestString(string s, IList<IList<int>> pairs)
        {
            var N = s.Length;
            var dsu = new DisjointSet(N);

            foreach (var e in pairs)
            {
                dsu.Union(e[0], e[1]);
            }

            var adjList = new Dictionary<int, List<int>>();

            for (int i = 0; i < N; i++)
            {
                var parent = dsu.FindParent(i);
                if (!adjList.ContainsKey(parent)) adjList[parent] = [];

                adjList[parent].Add(i);
            }

            var finalString = new char[N];
            foreach (var list in adjList.Values)
            {
                var originalString = new List<char>(list.Count);
                foreach (var e in list)
                {
                    originalString.Add(s[e]);
                }
                originalString.Sort();
                list.Sort();

                int k = 0;
                foreach (int e in list)
                {
                    finalString[e] = originalString[k++];
                }
            }

            return new string(finalString);
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

        // ----------------------------------------------- DFS Version

        // public static string SmallestString(string s, IList<IList<int>> pairs)
        // {
        //     var N = s.Length;
        //     var adjList = new List<int>[N];
        //     var charArray = new char[N];
        //     for (int i = 0; i < N; i++)
        //     {
        //         adjList[i] = [];
        //         charArray[i] = s[i];
        //     }

        //     foreach (var e in pairs)
        //     {
        //         adjList[e[0]].Add(e[1]);
        //         adjList[e[1]].Add(e[0]);
        //     }

        //     var visited = new bool[N];
        //     var finalString = new char[N];
        //     for (int i = 0; i < N; i++)
        //     {
        //         if (!visited[i])
        //         {
        //             var list = new List<int>();
        //             DFS(adjList, visited, list, i);

        //             var originalString = new List<char>(list.Count);
        //             foreach (var e in list)
        //             {
        //                 originalString.Add(s[e]);
        //             }
        //             originalString.Sort();
        //             list.Sort();

        //             int k = 0;
        //             foreach (int e in list)
        //             {
        //                 finalString[e] = originalString[k++];
        //             }
        //         }
        //     }

        //     return new string(finalString);
        // }

        // private static void DFS(List<int>[] adjList, bool[] visited, List<int> list, int node)
        // {
        //     if (visited[node]) return;

        //     visited[node] = true;
        //     list.Add(node);

        //     foreach (var e in adjList[node])
        //     {
        //         if (!visited[e])
        //         {
        //             DFS(adjList, visited, list, e);
        //         }
        //     }
        // }
    }
}