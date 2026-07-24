# 14 — Minimum Spanning Tree (Prim's & Kruskal's)

> **Related Topics:** [Shortest Path Overview](./10_Shortest_Path.md) | [Union Find](./09_Union_Find_DSU.md) | [Dijkstra](./11_Dijkstra.md)

---

## 1. What Is a Minimum Spanning Tree?

Imagine you need to connect N cities with telephone cables. You have a list of possible cable routes, each with a cost. You want every city to be reachable from every other city, using the minimum total cable cost.

That's the **Minimum Spanning Tree (MST)** problem.

**Spanning Tree:** A tree that connects all V nodes of a graph using exactly V-1 edges.

**Minimum Spanning Tree:** A spanning tree where the total edge weight is minimized.

```
Graph:          MST:
  1               1
0─5─1           0─5─1
|×  |           |
3   4           3
0─3─2           0─3─2

Total = 5+3+4+3 = 15    Total = 5+3+3 = 11 (minimum)
```

---

## 2. Key Properties of MST

1. An MST always has exactly **V-1 edges** (for V nodes)
2. An MST is **acyclic** (adding any edge creates a cycle)
3. Multiple MSTs can exist (if some edges have equal weight)
4. Every connected graph has at least one MST

---

## 3. Two Algorithms

### Prim's Algorithm — "Grow the Tree"

**Idea:** Start from any node. Greedily add the cheapest edge that connects a new node to the existing tree.

It's like Dijkstra, but instead of tracking distance from source, you track the **minimum edge weight to connect each node to the growing tree**.

**Visual — Prim's growing tree step by step:**
```
Graph:
    4       2
  0 ─── 1 ─── 2
  |     ×     |
  6     3     1
  |     ×     |
  3 ─── 4 ─── 5
    5       4

Start from node 0:
Step 1: Tree={0}   Candidates: 0-1(4), 0-3(6)
        Pick min → 0-1 (cost=4)    Tree={0,1}

Step 2: Tree={0,1} Candidates: 0-3(6), 1-2(2), 1-4(3)
        Pick min → 1-2 (cost=2)    Tree={0,1,2}

Step 3: Tree={0,1,2} Candidates: 0-3(6), 1-4(3), 2-5(1)
        Pick min → 2-5 (cost=1)    Tree={0,1,2,5}

Step 4: ...continue picking cheapest edge to a new node...

Key: at each step, add the minimum edge touching the TREE BOUNDARY
```

### Kruskal's Algorithm — "Sort and Add"

**Idea:** Sort all edges by weight. Add an edge if it doesn't create a cycle.

Uses **DSU** to efficiently check if adding an edge would create a cycle.

**Visual — Kruskal's step by step:**
```
Sorted edges: [2-5:1, 1-2:2, 1-4:3, 0-1:4, 4-5:4, 0-3:5, 3-4:5, 0-3:6]

Step 1: Add 2-5 (cost=1) → No cycle ✓  MST: {2-5}
Step 2: Add 1-2 (cost=2) → No cycle ✓  MST: {2-5, 1-2}
Step 3: Add 1-4 (cost=3) → No cycle ✓  MST: {2-5, 1-2, 1-4}
Step 4: Add 0-1 (cost=4) → No cycle ✓  MST: {2-5, 1-2, 1-4, 0-1}
Step 5: Add 4-5 (cost=4) → CYCLE! 4→5→2→1→4 ✕  Skip
Step 6: Add 3-4 (cost=5) → No cycle ✓  MST: done (V-1=5 edges)

Total MST cost: 1+2+3+4+5 = 15

Key: DSU tells us if Find(a)==Find(b) (same component = adding edge = cycle)
```

---

## 4. Prim's Algorithm

```
Initialize:
  visited = {start}
  minCost[start] = 0, minCost[all others] = ∞
  pq = PriorityQueue, add all nodes with key = minCost
  totalCost = 0

While not all nodes visited:
  u = extract-min from pq (unvisited node with min key)
  visited.add(u)
  totalCost += minCost[u]

  For each (v, weight) in adj[u]:
    If v not visited and weight < minCost[v]:
      minCost[v] = weight  ← update key in pq
```

---

## 5. C# Implementation — Prim's (Optimized)

```csharp
// From your MinimumCostToConnectAllPoints.cs (cleaner version)
public static int Prim(int n, List<(int node, int weight)>[] adj)
{
    int[] minDist = new int[n];
    Array.Fill(minDist, int.MaxValue);
    bool[] visited = new bool[n];
    int totalCost = 0;

    minDist[0] = 0;
    var pq = new PriorityQueue<int, int>();
    pq.Enqueue(0, 0);

    while (pq.Count > 0)
    {
        var node = pq.Dequeue();

        if (visited[node]) continue;  // skip if already in MST
        visited[node] = true;
        totalCost += minDist[node];

        foreach (var (neighbor, weight) in adj[node])
        {
            if (!visited[neighbor] && weight < minDist[neighbor])
            {
                minDist[neighbor] = weight;
                pq.Enqueue(neighbor, weight);
            }
        }
    }

    return totalCost;
}
```

