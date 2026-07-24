# 05 — Multi-Source BFS

> **Related Topics:** [BFS](./03_BFS.md) | [Grid Problems](./04_Grid_Problems.md) | [Shortest Path](./10_Shortest_Path.md)

---

## 1. What Is Multi-Source BFS?

Regular BFS starts from **one** node and fans out.

Multi-Source BFS starts from **multiple** nodes **simultaneously**. It's as if all source nodes start "spreading" at the same time, at time=0.

### The Mental Model

Think of it like dropping multiple stones in a pond at the same time. Each stone creates ripples. The ripples from all stones spread simultaneously. The distance of any point from the nearest stone is determined by which ripple reaches it first.

---

## 2. Why It Exists

Consider: "Find the distance from each cell to the nearest 0."

**Naive approach:** For every cell that's 1, run a separate BFS to find the nearest 0.
- Time: O((N×M)²) — TLE for large grids.

**Smart approach:** Start BFS from ALL zeros at once.
- All zeros have distance 0.
- Their neighbors have distance 1.
- And so on...
- Time: O(N×M) — optimal!

**The key insight:** If you think of zeros as "sources," you're just doing regular BFS from ALL sources simultaneously. The first time BFS reaches any cell, it's guaranteed to be from the nearest source.

**Visual — multi-source vs single-source:**
```
Grid with 2 rotten oranges (R) and fresh oranges (F):

  F F F F F
  F R F F F    ← 2 sources: both Rs start at minute=0
  F F F F F
  F F F R F
  F F F F F

Single-source BFS (wrong idea): would run 2 separate BFS, slow

Multi-source BFS (correct): All Rs in queue at start

  Minute 0:   Minute 1:        Minute 2:        Minute 3:
  . . . . .   . 1 . . .        1 1 1 . .        1 1 1 1 .
  . R . . .   1 R 1 . .   →   1 R 1 1 .   →   1 R 1 1 1
  . . . . .   . 1 . . .        1 1 1 1 .        1 1 1 1 1
  . . . R .   . . 1 R 1        . 1 1 R 1        1 1 1 R 1
  . . . . .   . . . 1 .        . . 1 1 1        . . 1 1 1

Note: spreading from BOTH sources simultaneously!
(R=rotten, numbers=minute when rotted)
```

---

## 3. Algorithm

```
Multi-Source BFS:
1. Enqueue ALL source nodes
2. Mark ALL source nodes as visited (distance = 0)
3. Run standard BFS
   - When you process a node, set neighbor's distance = current distance + 1
   - This guarantees each cell gets the MINIMUM distance from ANY source
```

The magic is in step 1 and 2: by treating all sources as if they're already "level 0," BFS naturally propagates distances from the nearest source to every other cell.

---

## 4. Template (C#)

```csharp
// Multi-Source BFS Template
var queue = new Queue<(int r, int c)>();
int[,] dist = new int[rows, cols];
for (int i = 0; i < rows; i++)
    for (int j = 0; j < cols; j++)
        dist[i, j] = int.MaxValue;

// Step 1 & 2: Enqueue ALL sources
for (int r = 0; r < rows; r++)
    for (int c = 0; c < cols; c++)
        if (grid[r][c] == SOURCE_VALUE)
        {
            queue.Enqueue((r, c));
            dist[r, c] = 0;
        }

int[][] dirs = [[-1,0],[1,0],[0,-1],[0,1]];

// Step 3: Standard BFS
while (queue.Count > 0)
{
    var (r, c) = queue.Dequeue();

    foreach (var d in dirs)
    {
        int nr = r + d[0], nc = c + d[1];
        if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
        if (dist[nr, nc] != int.MaxValue) continue; // already visited

        dist[nr, nc] = dist[r, c] + 1;
        queue.Enqueue((nr, nc));
    }
}
```

---

## 5. Deep Dry Runs

### Problem 06 — Rotting Oranges ⭐

**Task:** Given a grid with 0 (empty), 1 (fresh orange), 2 (rotten orange), find the minimum minutes to rot all oranges. -1 if impossible.

**Input:**
```
2 1 1
0 1 1
1 0 1
```

**Initialization:**
- Queue: [(0,0)] (the single rotten orange)
- freshCount = 6 (count all 1s)

**Execution:**

```
Queue: [(0,0)], minutes = 0

=== Level 1 (minute 0→1): ===
TempQueue = []
Process (0,0):
  Up (-1,0): out of bounds
  Down (1,0): grid[1][0] = 0, not fresh → skip
  Left (0,-1): out of bounds
  Right (0,1): grid[0][1] = 1 → make rotten, freshCount=5, tempQueue.Add((0,1))

TempQueue = [(0,1)] → non-empty, so minutes++
Queue = [(0,1)], minutes = 1

=== Level 2 (minute 1→2): ===
Process (0,1):
  Down (1,1): grid[1][1] = 1 → rotten, freshCount=4, tempQueue.Add((1,1))
  Right (0,2): grid[0][2] = 1 → rotten, freshCount=3, tempQueue.Add((0,2))

Queue = [(1,1), (0,2)], minutes = 2

=== Level 3 (minute 2→3): ===
Process (1,1):
  Down (2,1): grid[2][1] = 0 → skip
  Right (1,2): grid[1][2] = 1 → rotten, freshCount=2, add (1,2)
  Up (0,1): already rotten
  Left (1,0): 0 → skip

Process (0,2):
  Down (1,2): already being added
  (other directions: out of bounds or already rotten)

Queue = [(1,2), ...], minutes = 3

=== Level 4 (minute 3→4): ===
Process (1,2):
  Down (2,2): grid[2][2] = 1 → rotten, freshCount=1

Queue = [(2,2)], minutes = 4

=== Level 5 (minute 4→5): ===
Process (2,2):
  Left (2,1): 0 → skip
  Up (1,2): already rotten
  No other valid neighbors

TempQueue = [] → empty, minutes stays at 4

Still: freshCount = 1 → grid[2][0] is still fresh, but isolated!
Return -1
```

