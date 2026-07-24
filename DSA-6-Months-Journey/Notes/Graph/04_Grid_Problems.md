# 04 — Grid Problems

> **Related Topics:** [DFS](./02_DFS.md) | [BFS](./03_BFS.md) | [Multi-Source BFS](./05_MultiSource_BFS.md) | [Union Find](./09_Union_Find_DSU.md)

---

## 1. What Are Grid Problems?

A grid (2D array) is just a graph in disguise. Every cell `(row, col)` is a node. Adjacent cells are neighbors connected by edges.

The beautiful thing: **every graph algorithm you know works on grids.** You just need to translate "neighbors" from adjacency list to "the 4 (or 8) adjacent cells."

---

## 2. The Core Translation

```
Graph concept        Grid equivalent
─────────────────────────────────────
Node                 Cell (r, c)
Edge                 Shared boundary between cells
Visited set          visited[r][c] or modifying the grid
Adjacency list       4 neighbors: up, down, left, right
```

---

## 3. The Direction Array — Master This

```csharp
// 4-directional movement (most common)
int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];
//              up       down    left     right

// 8-directional movement (includes diagonals)
int[][] dirs = [
    [-1,-1], [-1,0], [-1,1],
    [0, -1],          [0, 1],
    [1, -1],  [1,0],  [1,1]
];
```

**Usage:**
```csharp
foreach (var d in dirs)
{
    int nr = r + d[0];
    int nc = c + d[1];

    // Boundary check FIRST
    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;

    // Then value check
    if (grid[nr][nc] != targetValue) continue;

    // Safe to process
    DFS(grid, nr, nc);
}
```

---

## 4. Boundary Check Template

Always check bounds before accessing a grid cell. This is the #1 source of bugs.

```csharp
// Safe to write as a helper
bool InBounds(int r, int c, int rows, int cols)
{
    return r >= 0 && r < rows && c >= 0 && c < cols;
}
```

Or inline:
```csharp
if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length) return;
```

---

## 5. Visited Strategies for Grids

### Strategy 1: Modify the grid in-place
**Use when:** The problem allows you to modify input, or asks you to "sink" visited cells.
```csharp
// Mark visited by changing value (your approach in #3 and #5)
grid[r][c] = '0';  // "sink" the land
```
**Pros:** No extra memory for visited array.
**Cons:** Destroys original data.

### Strategy 2: Separate visited 2D array
**Use when:** You need to preserve the original grid, or when the "new color" == "old color" (flood fill edge case).
```csharp
var visited = new bool[rows, cols];
visited[r, c] = true;
```

### Strategy 3: Mark with a sentinel value
**Use when:** The grid has a value you can use as a marker.
```csharp
image[r][c] = newColor;  // flood fill naturally marks as visited
```

---

## 6. Problems Covered

### Problem 02 — Flood Fill ⭐

**Task:** Given a 2D image, starting pixel `(sr, sc)`, replace the connected region of the same color with `color`.

**Pattern:** Classic DFS/BFS flood fill.

**Edge case you handled:** If `originalColor == newColor`, return immediately (otherwise infinite loop).

```csharp
// Your DFS solution (clean version):
public static void DFS(int[][] image, int r, int c, int original, int newColor)
{
    if (r < 0 || r >= image.Length || c < 0 || c >= image[0].Length) return;
    if (image[r][c] != original) return;

    image[r][c] = newColor;  // mark + fill

    DFS(image, r + 1, c, original, newColor);
    DFS(image, r - 1, c, original, newColor);
    DFS(image, r, c + 1, original, newColor);
    DFS(image, r, c - 1, original, newColor);
}

// Your BFS solution (with dirs array):
public static void BFS(int[][] image, int sr, int sc, int original, int newColor)
{
    int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];
    var queue = new Queue<(int, int)>();
    queue.Enqueue((sr, sc));

    while (queue.Count != 0)
    {
        var (r, c) = queue.Dequeue();
        foreach (var d in dirs)
        {
            int nr = r + d[0], nc = c + d[1];
            if (nr < 0 || nr >= image.Length || nc < 0 || nc >= image[0].Length) continue;
            if (image[nr][nc] != original) continue;

            image[nr][nc] = newColor;
            queue.Enqueue((nr, nc));
        }
    }
}
```

**Note:** You solved this with BOTH DFS and BFS — great practice!

---

### Problem 03 — Number of Islands ⭐

**Task:** Count the number of islands (connected regions of '1') in a grid of '1' and '0'.

**Pattern:** Component counting — for each unvisited '1', DFS to sink entire island.

```
1 1 0 0 0      island 1: (0,0),(0,1),(1,0),(1,1)
1 1 0 0 0  →   island 2: (2,2)
0 0 1 0 0      island 3: (3,3),(3,4)
0 0 0 1 1

Answer: 3
```

