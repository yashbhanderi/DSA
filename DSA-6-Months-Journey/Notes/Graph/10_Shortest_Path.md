# 10 — Shortest Path Algorithms (Overview)

> **Related Topics:** [BFS](./03_BFS.md) | [Dijkstra](./11_Dijkstra.md) | [Bellman-Ford](./12_Bellman_Ford.md) | [Floyd-Warshall](./13_Floyd_Warshall.md) | [Topological Sort](./08_Topological_Sort.md)

---

## 1. The Big Picture

Finding the shortest path is one of the most common graph problems. But there are MANY algorithms, each designed for a specific situation. Choosing the wrong one means wrong answers or TLE.

Let this be your decision flowchart.

---

## 2. Algorithm Selection Guide

```
Does the graph have weights?
│
├── NO (all edges = 1)
│   └── BFS → O(V+E), guaranteed shortest path
│
└── YES (weighted graph)
    │
    ├── Weights are ONLY 0 or 1?
    │   └── 0-1 BFS (Deque) → O(V+E)  ← faster than Dijkstra!
    │
    ├── Is it a DAG (no cycles)?
    │   └── Topological Sort + Relaxation → O(V+E)
    │
    ├── Are there NEGATIVE weights?
    │   │
    │   ├── YES
    │   │   ├── Need all-pairs? → Floyd-Warshall → O(V³)
    │   │   └── Single source? → Bellman-Ford → O(VE)
    │   │       ├── Also detects NEGATIVE CYCLES
    │   │
    │   └── NO (all weights ≥ 0)
    │       ├── Single source to all nodes? → Dijkstra → O((V+E)logV)
    │       └── All pairs? → Floyd-Warshall or run Dijkstra V times
```

---

## 3. Quick Comparison Table

| Algorithm | Graph Type | Negative Weights? | Time | Space | Use Case |
|-----------|------------|-------------------|------|-------|----------|
| BFS | Unweighted | N/A | O(V+E) | O(V) | Fewest hops |
| **0-1 BFS** | 0 or 1 weights only | No | **O(V+E)** | O(V) | Grid/graph with 0 or 1 cost edges |
| BFS in DAG (Topo) | DAG, weighted | Yes | O(V+E) | O(V) | DAG shortest path |
| Dijkstra | Any, weighted | No | O((V+E)logV) | O(V) | Most common |
| Bellman-Ford | Any, weighted | **Yes** | O(VE) | O(V) | Negative edges/cycles |
| Floyd-Warshall | Any, weighted | Yes | O(V³) | O(V²) | All-pairs |

---

## 4. BFS for Shortest Path (Unweighted)

**When to use:** No weights, or all weights = 1. Minimum number of hops/steps.

```csharp
// From ShortestPathInUndirectedGraph.cs
int[] dist = new int[V];
Array.Fill(dist, int.MaxValue);
dist[src] = 0;

var queue = new Queue<int>();
queue.Enqueue(src);

while (queue.Count > 0)
{
    var node = queue.Dequeue();
    foreach (var neighbor in adj[node])
    {
        if (dist[neighbor] == int.MaxValue) // not visited
        {
            dist[neighbor] = dist[node] + 1;
            queue.Enqueue(neighbor);
        }
    }
}
```

**Why it works:** BFS processes nodes in order of their hop count. The first time you reach a node = minimum hops.

---

## 5. Shortest Path in a DAG (Topo + Relaxation)

**When to use:** The graph is a DAG (directed, no cycles). Can have any weights including negative.

**Why DAGs are special:** In a DAG, when we process nodes in topological order, all predecessors of a node are processed before the node itself. So when we update distances for a node's neighbors, we're using finalized distances.

```csharp
// From ShortestPathInDAG.cs
// Step 1: Get topo order via DFS
void DFS(node):
    visited[node] = 1
    for neighbor in adj[node]:
        if not visited[neighbor]: DFS(neighbor)
    stack.Push(node)  // push after done

// Step 2: Initialize distances
dist[src] = 0, dist[everything else] = ∞

// Step 3: Process in topo order
while (stack not empty):
    node = stack.Pop()
    if dist[node] == ∞: continue
    for (neighbor, weight) in adj[node]:
        if dist[node] + weight < dist[neighbor]:
            dist[neighbor] = dist[node] + weight
```

**Time:** O(V+E) — much faster than Dijkstra for DAGs!

---

## 6. The "Relaxation" Concept

All shortest path algorithms use a concept called **relaxation**. It's the core operation:

```
If dist[u] + weight(u,v) < dist[v]:
    dist[v] = dist[u] + weight(u,v)  // "relax" edge (u,v)
```

**Plain English:** "Can I reach v cheaper by going through u first?"

**Visual — what relaxation does:**
```
Before relaxation:          After relaxing edge u→v (w=4):
                                              
  src ──10──► u               src ──10──► u  
              │                             │
              │ 4                           │ 4
              ▼                             ▼
  src ──20──► v      →        src ──14──► v
  
  dist[v] = 20 (via direct   dist[v] = 10+4 = 14 (via u)
  edge from src)              IMPROVED! Relax it.

dist[u]=10, weight(u,v)=4    10+4=14 < 20 → update dist[v]=14
```

The difference between algorithms is WHEN and HOW they relax:
- **Dijkstra:** relax only from the globally nearest node
- **Bellman-Ford:** relax ALL edges V-1 times
- **DAG relaxation:** relax in topological order (guarantees predecessors done first)