**Why -1?** The orange at (2,0) is isolated (surrounded by 0s). No rotten orange can reach it.

**Final answer: -1** ✓

---

### Problem 07 — Zero-One Matrix ⭐

**Task:** For each cell, find the distance to the nearest 0.

**Input:**
```
0 0 0
0 1 0
1 1 1
```

**Multi-Source BFS:**

```
Initialization:
  Sources (all zeros): (0,0),(0,1),(0,2),(1,0),(1,2)
  dist:
  0 0 0
  0 ∞ 0
  ∞ ∞ ∞

Queue: [(0,0),(0,1),(0,2),(1,0),(1,2)]

=== Processing (0,0): ===
  Down (1,0): dist=0, already visited
  Right (0,1): dist=0, already visited

=== Processing (0,1): ===
  Down (1,1): dist = 0+1 = 1, add to queue
  (others already visited)

=== Processing (0,2): ===
  Down (1,2): dist=0, already visited

=== Processing (1,0): ===
  Down (2,0): dist = 0+1 = 1, add to queue
  (others already visited)

=== Processing (1,2): ===
  Down (2,2): dist = 0+1 = 1, add to queue

dist so far:
0 0 0
0 1 0
1 ∞ 1

Queue: [(1,1),(2,0),(2,2)]

=== Processing (1,1): ===
  Down (2,1): dist = 1+1 = 2, add to queue

=== Processing (2,0): all neighbors visited ===
=== Processing (2,2): all neighbors visited ===

dist:
0 0 0
0 1 0
1 2 1  ✓
```

**Note how "1" in position (2,1) got distance 2, correctly — it's 2 cells away from the nearest 0.**

---

## 6. Variations

### Variation 1: Minimum Time Until "Infection" Stops
Used in Rotting Oranges — level-based BFS where you count levels (minutes).

### Variation 2: Walls That Block Spreading
```csharp
if (grid[nr][nc] == WALL) continue;  // walls don't spread
```

### Variation 3: Finding the Maximum Distance (Farthest Cell)
After multi-source BFS completes, the cell with the maximum distance is the farthest from any source.

```csharp
int maxDist = 0;
for (int r = 0; r < rows; r++)
    for (int c = 0; c < cols; c++)
        if (dist[r,c] != int.MaxValue && grid[r][c] == TARGET)
            maxDist = Math.Max(maxDist, dist[r,c]);
```

---

## 7. Level Counting Technique

Your Rotting Oranges and Zero-One Matrix solutions use a "temp queue" pattern. The more common pattern uses queue size:

```csharp
// Method 1: Your style (temp queue)
while (queue.Count > 0)
{
    var tempQueue = new Queue<(int,int)>();
    while (queue.Count > 0)
    {
        var node = queue.Dequeue();
        // process, add valid neighbors to tempQueue
    }
    if (tempQueue.Count > 0)
    {
        level++;
        // transfer tempQueue to queue
    }
}

// Method 2: Queue size (cleaner)
while (queue.Count > 0)
{
    int levelSize = queue.Count;
    for (int i = 0; i < levelSize; i++)
    {
        var node = queue.Dequeue();
        // process, add valid neighbors to queue
    }
    level++;
}
```

Both are equivalent. Method 2 is cleaner. Method 1 is what you used — both work.

---

## 8. Common Mistakes

| Mistake | Effect | Fix |
|---------|--------|-----|
| Forgetting to initialize all sources | Only spreads from first source | Loop to add ALL sources to queue |
| Not marking sources as visited | Sources re-enqueued by neighbors | Mark dist[src] = 0 or visited[src] = true upfront |
| Counting levels when tempQueue is empty | Off-by-one in time | Only increment time when tempQueue is non-empty |
| Not checking impossible case (freshCount > 0 at end) | Return wrong answer | After BFS, check if any fresh remain |

---

## 9. Recognition Checklist

```
If I see:
  → "multiple starting points spread simultaneously"     → Multi-Source BFS
  → "nearest distance from ANY source cell"             → Multi-Source BFS
  → "how many rounds until all cells infected?"         → Multi-Source BFS + level counting
  → "find the last cell to be reached"                  → Multi-Source BFS, find max dist
  → "Rotting / spreading / infection problem"           → Multi-Source BFS
```

---

## 10. Cheat Sheet

```
MULTI-SOURCE BFS = Regular BFS but start from ALL sources simultaneously

TEMPLATE:
  for each source cell:
      queue.Enqueue(source)
      dist[source] = 0 (or visited[source] = true)
  
  Run standard BFS — each cell gets minimum distance to nearest source

GOTCHAS:
  → Count fresh items upfront → check at end if any remain
  → Mark sources visited BEFORE BFS starts
  → Level counting: only increment when new nodes are discovered
```
