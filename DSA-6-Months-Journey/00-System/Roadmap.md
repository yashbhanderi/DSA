# DSA FAANG Preparation Bible — 6-Month System

> **Profile:** 3 YOE · .NET Fintech Engineer · Payoneer · Target: Google / Meta / Amazon / Atlassian / Uber / Flipkart  
> **Generated:** May 2026 · **Revision cadence built in** · **Obsidian-ready**

---

# 1. Executive Overview

## 1.1 Profile Analysis

| Dimension           | Assessment                                                                                                                                                |
| ------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Foundation**      | Solid. Arrays, Strings, Sliding Window, Linked List, Stack, Queue, Trees are done.                                                                        |
| **Gap**             | Graph and DP — the two highest-weight FAANG topics — are untouched.                                                                                       |
| **Hidden strength** | Fintech systems background gives you automatic credibility in system design + practical edge in graph problems (payment flows, fraud detection, routing). |
| **Risk area #1**    | Restart loop. You've identified it yourself. The fix is structural — this roadmap starts at Week 3, not Week 1.                                           |
| **Risk area #2**    | DP mental block. Most engineers with your profile have this. Fixed via pattern-first learning, not problem-first.                                         |
| **Risk area #3**    | Losing steam at Month 3. Built-in mock phase and milestone rewards combat this.                                                                           |
| **Risk area #4**    | C# comfort vs. LeetCode Java/Python solutions. Mitigated — you solve in C#, reference solutions in any language.                                          |

## 1.2 Strengths Inventory

- Two-pointer, sliding window, stack, tree traversal patterns: already internalized
- Systems thinking from fintech: directly applicable to graph modeling
- 3–4 hours/day is above average for a working engineer — you have enough runway
- 6+ month flexible timeline is optimal for FAANG-level prep (most under-prepared in 3 months)

## 1.3 Expected Outcome After 6 Months

| Milestone                          | Target           |
| ---------------------------------- | ---------------- |
| LeetCode problems solved (net new) | 280–330          |
| Graph patterns mastered            | 12 core patterns |
| DP patterns mastered               | 10 core patterns |
| Mock interviews completed          | 20+              |
| System design (bonus)              | 4 case studies   |

## 1.4 Hiring Probability Estimate by Company Tier

> These are honest estimates assuming you complete 80%+ of this roadmap with quality.

| Company       | DSA Bar     | Your Probability (post-roadmap) | Notes                                                        |
| ------------- | ----------- | ------------------------------- | ------------------------------------------------------------ |
| **Google**    | Extreme     | 20–30%                          | Hardest bar. Graph + DP depth critical. Multiple rounds.     |
| **Meta**      | Very High   | 30–40%                          | Pattern-heavy. Faster signals.                               |
| **Amazon**    | High        | 45–55%                          | LP rounds + DSA. BFS/DFS/DP + design.                        |
| **Apple**     | High        | 40–50%                          | Lower volume, quality-focused.                               |
| **Netflix**   | High        | 35–45%                          | Senior-bar even for SDE-2. System design weighted.           |
| **Atlassian** | Medium-High | 55–65%                          | Graph (Jira DAG) + DP. Very achievable.                      |
| **Uber**      | High        | 50–60%                          | Graph-heavy (maps). Your fintech + routing background helps. |
| **Flipkart**  | Medium      | 65–75%                          | Achievable with 4 months prep. Good entry target.            |

## 1.5 Realistic Expectations

- You will not master everything. Prioritize ROI.
- Graph + DP together take 10–12 weeks of real depth. Don't rush them.
- One quality problem solved correctly > three problems skimmed.
- FAANG is a lottery with preparation as the ticket. Your job is to buy enough tickets.

---

# 2. FAANG / Product Company DSA Requirements (2026)

## 2.1 Company-by-Company Breakdown

### Google

| Factor                | Detail                                                                     |
| --------------------- | -------------------------------------------------------------------------- |
| **Rounds**            | 4–5 coding rounds (45 min each)                                            |
| **Difficulty**        | Hard dominant, Medium baseline                                             |
| **Graph usage**       | Very high — BFS/DFS/Dijkstra/Union Find                                    |
| **DP depth**          | High — interval, bitmask, 2D grid DP common                                |
| **Frequency**         | Graphs appear in ~40% of rounds, DP in ~35%                                |
| **Style**             | Open-ended, expect you to derive optimal from scratch                      |
| **CP depth needed?**  | No, but pattern speed matters                                              |
| **Priority patterns** | BFS multi-source, Dijkstra variants, Topo sort, LCS, Knapsack, Interval DP |

### Meta

| Factor                | Detail                                                            |
| --------------------- | ----------------------------------------------------------------- |
| **Rounds**            | 2 coding + system design + behavioral                             |
| **Difficulty**        | Medium-Hard mix                                                   |
| **Graph usage**       | Medium — BFS/DFS/Union Find common                                |
| **DP depth**          | Medium — 1D/2D DP, LIS, Palindrome                                |
| **Style**             | Pattern recognition speed valued; expect follow-ups on complexity |
| **CP depth needed?**  | No                                                                |
| **Priority patterns** | Two pointer, BFS/DFS, Sliding window, Tree DP, Backtracking       |

### Amazon

| Factor                | Detail                                                              |
| --------------------- | ------------------------------------------------------------------- |
| **Rounds**            | 2 OA rounds + 4–5 interviews (LP + code)                            |
| **Difficulty**        | Medium dominant                                                     |
| **Graph usage**       | Medium — usually BFS/DFS                                            |
| **DP depth**          | Low-Medium — basic knapsack, memoization                            |
| **Style**             | Code + Leadership Principles justification                          |
| **CP depth needed?**  | No                                                                  |
| **Priority patterns** | Graphs (shortest path), Trees, Backtracking, Two pointer, DP basics |

### Apple

| Factor               | Detail                                                    |
| -------------------- | --------------------------------------------------------- |
| **Rounds**           | 3–4 technical rounds                                      |
| **Difficulty**       | Medium-Hard                                               |
| **Graph usage**      | Medium                                                    |
| **DP depth**         | Medium                                                    |
| **Style**            | Correctness + code quality weighted; fewer trick problems |
| **CP depth needed?** | No                                                        |

### Netflix

| Factor               | Detail                                                |
| -------------------- | ----------------------------------------------------- |
| **Rounds**           | Fewer rounds but very senior bar                      |
| **Difficulty**       | Hard                                                  |
| **Graph usage**      | High — content graph, recommendation systems          |
| **DP depth**         | Medium-High                                           |
| **Style**            | System design weighted heavily; DSA is qualifying bar |
| **CP depth needed?** | No                                                    |

### Atlassian

| Factor                | Detail                                               |
| --------------------- | ---------------------------------------------------- |
| **Rounds**            | 1–2 coding + system design                           |
| **Difficulty**        | Medium                                               |
| **Graph usage**       | High — Jira DAG, issue dependencies, workflow graphs |
| **DP depth**          | Low-Medium                                           |
| **Style**             | Practical problem-solving, clean code valued         |
| **CP depth needed?**  | No                                                   |
| **Priority patterns** | BFS/DFS, Topological sort, Trees, String processing  |

### Uber

| Factor                | Detail                                                   |
| --------------------- | -------------------------------------------------------- |
| **Rounds**            | 2–3 coding + system design                               |
| **Difficulty**        | Medium-Hard                                              |
| **Graph usage**       | Very high — routing, shortest path, surge pricing graphs |
| **DP depth**          | Medium                                                   |
| **Style**             | Real-world modeling; map/geo problems frequent           |
| **CP depth needed?**  | No                                                       |
| **Priority patterns** | Dijkstra, BFS, Union Find, Interval problems, Greedy     |

### Flipkart

| Factor                | Detail                                                 |
| --------------------- | ------------------------------------------------------ |
| **Rounds**            | 1 OA + 3–4 interviews                                  |
| **Difficulty**        | Medium                                                 |
| **Graph usage**       | Medium — supply chain, delivery graph                  |
| **DP depth**          | Medium                                                 |
| **Style**             | Similar to Amazon; LP-light                            |
| **CP depth needed?**  | No                                                     |
| **Priority patterns** | Trees, Graphs, DP (knapsack/coin change), Backtracking |

## 2.2 Comparison Table — Topic Weight by Company

