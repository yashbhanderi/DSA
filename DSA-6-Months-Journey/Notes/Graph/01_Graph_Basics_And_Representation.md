# 01 — Graph Basics & Representation

> **Related Topics:** [DFS](./02_DFS.md) | [BFS](./03_BFS.md) | [Union Find](./09_Union_Find_DSU.md)

---

## 1. What Is a Graph?

Imagine a city map. Cities are connected by roads. You can go from one city to another using those roads.

That's a graph.

- **Cities** = **Nodes** (also called vertices)
- **Roads** = **Edges** (also called connections)

A **graph** is simply a collection of nodes where some nodes are connected to each other by edges.

### Real-World Analogies

| Real World | Graph Equivalent |
|-----------|-----------------|
| Social network (friends) | Undirected graph |
| Instagram followers | Directed graph |
| Road map | Weighted graph |
| Course prerequisites | Directed Acyclic Graph (DAG) |
| Internet links | Directed graph |
| Electrical circuits | Weighted graph |

---

## 2. Core Terminology

### Nodes and Edges
```
    0 --- 1
    |     |
    3 --- 2
```
- **Nodes:** 0, 1, 2, 3
- **Edges:** (0,1), (1,2), (2,3), (0,3)

### Directed vs Undirected

```
Undirected:               Directed:

  0 ─── 1                 0 ──► 1
  │     │                 │     │
  │     │                 ▼     ▼
  3 ─── 2                 3     2

  You can go 0→1 or 1→0   You can ONLY follow the arrows
  It's a 2-way road        It's a one-way street
```

### Weighted vs Unweighted

```
Unweighted:   0 --- 1          (all edges cost the same)
Weighted:     0 --5-- 1        (edge has a specific cost/weight)
```

### Degree
- **Degree of a node** = number of edges connected to it
- In a directed graph:
  - **In-degree** = edges coming IN
  - **Out-degree** = edges going OUT

### Path
A sequence of nodes where each consecutive pair is connected by an edge.

### Cycle
A path that starts and ends at the same node.

### Connected Graph
Every node can be reached from every other node.

### Component
A group of nodes that are all connected to each other but not to any node outside the group.

---

## 3. How to Represent a Graph in Code

There are three ways. You need to know when to use each.

### Option 1: Adjacency List ⭐ (Most Common)

```
Graph:                  Adjacency List in memory:
  0 ─── 1              ┌────────────────────┐
  │     │              │ 0 │ → [1, 3]       │
  3 ─── 2              │ 1 │ → [0, 2]       │
                       │ 2 │ → [1, 3]       │
Adjacency List:        │ 3 │ → [0, 2]       │
  0: [1, 3]            └────────────────────┘
  1: [0, 2]            Each node stores ONLY its actual neighbors
  2: [1, 3]            Space: O(V + E)
  3: [0, 2]
```

**In C#:**
```csharp
// From your code: FindIfPathExistsInGraph.cs
var graph = new Dictionary<int, List<int>>();

for (int i = 0; i < n; i++)
    graph[i] = new List<int>();

for (int i = 0; i < edges.Length; i++)
{
    graph[edges[i][0]].Add(edges[i][1]);
    graph[edges[i][1]].Add(edges[i][0]); // undirected
}
```

**When to use:** Almost always. Space efficient for sparse graphs.

**Space:** O(V + E) — V for nodes, E for edges.

---

### Option 2: Adjacency Matrix

**Visual — what the matrix looks like:**
```
Graph:          Adjacency Matrix (1 = edge exists, 0 = no edge):
  0 ─── 1
  │     │         0   1   2   3
  3 ─── 2      ┌─────────────────┐
             0 │ 0   1   0   1   │  ← 0 connects to 1 and 3
             1 │ 1   0   1   0   │  ← 1 connects to 0 and 2
             2 │ 0   1   0   1   │  ← 2 connects to 1 and 3
             3 │ 1   0   1   0   │  ← 3 connects to 0 and 2
               └─────────────────┘

Check if 0-2 connected: matrix[0][2] = 0  → No edge ✓
Check if 0-1 connected: matrix[0][1] = 1  → Edge exists ✓
Space: O(V²) — allocates V×V cells regardless of edges
```

```
Graph:
    0 -- 1
    |    |
    3 -- 2

Matrix (1 = connected, 0 = not connected):
     0  1  2  3
  0 [0, 1, 0, 1]
  1 [1, 0, 1, 0]
  2 [0, 1, 0, 1]
  3 [1, 0, 1, 0]
```

**In C#:**
```csharp
// From your code: Help.txt snippet + Problem 24 (Floyd-Warshall)
int[,] matrix = new int[n, n];
// matrix[i][j] = 1 means i is connected to j
```

