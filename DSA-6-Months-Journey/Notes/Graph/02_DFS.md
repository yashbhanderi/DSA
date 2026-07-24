# 02 — DFS: Depth First Search

> **Related Topics:** [BFS](./03_BFS.md) | [Connected Components](./06_Connected_Components.md) | [Cycle Detection](./07_Cycle_Detection.md) | [Topological Sort](./08_Topological_Sort.md)

---

## 1. What Is DFS?

Imagine you're exploring a cave system. You pick one tunnel and go as deep as you can. When you hit a dead end, you come back and try the next tunnel.

That's DFS — **go deep first, come back only when stuck.**

### The Key Idea

DFS explores a graph by:
1. Starting at a node
2. Going as far as possible down one path
3. Backtracking when it can't go further
4. Trying the next unvisited path

---

## 2. Why DFS Exists

Before DFS, there was no systematic way to explore a graph completely. DFS gives us:
- A way to visit every node exactly once
- Natural recursion that mirrors the structure of the graph
- A foundation for cycle detection, topological sort, connected components

---

## 3. Core Concepts

### Visited Array / Set
The critical piece. Without it, DFS would loop forever.

```
visited = [false, false, false, false]  // before DFS
visited = [true,  true,  true,  true]   // after DFS covers all nodes
```

### The Call Stack (Implicit Stack)
When you call DFS recursively, your call stack IS your stack. Each recursive call represents going one level deeper.

**Visual — DFS on a real graph with call stack:**
```
Graph:   0 ── 1 ── 3
         |
         2 ── 4

DFS(0):                  Call stack:
  mark 0 visited         [DFS(0)]
  explore neighbor 1
    DFS(1):              [DFS(0), DFS(1)]
      mark 1 visited
      explore neighbor 3
        DFS(3):          [DFS(0), DFS(1), DFS(3)]
          mark 3 visited
          no unvisited neighbors
          RETURN         [DFS(0), DFS(1)]  ← pop 3
      explore neighbor 0 → already visited, skip
      RETURN             [DFS(0)]          ← pop 1
  explore neighbor 2
    DFS(2):              [DFS(0), DFS(2)]
      mark 2 visited
      explore neighbor 4
        DFS(4):          [DFS(0), DFS(2), DFS(4)]
          RETURN         [DFS(0), DFS(2)]  ← pop 4
      RETURN             [DFS(0)]          ← pop 2
  DONE                   []

Visit order: 0 → 1 → 3 → 2 → 4
```

### 4 Directions for Grid DFS
In grid problems, each cell has up to 4 neighbors:
```
int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];
//              up       down    left     right
```

---

## 4. Mental Model

> Think of DFS like exploring a maze with a ball of thread (like Theseus and the Minotaur).
> - You unroll the thread as you go deeper.
> - When you hit a dead end, you follow the thread back.
> - You never go down a path you've already explored.

The **visited** array is your ball of thread.

---

## 5. DFS Algorithm

### On a Generic Graph

```
DFS(node):
  1. Mark node as visited
  2. Process node (whatever the problem needs)
  3. For each neighbor of node:
       If neighbor is NOT visited:
           DFS(neighbor)
```

### Recursive Template (C#)

```csharp
public static void DFS(List<int>[] adj, bool[] visited, int node)
{
    visited[node] = true;

    // Process current node here
    Console.WriteLine(node);

    foreach (var neighbor in adj[node])
    {
        if (!visited[neighbor])
        {
            DFS(adj, visited, neighbor);
        }
    }
}

// Caller — handle disconnected graphs
for (int i = 0; i < n; i++)
{
    if (!visited[i])
        DFS(adj, visited, i);
}
```

---

## 6. DFS on a Grid

Grid problems convert the 2D grid into an implicit graph. Each cell `(row, col)` is a node. Its neighbors are the 4 adjacent cells.

**Visual — how DFS explores a grid:**
```
Grid: (1=land, 0=water)    DFS from (0,0), marking visited as X:

  Start:      Step 1:     Step 2:     Step 3:     Step 4:
  1 1 0       X 1 0       X X 0       X X 0       X X 0
  1 0 0  -->  1 0 0  -->  1 0 0  -->  X 0 0  -->  X 0 0
  0 0 1       0 0 1       0 0 1       0 0 1       0 0 1

  DFS(0,0)    (0,0) done   DFS goes   DFS(1,0)    All done,
  explores     explore     right to   (down from  backtrack
  first       right (0,1)  (0,1)       0,0)       to (0,0)

Call stack at deepest: [DFS(0,0) -> DFS(0,1) -> dead end, backtrack -> DFS(1,0) -> dead end]
Total visited: 3 cells = 1 island
```

