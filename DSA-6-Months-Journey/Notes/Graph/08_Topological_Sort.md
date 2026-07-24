# 08 — Topological Sort

> **Related Topics:** [DFS](./02_DFS.md) | [BFS](./03_BFS.md) | [Cycle Detection](./07_Cycle_Detection.md) | [Shortest Path](./10_Shortest_Path.md)

---

## 1. What Is Topological Sort?

Imagine you're getting dressed in the morning. You can't put on shoes before socks. You can't wear a shirt under a jacket you've already put on. There's a required ORDER.

**Topological Sort** gives you a linear ordering of nodes in a directed graph such that for every directed edge `A → B`, node A comes BEFORE node B in the ordering.

```
A → B → D
    ↓
    C

Valid topological orders:
  A B C D
  A B D C (D and C have no dependency between them)
  A C B D ← INVALID! (B must come before C since B→C)
```

**Critical rule:** Topological sort only exists for DAGs (Directed Acyclic Graphs). If there's a cycle, no valid ordering exists.

---

## 2. Why It Exists

Before topological sort, scheduling problems were unsolved:
- Build systems (compile A before B which depends on A)
- Task management (do prerequisites first)
- Package managers (install dependencies first)
- Course scheduling

---

## 3. Two Algorithms

### Algorithm 1: Kahn's Algorithm (BFS-based) ⭐ Recommended

**The idea:** 
1. Find all nodes with **in-degree = 0** (no prerequisites).
2. These can be processed first. Add them to a queue.
3. Process each node: remove it and "decrease" the in-degree of its neighbors.
4. When a neighbor's in-degree hits 0, add it to the queue.
5. Repeat until queue is empty.

If the result contains all nodes → valid topological order.
If some nodes are missing → cycle exists (those nodes were never freed).

**The Analogy:** Kahn's is like peeling an onion. You peel the outermost layer first (nodes with no dependencies), then the next layer, and so on.

**Visual — Kahn's step by step:**
```
Graph: A→C, A→D, B→D, B→E, C→F, D→F

In-degrees:
  A=0, B=0, C=1, D=2, E=1, F=2

Round 1: Queue=[A,B]  (in-degree 0)
  Process A: C--, D--  → C=0, D=1
  Process B: D--, E--  → D=0, E=0
  result = [A, B]

Round 2: Queue=[C,D,E]  (newly freed)
  Process C: F--  → F=1
  Process D: F--  → F=0
  Process E: (no outgoing)
  result = [A,B,C,D,E]

Round 3: Queue=[F]
  Process F
  result = [A,B,C,D,E,F]  ← all 6 nodes = no cycle ✓

Topological order: A B C D E F  (one valid order)
```

```csharp
// From your CourseSchedule2.cs
public static int[] KahnsTopologicalSort(int n, int[][] prerequisites)
{
    var adj = new List<int>[n];
    var inDegree = new int[n];
    for (int i = 0; i < n; i++) adj[i] = [];

    // Build graph (prerequisite[1] must come before prerequisite[0])
    foreach (var e in prerequisites)
    {
        adj[e[1]].Add(e[0]);   // e[1] → e[0]
        inDegree[e[0]]++;
    }

    // Enqueue all nodes with in-degree 0
    var queue = new Queue<int>();
    for (int i = 0; i < n; i++)
        if (inDegree[i] == 0)
            queue.Enqueue(i);

    var result = new List<int>();
    while (queue.Count > 0)
    {
        var node = queue.Dequeue();
        result.Add(node);

        foreach (var neighbor in adj[node])
        {
            inDegree[neighbor]--;
            if (inDegree[neighbor] == 0)
                queue.Enqueue(neighbor);
        }
    }

    // If result doesn't have all nodes → cycle
    return result.Count == n ? result.ToArray() : [];
}
```

---

### Algorithm 2: DFS-based Topological Sort

**The idea:**
1. Run DFS on all unvisited nodes.
2. When you finish processing a node completely (all neighbors done), push it to a stack.
3. Pop the stack → that's your topological order.

```
Why does this work?
If A → B, DFS(A) calls DFS(B) first.
DFS(B) finishes and gets pushed to stack first.
When we pop: A comes out before B.
→ A appears before B in order. ✓
```

