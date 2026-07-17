namespace DSA.Graph
{
    public class CourseSchedule2
    {
        public static void Main()
        {
            var numCourses = 3;
            int[][] prerequisites = [[1, 0], [1, 2], [0, 1]];

            System.Console.WriteLine(CanFinish(numCourses, prerequisites));
        }

        public static int[] CanFinish(int numCourses, int[][] prerequisites)
        {
            var adjList = new List<int>[numCourses];
            var inDegree = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                adjList[i] = [];
            }
            foreach (var e in prerequisites)
            {
                adjList[e[1]].Add(e[0]);
            }
            foreach (var e in adjList)
            {
                foreach (var f in e)
                {
                    inDegree[f]++;
                }
            }

            var queue = new Queue<int>();
            for (int i = 0; i < inDegree.Length; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            System.Console.WriteLine(queue.Count);

            var result = new List<int>();
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                foreach (var e in adjList[top])
                {
                    if (inDegree[e] != 0)
                    {
                        inDegree[e]--;

                        if (inDegree[e] == 0)
                        {
                            queue.Enqueue(e);
                        }
                    }
                }

                result.Add(top);
            }

            foreach (var e in inDegree)
            {
                if (e != 0) return [];
            }

            return [.. result];
        }

        /* Approach 1: DFS

        public static int[] CanFinish(int numCourses, int[][] prerequisites)
        {
            var adjList = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                adjList[i] = [];
            }
            foreach (var e in prerequisites)
            {
                adjList[e[1]].Add(e[0]);
            }

            var visited = new int[numCourses];
            var topo = new Stack<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == 0)
                {
                    if (!DFS(adjList, visited, topo, i))
                    {
                        return [];
                    }
                }
            }

            var result = new int[numCourses];
            int k = 0;
            while (topo.Count != 0)
            {
                result[k++] = topo.Pop();
            }

            return result;
        }

        public static bool DFS(List<int>[] adjList, int[] visited, Stack<int> topo, int node)
        {
            if (visited[node] == 1) return false;

            visited[node] = 1;

            foreach (var e in adjList[node])
            {
                if (visited[e] == 1) return false;

                if (visited[e] == 0 && !DFS(adjList, visited, topo, e))
                {
                    return false;
                }
            }

            visited[node] = 2;
            topo.Push(node);

            return true;
        }


        */
    }
}