### Grid DFS Template (C#)

```csharp
// From your FloodFill.cs and NumberOfIslands.cs
public static void DFS(int[][] grid, int r, int c)
{
    // Boundary check
    if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length)
        return;

    // Already visited or not a valid cell
    if (grid[r][c] != TARGET_VALUE)
        return;

    // Mark as visited (modify in-place or use visited array)
    grid[r][c] = VISITED_MARKER;

    // Explore 4 directions
    DFS(grid, r + 1, c);
    DFS(grid, r - 1, c);
    DFS(grid, r, c + 1);
    DFS(grid, r, c - 1);
}
```

---

## 7. Time & Space Complexity

| Case | Time | Space |
|------|------|-------|
| Generic graph | O(V + E) | O(V) for visited + call stack |
| Grid (N × M) | O(N × M) | O(N × M) for call stack |

**Why O(V + E)?**
- We visit each node once: O(V)
- We check each edge once (from both sides): O(E)
- Total: O(V + E)

**Why O(V) space?**
- In the worst case (a chain graph), the call stack goes V levels deep
- The visited array uses O(V) space

---

## 8. Deep Dry Runs

### Problem 02 — Flood Fill

**Input:**
```
Image:          Fill from (1,1) with color 2
1 1 1
1 1 0
1 0 1
Original color at (1,1) = 1
```

**DFS Execution:**

```
Start: DFS(1,1), originalColor=1
  Mark (1,1) = 2
  → DFS(2,1), DFS(0,1), DFS(1,2), DFS(1,0)

  DFS(2,1): grid[2][1] = 0, not originalColor → STOP
  DFS(0,1): grid[0][1] = 1 ✓
    Mark (0,1) = 2
    → DFS(1,1): already 2 → STOP
    → DFS(-1,1): out of bounds → STOP
    → DFS(0,2): grid[0][2] = 1 ✓
      Mark (0,2) = 2
      → all neighbors either visited or 0 → STOP
    → DFS(0,0): grid[0][0] = 1 ✓
      Mark (0,0) = 2
      → DFS(1,0): grid[1][0] = 1 ✓
        Mark (1,0) = 2
        → DFS(2,0): grid[2][0] = 1 ✓
          Mark (2,0) = 2
          ...

Final result:
2 2 2
2 2 0
2 0 1   ← only the connected region changed
```

**Key insight:** Marking `grid[r][c] = newColor` serves as the visited marker AND the result.

---

### Problem 03 — Number of Islands

**Input:**
```
Grid:
1 1 0 0 0
1 1 0 0 0
0 0 1 0 0
0 0 0 1 1
```

**Execution:**

```
i=0, j=0: grid[0][0] = '1', not visited
  islands++ → islands = 1
  Sink(0,0): mark visited
    Sink(1,0): mark visited
      Sink(2,0): '0' → stop
      Sink(0,0): already visited → stop
      Sink(1,1): mark visited
        Sink(2,1): '0' → stop
        Sink(0,1): mark visited
          Sink(0,2): '0' → stop
          ... completes island 1

i=0, j=1: already visited → skip
i=0, j=2: '0' → skip
...
i=2, j=2: grid[2][2] = '1', not visited
  islands++ → islands = 2
  Sink(2,2): mark visited
    all neighbors are '0' → single cell island

i=3, j=3: grid[3][3] = '1', not visited
  islands++ → islands = 3
  Sink(3,3): mark visited
    Sink(3,4): mark visited → ...

Final: 3 islands ✓
```

---

### Problem 05 — Max Area of Island

**Trick:** DFS returns a COUNT instead of void.

```csharp
public static int DFS(int[][] grid, int i, int j)
{
    // Base case: invalid or water
    if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0)
        return 0;

    grid[i][j] = 0;  // mark visited by sinking

    // Count this cell (1) + all connected cells
    return 1 + DFS(grid, i, j-1)
             + DFS(grid, i, j+1)
             + DFS(grid, i-1, j)
             + DFS(grid, i+1, j);
}
```

**Dry run for:**
```
0 1 1
1 1 0
0 0 0
```

```
DFS(0,1):
  grid[0][1] = 0
  return 1
    + DFS(0,0) = 0 (water)
    + DFS(0,2): mark 0, return 1 + DFS(1,2)=0 + DFS(-1,2)=0 + DFS(0,3)=0 + DFS(0,1)=0 = 1
    + DFS(1,1): mark 0, return 1 + DFS(1,0) + DFS(1,2) + DFS(2,1) + DFS(0,1)
              DFS(1,0): mark 0, return 1 + all neighbors 0 = 1
              = 1 + 1 + 0 + 0 + 0 = 2
    + DFS(-1,1) = 0
  = 1 + 0 + 1 + 2 + 0 = 4

maxArea = 4 ✓
```