| Topic         | Google | Meta | Amazon | Apple | Netflix | Atlassian | Uber  | Flipkart |
| ------------- | ------ | ---- | ------ | ----- | ------- | --------- | ----- | -------- |
| Graph BFS/DFS | ★★★★★  | ★★★★ | ★★★    | ★★★   | ★★★★    | ★★★★★     | ★★★★★ | ★★★      |
| Shortest Path | ★★★★★  | ★★★  | ★★★    | ★★★   | ★★★★    | ★★★       | ★★★★★ | ★★★      |
| Topo Sort     | ★★★★   | ★★★  | ★★     | ★★★   | ★★★     | ★★★★★     | ★★★   | ★★★      |
| Union Find    | ★★★★   | ★★★  | ★★     | ★★    | ★★★     | ★★        | ★★★   | ★★       |
| 1D DP         | ★★★★   | ★★★★ | ★★★    | ★★★   | ★★★     | ★★        | ★★★   | ★★★★     |
| 2D DP         | ★★★★★  | ★★★  | ★★     | ★★★   | ★★★★    | ★★        | ★★★   | ★★★      |
| Interval DP   | ★★★★★  | ★★★  | ★★     | ★★★   | ★★★     | ★★        | ★★    | ★★       |
| String DP     | ★★★★   | ★★★★ | ★★★    | ★★★   | ★★★     | ★★★       | ★★    | ★★★      |
| Tree DP       | ★★★★   | ★★★★ | ★★★    | ★★★   | ★★★     | ★★★       | ★★★   | ★★★      |
| Backtracking  | ★★★★   | ★★★★ | ★★★★   | ★★★   | ★★★     | ★★★       | ★★★   | ★★★★     |

---

# 3. Six-Month Master Roadmap

## Month 1 — Reactivation + Graph Foundations

| Parameter            | Detail                                                             |
| -------------------- | ------------------------------------------------------------------ |
| **Goal**             | Kill the restart loop. Enter Graph with momentum.                  |
| **Topics**           | Warmup (5–10Q), Graph representation, BFS, DFS, Cycle detection    |
| **Hours/week**       | 21–28 hrs (3–4 hrs/day)                                            |
| **Question target**  | 35–40 problems                                                     |
| **Revision target**  | Re-solve all warmup problems blind by Week 3                       |
| **Mock target**      | 0 (too early)                                                      |
| **Expected outcome** | Confident graph traversal. Can solve Medium BFS/DFS independently. |

## Month 2 — Graph Depth + Advanced Graph

| Parameter            | Detail                                                              |
| -------------------- | ------------------------------------------------------------------- |
| **Goal**             | Complete graph mastery. Shortest paths, Topo sort, Union Find, MST. |
| **Topics**           | Dijkstra, Bellman-Ford, Topological Sort, Union Find, Kruskal/Prim  |
| **Hours/week**       | 21–28 hrs                                                           |
| **Question target**  | 45–50 problems                                                      |
| **Revision target**  | Month 1 Graph problems — full blind re-solve                        |
| **Mock target**      | 1 mock (graph-only)                                                 |
| **Expected outcome** | Can tackle any Medium graph problem; Hard graph attempted.          |

## Month 3 — DP Foundations + 1D/2D DP

| Parameter            | Detail                                                             |
| -------------------- | ------------------------------------------------------------------ |
| **Goal**             | Break the DP mental block. Master memoization → tabulation flow.   |
| **Topics**           | 1D DP, Fibonacci variants, Coin Change, House Robber, 2D grid DP   |
| **Hours/week**       | 21–28 hrs                                                          |
| **Question target**  | 40–45 problems                                                     |
| **Revision target**  | Graph Month 1+2 — 20 most important problems                       |
| **Mock target**      | 1 mock (mixed: graph + easy DP)                                    |
| **Expected outcome** | Fluent in 1D/2D DP. Can define state and transition independently. |

## Month 4 — DP Depth + Subsequence / Knapsack / String DP

| Parameter            | Detail                                                              |
| -------------------- | ------------------------------------------------------------------- |
| **Goal**             | Complete DP mastery at FAANG interview bar                          |
| **Topics**           | LIS, LCS, Edit Distance, Knapsack variants, Partition DP, String DP |
| **Hours/week**       | 21–28 hrs                                                           |
| **Question target**  | 45–50 problems                                                      |
| **Revision target**  | All DP Month 3 blind re-solve + 10 graph hard problems              |
| **Mock target**      | 2 mocks                                                             |
| **Expected outcome** | Can identify DP patterns from problem statement alone.              |

## Month 5 — Consolidation + Hard Problems + Mock Ramp

| Parameter            | Detail                                                                                |
| -------------------- | ------------------------------------------------------------------------------------- |
| **Goal**             | Elevate to Hard territory. Start mock interviews seriously.                           |
| **Topics**           | Hard Graph (Tarjan, bridges, SCC), Hard DP (bitmask, interval), Backtracking advanced |
| **Hours/week**       | 21–28 hrs                                                                             |
| **Question target**  | 45–50 problems (mix Easy/Medium/Hard: 10/25/15)                                       |
| **Revision target**  | Monthly: all topics since Month 1 via spaced repetition                               |
| **Mock target**      | 4 mocks                                                                               |
| **Expected outcome** | Consistently solving Medium Hard. Occasional Hard. Mock scores improving.             |

## Month 6 — Interview Mode

| Parameter            | Detail                                                                            |
| -------------------- | --------------------------------------------------------------------------------- |
| **Goal**             | Full simulation. Refinement only, no new topics.                                  |
| **Topics**           | Company-specific problem sets, revision only, mock interview daily                |
| **Hours/week**       | 21–28 hrs                                                                         |
| **Question target**  | 30–35 problems (revision + company-tagged)                                        |
| **Revision target**  | Entire vault — SR system governs                                                  |
| **Mock target**      | 8–10 mocks                                                                        |
| **Expected outcome** | Interview-ready. Communicates clearly under pressure. Handles 85% of Medium cold. |

---

# 4. Warmup Phase (5–10 Questions Only)

> **Purpose:** Regain momentum without falling into the basics trap. These problems are chosen to feel good, be solvable fast, and cover bridges into Graph + DP.

| #   | Problem                         | Platform | Difficulty | Pattern                      | Reason Selected                                   |
| --- | ------------------------------- | -------- | ---------- | ---------------------------- | ------------------------------------------------- |
| 1   | Two Sum                         | LC #1    | Easy       | Hashing                      | Fast win. Confirms hashing pattern is live.       |
| 2   | Best Time to Buy and Sell Stock | LC #121  | Easy       | Sliding Window / Greedy      | Bridges sliding window → DP later.                |
| 3   | Valid Parentheses               | LC #20   | Easy       | Stack                        | Confirms stack still sharp.                       |
| 4   | Number of Islands               | LC #200  | Medium     | BFS/DFS                      | **Direct on-ramp to Graph.**                      |
| 5   | Clone Graph                     | LC #133  | Medium     | BFS/DFS + HashMap            | Forces graph node construction — essential.       |
| 6   | Word Ladder                     | LC #127  | Medium     | BFS (shortest path on graph) | Bridges word problems to graph thinking.          |
| 7   | Merge Intervals                 | LC #56   | Medium     | Intervals + Sorting          | Warm up sorting instinct. DP-adjacent.            |
| 8   | Climbing Stairs                 | LC #70   | Easy       | 1D DP (Fibonacci)            | First DP. Easiest possible entry.                 |
| 9   | Coin Change                     | LC #322  | Medium     | 1D DP (unbounded knapsack)   | The canonical DP problem. Teach memoization.      |
| 10  | Course Schedule                 | LC #207  | Medium     | Topo Sort + Cycle Detection  | Combines Graph + real-world (Atlassian-relevant). |

**Rules for warmup phase:**

- Time box: Max 7 days total.
- If you solve all 10 in 5 days, move on immediately.
- Do NOT add more problems. Resist.
- After completing: you are **no longer in warmup**. You are in Graph phase.

---

# 5. Graph Mastery Phase

## 5.1 Theory Order (Non-Negotiable)

```
Graph Representation
        ↓
       BFS
        ↓
       DFS
        ↓
   Cycle Detection
        ↓
  Topological Sort
        ↓
  Shortest Paths (BFS unweighted → Dijkstra → Bellman-Ford)
        ↓
    Union Find
        ↓
       MST
        ↓
  Bridges / Articulation Points (Tarjan)
        ↓
    Advanced (SCC, Floyd-Warshall, multi-source BFS)
```

---

## 5.2 Topic Deep Dives

### Graph Representation

| Aspect                   | Detail                                                                          |
| ------------------------ | ------------------------------------------------------------------------------- |
| **Concept**              | Adjacency List (HashMap / List[]), Adjacency Matrix, Edge List                  |
| **Mental model**         | Adjacency list = phone contacts per person. Matrix = Excel grid of connections. |
| **Interview importance** | Every single graph problem. Non-negotiable.                                     |
| **Difficulty**           | Easy                                                                            |
| **Pattern**              | Build graph from edges, then traverse                                           |
| **Common mistake**       | Using 1-indexed vs 0-indexed nodes wrong. Off by one in n+1 allocation.         |
| **Questions**            | LC #133 (Clone Graph), LC #797 (All Paths from Source)                          |

**C# snippet — Adjacency List:**

```csharp
var graph = new Dictionary<int, List<int>>();
foreach (var edge in edges) {
    if (!graph.ContainsKey(edge[0])) graph[edge[0]] = new List<int>();
    if (!graph.ContainsKey(edge[1])) graph[edge[1]] = new List<int>();
    graph[edge[0]].Add(edge[1]);
    graph[edge[1]].Add(edge[0]); // undirected
}
```