---

## 6. Kruskal's Algorithm

**Pseudocode:**
```
Sort all edges by weight
Initialize DSU with all nodes

For each edge (u, v, weight) in sorted order:
    If Find(u) != Find(v):   ← different components → safe to add
        Union(u, v)
        totalCost += weight
        edgeCount++

    If edgeCount == V-1: break  ← MST complete
```

**C# Implementation:**
```csharp
public static int Kruskal(int n, int[][] edges)
{
    // Sort edges by weight
    Array.Sort(edges, (a, b) => a[2] - b[2]);

    int[] parent = new int[n];
    int[] size = new int[n];
    for (int i = 0; i < n; i++) { parent[i] = i; size[i] = 1; }

    int Find(int x)
    {
        if (parent[x] != x) parent[x] = Find(parent[x]);
        return parent[x];
    }

    void Union(int a, int b)
    {
        int pa = Find(a), pb = Find(b);
        if (pa == pb) return;
        if (size[pa] < size[pb]) { parent[pa] = pb; size[pb] += size[pa]; }
        else                     { parent[pb] = pa; size[pa] += size[pb]; }
    }

    int totalCost = 0, edgesUsed = 0;

    foreach (var e in edges)
    {
        int u = e[0], v = e[1], w = e[2];

        if (Find(u) != Find(v))  // different components → no cycle
        {
            Union(u, v);
            totalCost += w;
            edgesUsed++;
        }

        if (edgesUsed == n - 1) break;  // MST complete
    }

    // If edgesUsed < n-1 → graph is disconnected, no MST possible
    return edgesUsed == n - 1 ? totalCost : -1;
}
```

**When to prefer Kruskal's over Prim's:**
- Edge list given directly (no adjacency list needed)
- Graph is sparse (E << V²)
- Cleaner to implement with DSU

**When to prefer Prim's:**
- Dense graph / complete graph (adjacency list given)
- Already using priority queue in the solution

---

## 7. Deep Dry Runs

### Problem 32 — Minimum Cost to Connect All Points ⭐

**Task:** Given 2D points, connect them all with minimum Manhattan distance cable. This is MST where edge(i,j) = |x_i - x_j| + |y_i - y_j|.

**Input:** points = [[0,0],[2,2],[3,10],[5,2],[7,0]]

This creates a complete graph (every point connects to every other) with Manhattan distances:

```
Distances (selected):
  0-1: |0-2|+|0-2| = 4
  0-2: |0-3|+|0-10| = 13
  0-3: |0-5|+|0-2| = 7
  0-4: |0-7|+|0-0| = 7
  1-2: |2-3|+|2-10| = 9
  1-3: |2-5|+|2-2| = 3
  1-4: |2-7|+|2-0| = 7
  2-3: |3-5|+|10-2| = 10
  2-4: |3-7|+|10-0| = 14
  3-4: |5-7|+|2-0| = 4
```

**Prim's (your approach — array-based without PQ):**
```
minDist = [0, ∞, ∞, ∞, ∞]  (start from 0)
visited = [F, F, F, F, F]

Round 1: currentNode = 0 (minDist[0]=0)
  visited[0] = true, totalCost += 0
  Update neighbors from 0:
    minDist[1] = min(∞, 4) = 4
    minDist[2] = min(∞, 13) = 13
    minDist[3] = min(∞, 7) = 7
    minDist[4] = min(∞, 7) = 7
  
  Find unvisited min: node 1 (dist=4)
  currentNode=1, currentCost=4

Round 2: currentNode = 1
  visited[1] = true, totalCost += 4 = 4
  Update from 1:
    minDist[2] = min(13, 9) = 9
    minDist[3] = min(7, 3) = 3 ← updated!
    minDist[4] = min(7, 7) = 7

  Find unvisited min: node 3 (dist=3)
  currentNode=3, currentCost=3

Round 3: currentNode = 3
  visited[3] = true, totalCost += 3 = 7
  Update from 3:
    minDist[2] = min(9, 10) = 9
    minDist[4] = min(7, 4) = 4 ← updated!
  
  Find unvisited min: node 4 (dist=4)

Round 4: currentNode = 4
  visited[4] = true, totalCost += 4 = 11
  Update from 4:
    minDist[2] = min(9, 14) = 9

  Find unvisited min: node 2 (dist=9)

Round 5: currentNode = 2
  visited[2] = true, totalCost += 9 = 20

Final total = 20 ✓
```