---

### Problem 08 — Clone Graph

**Key challenge:** When cloning, you might visit a node's neighbor that's already been cloned. Without a map, you'd create duplicates or loop forever.

```csharp
// Your solution's core DFS:
public static void DFS(Node node, Dictionary<int, Node> map)
{
    if (node is null) return;

    var newNode = new Node(node.val);  // create clone
    map.Add(node.val, newNode);        // register clone

    foreach (var neighbor in node.neighbors)
    {
        if (!map.ContainsKey(neighbor.val))
        {
            DFS(neighbor, map);        // clone the neighbor
        }
        newNode.neighbors.Add(map[neighbor.val]);  // link to clone
    }
}
```

**Why the map is crucial:**
```
Original: 1 - 2 - 3 - 4 - 1 (cycle)

Without map:
  DFS(1) → clone 1 → DFS(2) → clone 2 → DFS(3) → clone 3 → DFS(4) → clone 4 → DFS(1) → INFINITE LOOP!

With map:
  DFS(1) → clone 1, map[1]=clone1 → DFS(2) → clone 2, map[2]=clone2 → ...
  When we reach DFS(1) again: map.ContainsKey(1) is TRUE → skip DFS, just link → no infinite loop!
```

---

## 9. Patterns

### Pattern 1: Component Exploration
**Signal:** "Count/find all islands / components / groups"
```
for each unvisited node:
    component_count++
    DFS(node)  // marks entire component as visited
```
**Problems:** #3, #4, #5, #27

---

### Pattern 2: Flood Fill / Marking
**Signal:** "Change all connected cells of same color/value"
```
DFS(r, c):
    if invalid or wrong value: return
    change cell
    DFS(neighbors)
```
**Problems:** #2

---

### Pattern 3: DFS Returns a Value
**Signal:** "Find max/min/count in a connected region"
```
DFS(r, c):
    if invalid: return 0 (or base value)
    mark visited
    return 1 + DFS(neighbors)  // accumulate count
```
**Problems:** #5

---

### Pattern 4: DFS with HashMap (Clone/Copy)
**Signal:** "Clone/copy a graph", "visited means already cloned"
```
map = {}
DFS(node):
    newNode = clone(node)
    map[node] = newNode
    for neighbor:
        if neighbor not in map: DFS(neighbor)
        newNode.neighbors.Add(map[neighbor])
```
**Problems:** #8

---

### Pattern 5: Reverse DFS from Boundary ⭐ (Important Interview Pattern)
**Signal:** "Which cells can flow to both oceans?", "reachable from boundary"

**Classic problem: Pacific Atlantic Water Flow (LC 417)**

Water flows from high → low. Find cells from which water can reach BOTH the Pacific (top/left border) and Atlantic (bottom/right border).

**Reverse thinking:** Instead of simulating water flowing DOWN from each cell (expensive), simulate water flowing UP from ocean borders.

```
Grid (heights):    Pacific touches top & left
                   Atlantic touches bottom & right

  P P P P P
P 1 2 2 3 5 A
P 3 2 3 4 4 A
P 2 4 5 3 1 A
P 6 7 1 4 5 A
P 5 1 1 2 4 A
    A A A A A

Pacific-reachable (flow UP from P borders):
  mark cells where height >= neighbor (water can flow upstream from ocean)

Atlantic-reachable (flow UP from A borders):
  same logic from bottom/right

Answer: cells reachable from BOTH = intersection
```

```csharp
public static IList<IList<int>> PacificAtlantic(int[][] heights)
{
    int rows = heights.Length, cols = heights[0].Length;
    bool[,] pacific  = new bool[rows, cols];
    bool[,] atlantic = new bool[rows, cols];

    void DFS(int r, int c, bool[,] visited, int prevHeight)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols) return;
        if (visited[r, c]) return;
        if (heights[r][c] < prevHeight) return;  // can't flow uphill from ocean

        visited[r, c] = true;
        DFS(r+1, c, visited, heights[r][c]);
        DFS(r-1, c, visited, heights[r][c]);
        DFS(r, c+1, visited, heights[r][c]);
        DFS(r, c-1, visited, heights[r][c]);
    }

    // Pacific: top row + left column
    for (int r = 0; r < rows; r++) DFS(r, 0, pacific, 0);
    for (int c = 0; c < cols; c++) DFS(0, c, pacific, 0);

    // Atlantic: bottom row + right column
    for (int r = 0; r < rows; r++) DFS(r, cols-1, atlantic, 0);
    for (int c = 0; c < cols; c++) DFS(rows-1, c, atlantic, 0);

    // Intersection = cells reachable from both
    var result = new List<IList<int>>();
    for (int r = 0; r < rows; r++)
        for (int c = 0; c < cols; c++)
            if (pacific[r, c] && atlantic[r, c])
                result.Add(new List<int> { r, c });

    return result;
}
```

