# 11 — Dijkstra's Algorithm

> **Related Topics:** [Shortest Path Overview](./10_Shortest_Path.md) | [BFS](./03_BFS.md) | [Grid Problems](./04_Grid_Problems.md) | [Bellman-Ford](./12_Bellman_Ford.md)

---

## 1. What Is Dijkstra?

Dijkstra is the gold standard for finding shortest paths in weighted graphs with **non-negative** edge weights.

**The Analogy:** Imagine you're an explorer with a map. You stand at the start. You can see all roads directly connected to you and their distances. You always choose the CLOSEST point you haven't visited yet, explore it, and update distances from there.

This greedy strategy — always go to the globally nearest unvisited node — guarantees optimal shortest paths.

---

## 2. Why Dijkstra Works

The key insight is the **greedy guarantee:**

> When you pick the node with the smallest current distance from the priority queue, that distance is FINAL. No future path can improve it.

Why? Because all edge weights are ≥ 0. Any path that hasn't been processed yet would have to go through a node with distance ≥ current distance, making the total only larger.

**Visual — Dijkstra on a weighted graph:**
```
Graph:          Process order and dist[] evolution:
      2   3
  A ─── B ─── C     Start: dist = [A:0, B:∞, C:∞, D:∞]
  │     │     │
  6     1     4     Pop A (dist=0):
  │     │     │       B: 0+2=2 < ∞  → dist[B]=2
  D ─── E ─── F       D: 0+6=6 < ∞  → dist[D]=6
      5   2           dist = [A:0, B:2, C:∞, D:6, ...]

                    Pop B (dist=2):  ← globally nearest!
                      C: 2+3=5 < ∞  → dist[C]=5
                      E: 2+1=3 < ∞  → dist[E]=3
                      dist = [A:0, B:2, C:5, D:6, E:3]

                    Pop E (dist=3):  ← still greedy nearest!
                      F: 3+2=5 < ∞  → dist[F]=5
                      ...
```

**This breaks with negative edges!** A negative edge could offer a shortcut through a node with larger current distance.

---

## 3. The Priority Queue

Dijkstra needs to always pick the globally closest unvisited node. This requires a **min-heap priority queue**.

```
// PriorityQueue stores: (node, distance), priority = distance
// Pop = always get node with MINIMUM distance

PQ state as Dijkstra runs on: A--(2)--B--(3)--C, A--(6)--C

  Start:     PQ = [(0, A)]
  Pop A:     relax B→2, C→6    PQ = [(2, B), (6, C)]
  Pop B:     relax C→2+3=5     PQ = [(5, C), (6, C)] ← stale (6,C) stays!
  Pop (5,C): C finalized        PQ = [(6, C)]
  Pop (6,C): 6 > dist[C]=5     → SKIP (stale entry)
```

The key: **PriorityQueue allows duplicates**. A node can be enqueued multiple times with different distances. The stale-entry check handles this.

**In C#:**
```csharp
// ✅ Recommended: PriorityQueue<(int node, int dist), int>
var pq = new PriorityQueue<(int node, int dist), int>();
pq.Enqueue((src, 0), 0);  // item=(node,dist), priority=dist

var (node, d) = pq.Dequeue();

// ❌ Avoid in interviews: SortedSet approach (complex, less intuitive)
// Use PriorityQueue — it's cleaner and handles duplicates correctly
```

---

## 4. Dijkstra Algorithm

```
Initialize:
  dist[source] = 0
  dist[everything else] = ∞
  pq = [(0, source)]

While pq is not empty:
  (currentDist, node) = pq.pop_min()

  // Skip if we've already found a shorter path
  if currentDist > dist[node]: continue

  For each (neighbor, weight) in adj[node]:
      newDist = dist[node] + weight

      if newDist < dist[neighbor]:
          dist[neighbor] = newDist
          pq.push((newDist, neighbor))
```

---

## 5. C# Template (Dijkstra) ⭐

