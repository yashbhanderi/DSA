# 16 — Tree as Graph

> **Related Topics:** [BFS](./03_BFS.md) | [Topological Sort](./08_Topological_Sort.md) | [Connected Components](./06_Connected_Components.md)

---

## 1. Trees Are Graphs

A **tree** is a special graph:
- **Connected** (every node reachable from every other)
- **Acyclic** (no cycles)
- Has exactly **N-1 edges** for N nodes

When a graph problem gives you a "tree structure," you can apply all graph algorithms to it. Conversely, some graph problems on undirected acyclic graphs can be solved with tree-specific tricks.

---

## 2. The Leaf-Pruning Technique ⭐

Leaves in a tree have degree 1 (connected to only one other node). This property allows a beautiful iterative technique:

**Remove all leaves, which reveals new leaves, which you remove again... until 1 or 2 nodes remain.**

These final 1-2 nodes are the "center(s)" of the tree — they minimize the height when used as root.

**Visual — leaf pruning in action:**
```
Original tree:     Round 1 (remove      Round 2 (remove
                   leaves: 0,2,5,6)     new leaves: 1,4)
  0                                        
  |                     X                     
  1 ─── 2             1 ─── X             X
  |     |                   |                 |
  3     4             3     4             3   X
  |     |──►5         |     X
  |     │             |
  6     +─► (cut)     X

degrees after Round 1: node 3 has degree 1 now!

Round 3: only node 3 remains → it's the center!
Answer: [3]

Rule: stop when totalNodes ≤ 2 (there can be 1 or 2 centers)
```

---

## 3. Problem 13 — Minimum Height Trees ⭐

**Task:** Given an undirected tree with n nodes, find all roots that produce minimum height trees.

**Key insight:** The centers of a tree (1 or 2 nodes) always produce the minimum height. There can be at most 2 such centers.

**Why at most 2?** The center of a tree lies on the longest path (diameter) of the tree. The diameter has a midpoint, which could be 1 node (odd-length path) or 2 nodes (even-length path).

**Algorithm:** Repeatedly remove leaves (degree=1 nodes) until 1-2 nodes remain.

```
Tree:  0 - 1 - 2 - 3
           |
           4

degree: [1, 3, 1, 1, 1]
leaves: [0, 2, 3, 4]

Round 1: Remove 0, 2, 3, 4
  Reduce degree of their neighbor (1): degree[1] = 3-4+1... 
  Wait, let's be precise:
  
  Remove leaf 0: degree[1]-- = 2
  Remove leaf 2: degree[1]-- = 1
  Remove leaf 3: degree[2] was 1 → 0 (remove from tree)
  Remove leaf 4: degree[1]-- = 0
  
  Hmm, this removes node 1 too? No — the key is:
  Only add a node to next round's queue when its degree hits 1

Let's redo with your example: n=4, edges=[[1,0],[1,2],[1,3]]

Tree:
  0
  |
  1 - 2
  |
  3

degree = [1, 3, 1, 1]
leaves queue = [0, 2, 3]

totalNodes = 4

Round 1: leavesCount = 3
  totalNodes -= 3 → totalNodes = 1

  Process leaf 0: reduce degree[1]-- = 2. Not 1, don't add 1.
  Process leaf 2: reduce degree[1]-- = 1. Now 1! Add 1 to queue.
  Process leaf 3: reduce degree[1]-- = 0. Already at 0, skip.

  queue = [1]
  totalNodes = 1 ≤ 2 → STOP

Return: [1]  ✓
(Node 1 is the center — when used as root, tree has height 1)
```

---

## 4. C# Implementation (Your Solution)

```csharp
// From MinimumHeightTrees.cs
public static IList<int> FindMinHeightTrees(int n, int[][] edges)
{
    if (n == 1) return [0];  // single node → it's the root

    var adj = new List<int>[n];
    var degree = new int[n];
    for (int i = 0; i < n; i++) adj[i] = [];

    foreach (var e in edges)
    {
        adj[e[0]].Add(e[1]);
        adj[e[1]].Add(e[0]);
        degree[e[0]]++;
        degree[e[1]]++;
    }

    var queue = new Queue<int>();
    for (int i = 0; i < n; i++)
        if (degree[i] == 1)
            queue.Enqueue(i);  // all initial leaves

    int totalNodes = n;

    while (totalNodes > 2)  // stop when ≤ 2 nodes remain
    {
        int leavesCount = queue.Count;
        totalNodes -= leavesCount;

        for (int i = 0; i < leavesCount; i++)
        {
            int leaf = queue.Dequeue();

            foreach (var neighbor in adj[leaf])
            {
                degree[neighbor]--;

                if (degree[neighbor] == 1)  // this is now a leaf!
                    queue.Enqueue(neighbor);
            }
        }
    }

    return queue.ToList();  // remaining 1-2 nodes are the centers
}
```

