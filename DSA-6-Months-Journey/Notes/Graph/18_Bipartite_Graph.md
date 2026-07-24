# 18 — Bipartite Graph

> **Related Topics:** [DFS](./02_DFS.md) | [BFS](./03_BFS.md) | [Cycle Detection](./07_Cycle_Detection.md)

---

## 1. What Is a Bipartite Graph?

A graph is **bipartite** if you can color all nodes with exactly 2 colors such that no two adjacent nodes share the same color.

Think of it like a sports league — players on one team (color A) only play against players from the other team (color B). No one plays someone from their own team.

```
Bipartite:           NOT Bipartite (odd cycle):
  0 - 1               0
  |   |              / \
  3 - 2             1 - 2
Color: 0,2 = Red    Triangle → can't 2-color it
       1,3 = Blue
```

---

## 2. Key Theorem

> A graph is bipartite **if and only if** it contains **no odd-length cycle**.

This is why triangles (3-node cycles), 5-cycles, etc. make a graph non-bipartite.

Even-length cycles (4, 6, 8...) are fine for bipartite graphs.

---

## 3. Why It Matters (Interview Context)

Bipartite check shows up in:
- "Can you divide people/nodes into two groups?" 
- "Job matching / assignment problems" (bipartite matching)
- "Is there a 2-coloring?" or "Can you split nodes into two sets?"
- Problems that secretly involve checking for odd cycles

---

## 4. Algorithm — 2-Coloring via BFS

**Idea:** BFS from each unvisited node, alternately coloring neighbors.
- Start node → color 0
- All neighbors → color 1
- All their neighbors → color 0
- ...
- If you ever reach a neighbor with the SAME color as current → NOT bipartite!

**Visual — 2-coloring in action:**
```
Bipartite graph:               NOT bipartite:

  0 ─── 1 ─── 2                  0
  |               |              / \
  3 ─────────── 4              1 ─── 2

BFS from 0:                    BFS from 0:
  color[0]=0                     color[0]=0
  neighbors 1,3 → color=1        neighbors 1,2 → color=1
  neighbors of 1: 0(✓),2 → color=0   neighbors of 1: 0(✓),2
  neighbors of 2: 1(✓),4 → color=1   color[2]=1 already!
  neighbors of 4: 2(✓),3 → color=0   1 == color[1]=1 → CONFLICT!

  No conflict → BIPARTITE ✓       NOT BIPARTITE ✗

Groups: {0,2,4}=Red, {1,3}=Blue  (The triangle has no valid 2-coloring)
```

```csharp
// BFS 2-coloring
public static bool IsBipartite(List<int>[] adj, int n)
{
    int[] color = new int[n];
    Array.Fill(color, -1);  // -1 = uncolored

    for (int start = 0; start < n; start++)
    {
        if (color[start] != -1) continue;  // already colored

        color[start] = 0;
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            foreach (var neighbor in adj[node])
            {
                if (color[neighbor] == -1)
                {
                    color[neighbor] = 1 - color[node];  // flip color
                    queue.Enqueue(neighbor);
                }
                else if (color[neighbor] == color[node])
                {
                    return false;  // same color → conflict → NOT bipartite
                }
            }
        }
    }

    return true;
}
```

**Key trick:** `1 - color[node]` flips between 0 and 1 elegantly.

---

## 5. Algorithm — 2-Coloring via DFS

```csharp
// DFS 2-coloring
public static bool IsBipartite_DFS(List<int>[] adj, int[] color, int node, int c)
{
    color[node] = c;

    foreach (var neighbor in adj[node])
    {
        if (color[neighbor] == -1)
        {
            if (!IsBipartite_DFS(adj, color, neighbor, 1 - c))
                return false;
        }
        else if (color[neighbor] == c)
        {
            return false;  // same color as current → conflict
        }
    }

    return true;
}

// Caller:
int[] color = new int[n];
Array.Fill(color, -1);
for (int i = 0; i < n; i++)
    if (color[i] == -1 && !IsBipartite_DFS(adj, color, i, 0))
        return false;
return true;
```

---

## 6. Canonical Problem — LC 785 "Is Graph Bipartite?" ⭐

This is the **direct ask** you'll see in interviews. The input is an adjacency list where `graph[i]` = list of neighbors of node i.

```csharp
// LC 785 — exact solution
public static bool IsBipartite(int[][] graph)
{
    int n = graph.Length;
    int[] color = new int[n];
    Array.Fill(color, -1);

    for (int start = 0; start < n; start++)
    {
        if (color[start] != -1) continue;  // already colored

        // BFS from this component
        color[start] = 0;
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            foreach (var neighbor in graph[node])
            {
                if (color[neighbor] == -1)
                {
                    color[neighbor] = 1 - color[node];  // alternate color
                    queue.Enqueue(neighbor);
                }
                else if (color[neighbor] == color[node])
                {
                    return false;  // conflict → not bipartite
                }
            }
        }
    }

    return true;
}
```

