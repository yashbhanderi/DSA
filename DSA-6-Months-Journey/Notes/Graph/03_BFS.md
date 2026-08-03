# 03 — BFS: Breadth First Search

> **Related Topics:** [DFS](./02_DFS.md) | [Multi-Source BFS](./05_MultiSource_BFS.md) | [State Space BFS](./15_State_Space_BFS.md) | [Shortest Path](./10_Shortest_Path.md)

---

## 1. What Is BFS?V

Imagine dropping a stone into a pond. The ripple spreads outward in rings — first the immediate area, then the next ring, then the next.

That's BFS — **explore level by level, closest first.**

BFS visits all neighbors of the current node before going deeper. It explores the graph in "rings" radiating outward from the start.

### The Key Difference from DFS

```
Graph:
    0 -- 1 -- 3
    |
    2 -- 4

DFS order from 0: 0 → 1 → 3 → 2 → 4    (goes deep first)
BFS order from 0: 0 → 1 → 2 → 3 → 4    (level by level)
```

---

## 2. Why BFS Exists

BFS solves one critical problem that DFS cannot: **finding the shortest path in an unweighted graph.**

The reason is elegant: BFS visits nodes in order of their distance from the source. By the time you reach a node for the first time in BFS, you've taken the shortest possible path to get there.

DFS might reach the destination, but it won't guarantee it's the shortest path.

---

## 3. Core Concepts

### Queue: The Heart of BFS

BFS uses a **queue** (FIFO — First In, First Out). You add neighbors to the back, and process from the front. This automatically gives level-by-level order.

**Visual — BFS on a graph:**
```
Graph:                Level 0: Start at 0
    0                Level 1: Visit 1, 2
   / \               Level 2: Visit 3, 4, 5
  1   2              Level 3: Visit 6
 / \   \
3   4   5
        |
        6

Queue states:
  Step 1: [0]           ← dequeue 0, enqueue 1, 2
  Step 2: [1, 2]        ← dequeue 1, enqueue 3, 4
  Step 3: [2, 3, 4]     ← dequeue 2, enqueue 5
  Step 4: [3, 4, 5]     ← dequeue 3 (no children)
  Step 5: [4, 5]        ← dequeue 4 (no children)
  Step 6: [5]           ← dequeue 5, enqueue 6
  Step 7: [6]           ← dequeue 6 (no children)

Visit order: 0 → 1 → 2 → 3 → 4 → 5 → 6
Distances:   0    1    1    2    2    2    3
```

Notice: ALL nodes at distance 1 are processed BEFORE any node at distance 2. That's why BFS finds shortest paths.

### Level Tracking

To track "how many hops away" a node is, you can:

**Method 1:** Store distance alongside the node:
```csharp
var queue = new Queue<(int node, int distance)>();
queue.Enqueue((source, 0));
```

**Method 2:** Process level by level using current queue size:
```csharp
while (queue.Count > 0)
{
    int levelSize = queue.Count;  // all nodes at current level
    for (int i = 0; i < levelSize; i++)
    {
        var node = queue.Dequeue();
        // process
        // enqueue neighbors
    }
    level++;  // after processing entire level
}
```

**Method 3:** Use a temp queue (your style from RottingOranges and ZeroOneMatrix):
```csharp
while (queue.Count > 0)
{
    var tempQueue = new Queue<(int, int)>();
    while (queue.Count > 0)
    {
        // process current level → enqueue to tempQueue
    }
    // move tempQueue into queue
    minutes++;
}
```

---

## 4. Mental Model

> BFS is like a social media rumor spreading.
> - You tell 3 friends (level 1).
> - Each of them tells their friends (level 2).
> - And so on...
> 
> The people who heard it first (level 1) are closest to you. People in level 5 are 5 "degrees" away.
>
> If someone asks "who heard it first?" — that's level-1. BFS guarantees you process them FIRST.

---

## 5. BFS Algorithm

```
BFS(source):
  queue = [source]
  visited = {source}

  while queue not empty:
    node = queue.dequeue()
    process(node)

    for each neighbor of node:
      if neighbor NOT in visited:
        visited.add(neighbor)
        queue.enqueue(neighbor)
```

---

## 6. BFS Template (C#)

