// ============================================================
// Problem: M-Coloring Problem
// Topic: Backtracking
// ============================================================
// PROBLEM STATEMENT:
//   Given a graph and M colors, check if graph can be colored with
//   at most M colors such that no two adjacent nodes have same color.
//   Input: graph, m=3 → Output: true/false
// ============================================================

using System;
using System.Collections.Generic;

public class MColoring
{
    // APPROACH: Backtracking — Try each color for each node
    // Time: O(m^n)  |  Space: O(n)
    public bool Optimal(int n, List<int>[] graph, int m)
    {
        int[] colors = new int[n]; // 0 means uncolored
        return Solve(graph, colors, m, 0, n);
    }

    private bool Solve(List<int>[] graph, int[] colors, int m, int node, int n)
    {
        if (node == n) return true; // all nodes colored

        for (int color = 1; color <= m; color++)
        {
            if (IsSafe(graph, colors, node, color))
            {
                colors[node] = color;
                if (Solve(graph, colors, m, node + 1, n)) return true;
                colors[node] = 0; // backtrack
            }
        }

        return false; // no valid coloring found
    }

    private bool IsSafe(List<int>[] graph, int[] colors, int node, int color)
    {
        foreach (int neighbor in graph[node])
        {
            if (colors[neighbor] == color) return false;
        }
        return true;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Backtracking: Try each color (1 to m) for each node.
// - Validate: No adjacent node has the same color.
// - Time: O(m^n) worst case. Pruning helps in practice.
// - Graph coloring is NP-complete for general case.
// - Special case: m=2 = Bipartite check (BFS/DFS, polynomial time).
// ============================================================
