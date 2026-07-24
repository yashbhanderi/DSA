# 07 — Cycle Detection

> **Related Topics:** [DFS](./02_DFS.md) | [Topological Sort](./08_Topological_Sort.md) | [Union Find](./09_Union_Find_DSU.md)

---

## 1. What Is Cycle Detection?

A **cycle** is a path that starts and ends at the same node.

```
Cycle:        No Cycle (DAG):
0 → 1         0 → 1
↑   ↓         ↓   ↓
3 ← 2         3   2
```

Detecting cycles is critical for:
- Course scheduling (can we complete all courses?)
- Dependency resolution (is there a circular dependency?)
- Detecting redundant connections

---

## 2. Two Types of Cycle Detection

### Type 1: Cycle in a Directed Graph
Edges have direction. A cycle means you can follow arrows back to where you started.

### Type 2: Cycle in an Undirected Graph
No direction. A cycle means there's a "back edge" — an edge that connects to an already-visited node that is NOT the parent.

These require **different algorithms!**

---

## 3. Cycle Detection in Directed Graph — DFS with 3 Colors

### The 3-State System

Each node gets one of 3 states:

```
0 = WHITE = Not visited
1 = GRAY  = Currently being processed (in call stack) ← your ancestor!
2 = BLACK = Fully processed (done, no cycle through here)
```

**Visual — why GRAY = cycle:**
```
DFS from A:

  A → B → C → D
  |               |
  +-------←--------+  ← back-edge from D to A!

Call stack: [A(GRAY), B(GRAY), C(GRAY), D(GRAY)]
                                         ↓
                       D sees neighbor A which is GRAY → CYCLE!

If there was no edge D→A:
Call stack: [A(GRAY), B(GRAY), C(GRAY)]
  D finishes → D becomes BLACK
  C finishes → C becomes BLACK
  ...no cycle
```

**The critical rule:** If during DFS you reach a node that is GRAY, you found a cycle! A GRAY node means it's your ancestor in the current DFS path — following it creates a back-edge = cycle.

A BLACK node is safe — it's already been fully explored with no cycle.

### Algorithm

```
DFS_Cycle(node, status):
  status[node] = GRAY (mark in-progress)

  for each neighbor:
      if status[neighbor] == GRAY: → CYCLE FOUND!
      if status[neighbor] == WHITE: → explore it
          if DFS_Cycle(neighbor, status) found cycle: → propagate

  status[node] = BLACK (fully done)
  return no cycle
```

### C# Template

```csharp
// From your CourseSchedule.cs and FindEventualSafeStates.cs
public static bool HasCycle(List<int>[] adj, int[] status, int node)
{
    status[node] = 1;  // GRAY: currently processing

    foreach (var neighbor in adj[node])
    {
        if (status[neighbor] == 1) return true;   // GRAY → cycle!
        if (status[neighbor] == 0)                // WHITE → explore
            if (HasCycle(adj, status, neighbor))
                return true;
        // status == 2 (BLACK) → already done, safe → do nothing
    }

    status[node] = 2;  // BLACK: fully processed
    return false;
}

// Caller:
int[] status = new int[n]; // all start at 0 (WHITE)
for (int i = 0; i < n; i++)
    if (status[i] == 0 && HasCycle(adj, status, i))
        return false; // cycle detected → can't finish courses
```

---

## 4. Cycle Detection in Undirected Graph — DFS with Parent

### The Idea

In undirected graphs, every edge goes both ways. So when DFS explores A → B, it will naturally try B → A next. This is NOT a cycle — it's just the same edge backwards.

A real cycle exists only if DFS reaches a visited node that is NOT the direct parent.

**Visual — parent edge vs true back-edge:**
```
Graph with NO cycle:              Graph WITH cycle:

  0 ─── 1 ─── 2                   0 ─── 1 ─── 2
                                   │           │
  DFS(0, parent=-1):               └─────────── ┘
    Visit 1 (parent=0)
    Visit 2 (parent=1)             DFS(0, parent=-1):
    2's neighbor = 1               Visit 1 (parent=0)
    1 == parent → SKIP (ok!)       Visit 2 (parent=1)
    No cycle ✓                     2's neighbor = 0
                                   0 ≠ parent(1)
                                   0 is visited!
                                   → CYCLE FOUND! ✓
```

### Algorithm

```
DFS_Undirected(node, parent, visited):
  visited[node] = true

  for each neighbor:
      if neighbor == parent: skip (same edge back)
      if visited[neighbor]: → CYCLE FOUND!
      else: DFS_Undirected(neighbor, node, visited)
```