The algorithms differ in:
- What ORDER they relax edges
- How many times they relax each edge
- Whether they handle negative weights

---

## 7. Why Greedy Order Matters

**Dijkstra works because** it always processes the globally closest unvisited node. This greedy choice guarantees that when you set `dist[u]`, it's already the shortest possible.

**Dijkstra FAILS with negative edges because:** A negative edge might offer a shorter path through a node you've already "finalized." The greedy assumption breaks.

```
Example:
  0 --5-- 1 --(-10)-- 2
  0 --1-- 2

Dijkstra:
  Process 0: dist[1]=5, dist[2]=1
  Greedy: process node 2 (dist=1) → finalize dist[2]=1
  But actual shortest: 0→1→2 = 5-10 = -5 ← missed!
```

---

## 8. Problems Solved — Overview

| Problem | Algorithm | Key Insight |
|---------|-----------|-------------|
| #16 Undirected Graph Shortest Path | BFS | No weights = BFS |
| #15 Shortest Path in DAG | Topo Sort + Relax | DAG → topo order |
| #17 Network Delay Time | Dijkstra | Min time for signal |
| #18 Print Shortest Path | Dijkstra + Parent | Track parent array |
| #19 Shortest Path Binary Maze | BFS (or Dijkstra) | Grid, uniform cost |
| #20 Path With Min Effort | Dijkstra (max edge) | Custom "distance" |
| #21 Cheapest Flights K Stops | Modified Dijkstra | State includes stops |
| #22 Ways to Arrive at Destination | Dijkstra + DP | Count paths |
| #23 Bellman-Ford | Bellman-Ford | Negative edges |
| #24 Floyd-Warshall | Floyd-Warshall | All-pairs |
| #25 City with Fewest Neighbors | Floyd-Warshall | All-pairs + threshold |

---

## 9. The Parent Array Trick (Printing the Path)

To print the ACTUAL shortest path (not just the distance):

```csharp
// From PrintShortestPath.cs
int[] parent = new int[n];
parent[src] = src;  // source is its own parent

// During Dijkstra:
if (newDist < dist[neighbor])
{
    dist[neighbor] = newDist;
    parent[neighbor] = current;  // track where we came from
}

// Reconstruct path (traverse backwards):
var path = new List<int>();
int node = destination;
path.Add(node);

while (parent[node] != node)
{
    path.Add(parent[node]);
    node = parent[node];
}

path.Reverse();
// path is now source to destination
```

---

## 10. Common Mistakes Across All Shortest Path Algorithms

| Mistake | Fix |
|---------|-----|
| Using BFS on weighted graph | Use Dijkstra instead |
| Using Dijkstra with negative edges | Use Bellman-Ford |
| Not initializing distances to ∞ | Always `Array.Fill(dist, int.MaxValue)` |
| Integer overflow when adding: `int.MaxValue + anything` | Check for `== int.MaxValue` before adding, or use `long` |
| Off-by-one with 1-indexed nodes | Be careful: some problems use 1 to n indexing |
| Processing already-finalized nodes in Dijkstra | Check `if (distFromPQ > dist[node]) continue;` |

---

## 11. Recognition Checklist

```
If I see:
  → "shortest path", no weights           → BFS
  → "weights are 0 or 1 only"             → 0-1 BFS (deque)
  → "shortest path", weighted, no neg     → Dijkstra
  → "shortest path", negative weights     → Bellman-Ford
  → "all-pairs shortest path"             → Floyd-Warshall
  → "shortest path in DAG"               → Topo Sort + Relax
  → "minimum effort / maximum edge"      → Dijkstra with custom dist function
  → "at most K stops/hops"               → Modified Dijkstra with state (node, stops)
  → "count shortest paths"               → Dijkstra + ways[] array
  → "print the actual path"              → Any algorithm + parent array
  → "negative cycle detection"           → Bellman-Ford (Nth iteration check)
```

---

## 12. 0-1 BFS — Deque-Based Shortest Path ⭐

**When:** Edge weights are ONLY 0 or 1. Faster than Dijkstra (O(V+E) vs O((V+E)logV)).

**Why it works:** Use a `Deque` (double-ended queue).
- Edge weight = 0: push neighbor to the **FRONT** (same cost, process first)
- Edge weight = 1: push neighbor to the **BACK** (costs more, process later)

This maintains the BFS property: nodes are processed in order of increasing distance — without a heap!

**Template:**
```csharp
public static int[] ZeroOneBFS(List<(int node, int weight)>[] adj, int src, int n)
{
    int[] dist = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[src] = 0;

    var deque = new LinkedList<int>();  // acts as deque
    deque.AddFirst(src);

    while (deque.Count > 0)
    {
        var node = deque.First.Value;
        deque.RemoveFirst();

        foreach (var (neighbor, weight) in adj[node])
        {
            int newDist = dist[node] + weight;
            if (newDist < dist[neighbor])
            {
                dist[neighbor] = newDist;
                if (weight == 0)
                    deque.AddFirst(neighbor);   // 0-cost: front
                else
                    deque.AddLast(neighbor);    // 1-cost: back
            }
        }
    }
    return dist;
}
```

**Classic 0-1 BFS problem type:** Grid where moving to certain cells costs 0 and others cost 1. For example:
- "Minimum number of obstacles to remove" (cost 0 for open, cost 1 for obstacle)
- "Minimum flips to reach destination" (cost 0 for same direction, cost 1 for flip)

**Key insight:** 0-1 BFS is a special case of Dijkstra where the priority queue degenerates into a deque because only two distinct costs exist.