**Dry Run** (Graph = [[1,3],[0,2],[1,3],[0,2]] — a square):
```
Start 0: color[0]=0
  Neighbor 1: uncolored → color[1]=1, enqueue
  Neighbor 3: uncolored → color[3]=1, enqueue

Process 1 (color=1):
  Neighbor 0: color[0]=0 ≠ 1 → OK
  Neighbor 2: uncolored → color[2]=0, enqueue

Process 3 (color=1):
  Neighbor 0: color[0]=0 ≠ 1 → OK
  Neighbor 2: color[2]=0 ≠ 1 → OK

Process 2 (color=0): all neighbors colored, no conflict

Result: true ✓  (Group A: {0,2}, Group B: {1,3})
```

---

## 7. When Input Is an Adjacency Matrix

LeetCode problems often give you `graph[i]` = list of neighbors of i:
```csharp
public static bool IsBipartite(int[][] graph)
{
    int n = graph.Length;
    int[] color = new int[n];
    Array.Fill(color, -1);

    for (int start = 0; start < n; start++)
    {
        if (color[start] != -1) continue;

        color[start] = 0;
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach (var neighbor in graph[node])
            {
                if (color[neighbor] == -1)
                {
                    color[neighbor] = 1 - color[node];
                    queue.Enqueue(neighbor);
                }
                else if (color[neighbor] == color[node])
                    return false;
            }
        }
    }
    return true;
}
```

---

## 7. Dry Run

**Input:**
```
graph = [[1,3],[0,2],[1,3],[0,2]]
(0-1, 1-2, 2-3, 3-0 — a square)
```

```
color = [-1,-1,-1,-1]

Start node 0, color = 0
Queue: [0]

Process 0 (color=0):
  Neighbor 1: uncolored → color[1] = 1 - 0 = 1, enqueue
  Neighbor 3: uncolored → color[3] = 1 - 0 = 1, enqueue
Queue: [1, 3]

Process 1 (color=1):
  Neighbor 0: color[0]=0 ≠ 1 → OK
  Neighbor 2: uncolored → color[2] = 1 - 1 = 0, enqueue
Queue: [3, 2]

Process 3 (color=1):
  Neighbor 0: color[0]=0 ≠ 1 → OK
  Neighbor 2: color[2]=0 ≠ 1 → OK
Queue: [2]

Process 2 (color=0):
  Neighbor 1: color[1]=1 ≠ 0 → OK
  Neighbor 3: color[3]=1 ≠ 0 → OK
Queue: []

Return true ✓ (Square is bipartite: {0,2} = Group A, {1,3} = Group B)
```

**Counter-example (triangle):**
```
graph = [[1,2],[0,2],[0,1]]

Process 0 (color=0): color[1]=1, color[2]=1
Process 1 (color=1): 
  Neighbor 2: color[2]=1 == color[1]=1 → CONFLICT → return false ✓
```

---

## 8. Connection to Odd Cycles

Why does 2-coloring fail on odd cycles?

```
Triangle: 0 - 1 - 2 - 0

Color 0 = Red
Color 1 = Blue (neighbor of 0)
Color 2 = Red (neighbor of 1, must differ from Blue)
Edge 2-0: both Red → CONFLICT!

Even cycle (square): 0 - 1 - 2 - 3 - 0
0=R, 1=B, 2=R, 3=B → edge 3-0: B≠R → OK!
```

---

## 9. Time & Space Complexity

| | Complexity |
|---|---|
| Time | O(V + E) |
| Space | O(V) for color array + queue |

---

## 10. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Only starting BFS from node 0 | Loop through ALL nodes — graph might be disconnected |
| Forgetting disconnected components | The outer `for` loop handles this |
| Using `true/false` instead of `0/1/-1` for color | Use -1 for "unvisited", 0 and 1 for two colors |
| Checking color AFTER enqueueing | Check when you discover a neighbor, before enqueuing |

---

## 11. Recognition Checklist

```
If I see:
  → "split nodes into 2 groups with no same-group edge"  → Bipartite check
  → "can you 2-color this graph?"                        → Bipartite check
  → "is there an odd-length cycle?"                      → Bipartite check (false = odd cycle exists)
  → "job assignment / matching between two sets"         → Bipartite + matching
  → "team division problem"                              → Bipartite check
```

---

## 12. Cheat Sheet

```
BIPARTITE CHECK:
  color[] = -1 (unvisited), 0 or 1 (two groups)
  
  BFS from each unvisited node:
      color[start] = 0
      for each neighbor:
          if uncolored: color[nb] = 1 - color[current], enqueue
          if same color as current: NOT BIPARTITE!

EQUIVALENT TO: No odd-length cycle exists

DFS version: same logic, pass color as parameter

TIME: O(V+E)
SPACE: O(V)

FLIP TRICK: 1 - color[node] alternates between 0 and 1
```

---

## 13. Interview Summary

**Bipartite in 2 minutes:**

Try to 2-color the graph using BFS. Start any node as color 0. Every neighbor gets color 1. Every neighbor of neighbor gets color 0. If you ever reach a neighbor with the same color as the current node → not bipartite.

Graph is bipartite ↔ no odd-length cycles exist.

Must handle disconnected graphs: loop through ALL nodes, start BFS for each unvisited one.
