namespace DSA.Graph
{
    public class SatisfiabilityOfEqualityEquations
    {

        public static void Main()
        {
            string[] equations = ["d!=f", "f==e", "a==b", "a==c"];

            System.Console.WriteLine(EquationsPossible(equations));
        }

        public static bool EquationsPossible(string[] equations)
        {
            var chars = new HashSet<int>();
            foreach (var eq in equations)
            {
                var charA = eq[0] - 'a';
                var charB = eq[3] - 'a';
                chars.Add(charA);
                chars.Add(charB);
            }

            var dsu = new DisjointSet(26);

            foreach (var eq in equations)
            {
                if (eq[1] == '=')
                {
                    var charA = eq[0] - 'a';
                    var charB = eq[3] - 'a';

                    dsu.Union(charA, charB);
                    dsu.Union(charB, charA);
                }
            }

            foreach (var eq in equations)
            {
                var charA = eq[0] - 'a';
                var charB = eq[3] - 'a';
                if (eq[1] == '=' && dsu.FindParent(charA) != dsu.FindParent(charB))
                {
                    return false;
                }
                if (eq[1] == '!' && dsu.FindParent(charA) == dsu.FindParent(charB))
                {
                    return false;
                }
            }

            return true;
        }
    }


    // public class DisjointSet
    // {
    //     private int[] parent;
    //     public DisjointSet(int N)
    //     {
    //         parent = new int[N + 1];
    //         for (int i = 0; i <= N; i++)
    //         {
    //             parent[i] = i;
    //         }
    //     }

    //     public void Union(int a, int b)
    //     {
    //         var parentA = FindParent(a);
    //         var parentB = FindParent(b);

    //         if (parentA != parentB)
    //         {
    //             parent[parentA] = parentB;
    //         }
    //     }

    //     public int FindParent(int node)
    //     {
    //         if (parent[node] == node) return node;

    //         return FindParent(parent[node]);
    //     }
    // }
}