**When to use:** When you need O(1) edge lookup. Used in Floyd-Warshall, dense graphs.

**Space:** O(V²) — expensive for large sparse graphs.

---

### Option 3: Edge List

Just store all edges as pairs.

```csharp
int[][] edges = [[0, 1], [1, 2], [2, 3], [0, 3]];
```

**When to use:** Bellman-Ford algorithm. When you need to iterate all edges.

---

## 4. Building an Adjacency List (Template)

This pattern appears in nearly every problem in your repository.

```csharp
// Template from Help.txt + your solutions
public static List<int>[] BuildAdjList(int n, int[][] edges)
{
    List<int>[] adj = new List<int>[n];

    for (int i = 0; i < n; i++)
        adj[i] = new List<int>();

    foreach (var e in edges)
    {
        adj[e[0]].Add(e[1]);
        adj[e[1]].Add(e[0]); // remove for directed graph
    }

    return adj;
}
```

**For weighted graphs:**
```csharp
public static List<(int node, int weight)>[] BuildWeightedAdjList(int n, int[][] edges)
{
    var adj = new List<(int, int)>[n];

    for (int i = 0; i < n; i++)
        adj[i] = new List<(int, int)>();

    foreach (var e in edges)
    {
        // e[0] = src, e[1] = dest, e[2] = weight
        adj[e[0]].Add((e[1], e[2]));
        adj[e[1]].Add((e[0], e[2])); // remove for directed
    }

    return adj;
}
```

---

## 5. Types of Graphs — Summary Table

| Type | Description | Example |
|------|-------------|---------|
| Undirected | Edges go both ways | Friendship network |
| Directed | Edges have direction | Twitter follows |
| Weighted | Edges have cost | Road distances |
| Unweighted | All edges equal cost | Social connections |
| DAG | Directed, no cycles | Course prerequisites |
| Tree | Connected, undirected, no cycles | File system |
| Bipartite | Nodes split into 2 groups | Job matching |
| Complete | Every node connects to every other | Tournament |

---

## 6. Graph Problems You Solved

### Problem 01 — Find If Path Exists In Graph

**Task:** Given n nodes and edges, check if a path exists from `source` to `destination`.

**What you did:** Built adjacency list → BFS from source → return true if destination found.

**Key insight:** Any traversal (BFS or DFS) works here. BFS is more natural for "does a path exist."

```csharp
// Core idea from your solution:
var queue = new Queue<int>();
var visited = new HashSet<int>();

queue.Enqueue(source);
visited.Add(source);

while (queue.Count > 0)
{
    var current = queue.Dequeue();
    foreach (var neighbor in graph[current])
    {
        if (neighbor == destination) return true;
        if (!visited.Contains(neighbor))
        {
            visited.Add(neighbor);
            queue.Enqueue(neighbor);
        }
    }
}
return false;
```

---

## 7. Mental Model

> Think of a graph like a metro system.
> - **Stations** = Nodes
> - **Rail connections** = Edges
> - **Adjacency list** = For each station, the list of stations it directly connects to
> - **Adjacency matrix** = A big table where you look up row=station A, col=station B to see if they're directly connected

---

## 8. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Forgetting to add both directions for undirected graph | Always `adj[a].Add(b); adj[b].Add(a);` |
| Using adjacency matrix for large sparse graphs | Use adjacency list instead |
| Not initializing the adjacency list | Always initialize all indices to empty lists |
| Forgetting to handle disconnected graphs | Always loop through all nodes, not just from node 0 |

---

## 9. Interview Recognition Checklist

```
✅ "Given n nodes and m edges..." → Build adjacency list
✅ "Check if connected..." → BFS/DFS traversal
✅ "Find all nodes reachable from X..." → BFS/DFS
✅ "Given a 2D grid..." → Treat each cell as a node
✅ "Edges have weights..." → Use adjacency list of (node, weight) pairs
✅ "Directed graph..." → One-way edges only
```

---

## 10. Cheat Sheet

```
GRAPH = Nodes + Edges

ADJACENCY LIST:
  - Space: O(V + E)
  - Best for sparse graphs (most problems)
  - Used in: DFS, BFS, Dijkstra, Topo Sort

ADJACENCY MATRIX:
  - Space: O(V²)
  - Best for dense graphs or O(1) edge lookup
  - Used in: Floyd-Warshall

EDGE LIST:
  - Just a list of [src, dest, weight]
  - Used in: Bellman-Ford, Kruskal's

BUILD TEMPLATE:
  adj[a].Add(b);
  adj[b].Add(a); // only for undirected
```