```csharp
// From your CourseSchedule2.cs DFS approach:
public static bool DFS(List<int>[] adj, int[] visited, Stack<int> topo, int node)
{
    if (visited[node] == 1) return false;  // GRAY → cycle!

    visited[node] = 1;  // GRAY

    foreach (var neighbor in adj[node])
    {
        if (visited[neighbor] == 1) return false;  // cycle!
        if (visited[neighbor] == 0)
            if (!DFS(adj, visited, topo, neighbor))
                return false;
    }

    visited[node] = 2;  // BLACK → done
    topo.Push(node);    // push AFTER all neighbors processed
    return true;
}

// Pop stack for topo order
```

---

## 4. Deep Dry Runs

### Problem 10 — Course Schedule II (Kahn's Algorithm)

**Input:** numCourses=4, prerequisites=[[1,0],[2,0],[3,1],[3,2]]

```
Build graph:
  Edge [1,0]: adj[0].Add(1) → 0→1
  Edge [2,0]: adj[0].Add(2) → 0→2
  Edge [3,1]: adj[1].Add(3) → 1→3
  Edge [3,2]: adj[2].Add(3) → 2→3

inDegree: [0, 1, 1, 2]
         node: 0  1  2  3

Initial queue: [0]  (only 0 has inDegree=0)
result = []

Step 1: Dequeue 0
  result = [0]
  Neighbor 1: inDegree[1]-- = 0 → enqueue 1
  Neighbor 2: inDegree[2]-- = 0 → enqueue 2
  Queue: [1, 2]

Step 2: Dequeue 1
  result = [0, 1]
  Neighbor 3: inDegree[3]-- = 1 → not 0, don't enqueue yet
  Queue: [2]

Step 3: Dequeue 2
  result = [0, 1, 2]
  Neighbor 3: inDegree[3]-- = 0 → enqueue 3
  Queue: [3]

Step 4: Dequeue 3
  result = [0, 1, 2, 3]
  No neighbors
  Queue: []

result.Count = 4 = n → no cycle!
Return [0, 1, 2, 3] ✓

You can take courses in this order: 0 → 1 → 2 → 3
```

---

### Problem 14 — Alien Dictionary

**Task:** Given sorted alien language words, determine the order of characters.

**How to model as topo sort:**

```
Compare adjacent words character by character:
"wrt" and "wrf":
  w==w, r==r, t≠f → edge: t → f (t comes before f)

"wrf" and "er":
  w≠e → edge: w → e

"er" and "ett":
  e==e, r≠t → edge: r → t

"ett" and "rftt":
  e≠r → edge: e → r
```

```
Build edges: t→f, w→e, r→t, e→r

inDegree: w=0, r=1, t=1, f=1, e=1

Kahn's BFS:
  Initial queue: [w]

  Process w: result="w", decrease inDegree[e] → 0
  Queue: [e]

  Process e: result="we", decrease inDegree[r] → 0
  Queue: [r]

  Process r: result="wer", decrease inDegree[t] → 0
  Queue: [t]

  Process t: result="wert", decrease inDegree[f] → 0
  Queue: [f]

  Process f: result="wertf"
  Queue: []

Output: "wertf" ✓
```

**Edge case you handle:** If `word1.Length > word2.Length` and word2 is a prefix of word1 → invalid ordering → return "".

```csharp
if (j == minLen && word1.Length > word2.Length) return "";
// Example: ["abc", "ab"] — "abc" can't come before "ab"!
```

---

### Problem 15 — Shortest Path in DAG

**Task:** Find shortest path from node 0 to all nodes in a weighted DAG.

**Strategy:** Topological sort + relaxation in topo order.

```
Why this works:
In a DAG, when you process node A in topo order,
ALL paths leading INTO A have already been processed.
So shortestDist[A] is finalized before we use it to update neighbors.
```

```csharp
// Step 1: Get topological order (DFS)
DFS → push to stack after processing all neighbors

// Step 2: Process nodes in topo order (pop from stack)
while (stack.Count > 0)
{
    var node = stack.Pop();

    if (shortestDist[node] == int.MaxValue) continue; // unreachable

    foreach (var (neighbor, weight) in adj[node])
    {
        var newDist = shortestDist[node] + weight;
        shortestDist[neighbor] = Math.Min(shortestDist[neighbor], newDist);
    }
}
```