```csharp
// ✅ RECOMMENDED INTERVIEW TEMPLATE
public static int[] Dijkstra(List<(int neighbor, int weight)>[] adj, int src, int n)
{
    int[] dist = new int[n];
    Array.Fill(dist, int.MaxValue);
    dist[src] = 0;

    // Store (node, distToNode) — need dist in queue to detect stale entries
    var pq = new PriorityQueue<(int node, int d), int>();
    pq.Enqueue((src, 0), 0);

    while (pq.Count > 0)
    {
        var (node, d) = pq.Dequeue();

        // ✅ CRITICAL: Skip stale entries
        // Same node may be in PQ multiple times with old (higher) distances
        if (d > dist[node]) continue;

        foreach (var (neighbor, weight) in adj[node])
        {
            // ✅ CRITICAL: Guard against int.MaxValue overflow
            if (dist[node] == int.MaxValue) continue;

            int newDist = dist[node] + weight;

            if (newDist < dist[neighbor])
            {
                dist[neighbor] = newDist;
                pq.Enqueue((neighbor, newDist), newDist);
            }
        }
    }

    return dist;  // dist[i] = shortest distance from src to i; int.MaxValue = unreachable
}
```

**Two things that MUST be in your Dijkstra:**
1. `if (d > dist[node]) continue;` — stale entry skip
2. `if (dist[node] == int.MaxValue) continue;` — overflow guard

---

## 6. Time & Space Complexity

| Component | Cost |
|-----------|------|
| Each node enters priority queue | O(V log V) |
| Each edge causes potential enqueue | O(E log V) |
| **Total** | **O((V + E) log V)** |
| Space | O(V + E) |

With a SortedSet (your approach): same asymptotically, but SortedSet has higher constant factor.

---

## 7. Deep Dry Runs

### Problem 17 — Network Delay Time ⭐

**Task:** Signal sent from node k. Find time for ALL nodes to receive. Return -1 if some can't.

**Input:** times=[[2,1,1],[2,3,1],[3,4,1]], n=4, k=2

```
Build adj list:
  adj[2]: [(1,1), (3,1)]
  adj[3]: [(4,1)]

dist = [∞, ∞, ∞, ∞, ∞]   (indices 0 to 4, 1-indexed)
dist[2] = 0

PQ: [(node=2, d=0)]

=== Step 1: ===
  Pop (node=2, d=0)
  d=0 == dist[2]=0 → not stale ✓

  Neighbor 1: newDist = 0+1 = 1 < dist[1]=∞ → dist[1]=1, enqueue (1,1)
  Neighbor 3: newDist = 0+1 = 1 < dist[3]=∞ → dist[3]=1, enqueue (3,1)

  PQ: [(1,1), (3,1)]
  dist: [∞, 1, 0, 1, ∞]

=== Step 2: ===
  Pop (node=1, d=1)
  d=1 == dist[1]=1 → not stale ✓
  No outgoing edges from node 1

  PQ: [(3,1)]

=== Step 3: ===
  Pop (node=3, d=1)
  d=1 == dist[3]=1 → not stale ✓

  Neighbor 4: newDist = 1+1 = 2 < dist[4]=∞ → dist[4]=2, enqueue (4,2)

  PQ: [(4,2)]

=== Step 4: ===
  Pop (node=4, d=2)
  d=2 == dist[4]=2 → not stale ✓
  No outgoing edges from 4

  PQ: []

Final dist: [∞, 1, 0, 1, 2]

Check: all nodes 1-4 reachable? Yes ✓
maxTime = max(1, 0, 1, 2) = 2

Answer: 2 ✓
```

---

### Problem 18 — Print Shortest Path ⭐

**Key addition: Parent array to reconstruct path.**

```csharp
int[] parent = new int[n+1];
parent[src] = src;  // source's parent is itself

// During Dijkstra (use PriorityQueue template):
if (newDist < dist[neighbor])
{
    dist[neighbor] = newDist;
    parent[neighbor] = node;  // track predecessor
    pq.Enqueue((neighbor, newDist), newDist);
}

// Reconstruct path (walk backwards from destination):
int current = destination;
while (parent[current] != current)
{
    path.Add(current);
    current = parent[current];
}
path.Add(src);
path.Reverse();
```

---

### Problem 19 — Shortest Path in Binary Maze

**Task:** In a grid of 0s and 1s, find shortest path from `src` to `dest` moving only through 1s.

**This is Dijkstra on a grid.** Each cell is a node. Moving costs 1. 0s are walls.

Wait — since all moves cost 1, can't we just use BFS?