---

### Problem 26 — Minimum Cost to Connect All Houses

**Task:** Given houses as (x,y) coordinates, find MST with Manhattan distance.

This is essentially the same as Problem 32. Your implementation uses Prim's manually (without PQ — O(V²) time).

**Your array-based Prim's (O(V²)):**
```csharp
// Good for dense graphs where E = O(V²) anyway
while (currentNode != -1)
{
    visited[currentNode] = true;
    totalCost += currentCost;

    // Update minDist for all unvisited nodes
    for (int node = 0; node < N; node++)
    {
        if (!visited[node])
        {
            var cost = ManhattanDistance(currentNode, node);
            minDist[node] = Math.Min(minDist[node], cost);
        }
    }

    // Find unvisited node with minimum minDist
    currentNode = -1;
    currentCost = int.MaxValue;
    for (int i = 0; i < N; i++)
    {
        if (!visited[i] && minDist[i] < currentCost)
        {
            currentCost = minDist[i];
            currentNode = i;
        }
    }
}
```

**Why O(V²) is okay here:** The graph is complete (every point to every point), so E = O(V²). Prim's with PQ = O(E log V) = O(V² log V) which is worse! The array-based O(V²) approach is actually optimal for dense graphs.

---

## 8. Prim's vs Kruskal's

| | Prim's | Kruskal's |
|--|--|--|
| Approach | Grow tree from one node | Sort edges, add if no cycle |
| Data structure | Priority Queue | DSU |
| Best for | Dense graphs | Sparse graphs |
| Time | O(E log V) with PQ, O(V²) array | O(E log E) for sorting |
| Implementation | Like Dijkstra | Like DSU usage |

**For dense graphs** (E close to V²): Prim's with array = O(V²) is better.
**For sparse graphs** (E much less than V²): Kruskal's = O(E log E) is better.

---

## 9. Prim's vs Dijkstra — Key Difference

They look very similar! The difference is what you're minimizing:

| | Dijkstra | Prim's |
|--|--|--|
| Minimizes | Distance from SOURCE | Edge weight to join MST |
| dist[v] = | Total path weight from source | Just the edge weight from tree to v |
| Result | Shortest path tree | Minimum spanning tree |

```
In Dijkstra: newDist = dist[u] + weight(u,v)
In Prim's:   newDist = weight(u,v)  ← only the current edge!
```

---

## 10. Patterns

### Pattern 1: Connect All Points (Complete Graph MST)
```
Signal: "connect all points with minimum total distance"
Approach: Prim's with array (for dense, O(V²))
          or Kruskal's with sorted edges
```

### Pattern 2: MST with Explicit Edge List
```
Signal: given edge list, find MST
Approach: Kruskal's (sort edges, DSU for cycle check)
```

### Pattern 3: "Can we connect all?" + minimum operations
```
Signal: "minimum cables/roads to connect network"
        (#29: Number of Operations to Make Network Connected)
Approach: DSU to count components, answer = components - 1
```

---

## 11. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Confusing Prim's with Dijkstra | Prim's tracks edge weight, Dijkstra tracks path distance |
| Using Prim's PQ but not skipping visited nodes | Always check `if (visited[node]) continue` after dequeue |
| Forgetting minDist update can reduce existing value | Use `Math.Min(minDist[v], weight)` |
| For MST: adding V edges instead of V-1 | MST has exactly V-1 edges |

---

## 12. Recognition Checklist

```
If I see:
  → "connect all nodes with minimum total cost"   → MST (Prim's or Kruskal's)
  → "minimum total distance to connect all"       → MST
  → "cable/pipeline installation"                 → MST
  → "minimum cost spanning tree"                  → MST (explicit)
  → "Manhattan/Euclidean distance, connect all"   → MST on complete graph → Prim's O(V²)
```

---

## 13. Cheat Sheet

```
PRIM'S (O(E log V) with PQ, O(V²) array):
  minKey[src] = 0, minKey[others] = ∞
  visited = {}
  totalCost = 0
  
  while unvisited nodes remain:
      u = unvisited node with min minKey
      visited.add(u), totalCost += minKey[u]
      for (v, w) in adj[u]:
          if v not visited and w < minKey[v]:
              minKey[v] = w  ← NOT dist[u]+w!

KRUSKAL'S (O(E log E)):
  Sort edges by weight
  DSU initialization
  for each edge (u,v,w):
      if Find(u) != Find(v):
          Union(u,v), totalCost += w

KEY DIFFERENCE FROM DIJKSTRA:
  Prim's: newKey = edgeWeight only
  Dijkstra: newDist = distToSource + edgeWeight
```
