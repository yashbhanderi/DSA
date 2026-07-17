public class MinimumHeightTrees
{

    public static void Main()
    {
        int n = 4;
        int[][] edges = [[1, 0], [1, 2], [1, 3]];

        System.Console.WriteLine(string.Join(",", FindMinHeightTrees(n, edges)));
    }

    public static IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        var adjList = new List<int>[n];
        var degree = new int[n];
        for (int i = 0; i < n; i++)
        {
            adjList[i] = [];
        }
        foreach (var e in edges)
        {
            adjList[e[1]].Add(e[0]);
            adjList[e[0]].Add(e[1]);

            degree[e[0]]++;
            degree[e[1]]++;
        }

        var queue = new Queue<int>();
        for (int i = 0; i < degree.Length; i++)
        {
            if (degree[i] == 1)
            {
                queue.Enqueue(i);
            }
        }

        var result = new List<int>();
        var totalNodes = n;
        while (totalNodes > 2)
        {
            int leavesCount = queue.Count;

            totalNodes -= leavesCount;

            for (int i = 0; i < leavesCount; i++)
            {
                int leaf = queue.Dequeue();

                foreach (var neighbor in adjList[leaf])
                {
                    degree[neighbor]--;

                    if (degree[neighbor] == 1)
                        queue.Enqueue(neighbor);
                }
            }
        }

        return [.. queue];
    }
}