**Yes! BFS works here.** But your solution uses Dijkstra (which also works). For uniform cost grids, BFS is more efficient. For grids with varying costs, use Dijkstra.

**Grid Dijkstra template (from your solution):**
```csharp
int[,] dist = new int[N, M];
// fill with ∞

dist[src[0], src[1]] = 0;
var queue = new Queue<(int cost, (int r, int c) pos)>();
queue.Enqueue((0, (src[0], src[1])));

while (queue.Count > 0)
{
    var (cost, (r, c)) = queue.Dequeue();
    
    if (r == dest[0] && c == dest[1]) return cost;
    
    // Check 4 directions
    foreach (direction)
    {
        int nr = r + dr, nc = c + dc;
        if (valid && walkable && newCost < dist[nr, nc])
        {
            dist[nr, nc] = newCost;
            queue.Enqueue((newCost, (nr, nc)));
        }
    }
}
```

**Note:** Your solution uses `Queue` not `PriorityQueue` here. Since all costs are +1, BFS/Queue works. For weighted grids (problem 20), you'd need PriorityQueue.

---

### Problem 20 — Path With Minimum Effort ⭐

**Task:** Find a path where the MAXIMUM height difference between consecutive cells is minimized.

**This changes what "distance" means!**
- Normal Dijkstra: `newDist = oldDist + edge_weight`
- Here: `newDist = max(currentMaxDiff, |heights[r][c] - heights[nr][nc]|)`

The "distance" to a cell = the maximum height difference you've seen on the best path to that cell.

```csharp
// From your PathWithMinimumEffort.cs
var pq = new PriorityQueue<(int effort, (int r, int c) pos), int>();
pq.Enqueue((0, (0, 0)), 0);
dist[0, 0] = 0;

while (pq.Count > 0)
{
    var (effort, (r, c)) = pq.Dequeue();

    foreach (var direction)
    {
        int nr = r + dr, nc = c + dc;
        if (!valid) continue;

        // Custom distance: max of current effort and this edge's difference
        int newEffort = Math.Max(effort, Math.Abs(heights[nr][nc] - heights[r][c]));

        if (newEffort < dist[nr, nc])
        {
            dist[nr, nc] = newEffort;
            pq.Enqueue((newEffort, (nr, nc)), newEffort);
        }
    }
}

return dist[N-1, M-1];
```

**Mental model:** You're asking "what's the minimum possible maximum bump on any path to the destination?"

---

### Problem 21 — Find Cheapest Price With K Stops

**Task:** Find cheapest flight from `src` to `dst` with at most `k` stops.

**The catch:** Normal Dijkstra doesn't work here because the "cheapest" path might use too many stops.

**Your approach:** Track state as `(node, stops)`. Only consider paths with `stops <= k`.

```csharp
// State: (node, priceToNode, stops)
int[,] cheapestPrice = new int[n, n];  // cheapestPrice[node][stops] = min price
cheapestPrice[src, 0] = 0;

var pq = new PriorityQueue<(int node, int price, int stops), int>();
pq.Enqueue((src, 0, 0), 0);

while (pq.Count > 0)
{
    var (node, price, stops) = pq.Dequeue();

    foreach (var (dest, cost) in adj[node])
    {
        int newPrice = price + cost;

        if (stops <= k && cheapestPrice[dest, stops] > newPrice)
        {
            cheapestPrice[dest, stops] = newPrice;
            if (stops < k)
                pq.Enqueue((dest, newPrice, stops + 1), newPrice);
        }
    }
}

// Find minimum across all stop counts
return Math.Min over cheapestPrice[dst, 0..n-1]
```

---

### Problem 22 — Number of Ways to Arrive at Destination ⭐

**Task:** Count the number of shortest paths from 0 to n-1.

**Extend Dijkstra with a `ways[]` array:**

```csharp
long[] ways = new long[n];
ways[0] = 1;  // 1 way to reach source

// During Dijkstra:
if (totalTime < shortestTime[newNode])
{
    shortestTime[newNode] = totalTime;
    ways[newNode] = ways[currentNode];  // inherit count
    pq.Enqueue(...)
}
else if (totalTime == shortestTime[newNode])
{
    ways[newNode] = (ways[newNode] + ways[currentNode]) % MOD;
    // found another equally-short path → add its count
}
```

