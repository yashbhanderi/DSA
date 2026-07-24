# 15 — State Space BFS (Implicit Graphs)

> **Related Topics:** [BFS](./03_BFS.md) | [Shortest Path](./10_Shortest_Path.md)

---

## 1. What Is State Space BFS?

Sometimes the graph isn't given to you explicitly. The nodes and edges don't exist as a list — you have to figure them out on the fly.

These are **implicit graphs** where:
- **Nodes** = states (configurations, positions, words...)
- **Edges** = valid transitions between states
- **Goal** = reach a target state in minimum steps

BFS is perfect here because it finds the minimum number of transitions.

---

## 2. When Does This Pattern Appear?

- Word Ladder: words are nodes, one-letter-changes are edges
- Sliding puzzle: board configurations are nodes
- Lock combination: digit sequences are nodes
- Number transformations: numbers are nodes

The common thread: you're navigating a **space of states** where adjacent states are defined by the problem rules.

---

## 3. The Word Ladder Problem ⭐

### Problem 09 — Word Ladder

**Task:** Given `beginWord`, `endWord`, and a `wordList`, find the minimum number of word transformations to get from begin to end. Each transformation changes exactly one letter, and the intermediate word must be in wordList.

**Example:**
```
begin = "hit", end = "cog"
wordList = ["hot","dot","dog","lot","log","cog"]

Path: hit → hot → dot → dog → cog
Steps: 5 (counting beginWord as step 1)
```

**Why BFS?** We want MINIMUM steps → BFS.

**The graph:**
- Nodes = words
- Edge between two words = they differ by exactly one letter
- Find shortest path from beginWord to endWord

**Visual — the implicit graph for the Word Ladder example:**
```
Words: hit, hot, dot, dog, lot, log, cog

Edges (one letter apart):

  hit ─── hot ─── dot ─── dog ─── cog
              |               |           ^
              lot ─── log ─────────┘

BFS from "hit":
  Level 1: {hot}
  Level 2: {dot, lot}
  Level 3: {dog, log}
  Level 4: {cog}  ← FOUND! Length = 5 (hit counts as step 1)

BFS guarantees we find "cog" via the SHORTEST path.
```

**Why not DFS?** DFS might find a longer path first (e.g., hit→hot→lot→log→cog = 5 steps via a detour). BFS always gives shortest.

---

## 4. Naive vs Optimized Approach

### Naive: Compare Every Pair of Words
For each word in queue, compare it to every word in wordList. O(N × L) per step.

### Your Optimized: Pattern Map ⭐

Build a dictionary: `pattern → list of words matching that pattern`.

A pattern replaces one letter with `*`:
- "hit" → ["h*t", "*it", "hi*"]
- "hot" → ["h*t", "*ot", "ho*"]
- "dot" → ["d*t", "*ot", "do*"]

Words with the same pattern are connected!

```
Pattern "h*t": ["hit", "hot"] → hit and hot are neighbors
Pattern "*ot": ["hot", "dot", "lot"] → all connected
```

This is a genius optimization:
- Building the map: O(N × L) once
- Finding neighbors: O(1) lookup per pattern

```csharp
// From your WordLadder.cs
public static Dictionary<string, List<string>> BuildAdjList(IList<string> wordList)
{
    var patternMap = new Dictionary<string, List<string>>();

    foreach (var word in wordList)
    {
        for (int i = 0; i < word.Length; i++)
        {
            // Replace position i with '*'
            var pattern = string.Concat(word.AsSpan(0, i), "*", word.AsSpan(i + 1));

            if (!patternMap.TryGetValue(pattern, out var list))
            {
                list = [];
                patternMap[pattern] = list;
            }

            list.Add(word);
        }
    }

    return patternMap;
}
```

---

## 5. Deep Dry Run — Word Ladder

**Input:** beginWord="hit", endWord="cog", wordList=["hot","dot","dog","lot","log","cog"]

**Build Pattern Map:**
```
h*t → [hot]
*it → []    (no word *it in list)
hi* → []    (no word hi* in list)
h*t → [hot]  ← actually "hit" isn't in wordList, only words in wordList have patterns
*ot → [dot, lot]
d*t → [dot]
do* → [dot, dog]
d*g → [dog]
*og → [dog, log, cog]
l*t → [lot]
lo* → [lot, log]
l*g → [log]
c*g → [cog]
*og → [dog, log, cog]  (combined)
co* → [cog]
```