**Dry run with your example:**
```
V=6, Edges: 0→1(2), 0→4(1), 4→5(4), 4→2(2), 1→2(3), 2→3(6), 5→3(1)

Topo order (DFS from 0): [0, 4, 5, 1, 2, 3] (one valid order)

shortestDist: [0, ∞, ∞, ∞, ∞, ∞]

Process 0:
  0→1: dist[1] = 0+2 = 2
  0→4: dist[4] = 0+1 = 1
  dist: [0, 2, ∞, ∞, 1, ∞]

Process 4:
  4→5: dist[5] = 1+4 = 5
  4→2: dist[2] = 1+2 = 3
  dist: [0, 2, 3, ∞, 1, 5]

Process 5:
  5→3: dist[3] = 5+1 = 6
  dist: [0, 2, 3, 6, 1, 5]

Process 1:
  1→2: dist[2] = min(3, 2+3) = min(3,5) = 3 (no update)

Process 2:
  2→3: dist[3] = min(6, 3+6) = 6 (no update)

Process 3: no outgoing edges

Final: [0, 2, 3, 6, 1, 5] ✓
```

---

## 5. Patterns

### Pattern 1: Task Ordering / Course Scheduling
```
Signal: "prerequisites", "must complete A before B", "can we complete all?"
Approach: 
  Build directed graph → Kahn's BFS
  If topo order has all n nodes → possible, else → impossible (cycle)
```

### Pattern 2: Detect Cycle Using Kahn's
```
After Kahn's, if result.Count < n → there's a cycle
(some nodes never had inDegree=0 because they're in the cycle)
```

### Pattern 3: Alien Dictionary / String Ordering
```
Signal: "sorted order", "character ordering from words"
Approach:
  Compare adjacent words → extract ordering edges
  Kahn's BFS on character graph
```

### Pattern 4: Shortest Path in DAG
```
Signal: "weighted DAG", "shortest path"
Approach: Topo sort + relaxation in topo order
(faster than Dijkstra for DAGs!)
```

---

## 6. Kahn's vs DFS Topo Sort

| | Kahn's (BFS) | DFS |
|--|--|--|
| Direction | Forward: process prerequisites first | Backward: post-order gives topo |
| Cycle Detection | Yes: if result.Count < n | Yes: if GRAY node encountered |
| Complexity | O(V+E) | O(V+E) |
| When to prefer | When you want level information | When natural with recursion |
| Course Schedule II | ✅ Natural | ✅ Also works |

---

## 7. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Building edges in wrong direction | `adj[prerequisite].Add(course)`, not `adj[course].Add(prerequisite)` |
| Forgetting to check result.Count == n | Always check for cycle detection via Kahn's |
| Not initializing adj list for all nodes | Initialize all n nodes even if no edges |
| Alien Dictionary: not handling prefix case | Check `j==minLen && word1.Length > word2.Length` |
| Alien Dictionary: not checking result length vs unique chars | Result might be shorter if graph has cycle |

---

## 8. Recognition Checklist

```
If I see:
  → "course prerequisites"                  → Topological Sort (Kahn's)
  → "is this schedule possible?"            → Topo Sort + cycle check
  → "give the order of completion"          → Topological Sort
  → "alien / foreign language ordering"     → Extract edges from words → Topo Sort
  → "weighted DAG shortest path"            → Topo Sort + relaxation
  → "all nodes must be processed"           → Kahn's result.Count == n
```

---

## 9. Cheat Sheet

```
KAHN'S ALGORITHM:
  1. Compute inDegree for all nodes
  2. Enqueue nodes with inDegree == 0
  3. While queue:
       dequeue node, add to result
       for each neighbor: inDegree[neighbor]--
       if inDegree[neighbor] == 0: enqueue
  4. If result.Count == n: valid topo order (no cycle)
     Else: cycle exists

DFS TOPO SORT:
  DFS(node):
      visited[node] = GRAY
      for neighbor: DFS(neighbor)
      visited[node] = BLACK
      stack.Push(node)  ← push AFTER processing all neighbors
  
  Pop stack → topo order

COMPLEXITY: O(V + E) for both
```

---

## 10. Interview Summary

**Topological Sort in 2 minutes:**

Topological sort orders nodes so every directed edge goes forward (from earlier to later in the order).

Two algorithms:
1. **Kahn's:** Start with all in-degree-0 nodes. Remove them one by one, freeing their neighbors. Natural cycle detection: if fewer than n nodes processed → cycle.
2. **DFS:** Post-order DFS. Push to stack AFTER all neighbors done. Pop stack for order.

Use cases: Course scheduling, task dependencies, build systems, alien dictionary, shortest path in DAGs.

Key edge case: If `result.Count < n` (Kahn's) or GRAY node encountered (DFS) → cycle → no valid ordering.
