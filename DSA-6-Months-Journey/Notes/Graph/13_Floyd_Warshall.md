# 13 — Floyd-Warshall Algorithm

> **Related Topics:** [Shortest Path Overview](./10_Shortest_Path.md) | [Dijkstra](./11_Dijkstra.md) | [Bellman-Ford](./12_Bellman_Ford.md)

---

## 1. What Is Floyd-Warshall?

Floyd-Warshall computes the **shortest distance between EVERY pair of nodes** in a graph — called "all-pairs shortest path."

Where Dijkstra and Bellman-Ford find shortest paths FROM one source, Floyd-Warshall answers the question for every possible source simultaneously.

---

## 2. When Do You Need All-Pairs?

- "For each city, how many other cities are within distance D?"
- "Find the diameter of the graph (longest shortest path)"
- "Which node has the fewest neighbors within K distance?"

For single-source shortest path: Dijkstra (faster).
For all-pairs: Floyd-Warshall or run Dijkstra once for each node.

**When to choose Floyd-Warshall over running Dijkstra V times?**
- When the graph is DENSE (many edges): Floyd-Warshall's O(V³) beats running Dijkstra V times = O(V × (V+E)logV)
- When you need ALL pairs and the code should be simple
- When there are negative edges (Dijkstra can't handle them)
- When V is small (say V ≤ 500 for O(V³) to be feasible)

---

## 3. The Core Idea

**Dynamic Programming with intermediate nodes.**

`dist[i][j]` = shortest distance from i to j.

The key insight:
> For every pair (i, j), consider using node k as an intermediate stop. Is going i → k → j shorter than going i directly to j?

If yes, update: `dist[i][j] = min(dist[i][j], dist[i][k] + dist[k][j])`

Try every possible k (k from 0 to V-1). Try all k FIRST (outer loop), then all (i,j) pairs.

**Visual — what "intermediate node" means:**
```
Graph:                    Can we improve dist[0][2] using k=1?

  0 ─►3► 1                 Direct 0→2:   dist[0][2] = 10
  |         |                Via k=1:   dist[0][1] + dist[1][2]
  10        4                         = 3 + 4 = 7   ← SHORTER!
  |         |                Update:    dist[0][2] = 7
  ▼         ▼
  2         (weight labels)

Dist matrix BEFORE k=1:     AFTER k=1:
     0   1   2                 0   1   2
  0[ 0   3  10]             0[ 0   3   7]  ← improved!
  1[ ∞   0   4]             1[ ∞   0   4]
  2[ ∞   ∞   0]             2[ ∞   ∞   0]

Now repeat for k=2, k=3... trying every possible "stopover"
```

**Why k is the OUTER loop (not i or j)?**

This is the critical insight. When we "allow" k as an intermediate node, we must consider ALL (i,j) pairs with that intermediate. If k were inner, we might use a partially-computed dist[i][k] when computing dist[i][j], leading to incorrect results.

Think of it as: "OK, now that I've decided to allow node k to be used as a stop, let me update ALL pair distances."

---

## 5. C# Template

```csharp
// From your FloydWarshall.cs and FindCityWithSmallestNumberOfNeighbors.cs
public static void FloydWarshall(int[,] dist)
{
    int N = dist.GetLength(0);

    // Step 1: Initialize — replace -1 (no edge) with ∞
    for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
            if (i == j) dist[i, j] = 0;
            else if (dist[i, j] == -1) dist[i, j] = int.MaxValue;

    // Step 2: Floyd-Warshall
    for (int k = 0; k < N; k++)
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                if (i != k && j != k && i != j)
                    if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue)
                        dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);

    // Step 3: Replace ∞ back with -1 (unreachable)
    for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
            if (dist[i, j] == int.MaxValue)
                dist[i, j] = -1;
}
```

**Negative Cycle Detection:** After running Floyd-Warshall, check the diagonal. If `dist[i][i] < 0` for any i, a negative cycle passes through i.

---

## 6. Time & Space Complexity

| | Complexity |
|---|---|
| Time | O(V³) |
| Space | O(V²) for the dist matrix |

This is expensive for large graphs (V > 1000 becomes impractical). Use only when V is small.

---

## 7. Deep Dry Runs

### Problem 24 — Floyd-Warshall

**Input:** (3 nodes, edges: 0→1 weight 1, 0→2 weight 43, 1→2 weight 6, no edge from 2 to 0 or 2 to 1)

Initial dist:
```
     0    1    2
  0 [0,   1,  43]
  1 [1,   0,   6]
  2 [-1, -1,   0]   ← -1 means no edge
```

After initialization (replace -1 with ∞):
```
     0    1    2
  0 [0,   1,  43]
  1 [1,   0,   6]
  2 [∞,  ∞,   0]
```

**k=0 (using node 0 as intermediate):**
```
For all (i,j) pairs:
  (1,2): dist[1][0]+dist[0][2] = 1+43 = 44 > dist[1][2]=6 → no update
  (2,1): dist[2][0]+dist[0][1] = ∞+1 = ∞ > dist[2][1]=∞ → no update
  (2,0 and 0,2 excluded since i=k or j=k when k=0)

No changes.
```

**k=1 (using node 1 as intermediate):**
```
(0,2): dist[0][1]+dist[1][2] = 1+6 = 7 < dist[0][2]=43 → dist[0][2]=7 ✅
(2,0): dist[2][1]+dist[1][0] = ∞+1 = ∞ → no update

dist:
  0 [0,  1,  7]   ← 0→2 now 7 (via 1)
  1 [1,  0,  6]
  2 [∞, ∞,   0]
```

**k=2 (using node 2 as intermediate):**
```
No edges come FROM node 2 (dist[2][j] = ∞ for j≠2), so:
  dist[i][2] + dist[2][j] = dist[i][2] + ∞ = ∞ for all j≠2
No updates.

Final:
  0 [0,  1,  7]
  1 [1,  0,  6]
  2 [∞, ∞,   0]

Convert ∞ to -1:
  0 [0,  1,  7]
  1 [1,  0,  6]
  2 [-1,-1,  0]
```

---

### Problem 25 — Find City With Smallest Number of Neighbors Within Threshold

**Task:** Given n cities and weighted edges, find the city with the fewest reachable cities within distance threshold. Among ties, return the city with the largest number.

**Strategy:**
1. Run Floyd-Warshall to get all-pairs shortest distances.
2. For each city, count how many other cities are reachable within `distanceThreshold`.
3. Return the city with minimum reachable count (ties: prefer larger index).

```csharp
// From your FindCityWithSmallestNumberOfNeighbors.cs
// Initialize graph as adjacency matrix
// Build from edge list
// Run Floyd-Warshall (as above)

int city = 0, minNeighbors = int.MaxValue;
for (int i = 0; i < n; i++)
{
    int neighbors = 0;
    for (int j = 0; j < n; j++)
        if (i != j && graph[i, j] <= distanceThreshold)
            neighbors++;

    if (neighbors <= minNeighbors)  // <= handles ties (prefer larger index)
    {
        minNeighbors = neighbors;
        city = i;
    }
}

return city;
```

**Key trick:** Using `<=` (not `<`) when updating ensures that when there's a tie in `minNeighbors`, the later (larger) city index is chosen, which satisfies the problem requirement.

---

## 8. Pattern Recognition

### When to use Floyd-Warshall
- Need ALL-PAIRS shortest paths
- Small graph (V ≤ 400-500)
- Can have negative edges (but no negative cycles)
- "For each node, count reachable nodes within distance D"
- "Find the diameter of the graph"

### Building from Adjacency Matrix Input
When input is an adjacency matrix `isConnected[i][j]`:
```csharp
// Directly use as adjacency matrix for Floyd-Warshall
// Just set diagonal to 0 and missing edges to ∞
```

### Building from Edge List
```csharp
int[,] dist = new int[n, n];
// Initialize all to ∞ except diagonal (0)
for (int i = 0; i < n; i++)
    for (int j = 0; j < n; j++)
        dist[i, j] = (i == j) ? 0 : INF;

// Add edges
foreach (var edge in edges)
{
    dist[edge[0], edge[1]] = edge[2];
    dist[edge[1], edge[0]] = edge[2]; // if undirected
}

// Then run Floyd-Warshall
```

---

## 9. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Putting k as inner loop | Always: k outer, i middle, j inner |
| Not checking for ∞ before adding `dist[i][k] + dist[k][j]` | Overflow! Check `if (dist[i,k] != INF && dist[k,j] != INF)` |
| Using -1 as "no edge" and forgetting to convert | Convert -1 to ∞ before running, convert ∞ to -1 after |
| Forgetting that `dist[i][i]` should be 0 | Always initialize diagonal to 0 |
| Using for large graphs (V > 1000) | Use Dijkstra instead (per-source) |
| Not using <= when finding city with most-tie preference | Depends on problem — read carefully |

---

## 10. Recognition Checklist

```
If I see:
  → "all-pairs shortest path"                      → Floyd-Warshall
  → "for each node, count reachable nodes within D" → Floyd-Warshall + count
  → "small graph (V ≤ 500), find all distances"    → Floyd-Warshall
  → "graph diameter" (max of all shortest paths)   → Floyd-Warshall + max
  → "negative edges, all pairs"                    → Floyd-Warshall (handles neg edges)
```

---

## 11. Cheat Sheet

```
FLOYD-WARSHALL:
  dist[i][i] = 0
  dist[i][j] = edge weight (∞ if no edge)

  for k in 0..V-1:        ← intermediate node
      for i in 0..V-1:
          for j in 0..V-1:
              dist[i][j] = min(dist[i][j], dist[i][k] + dist[k][j])

COMPLEXITY: O(V³) time, O(V²) space
USE WHEN: all-pairs, small V, can have negative edges
NEGATIVE CYCLE: dist[i][i] < 0 after algorithm

KEY: k is the OUTERMOST loop! Never put it inside.
```

---

## 12. Interview Summary

**Floyd-Warshall in 2 minutes:**

Floyd-Warshall computes all-pairs shortest paths using DP. The idea: for every pair (i,j), try using each node k as an intermediate stop.

The triple nested loop: k is outer (intermediate node), i and j are inner (source and destination).

Use when: all-pairs needed, small graph (V ≤ 400-500), or negative edges present.

The critical rule: **k must be the outermost loop.** This ensures that when you use dist[i][k] and dist[k][j], both values already account for all intermediates from 0 to k-1.

Key edge cases: overflow protection when adding two large values, convert no-edge representations before running.
