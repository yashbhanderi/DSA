using System.Collections;

namespace DSA.Graph
{
    public class IsGraphBipartite
    {

        public static void Main()
        {
            int[][] graph = [[], [2, 4, 6], [1, 4, 8, 9], [7, 8], [1, 2, 8, 9], [6, 9], [1, 5, 7, 8, 9], [3, 6, 9], [2, 3, 4, 6, 9], [2, 4, 5, 6, 7, 8]];
            System.Console.WriteLine(CheckGraphBipartite(graph));
        }

        public static bool CheckGraphBipartite(int[][] graph)
        {
            int n = graph.Length;
            int[] color = new int[n];
            Array.Fill(color, -1);

            Queue<int> queue = new();

            for (int i = 0; i < n; i++)
            {
                if (color[i] != -1)
                    continue;

                queue.Enqueue(i);
                color[i] = 0;

                while (queue.Count > 0)
                {
                    int parent = queue.Dequeue();
                    int childColor = 1 - color[parent];

                    foreach (int child in graph[parent])
                    {
                        if (color[child] == -1)
                        {
                            color[child] = childColor;
                            queue.Enqueue(child);
                        }
                        else if (color[child] != childColor)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}