```csharp
// Standard BFS template
public static void BFS(List<int>[] adj, int source, int n)
{
    var queue = new Queue<int>();
    var visited = new bool[n];

    queue.Enqueue(source);
    visited[source] = true;

    while (queue.Count > 0)
    {
        var node = queue.Dequeue();
        Console.WriteLine(node); // process node

        foreach (var neighbor in adj[node])
        {
            if (!visited[neighbor])
            {
                visited[neighbor] = true;
                queue.Enqueue(neighbor);
            }
        }
    }
}
```

**Critical rule:** Mark visited when **enqueuing**, not when dequeuing. This prevents adding duplicates to the queue.

---

## 7. BFS for Shortest Path (Unweighted)

```csharp
// From your ShortestPathInUndirectedGraph.cs
public static int[] BFS_ShortestPath(List<int>[] adj, int src, int n)
{
    var dist = new int[n];
    Array.Fill(dist, int.MaxValue);

    var queue = new Queue<int>();
    dist[src] = 0;
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

    return dist;
}
```

**Why this gives shortest path:**
BFS processes level 1 (distance=1) before level 2 (distance=2) before level 3... When you first set `dist[neighbor]`, it's guaranteed to be the shortest because you haven't seen any shorter path yet.

---

## 8. Time & Space Complexity

| Case | Time | Space |
|------|------|-------|
| Generic graph | O(V + E) | O(V) for queue + visited |
| Grid (N × M) | O(N × M) | O(N × M) for queue |

**Why O(V + E)?**
- Every node enters the queue once: O(V)
- Every edge is examined twice (from each endpoint): O(E)

---

## 9. Deep Dry Runs

### Problem 01 — Find If Path Exists

**Input:** n=3, edges=[[0,1],[1,2],[2,0]], source=0, destination=2

```
Build graph: {0:[1,2], 1:[0,2], 2:[1,0]}

BFS:
  Queue: [0], Visited: {0}
  
  Step 1: Dequeue 0
    Neighbors: 1, 2
    Neighbor 1: not visited → enqueue
    Neighbor 2: == destination → RETURN TRUE ✓
```

Notice you returned early without processing the entire graph!

---

### Problem 06 — Rotting Oranges

**This is Multi-Source BFS — see [05_MultiSource_BFS.md](./05_MultiSource_BFS.md) for full details.**

**Core idea:**
- All rotten oranges start in the queue simultaneously (this is key!)
- Each BFS "level" = 1 minute
- Every minute, rottenness spreads to adjacent fresh oranges

```
Initial:
2 1 1
0 1 1
1 0 1

Fresh count: 6

Queue: [(0,0)]  ← the rotten orange at (0,0)
Level 1 (minute 1):
  Process (0,0): spread to (0,1) and (1,0)... wait (1,0)=0, skip
  Actually: (0,0) right → (0,1) fresh → make rotten, freshCount=5
  No other valid neighbors
  Queue: [(0,1)]
  minutes = 1

Level 2 (minute 2):
  Process (0,1): spread to (0,2) and (1,1)
  Queue: [(0,2), (1,1)]
  minutes = 2

...and so on
```

**Key code from your solution:**
```csharp
// Your level-by-level BFS with temp queue pattern
while (queue.Count != 0)
{
    var tempQueue = new Queue<(int, int)>();
    
    while (queue.Count != 0) // process entire current level
    {
        var (row, col) = queue.Dequeue();
        // spread to 4 neighbors, add fresh ones to tempQueue
    }

    if (tempQueue.Count > 0)
    {
        minutes++;
        // move tempQueue back to queue
    }
}
```

---

### Problem 07 — Zero-One Matrix (Multi-Source BFS)

**Task:** For each cell, find distance to nearest 0.

**Naive approach:** BFS from every 1-cell. This would be O(N²M²) — too slow.

**Clever approach:** Reverse the thinking! Start BFS from ALL zeros simultaneously. Their distance is 0. Their neighbors' distance is 1. And so on.

```
Input:
0 0 0
0 1 0
1 1 1

Initial queue: all zeros: (0,0),(0,1),(0,2),(1,0),(1,2)
visited: all zeros marked

Level 1 (distance=1):
  From (0,0): check (1,0) → already 0
  From (0,1): check (1,1) → it's 1! Set dist=1, enqueue (1,1)
  From (0,2): check (1,2) → already 0
  From (1,0): check (2,0) → it's 1! Set dist=1, enqueue (2,0)
  From (1,2): check (2,2) → it's 1! Set dist=1, enqueue (2,2)

Level 2 (distance=2):
  From (1,1): check (2,1) → it's 1! Set dist=2, enqueue (2,1)

Result:
0 0 0
0 1 0
1 2 1  ✓
```

