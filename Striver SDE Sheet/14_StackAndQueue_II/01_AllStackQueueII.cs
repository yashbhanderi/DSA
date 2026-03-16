// ============================================================
// Stack and Queue II — All 10 problems
// Topic: Stack & Queue Part II
// ============================================================
// Problems: Next Smaller Element, LRU Cache, LFU Cache,
//           Largest Rectangle in Histogram, Sliding Window Maximum,
//           Min Stack, Rotten Oranges, Stock Span, Max of Min Window, Celebrity
// ============================================================

using System;
using System.Collections.Generic;

// --- P1: Next Smaller Element ---
// Like NGE but find SMALLER. Traverse LEFT to RIGHT, maintain monotonic increasing stack.
public class NextSmallerElement
{
    public int[] Optimal(int[] arr)
    {
        int n = arr.Length;
        int[] result = new int[n];
        var stack = new Stack<int>();
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && stack.Peek() >= arr[i]) stack.Pop();
            result[i] = stack.Count > 0 ? stack.Peek() : -1;
            stack.Push(arr[i]);
        }
        return result;
    }
}

// --- P2: LRU Cache ---
// HashMap + Doubly Linked List. Get/Put in O(1).
public class LRUCache
{
    private class Node { public int Key, Val; public Node Prev, Next; }
    private Dictionary<int, Node> map = new();
    private Node head = new(), tail = new();
    private int capacity;

    public LRUCache(int cap) { capacity = cap; head.Next = tail; tail.Prev = head; }

    public int Get(int key)
    {
        if (!map.ContainsKey(key)) return -1;
        var node = map[key]; Remove(node); AddToFront(node);
        return node.Val;
    }

    public void Put(int key, int val)
    {
        if (map.ContainsKey(key)) { Remove(map[key]); map.Remove(key); }
        if (map.Count == capacity) { map.Remove(tail.Prev.Key); Remove(tail.Prev); }
        var node = new Node { Key = key, Val = val }; AddToFront(node); map[key] = node;
    }

    private void Remove(Node n) { n.Prev.Next = n.Next; n.Next.Prev = n.Prev; }
    private void AddToFront(Node n) { n.Next = head.Next; n.Prev = head; head.Next.Prev = n; head.Next = n; }
}

// --- P3: LFU Cache --- (Simplified description)
// HashMap + Frequency Map + Doubly Linked List per frequency. O(1) get/put.
// Key idea: Track min frequency. Evict LRU node at min frequency.
// (Full implementation omitted for brevity — uses similar DLL pattern as LRU)

// --- P4: Largest Rectangle in Histogram ---
// Input: [2,1,5,6,2,3] → Output: 10 (5*2)
// OPTIMAL: Monotonic stack. For each bar, find nearest smaller left and right. O(n).
public class LargestRectangleHistogram
{
    public int Optimal(int[] heights)
    {
        int n = heights.Length, maxArea = 0;
        var stack = new Stack<int>(); // indices
        for (int i = 0; i <= n; i++)
        {
            int h = (i == n) ? 0 : heights[i];
            while (stack.Count > 0 && h < heights[stack.Peek()])
            {
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }
            stack.Push(i);
        }
        return maxArea;
    }
}

// --- P5: Sliding Window Maximum ---
// Input: nums=[1,3,-1,-3,5,3,6,7], k=3 → Output: [3,3,5,5,6,7]
// OPTIMAL: Deque maintaining decreasing order. O(n).
public class SlidingWindowMaximum
{
    public int[] Optimal(int[] nums, int k)
    {
        var deque = new LinkedList<int>(); // indices
        var result = new int[nums.Length - k + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            while (deque.Count > 0 && deque.First.Value < i - k + 1) deque.RemoveFirst();
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) deque.RemoveLast();
            deque.AddLast(i);
            if (i >= k - 1) result[i - k + 1] = nums[deque.First.Value];
        }
        return result;
    }
}

// --- P6: Min Stack ---
// Stack that supports push, pop, top, and getMin in O(1).
public class MinStack
{
    private Stack<long> stack = new();
    private long min;
    public void Push(int val)
    {
        if (stack.Count == 0) { stack.Push(val); min = val; }
        else { stack.Push(val - min); if (val < min) min = val; }
    }
    public void Pop()
    {
        long top = stack.Pop();
        if (top < 0) min -= top; // restore previous min
    }
    public int Top() => stack.Peek() < 0 ? (int)min : (int)(stack.Peek() + min);
    public int GetMin() => (int)min;
}

// --- P7: Rotten Oranges --- (BFS multi-source)
// Time to rot all oranges. -1 if impossible.
public class RottenOranges
{
    public int Optimal(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length, fresh = 0, time = 0;
        var queue = new Queue<(int r, int c)>();
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            { if (grid[i][j] == 2) queue.Enqueue((i, j)); if (grid[i][j] == 1) fresh++; }

        int[] dr = { 0, 0, 1, -1 }, dc = { 1, -1, 0, 0 };
        while (queue.Count > 0 && fresh > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var (r, c) = queue.Dequeue();
                for (int d = 0; d < 4; d++)
                {
                    int nr = r + dr[d], nc = c + dc[d];
                    if (nr >= 0 && nr < m && nc >= 0 && nc < n && grid[nr][nc] == 1)
                    { grid[nr][nc] = 2; fresh--; queue.Enqueue((nr, nc)); }
                }
            }
            time++;
        }
        return fresh == 0 ? time : -1;
    }
}

// --- P8: Stock Span --- Previous Greater Element variant. Monotonic stack. O(n).
public class StockSpan { /* Similar to NGE — use monotonic stack of indices */ }

// --- P9: Max of Min for Every Window Size --- Using Next Smaller Element. O(n).
public class MaxOfMinWindow { /* Precompute NSE left/right, fill result array */ }

// --- P10: Celebrity Problem --- Stack-based elimination. O(n).
public class CelebrityProblem
{
    public int Optimal(int[][] matrix, int n)
    {
        var stack = new Stack<int>();
        for (int i = 0; i < n; i++) stack.Push(i);
        while (stack.Count > 1)
        {
            int a = stack.Pop(), b = stack.Pop();
            if (matrix[a][b] == 1) stack.Push(b); else stack.Push(a);
        }
        int candidate = stack.Pop();
        for (int i = 0; i < n; i++)
        {
            if (i != candidate && (matrix[candidate][i] == 1 || matrix[i][candidate] == 0))
                return -1;
        }
        return candidate;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - LRU Cache: HashMap + DLL. Most recently used at front, evict from tail.
// - Histogram: Monotonic stack of indices. Pop = bar height, width = i - stack.peek - 1.
// - Sliding Window Max: Deque (decreasing). Front = max. Remove expired and smaller.
// - Min Stack: Store (val - min). If stored < 0, val was new min. Restore on pop.
// - Rotten Oranges: Multi-source BFS. Level = time unit.
// - Celebrity: Stack elimination. One candidate survives. Verify in O(n).
// ============================================================
