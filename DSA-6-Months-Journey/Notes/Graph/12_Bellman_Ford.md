# 12 — Bellman-Ford Algorithm

> **Related Topics:** [Shortest Path Overview](./10_Shortest_Path.md) | [Dijkstra](./11_Dijkstra.md) | [Floyd-Warshall](./13_Floyd_Warshall.md)

---

## 1. What Is Bellman-Ford?

Bellman-Ford finds shortest paths from a single source to all other nodes — just like Dijkstra. But unlike Dijkstra, it **handles negative edge weights** and can **detect negative cycles**.

### Why Can't Dijkstra Handle Negative Weights?

```
   0 ─5─► 1 ─(-10)─► 2
   │                  ▲
   └───────1───────────┘

Dijkstra would:
  - Set dist[2] = 1 (via 0→2) ← finalizes this!
  - But actual shortest: 0→1→2 = 5-10 = -5

Dijkstra's greedy assumption fails because a negative edge can "undo" a previously optimal decision.
```

---

## 2. Core Idea

Bellman-Ford is not greedy. It's dynamic programming.

**The key insight:** The shortest path between any two nodes in a graph with V nodes can have at most **V-1 edges** (a path visiting all nodes exactly once).

So: **repeat edge relaxation exactly V-1 times.** After V-1 iterations, all shortest paths are found.

**Visual — how distances propagate over iterations:**
```
Graph:  0 ─►1► 1 ─►4► 2 ─►2► 3   (src=0)

Start:  dist = [0, ∞, ∞, ∞]

Iteration 1 (relax all edges):
  Edge 0→1 (w=1): 0+1=1 < ∞  →  dist[1]=1
  Edge 1→2 (w=4): 1+4=5 < ∞  →  dist[2]=5
  Edge 2→3 (w=2): 5+2=7 < ∞  →  dist[3]=7
  dist = [0, 1, 5, 7]  ← found paths with ≤1 hop, but also chained 3 hops!

  (Note: BF may find longer paths early if edges happen to be in order)

Iteration 2 (relax all edges again):
  No improvements this time.
  dist = [0, 1, 5, 7]  ← already optimal!

For a worst-case chain graph (reverse order edges), you NEED V-1 passes:
  Edges given as: 2→3, 1→2, 0→1 (backwards!)

  Iteration 1: only 0→1 updates (others can't since dist[1],dist[2]=∞)
  Iteration 2: 1→2 updates
  Iteration 3: 2→3 updates
  → needs 3 = V-1 iterations to reach all nodes
```

```
For i in 1 to V-1:
    For each edge (u, v, weight):
        If dist[u] + weight < dist[v]:
            dist[v] = dist[u] + weight
```

**Why V-1 times?** 
- Iteration 1: finds all paths with at most 1 edge
- Iteration 2: finds all paths with at most 2 edges
- ...
- Iteration V-1: finds all paths with at most V-1 edges = all possible shortest paths

---

## 3. Negative Cycle Detection

**What is a negative cycle?** A cycle where the total weight is negative. If one exists, you can keep going around it to make paths arbitrarily short (-∞). So "shortest path" becomes undefined.

**Visual — what a negative cycle looks like:**
```
  A ─►+5► B
  ▲         │
  |         │-8
  +──+2─── C

Cycle A→B→C→A = +5 + (-8) + 2 = -1  (negative!)

If you go around the cycle 100 times, cost = -100
Shortest path becomes -∞ → undefined!
```

**Detection:** After V-1 relaxations, do ONE MORE iteration. If ANY distance still decreases, a negative cycle exists!

```
If on the Vth iteration, dist[v] can still be reduced:
    → Negative cycle detected!
    → Return error / "no solution"
```

---

## 4. Algorithm (C#)

```csharp
// From your BellmanFord.cs
public static List<int> BellmanFord(int V, List<List<int>> edges, int src)
{
    int[] dist = new int[V];
    Array.Fill(dist, int.MaxValue);
    dist[src] = 0;

    // V-1 relaxations
    for (int i = 0; i < V - 1; i++)
    {
        foreach (var e in edges)
        {
            int u = e[0], v = e[1], w = e[2];

            if (dist[u] == int.MaxValue) continue;  // u unreachable

            if (dist[u] + w < dist[v])
                dist[v] = dist[u] + w;
        }
    }

    // Negative cycle check: one more relaxation
    foreach (var e in edges)
    {
        int u = e[0], v = e[1], w = e[2];

        if (dist[u] == int.MaxValue) continue;

        if (dist[u] + w < dist[v])
            return [-1];  // negative cycle!
    }

    return dist.ToList();
}
```

---

## 5. Time & Space Complexity

| | Complexity |
|---|---|
| Time | O(V × E) |
| Space | O(V) |

**Why O(V × E)?**
- V-1 iterations × E edges per iteration = O(V × E)

This is much slower than Dijkstra's O((V+E) log V). Use Bellman-Ford ONLY when necessary (negative weights).

---

## 6. Deep Dry Run

### Problem 23 — Bellman-Ford

**Input:** V=4, edges=[[0,1,4],[1,2,-6],[2,3,5],[3,1,-2]], src=0