```csharp
// ✅ RECOMMENDED: clean in-place DFS (no static field!)
public static void DFS(char[][] grid, int r, int c)
{
    if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length) return;
    if (grid[r][c] != '1') return;

    grid[r][c] = '0';  // sink it (marks visited)

    DFS(grid, r+1, c); DFS(grid, r-1, c);
    DFS(grid, r, c+1); DFS(grid, r, c-1);
}

int islands = 0;
for (int r = 0; r < grid.Length; r++)
    for (int c = 0; c < grid[0].Length; c++)
        if (grid[r][c] == '1') { islands++; DFS(grid, r, c); }
```

> **Note:** Your original solution used a static `Visited` HashSet. The in-place approach (modify grid to '0') is cleaner, more memory-efficient, and is what you should write in an interview.

```csharp
int islands = 0;
for (int r = 0; r < grid.Length; r++)
    for (int c = 0; c < grid[0].Length; c++)
        if (grid[r][c] == '1') { islands++; DFS(grid, r, c); }
```

---


### Problem 05 — Max Area of Island ⭐

**Task:** Find the largest island by area (number of cells).

**Pattern:** DFS returning count. The return value accumulates the area.

```csharp
// Your solution (elegant):
public static int DFS(int[][] grid, int i, int j)
{
    if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0)
        return 0;

    grid[i][j] = 0;  // mark visited

    return 1 + DFS(grid, i, j-1)
             + DFS(grid, i, j+1)
             + DFS(grid, i-1, j)
             + DFS(grid, i+1, j);
}
```

**Dry run:**
```
Grid: 0 1 1
      1 1 0

DFS(0,1):
  grid[0][1] = 0
  return 1
    + DFS(0,0) = 0 (it's 0)
    + DFS(0,2): grid[0][2]=1 → mark 0
               return 1 + DFS(1,2)=0 + ... = 1
    + DFS(1,1): grid[1][1]=1 → mark 0
               return 1 + DFS(1,0): mark 0, return 1 + DFS(2,0)=0 + ...
               = 1 + 1 = 2 (approximately)
    + DFS(-1,1) = 0
  Total = 4
```

---

### Problem 34 — Making A Large Island (Advanced Grid + DSU)

**Task:** You can flip exactly one 0 to 1. Find the largest possible island.

**Strategy:** This is a 2-pass algorithm.

**Pass 1 — DSU:** 
- Build DSU of all existing islands.
- Use `r * N + c` as the node index.

**Pass 2 — Try each 0:**
- For each 0 cell, check its 4 neighbors.
- Count distinct island sizes that would merge.
- Add 1 (for the flipped cell).

```csharp
// From your solution:
// Pass 1: build DSU
for (int r = 0; r < N; r++)
    for (int c = 0; c < N; c++)
        if (grid[r][c] == 1)
        {
            // Union with right and down neighbors if they're also 1
            if (r+1 < N && grid[r+1][c] == 1) dsu.Union(r*N+c, (r+1)*N+c);
            if (c+1 < N && grid[r][c+1] == 1) dsu.Union(r*N+c, r*N+(c+1));
        }

// Pass 2: try each 0
for (int r = 0; r < N; r++)
    for (int c = 0; c < N; c++)
        if (grid[r][c] == 0)
        {
            int totalArea = 1;
            var seenComponents = new HashSet<int>();
            // Check 4 neighbors
            // For each '1' neighbor, get its DSU parent
            // Add its size ONLY if we haven't seen this component before
            // (prevents double-counting when two 0-neighbors belong to same island)
        }
```

**Why DSU?** Because you need to quickly know "what island does this cell belong to?" and "how big is that island?" — both are O(α) with DSU.

---

## 7. Grid Problem Patterns

### Pattern 1: Island Counting
```
Signal: "count connected regions of same value"
Approach:
  for each cell:
      if cell is target AND not visited:
          count++
          DFS/BFS from cell (marks entire component as visited)
```

### Pattern 2: Flood Fill / Region Marking
```
Signal: "change all connected cells of same value"
Approach:
  DFS from starting cell
  Change value as you go (serves as visited marker)
```

### Pattern 3: Find Max/Min in a Region
```
Signal: "largest island", "maximum area"
Approach:
  DFS returning a count
  return 1 + DFS(neighbors)
```

### Pattern 4: Multi-Source BFS from All Boundary/Target Cells
```
Signal: "distance from nearest 0", "rotting spreads"
Approach:
  Enqueue ALL source cells initially
  Standard BFS
```

### Pattern 5: Two-Pass (Mark then Query)
```
Signal: "flip one cell to maximize island" (problem 34)
Approach:
  Pass 1: Label/build components (DSU or DFS with component ID)
  Pass 2: For each flippable cell, sum adjacent component sizes
```

