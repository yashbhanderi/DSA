// ============================================================
// Graph Part II — 6 problems
// Topic: Graphs Part II
// ============================================================
// Problems: Floyd Warshall, Prim's MST, Kruskal's MST,
//           Distinct Islands, Bipartite BFS, Bridges (Tarjan's)
// ============================================================

using System;
using System.Collections.Generic;

// --- P1: Floyd Warshall --- All-pairs shortest path. O(V^3).
public class FloydWarshall
{
    public void Solve(int[][] dist, int n)
    {
        for (int k = 0; k < n; k++)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (dist[i][k] != int.MaxValue && dist[k][j] != int.MaxValue)
                        dist[i][j] = Math.Min(dist[i][j], dist[i][k] + dist[k][j]);
    }
}

// --- P2: Prim's MST --- Greedy. Min-heap of edges. O((V+E) log V).
public class PrimsMST
{
    public int Solve(int n, List<(int to, int wt)>[] adj)
    {
        bool[] inMST = new bool[n];
        var pq = new PriorityQueue<(int node, int wt), int>();
        pq.Enqueue((0, 0), 0);
        int mstWeight = 0;
        while (pq.Count > 0)
        {
            var (node, wt) = pq.Dequeue();
            if (inMST[node]) continue;
            inMST[node] = true;
            mstWeight += wt;
            foreach (var (to, w) in adj[node])
                if (!inMST[to]) pq.Enqueue((to, w), w);
        }
        return mstWeight;
    }
}

// --- P3: Kruskal's MST --- Sort edges by weight. Union-Find. O(E log E).
public class KruskalMST
{
    private int[] parent, rank;

    public int Solve(int n, int[][] edges)
    {
        parent = new int[n]; rank = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;
        Array.Sort(edges, (a, b) => a[2].CompareTo(b[2])); // sort by weight

        int mstWeight = 0, edgesUsed = 0;
        foreach (var e in edges)
        {
            if (Find(e[0]) != Find(e[1]))
            {
                Union(e[0], e[1]);
                mstWeight += e[2];
                if (++edgesUsed == n - 1) break;
            }
        }
        return mstWeight;
    }

    private int Find(int x) => parent[x] == x ? x : parent[x] = Find(parent[x]);
    private void Union(int a, int b)
    {
        int pa = Find(a), pb = Find(b);
        if (rank[pa] < rank[pb]) parent[pa] = pb;
        else if (rank[pa] > rank[pb]) parent[pb] = pa;
        else { parent[pb] = pa; rank[pa]++; }
    }
}

// --- P4: Bridges in Graph (Tarjan's Algorithm) ---
public class Bridges
{
    private int timer = 0;
    public List<(int, int)> FindBridges(int n, List<int>[] adj)
    {
        int[] disc = new int[n], low = new int[n];
        bool[] visited = new bool[n];
        var bridges = new List<(int, int)>();
        Array.Fill(disc, -1);
        for (int i = 0; i < n; i++)
            if (!visited[i]) DFS(i, -1, adj, disc, low, visited, bridges);
        return bridges;
    }
    private void DFS(int u, int parent, List<int>[] adj, int[] disc, int[] low, bool[] visited, List<(int, int)> bridges)
    {
        visited[u] = true;
        disc[u] = low[u] = timer++;
        foreach (int v in adj[u])
        {
            if (v == parent) continue;
            if (!visited[v])
            {
                DFS(v, u, adj, disc, low, visited, bridges);
                low[u] = Math.Min(low[u], low[v]);
                if (low[v] > disc[u]) bridges.Add((u, v)); // bridge found
            }
            else low[u] = Math.Min(low[u], disc[v]);
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Floyd Warshall: 3 nested loops k→i→j. dist[i][j] = min(dist[i][j], dist[i][k]+dist[k][j]). O(V^3).
// - Prim's: Start from any node. Min-heap of (weight, node). Add cheapest edge to MST. O((V+E)logV).
// - Kruskal's: Sort all edges. Union-Find to avoid cycles. Pick cheapest edge that connects new components. O(ElogE).
// - Tarjan's Bridges: disc[] and low[]. Edge (u,v) is bridge if low[v] > disc[u].
// - Prim's vs Kruskal's: Prim's for dense graphs, Kruskal's for sparse. Both find MST.
// ============================================================