### C# Template

```csharp
public static bool HasCycleUndirected(List<int>[] adj, bool[] visited, int node, int parent)
{
    visited[node] = true;

    foreach (var neighbor in adj[node])
    {
        if (neighbor == parent) continue;  // skip the edge we came from

        if (visited[neighbor]) return true;  // back-edge → cycle!

        if (HasCycleUndirected(adj, visited, neighbor, node))
            return true;
    }

    return false;
}
```

---

## 5. DSU Approach for Cycle Detection (Undirected)

A simpler approach using Union-Find:

**Idea:** Process each edge. If both endpoints already have the same parent (already in same component), adding this edge creates a cycle.

```csharp
// From your FindRedundantConnection.cs
var dsu = new DSU(n);

foreach (var edge in edges)
{
    int a = edge[0], b = edge[1];

    if (dsu.Find(a) == dsu.Find(b))
        return edge;  // same component → cycle!

    dsu.Union(a, b);
}
```

This is elegant and O(E × α) — almost linear.

---

## 6. Deep Dry Runs

### Problem 10 — Course Schedule (Cycle Detection)

**Task:** Given `numCourses` and `prerequisites` (edges), can you finish all courses? (No if there's a cycle.)

**Input:** numCourses=4, prerequisites=[[1,0],[2,0],[3,1],[3,2]]

```
Directed edges: 0→1, 0→2, 1→3, 2→3

status = [0,0,0,0]  (all WHITE)

i=0: status[0]=0 → explore
  DFS(0): status[0]=1 (GRAY)
    Neighbor 1: status[1]=0 → DFS(1): status[1]=1 (GRAY)
      Neighbor 3: status[3]=0 → DFS(3): status[3]=1 (GRAY)
        No unvisited neighbors
        status[3]=2 (BLACK)
      status[1]=2 (BLACK)
    Neighbor 2: status[2]=0 → DFS(2): status[2]=1 (GRAY)
      Neighbor 3: status[3]=2 (BLACK) → skip (already done, safe)
      status[2]=2 (BLACK)
    status[0]=2 (BLACK)

No cycle detected → return true (can finish all courses)
```

**Now with a cycle:** numCourses=2, prerequisites=[[1,0],[0,1]]

```
Edges: 0→1, 1→0  (cycle!)

DFS(0): status[0]=1 (GRAY)
  Neighbor 1: status[1]=0 → DFS(1): status[1]=1 (GRAY)
    Neighbor 0: status[0]=1 → GRAY! → CYCLE DETECTED!
    return true
  return true
return false (can't finish)
```

---

### Problem 11 — Find Eventual Safe States

**Task:** Find all nodes from which you can eventually reach a "terminal" node without going through a cycle.

**Key insight:** A node is "safe" (BLACK) if DFS from that node never leads to a cycle. Nodes in or leading to cycles are "unsafe" (GRAY stays GRAY forever).

```csharp
// Your solution:
public static bool DetectCycle(int[][] graph, int[] status, int node)
{
    status[node] = 1; // GRAY

    foreach (var neighbor in graph[node])
    {
        if (status[neighbor] == 1) return true;  // cycle!
        if (status[neighbor] == 0 && DetectCycle(graph, status, neighbor))
            return true;
    }

    status[node] = 2; // BLACK = safe
    return false;
}

// Collect safe nodes: those with status == 2
```

**Example:**
```
graph = [[1,2],[2,3],[5],[0],[5],[],[]]
Edges: 0→1, 0→2, 1→2, 1→3, 2→5, 3→0

Cycle: 0→3→0 (0 and 3 are unsafe)
Also 1 reaches 3 (which is in cycle), so 1 is unsafe.
2 → 5 → terminal, 5 is terminal, 4 → 5 → terminal.

Safe nodes: [2, 4, 5, 6]
```

---

### Problem 12 — Find Redundant Connection

**Task:** Given edges that form a tree + 1 extra edge. Find the extra edge (the one that creates a cycle).

**DSU approach (your main solution):**
```csharp
var dsu = new DSU(edges.Length);

for (int i = 0; i < edges.Length; i++)
{
    var a = edges[i][0], b = edges[i][1];
    var pa = dsu.Find(a), pb = dsu.Find(b);

    if (pa != pb)
        dsu.Union(a, b);  // no cycle, union them
    else
        return edges[i];  // same parent → this edge creates a cycle!
}
```

**Dry run:** edges = [[1,2],[1,3],[2,3]]

```
Process [1,2]: Find(1)=1, Find(2)=2 → different → Union(1,2)
  parent[2] = 1
  parent: [0,1,1,3]

Process [1,3]: Find(1)=1, Find(3)=3 → different → Union(1,3)
  parent[3] = 1
  parent: [0,1,1,1]

Process [2,3]: Find(2): parent[2]=1 → return 1
              Find(3): parent[3]=1 → return 1
              → Same parent (1)! → CYCLE!
              return [2,3]  ✓
```

---

## 7. Patterns

### Pattern 1: Can we complete all tasks?
**Signal:** "Course prerequisites", "task dependencies", "no circular dependencies needed"
```
→ Build directed graph
→ Detect cycle with DFS 3-state
→ If cycle exists: impossible
```

### Pattern 2: Find safe nodes (no cycle reachable)
**Signal:** "Eventually reaches terminal node", "safe states"
```
→ DFS 3-state
→ Nodes that become BLACK = safe
```

### Pattern 3: Find the redundant edge
**Signal:** "Add edge to tree creates cycle", "extra edge", "redundant connection"
```
→ DSU: process edges, the first edge connecting two nodes in same component is redundant
```

---

## 8. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Using only `visited` (true/false) in directed graph | Use 3-state: 0=unvisited, 1=in-stack, 2=done |
| Confusing parent tracking in undirected vs. 3-state in directed | Use parent tracking for undirected, 3-state for directed |
| Not calling DFS for all unvisited nodes | Loop through all nodes in outer loop |
| Returning true immediately at cycle detection without backtracking status | The 3-state handles this: status stays GRAY if cycle found |

---

## 9. Comparison Table

| | Directed Graph | Undirected Graph |
|---|---|---|
| **Method 1** | DFS 3-state (WHITE/GRAY/BLACK) | DFS with parent tracking |
| **Method 2** | Kahn's (if topo order count < n → cycle) | DSU |
| **Key signal** | Back-edge to GRAY node | Back-edge to any visited node (not parent) |

---

## 10. Recognition Checklist

```
If I see:
  → "can finish all courses/tasks?"          → Cycle detection in directed graph (DFS 3-state)
  → "circular dependency?"                   → Cycle detection in directed graph
  → "safe states / terminal nodes"           → DFS 3-state, collect BLACK nodes
  → "redundant edge in undirected graph"     → DSU: find the first edge creating same-parent
  → "directed graph, detect back-edge"       → DFS 3-state
  → "undirected graph, detect cycle"         → DFS with parent OR DSU
```

---

## 11. Cheat Sheet

```
DIRECTED CYCLE DETECTION — DFS 3-STATE:
  status: 0=white, 1=gray(in-stack), 2=black(done)
  
  DFS(node):
      status[node] = 1 (GRAY)
      for neighbor:
          if status[neighbor] == 1: CYCLE!
          if status[neighbor] == 0: recurse
      status[node] = 2 (BLACK)

DIRECTED CYCLE DETECTION — KAHN'S (cleaner for cycle check only):
  Compute inDegree for all nodes
  Enqueue nodes with inDegree == 0
  Process queue, decrement neighbors' inDegree
  If total processed < n → CYCLE EXISTS
  (Nodes with inDegree never reaching 0 are in the cycle)

  ```csharp
  // Cycle check via Kahn's
  bool HasCycle(int n, List<int>[] adj)
  {
      int[] inDegree = new int[n];
      foreach (var node in Enumerable.Range(0, n))
          foreach (var nb in adj[node])
              inDegree[nb]++;

      var queue = new Queue<int>();
      for (int i = 0; i < n; i++)
          if (inDegree[i] == 0) queue.Enqueue(i);

      int processed = 0;
      while (queue.Count > 0)
      {
          var node = queue.Dequeue();
          processed++;
          foreach (var nb in adj[node])
              if (--inDegree[nb] == 0) queue.Enqueue(nb);
      }
      return processed < n;  // true = cycle exists
  }
  ```

UNDIRECTED CYCLE — DFS WITH PARENT:
  DFS(node, parent):
      visited[node] = true
      for neighbor:
          if neighbor == parent: skip
          if visited[neighbor]: CYCLE!
          else: DFS(neighbor, node)

UNDIRECTED CYCLE — DSU:
  For each edge (a, b):
      if Find(a) == Find(b): CYCLE!
      else: Union(a, b)

SAFE STATES:
  Run 3-state DFS
  Collect all nodes with status == 2 (BLACK)
```
