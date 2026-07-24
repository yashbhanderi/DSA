# 17 — Advanced DSU Applications

> **Related Topics:** [Union Find DSU](./09_Union_Find_DSU.md) | [Grid Problems](./04_Grid_Problems.md) | [MST](./14_MST.md)

---

## 1. Overview

Your later problems (#33, #34, #35) show creative DSU applications that go beyond basic connectivity. These are the "aha!" problems where recognizing DSU is the key insight.

---

## 2. Creative Index Mapping

DSU works on integers. Real problems have non-integer items. The key skill is **mapping items to integers creatively**.

### Map Type 1: 2D Grid → 1D Index
```csharp
int index = row * numCols + col;
// Used in: Problem 34 (Making a Large Island)
```

### Map Type 2: Row/Col in Separate Namespace
```csharp
// Rows: 0 to 10000
// Cols: 10001 to 20001 (offset by 10001)
int colIndex = col + 10001;
dsu.Union(row, colIndex);
// Used in: Problem 33 (Most Stones Removed)
```

### Map Type 3: String/Object → Integer ID
```csharp
var emailIdMap = new Dictionary<string, int>();
int id = 0;
if (!emailIdMap.ContainsKey(email))
    emailIdMap[email] = id++;
// Used in: Problem 31 (Accounts Merge)
```

---

## 3. Problem 33 — Most Stones Removed ⭐

### The Problem
Stones on a 2D grid. A stone can be removed if it shares a row OR column with another stone. Maximum stones removable?

### The Key Insight

**If stones can be removed when they share a row/column, stones in the same "connected component" can be reduced to 1 stone.**

Two stones are "connected" if they share a row or column (directly or transitively):
- Stone A at (0,0), Stone B at (0,3): share row 0 → connected
- Stone C at (2,3): shares col 3 with B → connected to B, transitively to A

**Result:** From a component of size k, we can remove k-1 stones (keep 1).

**So:** Total removable = totalStones - numberOfComponents

### The Creative DSU Trick

How do we "connect" stones that share a row or column without explicitly building a graph?

**Observation:** Two stones in the same ROW both have the same row coordinate. Two stones in the same COL both have the same column coordinate.

**Insight:** Union each stone's ROW and COLUMN together in DSU. Then stones sharing a row/column will end up in the same DSU component!

**Visual — how the row/col namespace trick works:**
```
Stones: (0,0), (0,2), (1,1), (2,1), (2,2)

DSU namespace:
  Rows:  0, 1, 2          ← indices 0, 1, 2
  Cols: c0,c1,c2          ← indices 10001, 10002, 10003

For each stone, Union(row, col):
  Stone(0,0): Union(0, c0)  → connects row-0 and col-0
  Stone(0,2): Union(0, c2)  → connects row-0 and col-2
  Stone(1,1): Union(1, c1)  → connects row-1 and col-1
  Stone(2,1): Union(2, c1)  → connects row-2 and col-1
  Stone(2,2): Union(2, c2)  → connects row-2 and col-2

After all unions, DSU components:
  Component A: {row-0, col-0, col-2, row-2, col-1, row-1}
               All stones are connected! (1 big component)

  Removable stones = 5 stones - 1 component = 4

Why do (0,0) and (2,2) end up in same component?
  (0,0) → row-0; (0,2) → row-0 = col-2; (2,2) → col-2 = row-2
  Transitively connected! That's the magic.
```

```csharp
// From your MostStonesRemovedWithSameRowColumn.cs
var dsu = new DisjointSet(20002);
// Row 0-10000 → indices 0-10000
// Col 0-10000 → indices 10001-20001

var nodes = new HashSet<int>();

foreach (var stone in stones)
{
    int row = stone[0];
    int col = stone[1] + 10001;  // offset column to avoid collision with rows

    dsu.Union(row, col);  // union this stone's row with its column

    nodes.Add(row);
    nodes.Add(col);
}

// Count distinct components
var parents = new HashSet<int>();
foreach (var node in nodes)
    parents.Add(dsu.FindParent(node));

return stones.Length - parents.Count;
```

### Dry Run

Stones: [[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]

```
Stone (0,0): Union(row=0, col=10001)  → {0, 10001}
Stone (0,1): Union(row=0, col=10002)  → {0, 10001, 10002} (0 already with 10001)
Stone (1,0): Union(row=1, col=10001)  → {0, 1, 10001, 10002} (10001 already with 0)
Stone (1,2): Union(row=1, col=10003)  → {0, 1, 10001, 10002, 10003}
Stone (2,1): Union(row=2, col=10002)  → {0, 1, 2, 10001, 10002, 10003}
Stone (2,2): Union(row=2, col=10003)  → already same component!

All stones in ONE component → 1 parent
Answer: 6 - 1 = 5  ✓
```

---

## 4. Problem 34 — Making a Large Island ⭐

### The Problem
Binary grid. Flip exactly one 0 to 1. Find maximum possible island size.

### Two-Pass Algorithm

**Pass 1: Build islands using DSU**
- For each cell with value 1, union it with its adjacent 1-cells.
- DSU tracks island components and their sizes.

**Pass 2: Try each 0 cell**
- For each 0 cell, look at its 4 neighbors.
- If neighbor is 1, find its DSU component.
- Sum the sizes of distinct components + 1 (for the flipped cell).
- Track maximum.

### Why DSU?

The key operation in Pass 2: "how big is the island this cell belongs to?" 

DSU supports this in O(α): `dsu.GetSize(dsu.FindParent(index))`.

Also critical: when two different 0-neighbors belong to the SAME island, we must not double-count. A `HashSet` of seen parent IDs handles this.

```csharp
// Pass 1: Build DSU
for (int r = 0; r < N; r++)
    for (int c = 0; c < N; c++)
        if (grid[r][c] == 1)
        {
            int idx = r * N + c;
            if (r+1 < N && grid[r+1][c] == 1) dsu.Union(idx, (r+1)*N + c);
            if (c+1 < N && grid[r][c+1] == 1) dsu.Union(idx, r*N + (c+1));
            // Only right and down to avoid duplicate unions
        }

// Pass 2: Query each 0
for (int r = 0; r < N; r++)
    for (int c = 0; c < N; c++)
        if (grid[r][c] == 0)
        {
            int totalArea = 1;
            var seen = new HashSet<int>();  // CRITICAL: avoid double-counting

            // Check all 4 neighbors
            foreach (var (nr, nc) in neighbors)
            {
                if (valid && grid[nr][nc] == 1)
                {
                    int parent = dsu.FindParent(nr * N + nc);
                    if (!seen.Contains(parent))
                    {
                        totalArea += dsu.GetSize(parent);
                        seen.Add(parent);
                    }
                }
            }

            maxIsland = Math.Max(maxIsland, totalArea);
        }

// Edge case: if no 0 exists in grid
if (maxIsland == int.MinValue) maxIsland = N * N;
```

### Dry Run

```
Grid:
1 1
1 0

N=2
DSU with N*N=4 nodes (indices 0,1,2,3)

Pass 1:
  (0,0)=1: idx=0
    right (0,1)=1: Union(0,1)
    down (1,0)=1: Union(0,2)
  (0,1)=1: idx=1
    right: out of bounds
    down (1,1)=0: skip (it's 0)
  (1,0)=1: idx=2
    right (1,1)=0: skip
    down: out of bounds

DSU: {0,1,2} all connected, size=3

Pass 2:
  (1,1)=0: idx=3
    Check neighbors:
      Up (0,1)=1: parent=FindParent(1)=0 (root), size=3, totalArea=1+3=4
      Left (1,0)=1: parent=FindParent(2)=0 (same!), SKIP (seen!)
    maxIsland = 4

Final: 4  ✓ (flip (1,1), entire grid becomes 1 island)
```

---

## 5. Problem 35 — Swim in Rising Water ⭐

### The Problem
Grid where each cell has a value (elevation). Water rises from 0. At time t, all cells with value ≤ t are underwater. Find minimum time t such that (0,0) is connected to (N-1,N-1).

### DSU Approach

Process cells in order of their elevation value. When we process cell with value t:
1. Mark it as "reachable"
2. Union it with adjacent cells that are already reachable (value ≤ t)
3. After each union, check if (0,0) and (N-1,N-1) are in the same component → return t

```csharp
// From your SwimInRisingWater.cs
// position[v] = (r, c) where grid[r][c] = v
(int, int)[] position = new (int, int)[N * N];
for (int i = 0; i < N; i++)
    for (int j = 0; j < N; j++)
        position[grid[i][j]] = (i, j);

var dsu = new DisjointSet(N * N);

for (int time = 0; time < N * N; time++)
{
    var (r, c) = position[time];

    // Union with adjacent cells that have value ≤ time (already "in water")
    if (r+1 < N && grid[r+1][c] <= time) dsu.Union(grid[r][c], grid[r+1][c]);
    if (r-1 >= 0 && grid[r-1][c] <= time) dsu.Union(grid[r][c], grid[r-1][c]);
    if (c+1 < N && grid[r][c+1] <= time) dsu.Union(grid[r][c], grid[r][c+1]);
    if (c-1 >= 0 && grid[r][c-1] <= time) dsu.Union(grid[r][c], grid[r][c-1]);

    // Check if start and end are connected
    if (dsu.FindParent(grid[0][0]) == dsu.FindParent(grid[N-1][N-1]))
        return time;

    time++;
}
```

**Key insight:** Using the grid VALUE as the DSU node index directly! No need for `r*N+c` because grid values are already unique (it's a permutation).

### Alternative: Dijkstra

This problem can also be solved with Dijkstra where `dist[r][c] = min time to reach (r,c)`:
```
dist = max(dist_to_current, grid[r][c])  // you must wait until this cell is accessible
```

DSU approach: O(N² log N) (sorting by time)
Dijkstra: O(N² log N²) = O(N² log N)

Both work! DSU is elegant here.

---

## 6. DSU Patterns Summary

| Problem | Creative Mapping | Key Insight |
|---------|-----------------|-------------|
| #33 Stones | Row/Col in same namespace (offset col) | Union row with col; same row/col = same component |
| #34 Large Island | `r*N+c` for grid cells | DSU tracks island sizes for O(1) query |
| #35 Swim in Water | Grid value as DSU node | Process cells in time order, check connectivity |

---

## 7. Recognition Checklist for Advanced DSU

```
If I see:
  → "stones/items sharing row or column are connected"     → DSU with row/col mapping
  → "flip one cell, maximize connected area"               → DSU + size tracking + two-pass
  → "when does start connect to end? (incremental)"       → DSU, process cells in order
  → "merge regions, query sizes"                          → DSU with size tracking
  → "non-integer items to connect"                        → Map items to integers, then DSU
```

---

## 8. Cheat Sheet

```
ADVANCED DSU:
  1. Creative mapping: map problem items to integers
     - 2D grid: r*cols + c
     - Row/Col shared: offset cols by 10001
     - Strings: assign IDs via dictionary

  2. DSU with SIZE tracking:
     size[root] = component size
     Use for: sum of adjacent island sizes

  3. Process in order:
     Sort items, process one by one
     After each, check if source-dest connected

  4. Double-counting prevention:
     HashSet of seen parent IDs
     Only add size if parent not already seen

TEMPLATE - Two pass (problem 34):
  Pass 1: Build DSU from all 1s
  Pass 2: For each 0, sum neighboring component sizes
          Use HashSet to avoid double-counting
```