```
dist = [0, ∞, ∞, ∞]

=== Iteration 1 (i=0): ===
  Edge [0,1,4]:  dist[0]+4=4 < dist[1]=∞ → dist[1]=4
  Edge [1,2,-6]: dist[1]+(-6)=4-6=-2 < dist[2]=∞ → dist[2]=-2
  Edge [2,3,5]:  dist[2]+5=-2+5=3 < dist[3]=∞ → dist[3]=3
  Edge [3,1,-2]: dist[3]+(-2)=3-2=1 < dist[1]=4 → dist[1]=1

dist = [0, 1, -2, 3]

=== Iteration 2 (i=1): ===
  Edge [0,1,4]:  dist[0]+4=4 > dist[1]=1 → no update
  Edge [1,2,-6]: dist[1]+(-6)=1-6=-5 < dist[2]=-2 → dist[2]=-5
  Edge [2,3,5]:  dist[2]+5=-5+5=0 < dist[3]=3 → dist[3]=0
  Edge [3,1,-2]: dist[3]+(-2)=0-2=-2 < dist[1]=1 → dist[1]=-2

dist = [0, -2, -5, 0]

=== Iteration 3 (i=2): ===
  Edge [0,1,4]:  no update
  Edge [1,2,-6]: dist[1]+(-6)=-2-6=-8 < dist[2]=-5 → dist[2]=-8
  Edge [2,3,5]:  dist[2]+5=-8+5=-3 < dist[3]=0 → dist[3]=-3
  Edge [3,1,-2]: dist[3]+(-2)=-3-2=-5 < dist[1]=-2 → dist[1]=-5

dist = [0, -5, -8, -3]

=== Negative Cycle Check (iteration V=4): ===
  Edge [3,1,-2]: dist[3]+(-2)=-3-2=-5 < dist[1]=-5?
  -5 < -5? NO
  
  Wait, let's recalculate more carefully:
  After 3 iterations: dist = [0, -5, -8, -3]
  Edge [3,1,-2]: -3 + (-2) = -5 = dist[1] → no change
  Edge [1,2,-6]: -5 + (-6) = -11 < dist[2]=-8 → REDUCTION POSSIBLE!
  
→ Negative cycle detected! Return [-1]
```

**Cycle that exists:** 1 → 2 → 3 → 1 with weight -6+5+(-2) = -3 (negative cycle!)

---

## 7. Problem 21 Revisited — Cheapest Price with K Stops (Bellman-Ford variant)

This problem can also be solved with Bellman-Ford! The "K stops" constraint means you do exactly K+1 relaxation iterations (instead of V-1).

Each iteration represents "one more stop allowed."

```csharp
// Bellman-Ford with exactly K+1 iterations
int[] dist = new int[n];
Array.Fill(dist, int.MaxValue);
dist[src] = 0;

for (int stop = 0; stop <= k; stop++)  // K+1 iterations
{
    int[] temp = (int[])dist.Clone();  // copy to avoid using updated values in same iteration
    
    foreach (var flight in flights)
    {
        int u = flight[0], v = flight[1], w = flight[2];
        if (dist[u] != int.MaxValue && dist[u] + w < temp[v])
            temp[v] = dist[u] + w;
    }
    
    dist = temp;
}
```

**Why copy? (Crucial!)** In standard Bellman-Ford, we relax edges with the CURRENT iteration's values. For "K stops" specifically, we need to ensure each iteration uses only values from the PREVIOUS round. Otherwise, a single iteration might chain multiple flights (more than 1 stop per round).

---

## 8. Bellman-Ford vs Dijkstra

| | Bellman-Ford | Dijkstra |
|--|--|--|
| Negative weights | ✅ Yes | ❌ No |
| Negative cycle detection | ✅ Yes | ❌ No |
| Time complexity | O(VE) | O((V+E)logV) |
| Algorithm type | DP / Relaxation | Greedy |
| When to use | Negative edges exist | No negative edges |

**Rule of thumb:** Always use Dijkstra if there are no negative edges. Only use Bellman-Ford when you need negative weight support.

---

## 9. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Forgetting the Vth iteration for cycle detection | Always run one extra relaxation after V-1 |
| Using Bellman-Ford when negative cycle exists but reporting distances anyway | Return error / "no solution" if Nth iteration still reduces distances |
| Not checking `dist[u] == int.MaxValue` before adding | `int.MaxValue + anything` overflows |
| For K-stops variant, not copying the array each iteration | MUST use temp copy to prevent chaining hops within same round |
| Confusing V-1 iterations with V iterations | Shortest paths need at most V-1 edges → V-1 iterations |

---

## 10. Recognition Checklist

```
If I see:
  → "negative edge weights"                  → Bellman-Ford (not Dijkstra!)
  → "detect negative cycle"                  → Bellman-Ford + Vth iteration check
  → "at most K hops/stops" (simple version)  → Bellman-Ford with K+1 iterations
  → "can this graph have arbitrarily short paths?" → Check negative cycles
```

---

## 11. Cheat Sheet

```
BELLMAN-FORD:
  dist[src] = 0, dist[all] = ∞
  
  for i in 1 to V-1:
      for each edge (u, v, w):
          if dist[u] + w < dist[v]:
              dist[v] = dist[u] + w
  
  // Negative cycle check:
  for each edge (u, v, w):
      if dist[u] + w < dist[v]: → NEGATIVE CYCLE!

COMPLEXITY: O(V × E)

USE WHEN: negative edge weights OR need negative cycle detection

KEY: Does NOT require ordering (processes all edges each time)
     Works on directed AND undirected graphs
```