**The "aha" moment:** The condition is reversed — you accept a neighbor when `heights[r][c] >= prevHeight`, because you're going UPHILL (opposite of water flow direction).

**Problems:** LC 417

---


## 10. Common Mistakes

| Mistake | Why It Happens | Fix |
|---------|----------------|-----|
| Stack overflow on large grids | DFS goes too deep | Use iterative DFS with explicit stack, or BFS |
| Forgetting boundary checks | Grid problems | Always check `r >= 0 && r < rows && c >= 0 && c < cols` |
| Visiting a node multiple times | Forgetting to mark visited | Mark BEFORE recursive calls, not after |
| Only starting DFS from node 0 | Assuming graph is connected | Loop through ALL nodes, start DFS for each unvisited one |
| Modifying original data | Returning wrong answer | Use a `visited` array instead of modifying grid when side effects matter |

---

## 11. Iterative DFS (with Explicit Stack)

When recursion is too deep, convert to iterative:

```csharp
public static void DFS_Iterative(List<int>[] adj, int start)
{
    var stack = new Stack<int>();
    var visited = new bool[adj.Length];

    stack.Push(start);
    visited[start] = true;

    while (stack.Count > 0)
    {
        var node = stack.Pop();
        Console.WriteLine(node); // process

        foreach (var neighbor in adj[node])
        {
            if (!visited[neighbor])
            {
                visited[neighbor] = true;
                stack.Push(neighbor);
            }
        }
    }
}
```

**Important:** Mark visited when pushing to stack, not when popping. Otherwise you'll push duplicates.

---

## 12. Variations

### DFS in 8 Directions (for grid problems)
Some problems allow diagonal moves:
```csharp
int[][] dirs = [
    [-1,-1], [-1,0], [-1,1],
    [0,-1],           [0,1],
    [1,-1],  [1,0],  [1,1]
];
```

### DFS with Return Value (tree-like computation)
Used when aggregating values up the recursion:
```csharp
int DFS(node) {
    int total = selfValue;
    foreach (neighbor)
        total += DFS(neighbor);
    return total;
}
```

---

## 13. Recognition Checklist

```
If I see:
  → "explore all connected cells/nodes"               → DFS
  → "count groups / islands / components"             → DFS outer loop + component counter
  → "change all connected cells of same color"        → DFS (flood fill)
  → "maximum area of connected region"                → DFS returning count
  → "copy / clone a graph"                            → DFS + HashMap
  → "any path exists from A to B"                     → DFS or BFS
  → "capture surrounded / not-border-connected cells" → DFS from borders, then sweep
  → "which cells can reach both X and Y boundary?"   → Two separate DFS from each boundary
```

---

## 14. Cheat Sheet

```
DFS TEMPLATE:
  visited[node] = true
  for neighbor in adj[node]:
      if not visited[neighbor]:
          DFS(neighbor)

GRID DFS:
  Boundary check → return
  Wrong value → return
  Mark visited (modify grid or use visited[])
  DFS(r+1,c), DFS(r-1,c), DFS(r,c+1), DFS(r,c-1)

COMPLEXITY:
  Time: O(V + E) for graph, O(N×M) for grid
  Space: O(V) for visited + call stack depth

YOUR SOLVED PROBLEMS:
  #2  Flood Fill       → grid DFS both ways
  #3  Number of Islands → DFS + counter
  #4  Complete Components → DFS + component analysis
  #5  Max Area Island  → DFS returning count
  #8  Clone Graph      → DFS + HashMap
```

---

## 15. Interview Summary

**DFS in 2 minutes:**

DFS goes deep before going wide. It uses recursion (or an explicit stack). The visited set prevents revisiting nodes.

Use DFS when:
- You need to explore an entire connected component
- You're doing flood fill / marking
- You're counting connected regions
- You need to track the path (recursion naturally tracks this)
- The problem is naturally recursive (trees, graphs)

BFS is better for shortest paths. DFS is better for exhaustive exploration, component analysis, and cycle detection.

**The one rule:** Always mark a node as visited BEFORE calling DFS on it, not after.