---

## 10. Patterns

### Pattern 1: Simple BFS Traversal
**Signal:** "Visit all nodes", "find all reachable nodes"
```csharp
queue.Enqueue(start);
visited[start] = true;
while (queue.Count > 0) { dequeue, process, enqueue unvisited neighbors }
```

### Pattern 2: BFS Shortest Path
**Signal:** "Minimum moves", "shortest path", "fewest steps" (unweighted)
```csharp
dist[start] = 0;
// In BFS: dist[neighbor] = dist[current] + 1
```

### Pattern 3: Level-by-Level BFS
**Signal:** "How many rounds?", "minimum time?", "level order"
```csharp
// Use queue.Count before inner loop to track level
int levelSize = queue.Count;
for (int i = 0; i < levelSize; i++) { ... }
level++;
```

### Pattern 4: Multi-Source BFS
**Signal:** "Multiple starting points", "nearest distance from ANY source"
```csharp
// Enqueue ALL sources at start, all with distance 0
foreach (var source in sources) { queue.Enqueue(source); visited[source] = true; }
// Then run standard BFS
```

---

## 11. BFS vs DFS — When to Choose

| Situation | Use BFS | Use DFS |
|-----------|---------|---------|
| Shortest path (unweighted) | ✅ BFS | ❌ DFS doesn't guarantee shortest |
| Level-order traversal | ✅ BFS | ❌ |
| Memory matters (wide graph) | ❌ Queue can be huge | ✅ Stack depth manageable |
| Deep narrow graph | ✅ Queue stays small | ❌ Stack overflow risk |
| Detect cycle in directed graph | ❌ | ✅ DFS 3-state |
| Find all paths | ❌ | ✅ DFS with backtracking |
| Topological sort | ✅ Kahn's | ✅ DFS |
| Connected components | ✅ Both work | ✅ Both work |

---

## 12. Common Mistakes

| Mistake | Effect | Fix |
|---------|--------|-----|
| Mark visited when dequeuing (not enqueuing) | Same node enters queue multiple times, wrong distances | Mark when **enqueuing** |
| Not handling disconnected graphs | Miss entire components | Loop through all nodes |
| Using DFS for "minimum steps" | Wrong answer | Use BFS |
| Wrong level counting | Off-by-one in "number of rounds" | Be careful with the level counting pattern |
| Not checking if neighbor is valid before enqueuing | Queue pollution, IndexOutOfRange | Always validate before enqueue |

---

## 13. Recognition Checklist

```
If I see:
  → "minimum steps / moves / operations"        → BFS (unweighted)
  → "shortest path"                              → BFS (unweighted) or Dijkstra (weighted)
  → "level-by-level processing"                 → BFS
  → "spreading from multiple sources"           → Multi-Source BFS
  → "nearest distance to any X"                 → Multi-Source BFS from all X's
  → "how many rounds until done?"               → Level BFS
  → "word transformation minimum steps"         → BFS on implicit graph
  → "fill rooms with distance from nearest gate" → Multi-Source BFS (Walls and Gates, LC 286)
```

---

## 14. Cheat Sheet

```
BFS TEMPLATE:
  queue.Enqueue(source)
  visited.Add(source)
  while queue not empty:
      node = queue.Dequeue()
      process(node)
      for neighbor in adj[node]:
          if not visited:
              visited.Add(neighbor)
              queue.Enqueue(neighbor)

SHORTEST PATH:
  dist[src] = 0
  dist[neighbor] = dist[current] + 1 (first time seen)

LEVEL TRACKING:
  int levelSize = queue.Count
  for (int i = 0; i < levelSize; i++) { ... }
  level++

MULTI-SOURCE:
  Enqueue ALL sources initially
  Run standard BFS

RULE: Mark visited ON ENQUEUE, not dequeue!
```

---

## 15. Interview Summary

**BFS in 2 minutes:**

BFS uses a queue to explore nodes level by level. It guarantees the shortest path in unweighted graphs because it visits nodes in order of their distance from the source.

Key use cases:
- Shortest path (unweighted)
- Level-order traversal
- Multi-source spreading problems
- "How many steps / rounds?"

The critical implementation detail: **mark visited when you enqueue, not when you dequeue.** This prevents duplicates in the queue.

For weighted graphs, BFS doesn't work — use Dijkstra instead.
