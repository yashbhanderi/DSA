namespace DSA.Graph
{
    public class CourseSchedule
    {
        public static void Main()
        {
            var numCourses = 2;
            int[][] prerequisites = [[1, 0]];

            // System.Console.WriteLine(CanFinish(numCourses, prerequisites));
        }

        /* Approach 1: Plain DFS 
        
        Approach 1: Plain DFS
        

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var adjList = new List<int>[numCourses];
            var status = new List<int>(numCourses);

            foreach (var e in prerequisites)
            {
                adjList[e[1]].Add(e[0]);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (status[i] == 0 && HasCycle(adjList, status, i))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasCycle(List<int>[] adjList, List<int> status, int node)
        {
            status[node] = 1;

            foreach (var nb in adjList[node])
            {
                if (status[nb] == 1) return true;

                if (status[nb] == 0 && HasCycle(adjList, status, nb))
                {
                    return true;
                }
            }

            status[node] = 2;
            return false;
        }
    
        */
    }
}