**Key observations:**
1. This is essentially Kahn's algorithm (topological sort for DAGs) applied to an undirected tree!
2. Leaves play the role of "in-degree = 0" nodes in Kahn's.
3. We stop at 1-2 nodes instead of processing all nodes.

---

## 5. Why This Works

Think of it geographically. The center of a country is the city that minimizes the maximum distance to any border. In a tree:

- Leaves are the "border" nodes.
- By peeling them off layer by layer, we move inward.
- The last nodes we can't peel are exactly the center(s).

**Proof that result has at most 2 nodes:**
- If 3 nodes remain, at least one connects to another in a chain, making it a leaf relative to the others → still removable. Contradiction.
- So we always end with 1 or 2.

---

## 6. Connection to Other Algorithms

| Algorithm | Connection to Tree Problems |
|-----------|---------------------------|
| Kahn's Algorithm | Leaf pruning IS Kahn's on trees |
| BFS | Finding tree center = BFS from leaves inward |
| Topological Sort | Tree is a DAG → topo sort applies |

---

## 7. Common Tree-as-Graph Patterns

### Pattern 1: Leaf Pruning for Centers
```
Find center(s) of tree
→ Repeatedly remove degree-1 nodes until 1-2 remain
```

### Pattern 2: Tree DP (not in your repo but important)
```
Post-order DFS to aggregate values up the tree
Used for: max path sum, diameter, subtree sizes
```

### Pattern 3: BFS on Trees
```
Trees are just undirected acyclic graphs
BFS gives shortest path (same as in general graphs)
Level order traversal of tree = BFS from root
```

### Pattern 4: Finding Tree Diameter

The **diameter** = longest path between any two nodes in the tree.

**Two-BFS Algorithm:**
```
1. BFS from any node u → find farthest node v
2. BFS from v → find farthest node w
3. dist(v, w) = diameter
```

```csharp
// Returns the diameter of a tree given as adjacency list
public static int TreeDiameter(List<int>[] adj, int n)
{
    // BFS helper: returns (farthestNode, distance)
    (int node, int dist) BFS(int start)
    {
        int[] dist = new int[n];
        Array.Fill(dist, -1);
        dist[start] = 0;

        var queue = new Queue<int>();
        queue.Enqueue(start);

        int farthest = start;
        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            if (dist[cur] > dist[farthest]) farthest = cur;

            foreach (var nb in adj[cur])
                if (dist[nb] == -1)
                {
                    dist[nb] = dist[cur] + 1;
                    queue.Enqueue(nb);
                }
        }
        return (farthest, dist[farthest]);
    }

    var (v, _)        = BFS(0);     // Step 1: find one end of diameter
    var (w, diameter) = BFS(v);     // Step 2: find other end + length
    return diameter;
}
```

**Why two BFS?** The first BFS from any node guarantees we reach one endpoint of the diameter. The second BFS from that endpoint gives the exact diameter length. This is proven correct (standard interview fact — trust it).

---

## 8. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Stopping at 0 nodes instead of ≤ 2 | Condition is `while (totalNodes > 2)` |
| Not handling n=1 edge case | Return [0] immediately if n==1 |
| Treating tree as directed | Tree edges are bidirected — add both ways |
| Confusing degree with n - 1 | Degree is per-node, tracks connections |

---

## 9. Recognition Checklist

```
If I see:
  → "find root that minimizes tree height"            → Leaf pruning / center finding
  → "n nodes, n-1 edges, find special root"           → Tree center algorithm
  → "given undirected acyclic graph"                  → It's a tree! Use tree-specific tricks
  → "tree problem"                                    → All graph algorithms apply!
```

---

## 10. Cheat Sheet

```
MINIMUM HEIGHT TREE CENTERS:
  The center(s) of a tree = the nodes that minimize max depth
  
  ALGORITHM:
    degree[i] = count of neighbors of i
    queue = all leaves (degree == 1)
    totalNodes = n
    
    while totalNodes > 2:
        leavesCount = queue.Count
        totalNodes -= leavesCount
        
        for each leaf in queue (current level only):
            for each neighbor of leaf:
                degree[neighbor]--
                if degree[neighbor] == 1:
                    add to queue
    
    return remaining queue (1 or 2 nodes)

RESULT: always 1 or 2 center nodes
```
