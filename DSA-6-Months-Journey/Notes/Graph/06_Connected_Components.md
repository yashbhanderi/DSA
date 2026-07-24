# 06 — Connected Components

> **Related Topics:** [DFS](./02_DFS.md) | [BFS](./03_BFS.md) | [Union Find](./09_Union_Find_DSU.md)

---

## 1. What Are Connected Components?

A **connected component** is a group of nodes where:
- Every node in the group can reach every other node in the group
- No node in the group can reach any node outside it

Think of it like islands in an ocean. Each island is a connected component.

```
Graph:
0 - 1    3 - 4    6
    |
    2

Components:
  Component 1: {0, 1, 2}
  Component 2: {3, 4}
  Component 3: {6}

Total components: 3
```

---

## 2. Why It Matters

Many real-world problems reduce to "count or identify connected components":
- How many isolated networks exist?
- Are these two nodes in the same group?
- How many separate islands are there?
- How many friend circles / provinces?

---

## 3. Algorithm — Finding All Components

The standard approach:

```
count = 0
for each node:
    if node is NOT visited:
        count++          ← found a new component!
        DFS/BFS(node)   ← marks entire component as visited
```

```csharp
public static int CountComponents(List<int>[] adj, int n)
{
    var visited = new bool[n];
    int count = 0;

    for (int i = 0; i < n; i++)
    {
        if (!visited[i])
        {
            count++;
            DFS(adj, visited, i);
        }
    }

    return count;
}

private static void DFS(List<int>[] adj, bool[] visited, int node)
{
    visited[node] = true;
    foreach (var neighbor in adj[node])
        if (!visited[neighbor])
            DFS(adj, visited, neighbor);
}
```

---

## 4. Problems Covered

### Problem 03 — Number of Islands

Islands = connected components of '1' cells in a grid.

```
For each '1' cell not yet visited:
    islands++
    DFS/BFS to mark entire island as visited
```

### Problem 04 — Number of Complete Connected Components

**Task:** Count how many connected components are "complete" (every node connects to every other node in the component).

**What makes a component "complete"?**
A complete graph of k nodes has exactly `k*(k-1)/2` edges.
Equivalently, the sum of all degrees in the component equals `k*(k-1)` (since each edge contributes 2 to degree sum).

```csharp
// ✅ RECOMMENDED: clean approach using closure variable
public static int CountCompleteComponents(int n, int[][] edges)
{
    var adj = new List<int>[n];
    for (int i = 0; i < n; i++) adj[i] = new List<int>();

    foreach (var e in edges)
    {
        adj[e[0]].Add(e[1]);
        adj[e[1]].Add(e[0]);
    }

    var visited = new bool[n];
    int complete = 0;

    for (int i = 0; i < n; i++)
    {
        if (visited[i])
            continue;

        int nodeCount = 0, edgeCount = 0;
        void DFS(int node)
        {
            visited[node] = true;
            nodeCount++;
            edgeCount += adj[node].Count;   // degree of this node
            foreach (var nb in adj[node])
                if (!visited[nb]) DFS(nb);
        }

        DFS(i);
        // Each edge counted twice (once from each end)
        // Complete graph: edgeCount = nodeCount * (nodeCount-1)
        if (edgeCount == nodeCount * (nodeCount - 1))
            complete++;
    }

    return complete;
}
```

**Why `edgeCount == nodeCount * (nodeCount - 1)`?**
In a complete component of k nodes:
- Total edges = k*(k-1)/2
- But each edge appears in both endpoints' adjacency lists → edgeCount (sum of all degrees) = k*(k-1)

> **Note:** Your original code passed `totalCount` by value without capturing the recursive return properly. The closure-based approach above is cleaner and correct.

### Problem 27 — Number of Provinces

**Task:** Given an adjacency matrix `isConnected`, count connected components.

**Provinces = Connected Components.**