**BFS from "hit":**
```
Queue: [("hit", 1)]
Visited: {"hit"}

Step 1: Process ("hit", distance=1)
  Patterns of "hit": "h*t", "*it", "hi*"
  
  "h*t": words = ["hot"]
    "hot" not visited → enqueue ("hot", 2), mark visited
    patternMap["h*t"].Clear()  ← optimization: clear to avoid revisiting!
  
  "*it": no words
  "hi*": no words

Queue: [("hot", 2)]
Visited: {"hit", "hot"}

Step 2: Process ("hot", distance=2)
  Patterns: "h*t", "*ot", "ho*"
  
  "h*t": already cleared → skip
  "*ot": words = ["dot", "lot"]
    "dot" → enqueue ("dot", 3)
    "lot" → enqueue ("lot", 3)
    patternMap["*ot"].Clear()
  "ho*": no words in list

Queue: [("dot",3), ("lot",3)]
Visited: {"hit","hot","dot","lot"}

Step 3: Process ("dot", distance=3)
  Patterns: "d*t", "*ot", "do*"
  "d*t": ["dot"] → already visited
  "*ot": cleared → skip
  "do*": ["dog"]
    "dog" → enqueue ("dog", 4)

Queue: [("lot",3), ("dog",4)]
Visited: {..."dog"}

Step 4: Process ("lot", distance=3)
  Patterns: "l*t", "*ot", "lo*"
  "*ot": cleared
  "lo*": ["lot","log"] → "lot" visited, "log" → enqueue ("log", 4)

Queue: [("dog",4), ("log",4)]

Step 5: Process ("dog", distance=4)
  Patterns: "d*g", "*og", "do*"
  "*og": ["dog","log","cog"]
    "dog" visited, "log" visited, "cog" → enqueue ("cog", 5)
  
Step 6: Process ("log", distance=4)
  Similar but "cog" already enqueued

Step 7: Process ("cog", distance=5)
  "cog" == endWord → RETURN 5 ✓
```

---

## 6. The "Clear After Use" Optimization

```csharp
adjList[pattern].Clear();  // from your code
```

Why this optimization? Once we've processed all words matching a pattern, we never need them again (they're visited). Clearing prevents re-enqueueing visited words.

This replaces the need for a visited check for the words themselves. **Clever!**

---

## 7. State Space BFS Template

```csharp
// General template for state-space BFS
var queue = new Queue<(State state, int steps)>();
var visited = new HashSet<State>();

queue.Enqueue((initialState, 0));
visited.Add(initialState);

while (queue.Count > 0)
{
    var (current, steps) = queue.Dequeue();

    if (current == targetState) return steps;

    foreach (var next in GetNeighbors(current))  // define valid transitions
    {
        if (!visited.Contains(next))
        {
            visited.Add(next);
            queue.Enqueue((next, steps + 1));
        }
    }
}

return -1; // not reachable
```

---

## 8. Generating Neighbors in Word Ladder

```csharp
// Option 1: Try all possible one-letter changes (O(L × 26) per word)
for (int i = 0; i < word.Length; i++)
    for (char c = 'a'; c <= 'z'; c++)
    {
        var newWord = word[..i] + c + word[(i+1)..];
        if (wordSet.Contains(newWord) && !visited.Contains(newWord))
            // add to queue
    }

// Option 2: Pattern map (your approach — faster for large wordList)
for (int i = 0; i < word.Length; i++)
{
    var pattern = word[..i] + "*" + word[(i+1)..];
    if (adjList.ContainsKey(pattern))
        foreach (var neighbor in adjList[pattern])
            // add to queue
}
```

Option 2 is better when the wordList is large and patterns are shared.

---

## 9. More State Space BFS Problems (Not in Your Repo — For Completeness)

### Sliding Puzzle (8-puzzle)
- State = string representation of board
- Neighbors = valid moves (slide tiles)
- BFS for minimum moves

### Open the Lock
- State = 4-digit combination
- Neighbors = turning each digit +1 or -1
- BFS avoiding "dead" combinations

### Jump Game (if you think graph)
- State = current position
- Neighbors = positions reachable in one jump
- BFS for minimum jumps

---

## 10. Common Mistakes

| Mistake | Fix |
|---------|-----|
| Using DFS (finds A path, not shortest) | Always use BFS for minimum steps |
| Not checking if endWord is in wordList | Early return if not present |
| Marking visited when DEQUEUING (too late) | Mark when ENQUEUING |
| Not generating neighbors correctly | Test neighbor generation separately |
| Forgetting to include beginWord distance as 1 | Initialize queue with distance 1 |

---

## 11. Recognition Checklist

```
If I see:
  → "minimum transformations/steps between states"    → BFS on implicit graph
  → "word ladder" / "change one letter at a time"     → BFS + pattern map
  → "grid/state transformations"                      → State BFS
  → "minimum moves in a puzzle"                       → BFS over all possible states
  → "graph not given explicitly, neighbors computed"  → Implicit graph BFS
```

---

## 12. Cheat Sheet

```
STATE SPACE BFS:
  When: graph not given, nodes=states, edges=valid transitions
  Why: Find minimum transitions (steps)
  How: BFS (not DFS!)

WORD LADDER PATTERN MAP:
  For each word:
      For each position:
          pattern = word with '*' at that position
          patternMap[pattern].Add(word)

  During BFS:
      For each pattern of current word:
          For each word matching pattern:
              enqueue if not visited

OPTIMIZATION: Clear pattern list after using
              (avoids revisiting those words)

TIME: O(N × L) to build map + O(N × L) BFS = O(N × L)
SPACE: O(N × L) for pattern map
```
