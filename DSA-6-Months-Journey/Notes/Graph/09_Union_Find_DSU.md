# 09 — Union Find (DSU — Disjoint Set Union)

> **Related Topics:** [Connected Components](./06_Connected_Components.md) | [Cycle Detection](./07_Cycle_Detection.md) | [MST](./14_MST.md) | [Advanced DSU](./17_Advanced_DSU.md)

---

## 1. What Is Union-Find?

Imagine you have a bunch of people, and you want to track friend groups. When two people become friends, their groups merge. You also want to quickly answer: "Are these two people in the same friend group?"

That's exactly what **Disjoint Set Union (DSU)** solves.

DSU maintains a collection of **disjoint** (non-overlapping) sets and supports two operations:
- **Find(x):** Which group does x belong to? (returns the representative/parent of x's group)
- **Union(x, y):** Merge x's group with y's group.

---

## 2. Why It Exists

Before DSU, checking if two nodes were in the same component required BFS/DFS — O(V+E) per query. For problems with many connectivity queries, this is too slow.

DSU solves connectivity in near-constant time: **O(α)** per operation, where α is the inverse Ackermann function (practically = 1 or 2, never more than 4 for any real input).

---

## 3. Core Data Structure

Each node has a **parent**. If `parent[x] == x`, then x is the root (representative) of its group.

```
Initially:
  parent[0]=0, parent[1]=1, parent[2]=2, parent[3]=3
  Each node is its own parent (own group)

After Union(0,1):
  parent[1]=0  (or parent[0]=1 depending on rank/size)
  Group {0,1} with root 0

After Union(1,2):
  Find(1)=0, so we're merging group of root 0 with group of root 2
  parent[2]=0
  Group {0,1,2} with root 0
```

---

## 4. Naive Find (WITHOUT Path Compression)

```csharp
// From your earliest DSU (12_FindRedundantConnection.cs)
public int Find(int x)
{
    if (parent[x] == x)
        return x;
    return Find(parent[x]);  // traverse up to root
}
```

**Problem:** In the worst case (chain: 1→2→3→4→5→6), Find(1) takes O(N) time. After many unions, the tree can become a chain.

---

## 5. Path Compression ⭐ (Optimization 1)

**Idea:** When we go up the chain to find the root, WHY NOT directly connect everyone to the root? That way, next time Find is called, it's O(1).

```csharp
// From your SmallestStringWithSwaps.cs, AccountsMerge.cs, etc.
public int FindParent(int node)
{
    if (parent[node] != node)
    {
        parent[node] = FindParent(parent[node]); // PATH COMPRESSION
    }
    return parent[node];
}
```

**Before path compression:**
```
Chain: 5 → 4 → 3 → 2 → 1 → 0 (root)
Find(5) traverses: 5 → 4 → 3 → 2 → 1 → 0 (6 steps)
```

**After path compression:**
```
All point directly to root:
5 → 0
4 → 0
3 → 0
2 → 0
1 → 0
Find(5) → 0 (1 step!)
```

---

## 6. Union by Size ⭐ (Optimization 2)

**Problem with naive union:** Always merging by attaching one root to another arbitrarily can create tall, unbalanced trees.

**Solution:** When merging, always attach the SMALLER tree under the LARGER tree. This keeps the tree shallow.

**Visual — naive vs smart union:**
```
Naive Union (bad):           Union by Size (good):

Merge {A,B,C} + {D,E}       Merge {A,B,C} + {D,E}

    A                               A
    |                              /|\
    B    +   D        ==>         B C D
    |        |                         |
    C        E                         E

Tree height = 4 (bad!)       Tree height = 2 (flat!)
Find(C) takes 4 steps        Find(E) takes 2 steps

Rule: smaller group (D,E) goes UNDER larger group root (A)
```

```csharp
public void Union(int a, int b)
{
    int parentA = FindParent(a);
    int parentB = FindParent(b);

    if (parentA == parentB) return;  // already in same group

    // Union by SIZE: smaller tree goes under larger tree
    if (size[parentA] < size[parentB])
    {
        parent[parentA] = parentB;
        size[parentB] += size[parentA];
    }
    else
    {
        parent[parentB] = parentA;
        size[parentA] += size[parentB];
    }
}
```

---

## 6b. Union by Rank (Alternative to Size)

**Rank** = upper bound on the HEIGHT of the tree (not exact size, just height estimate).

- Initially all ranks = 0
- When merging trees of **different rank**: attach shorter (lower rank) under taller (higher rank), rank unchanged
- When merging trees of **equal rank**: attach either way, increment the winner's rank by 1

```csharp
public class DSU_ByRank
{
    private readonly int[] parent;
    private readonly int[] rank;

    public DSU_ByRank(int n)
    {
        parent = new int[n];
        rank = new int[n];  // all start at 0
        for (int i = 0; i < n; i++) parent[i] = i;
    }

    public int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);  // path compression
        return parent[x];
    }

    public void Union(int a, int b)
    {
        int pa = Find(a), pb = Find(b);
        if (pa == pb) return;

        if (rank[pa] < rank[pb])      parent[pa] = pb;        // pa is shorter
        else if (rank[pa] > rank[pb]) parent[pb] = pa;        // pb is shorter
        else { parent[pb] = pa; rank[pa]++; }                 // equal → one becomes root, rank++
    }
}
```

### Union by Size vs Union by Rank

| | Union by Size | Union by Rank |
|---|---|---|
| What it tracks | Exact number of nodes | Height upper bound |
| Better for | When you need `GetSize()` queries | Pure connectivity |
| Complexity | O(α) | O(α) |
| Which to use in interview | **Use Size** — it also lets you query component size | Use Rank if size query not needed |

> **Interview tip:** Both give identical O(α) complexity. Prefer **Union by Size** because it also gives you `GetSize()` for free. Only switch to Rank if an interviewer specifically asks.

---

## 6c. Iterative Find (Avoid Stack Overflow)

The recursive Find can overflow the call stack for very deep trees (rare after union by size/rank, but safe to know):

```csharp
// Iterative path compression
public int Find(int x)
{
    int root = x;
    while (parent[root] != root) root = parent[root];  // find root

    while (parent[x] != root)   // compress: point all nodes to root
    {
        int next = parent[x];
        parent[x] = root;
        x = next;
    }
    return root;
}
```

In practice with union by size/rank, trees stay very flat, so recursive Find is fine for almost all interview problems.

---

## 7. Complete DSU Template ⭐

This is the version you used in your most polished solutions (Problems 30, 31, 33, 34, 35):

```csharp
public class DisjointSet
{
    private readonly int[] parent;
    private readonly int[] size;

    public DisjointSet(int n)
    {
        parent = new int[n];
        size = new int[n];

        for (int i = 0; i < n; i++)
        {
            parent[i] = i;   // each node is its own parent
            size[i] = 1;     // each group starts with size 1
        }
    }

    // Find with path compression
    public int FindParent(int node)
    {
        if (parent[node] != node)
            parent[node] = FindParent(parent[node]);  // compress path
        return parent[node];
    }

    // Union by size
    public void Union(int a, int b)
    {
        int parentA = FindParent(a);
        int parentB = FindParent(b);

        if (parentA == parentB) return;

        if (size[parentA] < size[parentB])
        {
            parent[parentA] = parentB;
            size[parentB] += size[parentA];
        }
        else
        {
            parent[parentB] = parentA;
            size[parentA] += size[parentB];
        }
    }

    // Get size of component
    public int GetSize(int node) => size[FindParent(node)];
}
```

---

## 8. Complexity

| Operation | Naive | With Path Compression | With Path Compression + Union by Size |
|-----------|-------|-----------------------|--------------------------------------|
| Find | O(N) | O(log N) amortized | O(α(N)) ≈ O(1) |
| Union | O(N) | O(log N) amortized | O(α(N)) ≈ O(1) |

α(N) is the inverse Ackermann function. For any practical N (even N = 10^80), α(N) ≤ 4.

---

## 9. Deep Dry Runs

### Problem 12 — Find Redundant Connection (DSU approach)

**Input:** edges = [[2,7],[7,8],[3,6],[2,5],[6,8],[4,8],[2,8],[1,8],[7,10],[3,9]]

```
DSU initialized: parent[i]=i for all i, size[i]=1

Process [2,7]: Find(2)=2, Find(7)=7 → different → Union(2,7)
  parent[7]=2, size[2]=2
  
Process [7,8]: Find(7)=2, Find(8)=8 → different → Union(2,8)
  parent[8]=2, size[2]=3

Process [3,6]: Find(3)=3, Find(6)=6 → different → Union(3,6)
  parent[6]=3, size[3]=2

Process [2,5]: Find(2)=2, Find(5)=5 → different → Union(2,5)
  parent[5]=2, size[2]=4

Process [6,8]: Find(6)=3, Find(8)=2 → different → Union(2,3)
  size[2]=4 > size[3]=2 → parent[3]=2, size[2]=6

Process [4,8]: Find(4)=4, Find(8)=2 → different → Union(2,4)
  parent[4]=2, size[2]=7

Process [2,8]: Find(2)=2, Find(8)=2 → SAME PARENT!
  → Return [2,8]  ✓ (redundant edge)
```

---

### Problem 28 — Satisfiability of Equality Equations

**Task:** Given equations like `"a==b"`, `"b!=c"`, determine if all can be satisfied simultaneously.

**Strategy:**
1. Process all `==` equations first → Union the two characters
2. Then check all `!=` equations → if two characters in the same set, contradiction!

```csharp
// Your solution:
var dsu = new DisjointSet(26); // 26 letters

// Pass 1: Union all equal pairs
foreach (var eq in equations)
    if (eq[1] == '=')
        dsu.Union(eq[0]-'a', eq[3]-'a');

// Pass 2: Check inequality pairs
foreach (var eq in equations)
    if (eq[1] == '!')
        if (dsu.FindParent(eq[0]-'a') == dsu.FindParent(eq[3]-'a'))
            return false;  // They're in same set but claimed !=

return true;
```

**Example:** ["a==b", "b==c", "a!=c"]

```
Pass 1:
  "a==b": Union(a,b)
  "b==c": Union(b,c)
  Now a, b, c all in same component

Pass 2:
  "a!=c": Find(a) == Find(c)? YES → they're equal!
  But equation says a!=c → CONTRADICTION → return false
```

---

### Problem 29 — Number of Operations to Make Network Connected

**Task:** Given n computers and connections, find minimum cables needed to connect all. Return -1 if impossible.

**Insight:**
- To connect k components, you need exactly k-1 cables.
- "Extra" cables (those creating cycles) can be rerouted.
- Minimum cables needed = (number of components - 1)
- If extra cables ≥ (components - 1) → possible, return (components - 1)
- Else → return -1

```csharp
var dsu = new DisjointSet(n);
var extraCables = 0;

foreach (var conn in connections)
{
    if (dsu.FindParent(conn[0]) == dsu.FindParent(conn[1]))
        extraCables++;  // this cable creates a cycle = it's extra
    else
        dsu.Union(conn[0], conn[1]);
}

// Count distinct components
var parents = new HashSet<int>();
for (int i = 0; i < n; i++)
    parents.Add(dsu.FindParent(i));

int components = parents.Count;
int needed = components - 1;

return extraCables >= needed ? needed : -1;
```

---

### Problem 30 — Smallest String With Swaps

**Task:** You can swap characters at any indices in the given list. Return the lexicographically smallest string.

**Key insight:** Indices that are connected (directly or transitively through swaps) can be rearranged freely among themselves. So:
1. Union all swap pairs → find connected components of indices.
2. For each component, collect the characters, sort them, place sorted chars back at sorted positions.

```csharp
var dsu = new DisjointSet(N);
foreach (var pair in pairs)
    dsu.Union(pair[0], pair[1]);

// Group indices by their root parent
var groups = new Dictionary<int, List<int>>();
for (int i = 0; i < N; i++)
{
    var parent = dsu.FindParent(i);
    if (!groups.ContainsKey(parent)) groups[parent] = [];
    groups[parent].Add(i);
}

var result = new char[N];
foreach (var group in groups.Values)
{
    var chars = group.Select(i => s[i]).OrderBy(c => c).ToList();
    group.Sort();  // sort indices

    for (int k = 0; k < group.Count; k++)
        result[group[k]] = chars[k];  // smallest chars at smallest indices
}
```

**Example:** s="dcab", pairs=[[0,3],[1,2],[0,2]]

```
Union(0,3): {0,3}
Union(1,2): {1,2}
Union(0,2): {0,3} and {1,2} → {0,1,2,3}

All indices in one component!
Chars: d,c,a,b → sorted: a,b,c,d
Indices sorted: 0,1,2,3

result[0]='a', result[1]='b', result[2]='c', result[3]='d'
→ "abcd" ✓
```

---

### Problem 31 — Accounts Merge

**Task:** Merge accounts that share at least one email. Each account has a name and emails.

**Strategy:**
1. Assign each unique email an integer ID.
2. For each account, union all its emails together.
3. Group emails by their root parent.
4. For each group, find the name and sort emails.

This is DSU on items that aren't naturally integers (emails) → map them to integers first.

---

## 10. Patterns

### Pattern 1: Count Connected Components
```
DSU over all nodes/items
Count distinct FindParent() values
```
**Problems:** #27, #29, #33

### Pattern 2: Cycle Detection in Undirected Graph
```
For each edge (a,b):
    if Find(a) == Find(b): CYCLE
    else: Union(a,b)
```
**Problems:** #12

### Pattern 3: Two-Pass (Union all == then check !=)
```
Pass 1: Union all equality constraints
Pass 2: Check inequality constraints against DSU
```
**Problems:** #28

### Pattern 4: Group items to sort/rearrange
```
Union connected items
Group by parent
Sort within each group
```
**Problems:** #30, #31

### Pattern 5: Creative Index Mapping
```
When items are not naturally integers, map them:
  email → integer ID (problems 31)
  (row, col) → row*N + col (problem 34)
  row/col in same namespace (problem 33)
```

---

## 11. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Forgetting path compression → O(N) per query | Always use recursive path compression |
| Not using union by size → unbalanced tree | Always track size, merge smaller into larger |
| Calling Union before checking if same parent | Always check `if (parentA == parentB) return;` |
| 1-indexed nodes but 0-indexed array | Create array of size n+1 or adjust indices |
| Forgetting to call FindParent (not just parent[]) | parent[] is direct parent, FindParent() is root |
| Problem 33: not offsetting col by 10001 | Rows 0-10000 and cols 0-10000 overlap! Offset cols by 10001 |

---

## 12. DSU Evolution in Your Code

Looking at how your DSU evolved across problems:

| Problem | DSU Version | Missing |
|---------|-------------|---------|
| #12 | Naive Find (no compression) | Path compression, size |
| #27 | Basic Find (recursive, no compression) | Path compression, size |
| #29, #28 | Same basic version | Path compression, size |
| #30, #31 | Full DSU (compression + union by size) | Nothing ✅ |
| #33, #34, #35 | Full DSU (compression + union by size) | Nothing ✅ |

Your DSU matured over time. The final version in problems 30+ is optimal.

---

## 13. Recognition Checklist

```
If I see:
  → "merge groups"                           → DSU
  → "are X and Y connected / in same group?" → DSU Find
  → "count number of components"             → DSU count unique parents
  → "redundant / extra connection"           → DSU cycle detection
  → "accounts/emails merge"                  → DSU with string→int mapping
  → "constraints: a==b, b!=c"               → DSU two-pass
  → "swappable indices, smallest result"     → DSU + sort within groups
  → "connect all nodes, min operations"      → DSU count components - 1
```

---

## 14. Cheat Sheet

```
DSU TEMPLATE:
  parent[i] = i, size[i] = 1

  FindParent(node):
      if parent[node] != node:
          parent[node] = FindParent(parent[node])  // path compression
      return parent[node]

  Union(a, b):
      pa = FindParent(a), pb = FindParent(b)
      if pa == pb: return
      if size[pa] < size[pb]: parent[pa] = pb, size[pb] += size[pa]
      else: parent[pb] = pa, size[pa] += size[pb]

CYCLE DETECTION:
  if FindParent(a) == FindParent(b) BEFORE Union → cycle

COUNT COMPONENTS:
  HashSet<int> parents
  for each node: parents.Add(FindParent(node))
  return parents.Count

COMPLEXITY: O(α) ≈ O(1) per operation
```

---

## 15. Interview Summary

**DSU in 2 minutes:**

DSU maintains groups of connected items. Two operations: Find (which group?) and Union (merge groups).

Optimizations:
1. **Path compression** in Find: makes everyone point directly to root.
2. **Union by size**: smaller tree goes under larger tree.

Together: O(α) ≈ O(1) per operation.

Use DSU when:
- Merging groups dynamically
- Checking connectivity efficiently
- Counting components with many merge operations
- Detecting cycles in undirected graphs

The two-pass pattern (union all equalities, then check inequalities) is very powerful for constraint satisfaction problems.