```csharp
// ✅ Clean DFS approach (recommended over DSU for this simple case)
int provinces = 0;
var visited = new bool[N];

for (int i = 0; i < N; i++)
{
    if (!visited[i])
    {
        provinces++;
        DFS(i);
    }
}

void DFS(int node)
{
    visited[node] = true;
    for (int j = 0; j < N; j++)
        if (isConnected[node][j] == 1 && !visited[j])
            DFS(j);
}
```

---

### Graph Valid Tree (LC 261) ⭐

**Task:** Given n nodes and a list of edges, determine if the edges form a valid tree.

**A valid tree must have:**
1. Exactly **n-1 edges** (fewer = disconnected, more = cycle)
2. All nodes **connected** (1 component)

```
Valid Tree (n=5):     NOT a tree (cycle):
  0                     0
 / \                   / \
1   2                 1 - 2
|   |                     |
3   4                     3

4 nodes, 4 edges → cycle   4 nodes, 3 edges, connected → valid
```

```csharp
public static bool ValidTree(int n, int[][] edges)
{
    // Quick check: a tree has exactly n-1 edges
    if (edges.Length != n - 1) return false;

    // Build adjacency list
    var adj = new List<int>[n];
    for (int i = 0; i < n; i++) adj[i] = new List<int>();
    foreach (var e in edges)
    {
        adj[e[0]].Add(e[1]);
        adj[e[1]].Add(e[0]);
    }

    // BFS from node 0: if we visit all n nodes → connected → valid tree
    var visited = new bool[n];
    var queue = new Queue<int>();
    queue.Enqueue(0);
    visited[0] = true;
    int count = 1;

    while (queue.Count > 0)
    {
        var node = queue.Dequeue();
        foreach (var nb in adj[node])
            if (!visited[nb])
            {
                visited[nb] = true;
                queue.Enqueue(nb);
                count++;
            }
    }

    return count == n;  // true = all nodes reachable = connected
}
```

**Why n-1 edges + connected = tree?**
- n-1 edges, connected → exactly 0 cycles (a tree by definition)
- n-1 edges, not connected → impossible to connect all
- n edges, connected → exactly 1 cycle exists

---

## 5. Complete vs Connected Component

| Term | Meaning |
|------|---------|
| Connected Component | A group where all nodes can reach each other |
| Complete Component | A connected component where EVERY pair is directly connected |

```
Connected but NOT complete:    Complete:
0 - 1 - 2                      0 - 1
                                |×  |
                                2 - 3
(0 and 2 not directly linked)  (every node to every node)
```

---

## 6. DFS vs BFS vs DSU for Components

| Method | When to Use | Advantage |
|--------|-------------|-----------|
| DFS | General graphs, grids | Simple, recursive |
| BFS | When you need level info | Iterative, clear |
| DSU | Online queries ("are A and B connected?") | O(α) per query |

For simple component counting, DFS is usually the cleanest.
For dynamic connectivity (edges added over time), DSU is essential.

---

## 7. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Starting loop from i=1 instead of i=0 | 0-indexed graphs: start at 0 |
| Using adjacency matrix but iterating adjacency list | Match representation to algorithm |
| Counting a component multiple times | Only count when `!visited[i]` |
| Forgetting that isolated nodes are components too | The outer loop handles this |

---

## 8. Recognition Checklist

```
If I see:
  → "how many groups / islands / provinces / circles?" → Count components
  → "are A and B in the same group?"                   → DSU or DFS to find component
  → "merge groups that share something"                → DSU
  → "all nodes reachable from each other"              → 1 component check
  → "n nodes, n-1 edges, is it a valid tree?"          → edges.Length==n-1 && BFS visits all n nodes
```

---

## 9. Cheat Sheet

```
COMPONENT COUNTING:
  count = 0
  for each node:
      if not visited:
          count++
          DFS/BFS(node)

COMPLETE COMPONENT:
  k nodes, each must have degree (k-1)
  Total edges = k*(k-1)/2

APPROACHES:
  → DFS: simple, recursive
  → BFS: iterative
  → DSU: best for dynamic/query problems
```
