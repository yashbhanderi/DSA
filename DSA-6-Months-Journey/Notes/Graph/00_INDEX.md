# 📊 Graph — Complete Interview Handbook

> Your single source of truth for Graphs. Read this before every interview.

---

## 📁 Topic Files

| # | File | Topics Covered | Problems |
|---|------|---------------|---------|
| 01 | [Graph Basics & Representation](./01_Graph_Basics_And_Representation.md) | What is a graph, terminology, adjacency list/matrix, directed/undirected | #1, #8 |
| 02 | [DFS — Depth First Search](./02_DFS.md) | DFS on graphs, grids, recursion, stack-based | #2, #3, #4, #5, #8 |
| 03 | [BFS — Breadth First Search](./03_BFS.md) | BFS on graphs, level-by-level traversal | #1, #6, #7 |
| 04 | [Grid Problems](./04_Grid_Problems.md) | Islands, flood fill, multi-source BFS on grids | #2, #3, #5, #6, #7, #34 |
| 05 | [Multi-Source BFS](./05_MultiSource_BFS.md) | Starting BFS from multiple nodes simultaneously | #6, #7 |
| 06 | [Connected Components](./06_Connected_Components.md) | Finding and counting components | #3, #4, #27 |
| 07 | [Cycle Detection](./07_Cycle_Detection.md) | Directed and undirected cycle detection | #10, #11, #12 |
| 08 | [Topological Sort](./08_Topological_Sort.md) | DFS topo sort, Kahn's BFS algorithm | #10, #13, #14, #15 |
| 09 | [Union Find — DSU](./09_Union_Find_DSU.md) | DSU with path compression, union by size, union by rank | #12, #27, #28, #29, #30, #31, #33, #34, #35 |
| 10 | [Shortest Path Algorithms](./10_Shortest_Path.md) | BFS, 0-1 BFS, Dijkstra, Bellman-Ford, Floyd-Warshall | #15–#25 |
| 11 | [Dijkstra's Algorithm](./11_Dijkstra.md) | Priority queue Dijkstra, grid Dijkstra, variants | #17, #18, #19, #20, #21, #22 |
| 12 | [Bellman-Ford Algorithm](./12_Bellman_Ford.md) | Negative weights, negative cycle detection | #21, #23 |
| 13 | [Floyd-Warshall Algorithm](./13_Floyd_Warshall.md) | All-pairs shortest path | #24, #25 |
| 14 | [Minimum Spanning Tree](./14_MST.md) | Prim's and Kruskal's algorithms | #26, #32 |
| 15 | [State Space BFS](./15_State_Space_BFS.md) | Word Ladder, BFS with states, implicit graphs | #9 |
| 16 | [Tree as Graph](./16_Tree_As_Graph.md) | Treating trees as undirected graphs, leaf pruning, diameter | #13 |
| 17 | [Advanced DSU Applications](./17_Advanced_DSU.md) | DSU on grids, creative DSU mappings | #33, #34, #35 |
| 18 | [Bipartite Graph](./18_Bipartite_Graph.md) | 2-coloring via BFS/DFS, odd-cycle detection | — |

---

## 🗺️ Learning Path

```
Graph Basics → DFS → BFS → Grid Problems
     ↓              ↓
Connected      Multi-Source BFS
Components          ↓
     ↓         State Space BFS
Cycle Detection
     ↓
Topological Sort → Shortest Path in DAG
                         ↓
                   Dijkstra → Bellman-Ford → Floyd-Warshall
                         ↓
                   MST (Prim + Kruskal)
                         ↓
                Union Find → Advanced DSU
```

---

## 📋 Quick Algorithm Selector

| Situation | Use This |
|-----------|----------|
| Unweighted graph, shortest path | BFS |
| Weights are 0 or 1 only | **0-1 BFS (deque)** |
| Detect all reachable nodes | DFS or BFS |
| Count connected components | DFS / BFS / DSU |
| Detect cycle in directed graph | DFS with 3-state coloring |
| Detect cycle in undirected graph | DSU or DFS with parent tracking |
| Find topological order | Kahn's (BFS) or DFS |
| Weighted graph, no negative edges | Dijkstra |
| Negative edge weights | Bellman-Ford |
| All-pairs shortest path | Floyd-Warshall |
| Minimum spanning tree | Prim's or Kruskal's |
| Merge groups / find connectivity | Union Find (DSU) |
| Implicit graph (words, states) | BFS + HashMap |
| Grid shortest path (uniform cost) | BFS |
| Grid shortest path (weighted) | Dijkstra on grid |
| K stops constraint | Modified Dijkstra / BFS layers |
| Count shortest paths | Dijkstra + ways[] array |
| 2-color graph / no odd cycles | Bipartite check (BFS/DFS 2-coloring) |

---

## 🧠 30-Second Interview Checklist

Before coding any graph problem, ask yourself:

1. **Directed or Undirected?**
2. **Weighted or Unweighted?**
3. **Are there negative weights?**
4. **Do I need shortest path or just reachability?**
5. **Is it a grid or explicit graph?**
6. **Do I need cycle detection?**
7. **Is there an ordering constraint?** (→ Topological Sort)
8. **Am I merging groups?** (→ DSU)

---

## 📌 Repository Problems Index

| # | Problem | Topic | Algorithm |
|---|---------|-------|-----------|
| 01 | Find If Path Exists In Graph | Graph Basics, BFS | BFS |
| 02 | Flood Fill | Grid DFS/BFS | DFS + BFS |
| 03 | Number Of Islands | Grid DFS | DFS |
| 04 | Number Of Complete Connected Components | DFS, Components | DFS |
| 05 | Max Area Of Island | Grid DFS | DFS (return count) |
| 06 | Rotting Oranges | Multi-Source BFS | BFS |
| 07 | Zero-One Matrix | Multi-Source BFS | BFS |
| 08 | Clone Graph | DFS with HashMap | DFS |
| 09 | Word Ladder | State Space BFS | BFS + Pattern Map |
| 10 | Course Schedule I | Cycle Detection | DFS 3-state |
| 10 | Course Schedule II | Topological Sort | Kahn's + DFS |
| 11 | Find Eventual Safe States | Cycle Detection | DFS 3-state |
| 12 | Find Redundant Connection | DSU / Cycle | DSU + DFS |
| 13 | Minimum Height Trees | Tree as Graph | Leaf Pruning BFS |
| 14 | Alien Dictionary | Topological Sort | Kahn's BFS |
| 15 | Shortest Path In DAG | Topo + Relaxation | DFS Topo + DP |
| 16 | Shortest Path In Undirected Graph | BFS | BFS |
| 17 | Network Delay Time | Dijkstra | Dijkstra (SortedSet) |
| 18 | Print Shortest Path | Dijkstra + Parent | Dijkstra |
| 19 | Shortest Path In Binary Maze | Grid Dijkstra | BFS/Dijkstra |
| 20 | Path With Minimum Effort | Grid Dijkstra | Dijkstra (max edge) |
| 21 | Find Cheapest Price (K stops) | Modified Dijkstra | Dijkstra + stops |
| 22 | Number Of Ways To Arrive At Destination | Dijkstra + DP | Dijkstra + ways[] |
| 23 | Bellman-Ford | Bellman-Ford | Bellman-Ford |
| 24 | Floyd-Warshall | Floyd-Warshall | Floyd-Warshall |
| 25 | Find City With Smallest Number Of Neighbors | Floyd-Warshall | Floyd-Warshall |
| 26 | Minimum Cost To Connect All Houses | MST (Prim's) | Prim's |
| 27 | Number Of Provinces | DSU / DFS | DSU |
| 28 | Satisfiability Of Equality Equations | DSU | DSU |
| 29 | Number Of Operations To Make Network Connected | DSU | DSU |
| 30 | Smallest String With Swaps | DSU + Sorting | DSU + Sort |
| 31 | Accounts Merge | DSU | DSU |
| 32 | Minimum Cost To Connect All Points | MST (Prim's) | Prim's |
| 33 | Most Stones Removed With Same Row/Column | DSU (creative mapping) | DSU |
| 34 | Making A Large Island | DSU on Grid | DSU |
| 35 | Swim In Rising Water | DSU / Dijkstra | DSU |