---

### BFS (Breadth-First Search)

| Aspect                   | Detail                                                                                        |
| ------------------------ | --------------------------------------------------------------------------------------------- |
| **Concept**              | Level-order traversal using Queue                                                             |
| **Mental model**         | Ripples in a pond — closest nodes first                                                       |
| **Interview importance** | ★★★★★ — Shortest path on unweighted graphs, multi-source BFS, flood fill                      |
| **Difficulty**           | Easy-Medium                                                                                   |
| **Patterns**             | Shortest path unweighted, level-by-level processing, multi-source BFS                         |
| **Common mistakes**      | Not marking visited BEFORE enqueue (causes duplicates). Forgetting edge case: isolated nodes. |

**Template (C#):**

```csharp
var queue = new Queue<int>();
var visited = new HashSet<int>();
queue.Enqueue(start);
visited.Add(start);

while (queue.Count > 0) {
    int node = queue.Dequeue();
    // process node
    foreach (var neighbor in graph[node]) {
        if (!visited.Contains(neighbor)) {
            visited.Add(neighbor);
            queue.Enqueue(neighbor);
        }
    }
}
```

**Question Progression:**

1. LC #200 — Number of Islands (BFS basics)
2. LC #286 — Walls and Gates (Multi-source BFS)
3. LC #994 — Rotting Oranges (Multi-source BFS with time tracking)
4. LC #127 — Word Ladder (BFS on implicit graph)
5. LC #1926 — Nearest Exit from Entrance in Maze
6. LC #1091 — Shortest Path in Binary Matrix

---

### DFS (Depth-First Search)

| Aspect                   | Detail                                                                                        |
| ------------------------ | --------------------------------------------------------------------------------------------- |
| **Concept**              | Recursive or iterative (stack) — go deep before going wide                                    |
| **Mental model**         | Exploring a cave — go as deep as possible, backtrack                                          |
| **Interview importance** | ★★★★★ — Connected components, path finding, backtracking                                      |
| **Difficulty**           | Easy-Medium                                                                                   |
| **Patterns**             | Flood fill, connected components, path enumeration, island perimeter                          |
| **Common mistakes**      | Stack overflow on large graphs (use iterative). Forgetting to mark visited in recursive case. |

**Template (C#):**

```csharp
void DFS(int node, HashSet<int> visited, Dictionary<int, List<int>> graph) {
    visited.Add(node);
    // process node
    foreach (var neighbor in graph[node]) {
        if (!visited.Contains(neighbor)) {
            DFS(neighbor, visited, graph);
        }
    }
}
```

**Question Progression:**

1. LC #200 — Number of Islands
2. LC #130 — Surrounded Regions
3. LC #417 — Pacific Atlantic Water Flow
4. LC #695 — Max Area of Island
5. LC #547 — Number of Provinces
6. LC #1020 — Number of Enclaves

---

### Cycle Detection

| Aspect                   | Detail                                                                      |
| ------------------------ | --------------------------------------------------------------------------- |
| **Concept**              | Undirected: visited + parent tracking. Directed: visited + recursion stack. |
| **Mental model**         | Directed: "Am I visiting a node that I'm currently processing upstream?"    |
| **Interview importance** | ★★★★ — Prerequisite check, deadlock detection                               |
| **Difficulty**           | Medium                                                                      |
| **Patterns**             | Three-color DFS (WHITE/GRAY/BLACK), parent check in undirected              |
| **Common mistakes**      | Confusing undirected and directed cycle detection logic                     |

**Question Progression:**

1. LC #207 — Course Schedule (directed, detect cycle)
2. LC #802 — Find Eventual Safe States
3. LC #684 — Redundant Connection (undirected)
4. LC #685 — Redundant Connection II (directed)

---

### Topological Sort

| Aspect                   | Detail                                                                             |
| ------------------------ | ---------------------------------------------------------------------------------- |
| **Concept**              | Linear order of a DAG. Two approaches: Kahn's (BFS-based, in-degree) and DFS-based |
| **Mental model**         | Course prerequisites: take courses with no dependencies first                      |
| **Interview importance** | ★★★★★ — Atlassian (Jira DAG), build systems, scheduling                            |
| **Difficulty**           | Medium                                                                             |
| **Patterns**             | In-degree array, queue, Kahn's algorithm                                           |
| **Common mistakes**      | Not detecting cycle (if result length < number of nodes, cycle exists)             |

**Kahn's Algorithm (C#):**

```csharp
int[] inDegree = new int[n];
var graph = new List<List<int>>();
// build graph and inDegree...

var queue = new Queue<int>();
for (int i = 0; i < n; i++)
    if (inDegree[i] == 0) queue.Enqueue(i);

var order = new List<int>();
while (queue.Count > 0) {
    int node = queue.Dequeue();
    order.Add(node);
    foreach (var neighbor in graph[node]) {
        if (--inDegree[neighbor] == 0) queue.Enqueue(neighbor);
    }
}
bool valid = order.Count == n; // false = cycle exists
```

**Question Progression:**

1. LC #207 — Course Schedule
2. LC #210 — Course Schedule II
3. LC #310 — Minimum Height Trees
4. LC #329 — Longest Increasing Path in Matrix
5. LC #269 — Alien Dictionary _(Hard — important for Google)_

---

### Shortest Path

#### Unweighted — BFS

> Already covered. Use BFS for unit-weight graphs.

#### Dijkstra (Non-negative weights)

| Aspect                   | Detail                                                                          |
| ------------------------ | ------------------------------------------------------------------------------- |
| **Concept**              | Greedy + Min-Heap. Relax edges by always picking the cheapest unvisited node.   |
| **Mental model**         | Uber surge pricing — always dispatch the closest driver (cheapest edge)         |
| **Interview importance** | ★★★★★ — Uber, Google Maps, network routing problems                             |
| **Difficulty**           | Medium-Hard                                                                     |
| **Pattern**              | `PriorityQueue<(dist, node)>`, visited set, dist array initialized to ∞         |
| **Common mistakes**      | Not skipping stale entries from heap. Using negative weights (breaks Dijkstra). |

**Template (C#):**

```csharp
var dist = new int[n];
Array.Fill(dist, int.MaxValue);
dist[src] = 0;

var pq = new PriorityQueue<(int dist, int node), int>();
pq.Enqueue((0, src), 0);

while (pq.Count > 0) {
    var (d, u) = pq.Dequeue();
    if (d > dist[u]) continue; // stale entry
    foreach (var (v, w) in graph[u]) {
        if (dist[u] + w < dist[v]) {
            dist[v] = dist[u] + w;
            pq.Enqueue((dist[v], v), dist[v]);
        }
    }
}
```

**Question Progression:**

1. LC #743 — Network Delay Time
2. LC #1631 — Path with Minimum Effort
3. LC #787 — Cheapest Flights Within K Stops (modified Dijkstra)
4. LC #1514 — Path with Maximum Probability
5. LC #778 — Swim in Rising Water _(binary search on Dijkstra)_

#### Bellman-Ford (Negative weights / detect negative cycles)

| Aspect                   | Detail                                                                              |
| ------------------------ | ----------------------------------------------------------------------------------- |
| **Concept**              | Relax all edges n-1 times. O(VE) — slow but handles negatives.                      |
| **Mental model**         | Try every road n-1 times — eventually find the shortest path even through negatives |
| **Interview importance** | ★★★ — Specifically for negative weights / currency exchange problems                |
| **Difficulty**           | Medium                                                                              |
| **Common mistakes**      | Forgetting the nth relaxation pass to detect negative cycles                        |

**Question Progression:**

1. LC #787 — Cheapest Flights Within K Stops (BF variant)
2. LC #743 — Network Delay Time (compare BF vs Dijkstra)
3. Currency arbitrage (conceptual, Google/quant-adjacent)

---

### Union Find (Disjoint Set Union — DSU)

| Aspect                   | Detail                                                                                    |
| ------------------------ | ----------------------------------------------------------------------------------------- |
| **Concept**              | Track connected components. Union by rank + path compression.                             |
| **Mental model**         | Group of friends: find the leader of each group. Merging groups = union.                  |
| **Interview importance** | ★★★★ — Connected components, MST (Kruskal), detecting redundant edges                     |
| **Difficulty**           | Medium                                                                                    |
| **Pattern**              | `Find(x)` with path compression, `Union(x, y)` with rank                                  |
| **Common mistakes**      | Not implementing path compression → TLE. Forgetting to check same component before union. |

**Template (C#):**

```csharp
int[] parent, rank;
void Init(int n) {
    parent = Enumerable.Range(0, n).ToArray();
    rank = new int[n];
}
int Find(int x) => parent[x] == x ? x : parent[x] = Find(parent[x]);
bool Union(int x, int y) {
    int px = Find(x), py = Find(y);
    if (px == py) return false;
    if (rank[px] < rank[py]) (px, py) = (py, px);
    parent[py] = px;
    if (rank[px] == rank[py]) rank[px]++;
    return true;
}
```

**Question Progression:**

1. LC #547 — Number of Provinces
2. LC #684 — Redundant Connection
3. LC #990 — Satisfiability of Equality Equations
4. LC #1202 — Smallest String With Swaps
5. LC #1319 — Number of Operations to Make Network Connected
6. LC #721 — Accounts Merge _(Hard — important)_

---

### Minimum Spanning Tree (MST)

| Aspect                   | Detail                                                        |
| ------------------------ | ------------------------------------------------------------- |
| **Concept**              | Kruskal (sort edges + DSU) or Prim (greedy + min-heap)        |
| **Mental model**         | Build a network connecting all cities with minimum cable cost |
| **Interview importance** | ★★★ — Less frequent but present in Google/Amazon              |
| **Difficulty**           | Medium-Hard                                                   |

**Question Progression:**

1. LC #1135 — Connecting Cities With Minimum Cost
2. LC #1168 — Optimize Water Distribution in a Village
3. LC #1584 — Min Cost to Connect All Points

---

### Tarjan's Algorithm (Bridges, Articulation Points, SCC)

| Aspect                   | Detail                                                                               |
| ------------------------ | ------------------------------------------------------------------------------------ |
| **Concept**              | DFS with discovery time and low-link values                                          |
| **Mental model**         | Critical network links — removing them disconnects the network                       |
| **Interview importance** | ★★★ — Google Hard, network reliability                                               |
| **Difficulty**           | Hard                                                                                 |
| **When to use**          | Finding bridges (critical edges), articulation points, Strongly Connected Components |

**Question Progression:**

1. LC #1192 — Critical Connections in a Network (Bridges)
2. LC #1489 — Find Critical and Pseudo-Critical Edges
3. Concept: SCC via Kosaraju or Tarjan (understand algorithm, implement once)

---

### Advanced Graph Patterns

| Pattern                       | Key Problems     | Companies                |
| ----------------------------- | ---------------- | ------------------------ |
| Multi-source BFS              | LC #994, LC #286 | Google, Meta             |
| BFS on implicit graph         | LC #127, LC #433 | Google                   |
| 0-1 BFS                       | LC #1368         | Google, Uber             |
| Bidirectional BFS             | LC #127 variant  | Google                   |
| Graph coloring / bipartite    | LC #785, LC #886 | Meta, Google             |
| Euler path/circuit            | LC #332          | Google                   |
| Floyd-Warshall (all pairs)    | LC #1334         | Amazon                   |
| Network flow (awareness only) | —                | Not common in interviews |

---

# 6. Dynamic Programming Mastery Phase

## 6.1 The DP Mental Framework (Read Before Solving Anything)

> DP is not memorizing solutions. DP is recognizing the **overlapping subproblem signal** and building state.

**The 4-Step DP Protocol:**

1. **Identify** — "Can I break this into smaller identical subproblems?"
2. **Define state** — `dp[i]` = ? (be explicit and verbose)
3. **Write transition** — How does `dp[i]` depend on previous states?
4. **Handle base cases** — What are the terminal values?

**Recognition signal:**

- Problem asks for: _min/max/count/exists_ over a combinatorial space
- Brute force is exponential (2^n or n!)
- Subproblems repeat (draw recursion tree — notice overlap)

---

## 6.2 1D DP

| Aspect                  | Detail                                                             |
| ----------------------- | ------------------------------------------------------------------ |
| **Mental model**        | Each cell answers: "What's the best answer _up to_ this point?"    |
| **State definition**    | `dp[i]` = answer for first i elements / subproblem of size i       |
| **Transition**          | Usually: `dp[i] = f(dp[i-1], dp[i-2], ...)`                        |
| **Interview frequency** | ★★★★★                                                              |
| **Optimization**        | Often reducible to O(1) space (rolling variables)                  |
| **Common mistakes**     | Wrong base case. Not thinking about what dp[0] means semantically. |

**Question Progression:**

1. LC #70 — Climbing Stairs (base case practice)
2. LC #198 — House Robber
3. LC #213 — House Robber II (circular variant)
4. LC #300 — Longest Increasing Subsequence
5. LC #322 — Coin Change
6. LC #139 — Word Break
7. LC #91 — Decode Ways (edge cases)
8. LC #152 — Maximum Product Subarray (Kadane variant)
9. LC #416 — Partition Equal Subset Sum
10. LC #494 — Target Sum

---

## 6.3 2D DP / Grid DP

| Aspect                  | Detail                                                                            |
| ----------------------- | --------------------------------------------------------------------------------- |
| **Mental model**        | Fill a table where `dp[i][j]` = answer for subproblem (i, j)                      |
| **State definition**    | `dp[i][j]` = answer using first i of A and first j of B, OR at cell (i,j) of grid |
| **Transition**          | Usually: top, left, or diagonal neighbor                                          |
| **Interview frequency** | ★★★★★ — Google especially                                                         |
| **Optimization**        | Current row only needs previous row → O(n) space                                  |
| **Common mistakes**     | Off-by-one in index mapping. Forgetting to initialize first row/col.              |

**Question Progression:**

1. LC #62 — Unique Paths (baseline 2D)
2. LC #63 — Unique Paths II (with obstacles)
3. LC #64 — Minimum Path Sum
4. LC #221 — Maximal Square
5. LC #931 — Minimum Falling Path Sum
6. LC #1143 — LCS (two-sequence 2D DP)
7. LC #72 — Edit Distance _(Hard — critically important)_
8. LC #97 — Interleaving String
9. LC #174 — Dungeon Game (reverse DP)
10. LC #741 — Cherry Pickup _(Hard — 2-agent 2D DP)_

---

## 6.4 Subsequence DP

| Aspect                  | Detail                                                                          |
| ----------------------- | ------------------------------------------------------------------------------- |
| **Mental model**        | "I can either use or not use each element"                                      |
| **Recognition pattern** | Contains word "subsequence" (not substring) — think 2D table over two sequences |
| **State definition**    | `dp[i][j]` = answer for A[0..i-1] and B[0..j-1]                                 |
| **Transition**          | If match: `dp[i][j] = dp[i-1][j-1] + something`. Else: max/min of adjacent.     |
| **Mistakes**            | LCS vs LIS confusion. LCS needs 2D; LIS needs 1D.                               |

**Question Progression:**

1. LC #1143 — Longest Common Subsequence
2. LC #300 — Longest Increasing Subsequence (binary search O(n log n) variant)
3. LC #115 — Distinct Subsequences _(Hard)_
4. LC #516 — Longest Palindromic Subsequence
5. LC #1312 — Minimum Insertions to Make String Palindrome

---

## 6.5 Knapsack Variants

| Variant                | Mental Model                          | Key Problem                                 |
| ---------------------- | ------------------------------------- | ------------------------------------------- |
| **0/1 Knapsack**       | Take or skip each item (can't repeat) | LC #416 Partition Equal Subset Sum          |
| **Unbounded Knapsack** | Can reuse items infinitely            | LC #322 Coin Change, LC #518 Coin Change II |
| **Bounded Knapsack**   | Limited copies of each item           | Less common in interviews                   |
| **Multiple Knapsack**  | Awareness only                        | Not FAANG-interview level                   |

**Knapsack recognition pattern:**

> "Given items with weight/value, optimize total with a capacity constraint" — 0/1 or unbounded

**Question Progression:**

1. LC #416 — Partition Equal Subset Sum (0/1)
2. LC #494 — Target Sum (count variant)
3. LC #518 — Coin Change II (unbounded, count)
4. LC #474 — Ones and Zeroes (2D knapsack)
5. LC #1049 — Last Stone Weight II

---

## 6.6 String DP

| Aspect                  | Detail                                                                |
| ----------------------- | --------------------------------------------------------------------- |
| **Mental model**        | Two strings → 2D table. One string → 1D with interval or index        |
| **Recognition**         | Edit distance, interleaving, wildcard matching, distinct subsequences |
| **Interview frequency** | ★★★★ — Google especially                                              |
| **Mistakes**            | Not handling empty string base cases. Wrong transition on mismatch.   |

**Question Progression:**

1. LC #72 — Edit Distance
2. LC #10 — Regular Expression Matching _(Hard)_
3. LC #44 — Wildcard Matching _(Hard)_
4. LC #97 — Interleaving String
5. LC #115 — Distinct Subsequences
6. LC #647 — Palindromic Substrings (expand around center vs DP)
7. LC #5 — Longest Palindromic Substring

---

## 6.7 Interval DP

| Aspect                  | Detail                                                                     |
| ----------------------- | -------------------------------------------------------------------------- |
| **Mental model**        | Solve for smaller intervals, build up to larger                            |
| **Recognition**         | "Burst", "merge", "optimal parenthesization" — ranges defined by [i, j]    |
| **State definition**    | `dp[i][j]` = answer for range [i..j]                                       |
| **Transition**          | Iterate over split point k: `dp[i][j] = min(dp[i][k] + dp[k+1][j] + cost)` |
| **Interview frequency** | ★★★★ — Google loves this pattern                                           |
| **Mistakes**            | Wrong iteration order (length must grow outward)                           |

**Question Progression:**

1. LC #312 — Burst Balloons _(Hard — canonical interval DP)_
2. LC #1039 — Minimum Score Triangulation of Polygon
3. LC #1000 — Minimum Cost to Merge Stones
4. LC #516 — Longest Palindromic Subsequence (also interval DP)

---

## 6.8 Partition DP

| Aspect                  | Detail                                                 |
| ----------------------- | ------------------------------------------------------ |
| **Mental model**        | Split array into k parts optimally                     |
| **Recognition**         | "Divide array into k groups", "cut", "split with cost" |
| **State**               | `dp[i][k]` = answer for first i elements with k cuts   |
| **Interview frequency** | ★★★                                                    |

**Question Progression:**

1. LC #813 — Largest Sum of Averages
2. LC #1043 — Partition Array for Maximum Sum
3. LC #410 — Split Array Largest Sum _(binary search also works — know both)_

---

## 6.9 State / Bitmask DP

| Aspect                  | Detail                                                   |
| ----------------------- | -------------------------------------------------------- |
| **Mental model**        | State = bitmask of which items you've used               |
| **Recognition**         | n ≤ 20, "visit all nodes", "assign each item to a state" |
| **Interview frequency** | ★★ — Hard, but appears at Google                         |
| **Mistakes**            | Bit indexing errors. Forgetting to initialize dp with ∞  |

**Question Progression:**

1. LC #526 — Beautiful Arrangement
2. LC #691 — Stickers to Spell Word _(Hard)_
3. LC #847 — Shortest Path Visiting All Nodes _(Hard — BFS + bitmask)_

---

## 6.10 Tree DP

| Aspect                  | Detail                                                         |
| ----------------------- | -------------------------------------------------------------- |
| **Mental model**        | Bottom-up DP on tree — each node aggregates from its children  |
| **Recognition**         | "Maximum/min path in tree", "diameter", "house robber on tree" |
| **Interview frequency** | ★★★★ — Very common in FAANG                                    |
| **State**               | Usually: `dp[node]` = answer for subtree rooted at node        |

**Question Progression:**

1. LC #337 — House Robber III
2. LC #543 — Diameter of Binary Tree
3. LC #124 — Binary Tree Maximum Path Sum _(Hard)_
4. LC #968 — Binary Tree Cameras _(Hard)_
5. LC #1245 — Tree Diameter

---

# 7. Topic-wise Elite Resources

## 7.1 Primary Learning Platforms

| Resource                   | URL              | Why Elite                                                                          |
| -------------------------- | ---------------- | ---------------------------------------------------------------------------------- |
| **NeetCode.io**            | neetcode.io      | Curated 150/250 problem list + video for every problem. Best interview ROI.        |
| **TakeUForward (Striver)** | takeuforward.org | Best structured Graph + DP series. Step-by-step theory + 10–15 problems per topic. |
| **AlgoMonster**            | algo.monster     | Pattern-based learning. Maps every LC problem to a pattern family.                 |
| **LeetCode**               | leetcode.com     | Ground truth for problem practice. Use company tags + frequency filters.           |

**Your priority stack:** TakeUForward (theory) → NeetCode (curated problems) → LeetCode (practice).

---

## 7.2 Graph Resources

| Resource                       | Type                    | Why                                                                                        |
| ------------------------------ | ----------------------- | ------------------------------------------------------------------------------------------ |
| **Striver's Graph Series**     | TakeUForward playlist   | 54-video series. Best structured graph learning in existence. Theory → problems per topic. |
| **NeetCode Graph playlist**    | YouTube                 | Each video = one problem pattern explained with code.                                      |
| **VisuAlgo — Graph**           | visualgo.net/en/graphds | Visual BFS/DFS/Dijkstra step-by-step. Use for mental model formation.                      |
| **CP-Algorithms**              | cp-algorithms.com       | Deep reference for Dijkstra, Bellman-Ford, Tarjan. Only for reference.                     |
| **LC #blind75 / #neetcode150** | LeetCode lists          | These are the canonical graph problem sets for interviews.                                 |

---

## 7.3 DP Resources

| Resource                              | Type                  | Why                                                                                        |
| ------------------------------------- | --------------------- | ------------------------------------------------------------------------------------------ |
| **Striver's DP Series**               | TakeUForward          | 56-video series. Best DP learning resource on the internet. Covers all interview patterns. |
| **NeetCode DP playlist**              | YouTube               | Excellent for pattern recognition and code walkthroughs.                                   |
| **"Dynamic Programming is not hard"** | GitHub: vnmakarov/mir | Conceptual clarity for state definition strategy.                                          |
| **Aditya Verma DP playlist**          | YouTube               | Specifically for Knapsack variants. Best knapsack explanation available.                   |
| **LC DP study plan**                  | LeetCode              | 45-day official study plan. Good for structured problem exposure.                          |

---

## 7.4 YouTube: Watch Once, Understand Forever

| Topic                  | Channel                | Specific Video/Playlist          | Why                                                   |
| ---------------------- | ---------------------- | -------------------------------- | ----------------------------------------------------- |
| **Graph fundamentals** | Striver (TakeUForward) | Graph Series Playlist            | Explains from scratch with code, builds mental models |
| **Dijkstra**           | NeetCode               | "Dijkstra's Algorithm"           | Cleanest explanation of heap-based Dijkstra           |
| **Union Find**         | William Fiset          | "Union Find" playlist            | Visual step-by-step, best in class                    |
| **DP mental model**    | Striver                | DP Series (video 1–5)            | Changes how you think about DP problems permanently   |
| **Knapsack**           | Aditya Verma           | Knapsack Playlist                | The canonical knapsack explanation                    |
| **Topological Sort**   | NeetCode               | "Course Schedule" video          | Best explanation of both Kahn's + DFS approaches      |
| **Backtracking**       | NeetCode               | Backtracking Playlist            | Decision tree mental model — essential                |
| **LIS**                | Striver                | "Longest Increasing Subsequence" | Explains O(n log n) with patience sorting analogy     |

---

## 7.5 Elite Misc Resources

| Resource                            | Type             | Use Case                                                               |
| ----------------------------------- | ---------------- | ---------------------------------------------------------------------- |
| **NeetCode 150**                    | Problem Sheet    | Primary problem list. Print/bookmark.                                  |
| **Striver SDE Sheet**               | Problem Sheet    | Backup problem list. More comprehensive than NC150.                    |
| **Grind 75**                        | Problem Sheet    | Time-boxed preparation (use in Month 6 for last sprint)                |
| **LeetCode company tags (premium)** | Problem Filter   | Filter by Google/Meta/Amazon + last 6 months. Worth $35.               |
| **VisuAlgo**                        | Visual Simulator | BFS/DFS/Dijkstra/Union Find visualization                              |
| **Algorithm Visualizer**            | Visual Simulator | github.com/algorithm-visualizer — animated code execution              |
| **Anki**                            | Flashcard Tool   | Create cards for: state definitions, complexity, common mistakes       |
| **CS Dojo — Big-O cheat sheet**     | Cheat Sheet      | bigocheatsheet.com — complexity reference                              |
| **Tech Interview Handbook**         | Guide            | techinterviewhandbook.org — comprehensive end-to-end guide             |
| **Blind (TeamBlind)**               | Community        | Interview experience reports per company. Use for calibration.         |
| **Leetcode Discuss**                | Community        | Best editorial alternatives. Search "[problem name] solution approach" |

---

# 8. Problem Solving System

## 8.1 The Full Workflow

```
Read problem
    ↓
Understand (5 min)
 - Restate in own words
 - Identify input/output types
 - Find edge cases (empty, single, duplicates, negatives)
    ↓
Identify pattern (5 min)
 - Which category? (Graph / DP / Two Pointer / etc.)
 - What's the brute force?
 - Can I optimize?
    ↓
Attempt (25 min) ← HARD STOP
    ↓ (if stuck after 25 min)
Look at hint / topic tag (5 min)
    ↓ (if still stuck)
Read editorial approach (NOT code) (10 min)
    ↓
Code from scratch (not copy-paste)
    ↓
Dry run on 2 examples
    ↓
Tag and log the problem
```

## 8.2 Stuck State Protocol

| Time stuck             | Action                                                    |
| ---------------------- | --------------------------------------------------------- |
| 0–10 min               | Keep going. This is normal friction.                      |
| 10–20 min              | Re-read constraints. Draw the problem. Write brute force. |
| 20–25 min              | Peek at topic tag only (not solution).                    |
| 25+ min                | Read high-level approach from editorial. No code yet.     |
| After reading approach | Close editorial. Code it yourself.                        |

**Golden rule:** Never copy-paste solution code. Always retype from understanding.

## 8.3 Tagging System

For every problem solved, tag it:

```
Status: [Solved Clean | Solved w/ Hint | Read Editorial | Unsolved]
Pattern: [BFS | DFS | Dijkstra | UnionFind | 1D-DP | 2D-DP | Knapsack | ...]
Difficulty: [Easy | Medium | Hard]
Company: [Google | Meta | Amazon | Atlassian | Uber | Flipkart | General]
Revisit: [Yes | No]
Notes: [1-2 line personal insight]
```

## 8.4 Re-Solve Protocol

| Trigger                           | Action                                    |
| --------------------------------- | ----------------------------------------- |
| Solved with hint                  | Re-solve blind in 3 days                  |
| Solved clean                      | Re-solve blind in 1 week                  |
| Still not clean after 2nd attempt | Add to "Weak Patterns" list               |
| After 3 weeks                     | Quick re-solve (15 min) — confirm fluency |

## 8.5 Editorial Usage Rules

- Read editorial **approach** only (first paragraph). Then solve.
- If you re-read the code: rewrite it entirely in your own style.
- After reading any editorial: write a 2-line "mental model" note in your vault.
- Never read editorial within the first 20 minutes.

---

# 9. Company-wise Question Strategy

## 9.1 Google

**Profile:** Hardest. Values: novel thinking, clean solutions, handling edge cases, derivation from first principles.

| Factor           | Detail                                                                             |
| ---------------- | ---------------------------------------------------------------------------------- |
| Difficulty mix   | 20% Medium, 70% Hard, 10% "Graph/DP fusion"                                        |
| Priority topics  | Graph (BFS multi-source, Dijkstra, Topo sort, Tarjan), Interval DP, 2D DP, Tree DP |
| Prep approach    | Solve 50+ graph problems + 40+ DP problems. Practice verbal explanation.           |
| Problem patterns | LC Hard tagged Google (filter last 6 months on premium)                            |
| Secret weapon    | Practice explaining your approach before coding. Google values communication.      |

**Must-solve list (Google-tagged):**

- LC #269 Alien Dictionary
- LC #329 Longest Increasing Path in Matrix
- LC #312 Burst Balloons
- LC #1192 Critical Connections in Network
- LC #847 Shortest Path Visiting All Nodes
- LC #1235 Maximum Profit in Job Scheduling

---

## 9.2 Meta

**Profile:** Speed + accuracy. Pattern recognition at medium level is enough for most rounds.

| Factor           | Detail                                                                |
| ---------------- | --------------------------------------------------------------------- |
| Difficulty mix   | 60% Medium, 30% Hard, 10% Easy                                        |
| Priority topics  | BFS/DFS, Tree DP, Two Pointer, Backtracking, String DP                |
| Prep approach    | Drill NeetCode 150. Focus on medium speed (under 20 min per medium).  |
| Problem patterns | Graph connectivity, Binary tree operations, Backtracking permutations |

**Must-solve:**

- LC #236 LCA of Binary Tree
- LC #543 Diameter of Binary Tree
- LC #124 Binary Tree Maximum Path Sum
- LC #79 Word Search (backtracking)
- LC #51 N-Queens

---

## 9.3 Amazon

**Profile:** Medium-focused. DSA + Leadership Principles. LPs are non-negotiable.

| Factor                 | Detail                                                           |
| ---------------------- | ---------------------------------------------------------------- |
| Difficulty mix         | 70% Medium, 20% Hard, 10% Easy                                   |
| Priority topics        | Graphs (BFS/DFS/Topo), Trees, DP (Knapsack, basic), Backtracking |
| Prep approach          | DSA + prepare 8 STAR stories for LPs.                            |
| LP principles critical | Deliver Results, Customer Obsession, Ownership, Earn Trust       |

**Must-solve:**

- LC #1 Two Sum (variant questions)
- LC #200 Number of Islands
- LC #207 Course Schedule
- LC #322 Coin Change
- LC #347 Top K Frequent Elements

---

## 9.4 Atlassian

**Profile:** Practical. Graph (DAG workflows), clean code, design-aware.

| Factor          | Detail                                                                      |
| --------------- | --------------------------------------------------------------------------- |
| Difficulty mix  | 80% Medium, 20% Hard                                                        |
| Priority topics | Topological sort, BFS/DFS, String parsing, Trees, Union Find                |
| Prep approach   | Relate graph problems to Jira/workflow/dependency use cases in explanations |
| Secret weapon   | Clean code matters more here than pure speed.                               |

**Must-solve:**

- LC #210 Course Schedule II (topo sort)
- LC #310 Minimum Height Trees
- LC #1091 Shortest Path in Binary Matrix
- LC #721 Accounts Merge (Union Find)

---

## 9.5 Uber

**Profile:** Graph-heavy (routing, maps). Real-world modeling valued.

| Factor          | Detail                                                  |
| --------------- | ------------------------------------------------------- |
| Difficulty mix  | 60% Medium, 40% Hard                                    |
| Priority topics | Dijkstra, BFS, Union Find, Interval problems, Greedy    |
| Prep approach   | Frame solutions in terms of routing/delivery use cases. |

**Must-solve:**

- LC #743 Network Delay Time (Dijkstra)
- LC #787 Cheapest Flights K Stops
- LC #1631 Path with Minimum Effort
- LC #56 Merge Intervals

---

## 9.6 Flipkart

**Profile:** Amazon-like. Medium bar. Good entry target for confidence.

| Factor          | Detail                                                          |
| --------------- | --------------------------------------------------------------- |
| Difficulty mix  | 70% Medium, 20% Hard                                            |
| Priority topics | Trees, Graphs, DP (Knapsack/Coin Change), Backtracking, Sorting |
| Prep approach   | NeetCode 150 completion is sufficient.                          |

**Must-solve:**

- LC #322 Coin Change
- LC #416 Partition Equal Subset Sum
- LC #739 Daily Temperatures (Stack)
- LC #146 LRU Cache

---

# 10. Weekly Plan (24 Weeks)

> **Legend:** Q = LeetCode problems to solve. R = Revision. H = Hours/week.

---

### Weeks 1–2: Warmup + Graph Entry

| Week       | Topics                                            | Questions | Hours | Deliverables                                  |
| ---------- | ------------------------------------------------- | --------- | ----- | --------------------------------------------- |
| **Week 1** | Warmup problems (Q1–Q6 from Section 4)            | 6         | 21    | Complete warmup Q1–Q6                         |
| **Week 2** | Warmup Q7–Q10 + Graph representation + BFS theory | 8         | 24    | Vault notes for BFS. Graph class in C# coded. |

---

### Weeks 3–5: BFS/DFS Depth

| Week       | Topics                                                                     | Questions | Hours | Deliverables                                               |
| ---------- | -------------------------------------------------------------------------- | --------- | ----- | ---------------------------------------------------------- |
| **Week 3** | BFS — full pattern (multi-source, word ladder)                             | 6         | 21    | 6 BFS problems solved. Template memorized.                 |
| **Week 4** | DFS — full pattern (flood fill, connected components, paths)               | 6         | 21    | 6 DFS problems solved.                                     |
| **Week 5** | Cycle detection (undirected + directed) + re-solve Week 3–4 problems blind | 4 + 6R    | 24    | Cycle detection fluent. First blind re-solve session done. |

---

### Weeks 6–7: Topological Sort + Shortest Path Basics

| Week       | Topics                                          | Questions | Hours | Deliverables                         |
| ---------- | ----------------------------------------------- | --------- | ----- | ------------------------------------ |
| **Week 6** | Topological Sort (Kahn's + DFS-based)           | 5         | 21    | Course Schedule I & II solved clean. |
| **Week 7** | Unweighted shortest path (BFS) + Dijkstra intro | 6         | 24    | Dijkstra template coded from memory. |

---

### Weeks 8–9: Dijkstra Deep + Bellman-Ford + Union Find

| Week       | Topics                                | Questions | Hours | Deliverables                                         |
| ---------- | ------------------------------------- | --------- | ----- | ---------------------------------------------------- |
| **Week 8** | Dijkstra variants (modified, k-stops) | 5         | 21    | 5 Dijkstra problems solved.                          |
| **Week 9** | Bellman-Ford + Union Find             | 6         | 24    | Union Find template with path compression memorized. |

---

### Week 10: MST + Graph Month Review

| Week        | Topics                                    | Questions | Hours | Deliverables                                                    |
| ----------- | ----------------------------------------- | --------- | ----- | --------------------------------------------------------------- |
| **Week 10** | MST (Kruskal + Prim) + Month 1–2 revision | 4 + 10R   | 24    | Full graph revision. 10 problems re-solved blind. 1 graph mock. |

---

### Weeks 11–12: DP Entry — 1D DP

| Week        | Topics                                              | Questions | Hours | Deliverables                                               |
| ----------- | --------------------------------------------------- | --------- | ----- | ---------------------------------------------------------- |
| **Week 11** | 1D DP: Climbing Stairs → House Robber → Coin Change | 6         | 21    | State definition practice. 4-step protocol applied to all. |
| **Week 12** | 1D DP: Word Break → Decode Ways → Target Sum        | 6         | 24    | Pattern recognition for 1D DP locked in.                   |

---

### Weeks 13–14: 2D DP + Grid DP

| Week        | Topics                                                  | Questions | Hours | Deliverables                                        |
| ----------- | ------------------------------------------------------- | --------- | ----- | --------------------------------------------------- |
| **Week 13** | 2D DP: Unique Paths → Minimum Path Sum → Maximal Square | 5         | 21    | 2D table construction fluent.                       |
| **Week 14** | 2D DP: LCS + Edit Distance                              | 4         | 24    | Edit Distance solved clean (Hard). Major milestone. |

---

### Weeks 15–16: Subsequence DP + Knapsack

| Week        | Topics                                                    | Questions | Hours | Deliverables                                   |
| ----------- | --------------------------------------------------------- | --------- | ----- | ---------------------------------------------- |
| **Week 15** | LCS, LIS (both O(n²) and O(n log n) variants)             | 5         | 21    | LIS binary search approach understood + coded. |
| **Week 16** | Knapsack (0/1 + unbounded): Partition Sum, Coin Change II | 6         | 24    | Knapsack variants distinguishable by pattern.  |

---

### Weeks 17–18: String DP + Interval DP

| Week        | Topics                                           | Questions | Hours | Deliverables                          |
| ----------- | ------------------------------------------------ | --------- | ----- | ------------------------------------- |
| **Week 17** | String DP: Regex Matching, Wildcard, Palindromic | 5         | 21    | Hardest string DP attempted.          |
| **Week 18** | Interval DP: Burst Balloons + others             | 4         | 24    | Interval DP iteration order mastered. |

---

### Week 19: Tree DP + DP Month Review

| Week         | Topics                                                   | Questions | Hours | Deliverables               |
| ------------ | -------------------------------------------------------- | --------- | ----- | -------------------------- |
| **Week 19**  | Tree DP: House Robber III, Binary Tree Max Path, Cameras | 4         | 21    | Tree DP pattern locked.    |
| **+ Review** | Re-solve 15 DP problems blind                            | 15R       | —     | Full DP revision. 2 mocks. |

---

### Weeks 20–21: Hard Problem Push

| Week        | Topics                                        | Questions | Hours | Deliverables                       |
| ----------- | --------------------------------------------- | --------- | ----- | ---------------------------------- |
| **Week 20** | Hard Graph: Tarjan, Bridges, SCC, Bitmask BFS | 5         | 24    | LC #1192 solved.                   |
| **Week 21** | Hard DP: Bitmask DP, Partition DP             | 5         | 24    | LC #847 attempted. LC #312 solved. |

---

### Weeks 22–23: Company-Specific Drills + Full Mock Ramp

| Week        | Topics                                             | Questions | Hours | Deliverables                                                 |
| ----------- | -------------------------------------------------- | --------- | ----- | ------------------------------------------------------------ |
| **Week 22** | Google-tagged problems (LC premium, last 6 months) | 10        | 24    | Google problem exposure. Pattern recognition speed measured. |
| **Week 23** | Meta + Amazon + Atlassian tagged problems          | 10        | 24    | 4 mocks scheduled. Behavioral prep parallel.                 |

---

### Week 24: Final Sprint

| Week        | Topics                                   | Questions | Hours | Deliverables                                                                                  |
| ----------- | ---------------------------------------- | --------- | ----- | --------------------------------------------------------------------------------------------- |
| **Week 24** | Grind 75 remaining + Vault revision only | 5         | 21    | All vault tagged problems reviewed. Final readiness check. Mock interview with peer or Pramp. |

---

# 11. Obsidian Structure

## 11.1 Vault Hierarchy

```
📁 DSA-Bible/
│
├── 📁 00-System/
│   ├── Dashboard.md          ← Progress tracker + daily log
│   ├── Weekly-Review.md      ← Sunday retrospective
│   └── Rules.md              ← Your personal DSA rules
│
├── 📁 01-Graph/
│   ├── 00-Graph-Index.md     ← Overview + progress
│   ├── 01-BFS.md
│   ├── 02-DFS.md
│   ├── 03-Cycle-Detection.md
│   ├── 04-Topo-Sort.md
│   ├── 05-Dijkstra.md
│   ├── 06-Bellman-Ford.md
│   ├── 07-Union-Find.md
│   ├── 08-MST.md
│   ├── 09-Tarjan.md
│   └── 10-Advanced.md
│
├── 📁 02-DP/
│   ├── 00-DP-Index.md
│   ├── 01-DP-Framework.md    ← 4-step protocol lives here
│   ├── 02-1D-DP.md
│   ├── 03-2D-DP.md
│   ├── 04-Subsequence-DP.md
│   ├── 05-Knapsack.md
│   ├── 06-String-DP.md
│   ├── 07-Interval-DP.md
│   ├── 08-Partition-DP.md
│   ├── 09-Tree-DP.md
│   └── 10-Bitmask-DP.md
│
├── 📁 03-Warmup/
│   └── Warmup-10.md
│
├── 📁 04-Problem-Log/
│   ├── YYYY-MM-DD.md         ← Daily problem notes (one file per day)
│   └── Master-Problem-List.md← All problems tagged
│
├── 📁 05-Company/
│   ├── Google.md
│   ├── Meta.md
│   ├── Amazon.md
│   ├── Atlassian.md
│   ├── Uber.md
│   └── Flipkart.md
│
├── 📁 06-Mock-Interviews/
│   ├── Mock-Log.md
│   └── Mock-Template.md
│
├── 📁 07-Revision/
│   ├── Weak-Patterns.md      ← Problems you couldn't solve 2+ times
│   └── SR-Queue.md           ← Spaced repetition queue
│
└── 📁 08-Resources/
    └── Resource-Index.md
```

## 11.2 Problem Note Template

````markdown
# [Problem Name] — LC #[number]

**Date:** YYYY-MM-DD  
**Status:** Solved Clean / Solved w/ Hint / Read Editorial  
**Pattern:** [BFS | DFS | Dijkstra | 1D-DP | ...]  
**Difficulty:** Easy / Medium / Hard  
**Company:** Google / Meta / General  
**Revisit:** Yes / No

---

## Problem Summary

[2–3 lines restatement in your own words]

## My Approach

[What did you think first? What pattern did you recognize?]

## Key Insight

[The "aha" moment — the single insight that unlocks the solution]

## Code (C#)

```csharp
// your solution
```
````

## Complexity

- Time: O(?)
- Space: O(?)

## Mistakes Made

- [List any bugs or wrong approaches]

## Mental Model (1 line)

[Analogy or 1-sentence description for future recall]

## Revisit On

[Date + 3 days if solved with hint, +7 days if solved clean]

```

## 11.3 Tags to Use

```

#graph/bfs #graph/dfs #graph/dijkstra #graph/topo #graph/unionfind
#dp/1d #dp/2d #dp/knapsack #dp/string #dp/interval #dp/tree #dp/bitmask
#difficulty/easy #difficulty/medium #difficulty/hard
#company/google #company/meta #company/amazon #company/atlassian #company/uber
#status/clean #status/hint #status/editorial
#revisit #weak-pattern

```

---

# 12. Revision Engine

## 12.1 Daily Revision (15 minutes every day)

**Before starting new problems, always:**
1. Open `SR-Queue.md` — solve 1–2 problems from the queue (timed: 15 min)
2. If solved clean → mark done, push next revisit date out
3. If failed → re-read your own notes, mark as "still weak"

## 12.2 Weekly Revision (Every Sunday — 90 minutes)

```

1. Review all problems solved this week (5 min)
2. Identify the 2–3 weakest patterns (10 min)
3. Re-solve 5–6 problems blind from the current month (45 min)
4. Update Dashboard.md with week metrics (10 min)
5. Plan next week's topics + adjust if behind (20 min)

```

## 12.3 Monthly Revision

At the end of each month, before starting next month's new topics:

```

1. Re-solve 10 "important" problems from the month blind
2. Check all "Revisit: Yes" problems in the month's log
3. Update Weak-Patterns.md
4. Honest assessment: Am I ahead/behind roadmap?

```

## 12.4 Spaced Repetition Schedule

| Solve quality | First revisit | Second revisit | Third revisit |
|---|---|---|---|
| Solved Clean | +7 days | +21 days | +60 days |
| Solved with Hint | +3 days | +10 days | +30 days |
| Read Editorial | +1 day | +5 days | +15 days |
| Failed twice | Add to Weak-Patterns.md | Review weekly | — |

## 12.5 The Weak Patterns List

- Maintain `Weak-Patterns.md` — max 10 entries at a time
- Each entry: problem name + what broke + retry date
- Clear a problem from this list only after solving it cold, twice

---

# 13. Mock Interview Phase

## 13.1 When to Start

| Phase | Mock activity |
|---|---|
| Month 1–2 | Zero mocks. Focus only on learning. |
| Month 3 | 1 graph-only mock (self-timed, no interviewer) |
| Month 4 | 2 mocks (peer or platform) |
| Month 5 | 4 mocks |
| Month 6 | 8–10 mocks — full interview simulation |

## 13.2 Platforms

| Platform | Use case | Cost |
|---|---|---|
| **Pramp** | Free peer mock interviews | Free |
| **interviewing.io** | Anonymous mocks with engineers from FAANG | $200–300 for paid; free practice rounds |
| **NeetCode mock** | Self-timed problem sets | Free |
| **LeetCode contest** | Weekly contests for time pressure practice | Free |
| **Peer interviews** | With a friend or colleague | Free |

**Recommendation:** Start with Pramp (free, structured). Upgrade to interviewing.io at Month 5 for real FAANG engineer interviewers.

## 13.3 Mock Interview Protocol

**Before mock:**
- Set 45-minute timer
- No IDE — use Google Docs or shared editor
- No LeetCode autocomplete

**During mock:**
```

1. Clarify problem (2 min) — ask about constraints, edge cases
2. State brute force aloud (2 min)
3. Optimize + explain approach (5 min) — before coding
4. Code (20 min)
5. Dry run on examples (5 min)
6. Analyze complexity (3 min)
7. Handle edge cases (3 min)
8. Buffer (5 min)

````

**After mock:**
- Log in `Mock-Log.md`: problem, approach taken, mistakes, score (1–10)
- Identify: communication issue? Logic issue? Speed issue?
- Fix the weakest dimension next week

## 13.4 Company Simulation

| Month 6 week | Simulate |
|---|---|
| Week 21 | Atlassian + Flipkart style (Medium, practical) |
| Week 22 | Amazon style (Medium + behavioral) |
| Week 23 | Meta + Uber style (Medium-Hard, speed) |
| Week 24 | Google style (Hard, derivation-heavy) |

---

# 14. Metrics Dashboard

## 14.1 Problem Tracker Table

Copy this into `Dashboard.md` and update weekly:

```markdown
## Problem Tracker

| Month | Target Q | Solved Q | Easy | Medium | Hard | Revision Done |
|-------|----------|----------|------|--------|------|---------------|
| 1     | 35–40    |          |      |        |      |               |
| 2     | 45–50    |          |      |        |      |               |
| 3     | 40–45    |          |      |        |      |               |
| 4     | 45–50    |          |      |        |      |               |
| 5     | 45–50    |          |      |        |      |               |
| 6     | 30–35    |          |      |        |      |               |
| **TOTAL** | **~285** |      |      |        |      |               |
````

## 14.2 Pattern Mastery Tracker

```markdown
## Graph Mastery

| Pattern         | Status          | Questions Solved | Clean Solve % |
| --------------- | --------------- | ---------------- | ------------- |
| BFS             | [ ] Not started |                  |               |
| DFS             | [ ] Not started |                  |               |
| Cycle Detection |                 |                  |               |
| Topo Sort       |                 |                  |               |
| Dijkstra        |                 |                  |               |
| Bellman-Ford    |                 |                  |               |
| Union Find      |                 |                  |               |
| MST             |                 |                  |               |
| Tarjan          |                 |                  |               |

## DP Mastery

| Pattern        | Status          | Questions Solved | Clean Solve % |
| -------------- | --------------- | ---------------- | ------------- |
| 1D DP          | [ ] Not started |                  |               |
| 2D DP          |                 |                  |               |
| Subsequence DP |                 |                  |               |
| Knapsack 0/1   |                 |                  |               |
| Knapsack Unbnd |                 |                  |               |
| String DP      |                 |                  |               |
| Interval DP    |                 |                  |               |
| Tree DP        |                 |                  |               |
| Bitmask DP     |                 |                  |               |
```

## 14.3 Mock Interview Score Log

```markdown
## Mock Log

| Date | Platform | Problem | Difficulty | Approach Quality | Code Quality | Communication | Total /10 | Notes |
| ---- | -------- | ------- | ---------- | ---------------- | ------------ | ------------- | --------- | ----- |
|      |          |         |            | /3               | /3           | /4            |           |       |
```

## 14.4 Weekly Health Check

```markdown
## Week [N] — [Date Range]

**Problems solved this week:** X  
**Clean solve rate:** X%  
**Revisit problems done:** X  
**Weakest pattern this week:** \_**\_  
**Strongest pattern this week:** \_\_**  
**On track for roadmap?** Yes / No  
**Adjustment needed?** \_**\_  
**Mood/energy level (1–10):** \_\_**
```

---

# 15. Final Interview Readiness Checklist

## 15.1 Graph Readiness Checklist

```
[ ] Can implement BFS from memory in under 3 minutes
[ ] Can implement DFS (recursive + iterative) from memory
[ ] Can detect cycles in undirected graph (parent method)
[ ] Can detect cycles in directed graph (3-color DFS)
[ ] Can implement Kahn's topological sort from memory
[ ] Can implement Dijkstra with min-heap from memory
[ ] Can implement Union Find with path compression from memory
[ ] Can identify when to use BFS vs DFS vs Dijkstra from problem statement
[ ] Have solved 3+ multi-source BFS problems
[ ] Have solved LC #1192 (Bridges — Tarjan)
[ ] Can explain graph algorithm choices during a mock without hesitation
```

## 15.2 DP Readiness Checklist

```
[ ] Can identify DP problems from "min/max/count + overlapping subproblems" signal
[ ] Can verbally define dp[i] state for any 1D DP problem
[ ] Can construct 2D DP table for LCS and Edit Distance
[ ] Can implement 0/1 Knapsack and distinguish from Unbounded
[ ] Have solved Edit Distance (LC #72) clean
[ ] Have solved Burst Balloons (LC #312) clean
[ ] Have solved LIS with O(n log n) binary search approach
[ ] Can explain space optimization (row compression) for 2D DP
[ ] Can solve Tree DP (House Robber III) clean
[ ] Can identify interval DP by iteration order
```

## 15.3 General Interview Readiness

```
[ ] Can solve 80%+ of Medium problems cold in under 25 minutes
[ ] Can articulate time + space complexity immediately after coding
[ ] Can handle "optimize further" follow-up questions
[ ] Practiced communicating while coding (no silent coding)
[ ] Completed 15+ mock interviews
[ ] Have company-specific problem sets reviewed for target companies
[ ] STAR stories ready for Amazon/behavioral rounds (if applicable)
[ ] Can solve at least 3 Hards in your strongest patterns
[ ] Consistent sleep and energy management in last 4 weeks
```

## 15.4 Weakness Detection Checklist

Run this weekly from Month 4 onwards:

```
[ ] Is there a pattern I've avoided for 2+ weeks? → Schedule it this week.
[ ] Is my clean solve rate below 60%? → Slow down, more revision.
[ ] Am I skipping re-solves? → Fix the revision system.
[ ] Am I spending 30+ min on Easy problems? → Recalibrate expectations.
[ ] Am I doing mock interviews? → If not after Month 4, start now.
[ ] Am I building new notes in Obsidian? → If not, vault is dying.
[ ] Is Graph or DP falling behind? → Do not add new topics. Reinforce weak one.
```

## 15.5 FAANG Readiness Tiers

| Tier            | Criteria                                                              | Companies                 |
| --------------- | --------------------------------------------------------------------- | ------------------------- |
| **Ready**       | 85%+ Medium clean, 3+ Hards solved, 15+ mocks, all patterns completed | Google, Meta              |
| **Competitive** | 70%+ Medium clean, 1–2 Hards per pattern, 10+ mocks                   | Amazon, Netflix, Apple    |
| **Strong**      | 60%+ Medium clean, most patterns covered, 6+ mocks                    | Atlassian, Uber, Flipkart |
| **Not ready**   | Below 60% Medium, major patterns incomplete                           | Delay applications        |

---

# Appendix: Personal Operating Rules

> These rules are non-negotiable. Print and keep visible.

1. **No warmup expansion.** 10 problems max. Move on.
2. **25-minute hard stop.** Read hint. Never grind indefinitely.
3. **Never copy-paste solution code.** Always re-type from understanding.
4. **One quality > three skimmed.** Depth over breadth.
5. **Sunday revision is mandatory.** Not optional. Never skip.
6. **No new topic until current topic has 60%+ clean rate.**
7. **Mocks from Month 3.** Talking while coding is a different skill. Train it early.
8. **Vault is your second brain.** If you don't note it, you didn't learn it.
9. **Trust the schedule.** When behind, skip new problems — do revision instead.
10. **Graph and DP are the game.** Everything else is warmup.

---

_Last updated: May 2026 | Profile: Yash — .NET Fintech Engineer | Target: FAANG + Atlassian + Uber + Flipkart_
