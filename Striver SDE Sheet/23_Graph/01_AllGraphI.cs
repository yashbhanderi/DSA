// ============================================================
// Graph Part I — 12 problems
// Topic: Graphs
// ============================================================
// Problems: Clone Graph, DFS, BFS, Cycle Detection (Undirected + Directed),
//           Topological Sort (BFS Kahn's + DFS), Number of Islands,
//           Bipartite Graph, SCC (Kosaraju), Dijkstra, Bellman-Ford
// ============================================================

using System;
using System.Collections.Generic;

// --- P1: Clone Graph ---
public class CloneGraph
{
    public Dictionary<int, List<int>> Clone(Dictionary<int, List<int>> graph)
    {
        var visited = new Dictionary<int, List<int>>();
        foreach (var node in graph) visited[node.Key] = new List<int>(node.Value);
        return visited;
        // For OOP Node clone: use HashMap old→new, DFS/BFS to clone neighbors.
    }
}

// --- P2-3: DFS and BFS ---
public class GraphTraversals
{
    public List<int> DFS(int start, List<int>[] adj, int n)
    {
        var result = new List<int>();
        bool[] visited = new bool[n];
        DFSHelper(start, adj, visited, result);
        return result;
    }
    private void DFSHelper(int node, List<int>[] adj, bool[] visited, List<int> result)
    {
        visited[node] = true;
        result.Add(node);
        foreach (int neighbor in adj[node])
            if (!visited[neighbor]) DFSHelper(neighbor, adj, visited, result);
    }

    public List<int> BFS(int start, List<int>[] adj, int n)
    {
        var result = new List<int>();
        bool[] visited = new bool[n];
        var queue = new Queue<int>();
        visited[start] = true;
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            result.Add(node);
            foreach (int neighbor in adj[node])
                if (!visited[neighbor]) { visited[neighbor] = true; queue.Enqueue(neighbor); }
        }
        return result;
    }
}

// --- P4: Detect Cycle in Undirected Graph (BFS/DFS) ---
public class CycleUndirected
{
    public bool HasCycle(int n, List<int>[] adj)
    {
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
            if (!visited[i] && DFS(i, -1, adj, visited)) return true;
        return false;
    }
    private bool DFS(int node, int parent, List<int>[] adj, bool[] visited)
    {
        visited[node] = true;
        foreach (int neighbor in adj[node])
        {
            if (!visited[neighbor]) { if (DFS(neighbor, node, adj, visited)) return true; }
            else if (neighbor != parent) return true; // visited & not parent → cycle
        }
        return false;
    }
}

// --- P5: Detect Cycle in Directed Graph (DFS) ---
public class CycleDirected
{
    public bool HasCycle(int n, List<int>[] adj)
    {
        bool[] visited = new bool[n], pathVisited = new bool[n];
        for (int i = 0; i < n; i++)
            if (!visited[i] && DFS(i, adj, visited, pathVisited)) return true;
        return false;
    }
    private bool DFS(int node, List<int>[] adj, bool[] visited, bool[] pathVisited)
    {
        visited[node] = pathVisited[node] = true;
        foreach (int neighbor in adj[node])
        {
            if (!visited[neighbor] && DFS(neighbor, adj, visited, pathVisited)) return true;
            if (pathVisited[neighbor]) return true; // back edge → cycle
        }
        pathVisited[node] = false; // backtrack
        return false;
    }
}

// --- P6-7: Topological Sort (Kahn's BFS + DFS) ---
public class TopologicalSort
{
    // Kahn's Algorithm (BFS): Process nodes with indegree 0. O(V+E).
    public List<int> KahnBFS(int n, List<int>[] adj)
    {
        int[] indegree = new int[n];
        foreach (var edges in adj) foreach (int v in edges) indegree[v]++;
        var queue = new Queue<int>();
        for (int i = 0; i < n; i++) if (indegree[i] == 0) queue.Enqueue(i);
        var result = new List<int>();
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            result.Add(node);
            foreach (int neighbor in adj[node])
                if (--indegree[neighbor] == 0) queue.Enqueue(neighbor);
        }
        return result; // If result.Count != n → cycle exists
    }
}

// --- P8: Number of Islands ---
public class NumberOfIslands
{
    public int Optimal(char[][] grid)
    {
        int count = 0, m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (grid[i][j] == '1') { count++; DFS(grid, i, j, m, n); }
        return count;
    }
    private void DFS(char[][] grid, int r, int c, int m, int n)
    {
        if (r < 0 || r >= m || c < 0 || c >= n || grid[r][c] != '1') return;
        grid[r][c] = '0'; // mark visited
        DFS(grid, r + 1, c, m, n); DFS(grid, r - 1, c, m, n);
        DFS(grid, r, c + 1, m, n); DFS(grid, r, c - 1, m, n);
    }
}

// --- P9: Bipartite Graph --- BFS/DFS coloring with 2 colors.
// --- P10: Kosaraju's SCC --- Step 1: Fill order (DFS). Step 2: Transpose. Step 3: DFS on transpose.
// --- P11: Dijkstra's --- Priority queue + relaxation. O((V+E) log V).

public class Dijkstra
{
    public int[] ShortestPath(int n, List<(int to, int wt)>[] adj, int src)
    {
        int[] dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        dist[src] = 0;
        var pq = new PriorityQueue<int, int>(); // node, distance
        pq.Enqueue(src, 0);
        while (pq.Count > 0)
        {
            pq.TryDequeue(out int node, out int d);
            if (d > dist[node]) continue;
            foreach (var (to, wt) in adj[node])
                if (dist[node] + wt < dist[to])
                { dist[to] = dist[node] + wt; pq.Enqueue(to, dist[to]); }
        }
        return dist;
    }
}

// --- P12: Bellman-Ford --- V-1 relaxation passes. Detects negative cycles.
public class BellmanFord
{
    public int[] ShortestPath(int n, int[][] edges, int src)
    {
        int[] dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        dist[src] = 0;
        for (int i = 0; i < n - 1; i++)
            foreach (var e in edges)
                if (dist[e[0]] != int.MaxValue && dist[e[0]] + e[2] < dist[e[1]])
                    dist[e[1]] = dist[e[0]] + e[2];
        // Check negative cycle: one more pass
        foreach (var e in edges)
            if (dist[e[0]] != int.MaxValue && dist[e[0]] + e[2] < dist[e[1]])
                return null; // negative cycle
        return dist;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - DFS: Stack/recursion. BFS: Queue.
// - Undirected cycle: visited neighbor ≠ parent → cycle.
// - Directed cycle: pathVisited (in current DFS path) → back edge → cycle.
// - TopoSort (Kahn's): BFS with indegree. Nodes with indeg 0 → queue.
// - Islands: DFS/BFS flood fill. Count connected components of '1'.
// - Dijkstra: Min-heap + relaxation. NO negative weights. O((V+E) log V).
// - Bellman-Ford: V-1 passes of edge relaxation. Handles negative weights. O(VE).
// - Kosaraju's SCC: Finish order → transpose → DFS. O(V+E).
// ============================================================
