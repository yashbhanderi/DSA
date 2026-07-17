// namespace DSA.Graph
// {
//     public class DisjointSet
//     {
//         private readonly int[] parent;
//         private readonly int[] size;

//         public DisjointSet(int n)
//         {
//             parent = new int[n];
//             size = new int[n];

//             for (int i = 0; i < n; i++)
//             {
//                 parent[i] = i;
//                 size[i] = 1;
//             }
//         }

//         public int FindParent(int node)
//         {
//             if (parent[node] != node)
//             {
//                 parent[node] = FindParent(parent[node]); // Path Compression
//             }

//             return parent[node];
//         }

//         public void Union(int a, int b)
//         {
//             int parentA = FindParent(a);
//             int parentB = FindParent(b);

//             if (parentA == parentB)
//                 return;

//             // Union by Size
//             if (size[parentA] < size[parentB])
//             {
//                 parent[parentA] = parentB;
//                 size[parentB] += size[parentA];
//             }
//             else
//             {
//                 parent[parentB] = parentA;
//                 size[parentA] += size[parentB];
//             }
//         }
//     }
// }