### Pattern 6: Boundary DFS/BFS ⭐ (Very Common Interview Pattern)
```
Signal: "capture surrounded regions", "safe cells connected to border"
Approach:
  Step 1: Start DFS/BFS from ALL border cells of target value
          Mark them as "safe" (cannot be captured)
  Step 2: Traverse grid — unmarked targets are captured/changed
          Restore safe-marked cells to original value
```

**Classic problem: Surrounded Regions (LC 130)**

Capture all 'O's that are NOT connected to the border. Border-connected 'O's are safe.

```
Input:          After capture:
X X X X        X X X X
X O O X   →    X X X X
X X O X        X X X X
X O X X        X O X X   ← border 'O' stays!
```

```csharp
public static void Solve(char[][] board)
{
    int rows = board.Length, cols = board[0].Length;

    void DFS(int r, int c)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols) return;
        if (board[r][c] != 'O') return;
        board[r][c] = 'S';  // mark as Safe
        DFS(r+1, c); DFS(r-1, c); DFS(r, c+1); DFS(r, c-1);
    }

    // Step 1: DFS from all border 'O's — mark connected as Safe
    for (int r = 0; r < rows; r++)
    {
        if (board[r][0]    == 'O') DFS(r, 0);
        if (board[r][cols-1] == 'O') DFS(r, cols-1);
    }
    for (int c = 0; c < cols; c++)
    {
        if (board[0][c]      == 'O') DFS(0, c);
        if (board[rows-1][c] == 'O') DFS(rows-1, c);
    }

    // Step 2: Flip remaining 'O' → 'X', restore 'S' → 'O'
    for (int r = 0; r < rows; r++)
        for (int c = 0; c < cols; c++)
        {
            if (board[r][c] == 'O') board[r][c] = 'X';  // captured!
            if (board[r][c] == 'S') board[r][c] = 'O';  // restore safe
        }
}
```

**Why start from borders?** Any 'O' touching the border can't be surrounded. DFS from borders marks all such 'O's. Everything else is captured.

---

## 8. Common Grid Mistakes

| Mistake | Fix |
|---------|-----|
| `grid[row][col]` instead of `grid[r][c]` (wrong variable) | Use consistent naming |
| Bounds check after accessing cell | Bounds check FIRST, always |
| Forgetting to check visited before modifying | Either check first or check value serves as visited |
| Double-counting components in problem 34 | Use a `HashSet` of seen parent IDs |
| Off-by-one in bounds: `r >= grid.Length` vs `r > grid.Length` | Use `>=` (Length is exclusive) |
| Using `r` for column and `c` for row | Stay consistent: row=`r`, col=`c` |
| Not handling the case where all cells are 1 (no 0 to flip) | Check if `largestIsland == int.MinValue` → return N*N |

---

## 9. Index Encoding for 2D → 1D

When using DSU on grids, you need to map `(row, col)` to a single integer:

```csharp
int index = row * numCols + col;

// Reverse:
int row = index / numCols;
int col = index % numCols;
```

**Used in your code:** Problems 34 and 35.

---

## 10. Recognition Checklist

```
If I see:
  → "2D grid with 0s and 1s"                    → Island problem (DFS/BFS)
  → "count groups of connected cells"            → Component counting
  → "fill connected region with new color"       → Flood fill (DFS/BFS)
  → "largest connected region"                   → DFS returning count
  → "distance from nearest 0 / target"           → Multi-source BFS
  → "flip one cell to maximize"                  → Two-pass: DSU + query
  → "N × N grid, union adjacent cells"           → DSU with index = r*N + c
  → "capture surrounded / safe cells on border" → Boundary DFS from borders, then sweep
```

---

## 11. Cheat Sheet

```
GRID = GRAPH where node = (r, c), edges = 4 adjacent cells

BOUNDS CHECK: r >= 0 && r < rows && c >= 0 && c < cols

DIRECTION ARRAY:
  int[][] dirs = [[-1,0],[1,0],[0,-1],[0,1]]

INDEX ENCODING: index = r * cols + c

VISIT STRATEGIES:
  1. visited[r][c] = true   (explicit array)
  2. grid[r][c] = sentinel  (modify in-place) ← most common

PATTERNS:
  Count islands:    loop grid → if '1' and not visited → DFS/BFS + count++
  Flood fill:       DFS from (sr,sc), change color as you go
  Max area:         DFS returning 1 + DFS(neighbors)
  Nearest source:   Multi-source BFS from all sources
  Flip one cell:    DSU pass + query pass
  Boundary safe:    DFS from ALL 4 borders → mark safe → sweep and flip
```
