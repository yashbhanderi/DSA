namespace DSA.Graph
{
    public class AccountsMerge
    {

        public static void Main()
        {
            string[][] accounts = [["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["John", "johnsmith@mail.com", "john00@mail.com"], ["Mary", "mary@mail.com"], ["John", "johnnybravo@mail.com"]];

            var result = AccountsMergeList(accounts);
            foreach (var e in result)
            {
                foreach (var ele in e)
                {
                    System.Console.WriteLine(ele);
                }
            }
        }

        public static IList<IList<string>> AccountsMergeList(IList<IList<string>> accounts)
        {
            var emailIdMapping = new Dictionary<string, int>();
            var emailPersonMapping = new Dictionary<string, string>();
            int id = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                for (int j = 1; j < accounts[i].Count; j++)
                {
                    var email = accounts[i][j];
                    var name = accounts[i][0];

                    if (!emailIdMapping.ContainsKey(email))
                    {
                        emailIdMapping[email] = id++;
                    }
                    emailPersonMapping[email] = name;
                }
            }
            var dsu = new DisjointCharSet(id);

            for (int i = 0; i < accounts.Count; i++)
            {
                for (int j = 2; j < accounts[i].Count; j++)
                {
                    dsu.Union(emailIdMapping[accounts[i][j]], emailIdMapping[accounts[i][j - 1]]);
                }
            }

            var groups = new Dictionary<int, List<string>>();
            foreach (var e in emailIdMapping.Keys)
            {
                var parent = dsu.FindParent(emailIdMapping[e]);
                if (!groups.ContainsKey(parent)) groups[parent] = [];

                groups[parent].Add(e);
            }

            var response = new List<IList<string>>();

            foreach (var e in groups.Values)
            {
                e.Sort(StringComparer.Ordinal);
                var person = emailPersonMapping[e[0]];

                var list = new List<string>();
                list.Add(person);
                list.AddRange(e);

                response.Add(list);
            }

            return response;
        }

        private class DisjointCharSet
        {
            private readonly int[] parent;
            private readonly int[] size;

            public DisjointCharSet(int n)
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