**Key insight:**
- If new path is shorter → reset ways count
- If new path equals the shortest → add to ways count
- If new path is longer → ignore

---

## 8. Patterns

### Pattern 1: Standard Dijkstra
```
Single source, non-negative weights, find all shortest distances
```

### Pattern 2: Grid Dijkstra
```
2D grid with varying costs per cell/edge
Use (cost, r, c) in PriorityQueue
```

### Pattern 3: Custom Distance Function
```
"Minimize maximum edge" → dist = max(currentDist, edgeWeight)
"Minimize sum of edges" → dist = currentDist + edgeWeight
"Minimize product" → dist = currentDist * edgeWeight
```

### Pattern 4: Dijkstra + State
```
When constraints limit valid paths (K stops)
State = (node, constraint_value)
Expand state space accordingly
```

### Pattern 5: Dijkstra + DP (Count Paths)
```
Augment with ways[] array
ways[node] = number of shortest paths to node
```

---

## 9. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Using Dijkstra with negative edges | Use Bellman-Ford |
| Not skipping stale entries: `if (distFromPQ > dist[node]) continue` | Always add this check! |
| Overflow: `dist[node] + weight` when `dist[node] = int.MaxValue` | Check for MaxValue before adding |
| Not using priority queue (using regular queue) | Must use min-heap for weighted graphs |
| SortedSet vs PriorityQueue: SortedSet doesn't allow duplicates properly | Use PriorityQueue, or use SortedSet<(dist, node)> with unique keys |

---

## 10. SortedSet vs PriorityQueue — Use PriorityQueue

Your original solutions used `SortedSet<(int dist, int node)>`. Here's why **switch to PriorityQueue** for interviews:

| | PriorityQueue | SortedSet |
|---|---|---|
| Duplicates | ✅ Handles naturally | ❌ Needs workaround — (dist,node) must be unique |
| API clarity | ✅ Enqueue/Dequeue | ❌ Add/First/Remove verbosity |
| Interview standard | ✅ Yes | ❌ Less common |
| Behavior with same priority | ✅ Fine | ⚠️ Same (dist,node) silently dropped |

**Always use `PriorityQueue<(int node, int d), int>` in interviews.**

The SortedSet approach works because `(dist, node)` tuples are naturally unique (different nodes). But it breaks if you try to add the same `(dist, node)` twice — and it's harder to explain under pressure.

---

## 11. Recognition Checklist

```
If I see:
  → "shortest path", weighted, non-negative    → Dijkstra
  → "minimum cost / time / distance"           → Dijkstra
  → "grid with heights / costs"                → Grid Dijkstra
  → "minimum of maximum edge"                  → Dijkstra with max() operation
  → "at most K stops"                          → Dijkstra + state (node, stops)
  → "count shortest paths"                     → Dijkstra + ways[] array
  → "print the path"                           → Dijkstra + parent[] array
```

---

## 12. Cheat Sheet

```
DIJKSTRA TEMPLATE:
  dist[src] = 0, dist[all] = ∞
  pq = PriorityQueue, enqueue (0, src)
  
  while pq not empty:
      (d, node) = pq.Dequeue()
      if d > dist[node]: continue  ← CRITICAL
      
      for (neighbor, weight) in adj[node]:
          newDist = d + weight
          if newDist < dist[neighbor]:
              dist[neighbor] = newDist
              pq.Enqueue(neighbor, newDist)

COMPLEXITY: O((V+E) log V)

VARIANTS:
  Grid → (cost, (r, c)) in PQ
  Custom dist → change newDist formula
  K stops → add stops to state
  Count paths → add ways[] array

RULE: Non-negative weights only!
```

---

## 13. Interview Summary

**Dijkstra in 2 minutes:**

Dijkstra finds shortest paths from a source in weighted graphs (non-negative weights only).

Algorithm: Always greedily pick the unvisited node with minimum current distance. Relax all its edges. The min-heap (priority queue) makes this efficient.

The "stale entry" check `if (dist > dist[node]) continue` is crucial for the priority queue version.

Key variants:
- Grid problems: treat each cell as a node with (r,c,cost) in PQ
- Custom distance: change what "dist" means (e.g., max edge)
- K stops: expand state space to include stop count
- Count paths: add a `ways[]` array alongside `dist[]`
