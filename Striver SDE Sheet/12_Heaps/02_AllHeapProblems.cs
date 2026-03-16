// ============================================================
// Problems: Kth Largest Element + K Max Sum Combinations +
//           Find Median from Data Stream + Merge K Sorted Arrays +
//           K Most Frequent Elements
// Topic: Heaps (All remaining heap problems)
// ============================================================

using System;
using System.Collections.Generic;

// --- Problem 2: Kth Largest Element ---
// Input: nums=[3,2,1,5,6,4], k=2 → Output: 5
// OPTIMAL: Use min-heap of size k. Top = kth largest. O(n log k)
public class KthLargestElement
{
    public int Optimal(int[] nums, int k)
    {
        var minHeap = new PriorityQueue<int, int>();
        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k) minHeap.Dequeue();
        }
        return minHeap.Peek();
    }
}
// NOTES: Min-heap of size k keeps k largest. Top = kth largest. O(n log k).
//        QuickSelect alternative: O(n) average, O(n^2) worst.

// --- Problem 3: K Maximum Sum Combinations ---
// Given two sorted arrays, find K pairs with largest sums.
// OPTIMAL: Max-heap with (sum, i, j). Explore (i-1,j) and (i,j-1). O(K log K)
public class KMaxSumCombinations
{
    public List<int> Optimal(int[] a, int[] b, int k)
    {
        Array.Sort(a); Array.Sort(b);
        int n = a.Length;
        var maxHeap = new PriorityQueue<(int i, int j), int>(Comparer<int>.Create((x, y) => y - x));
        var visited = new HashSet<(int, int)>();
        var result = new List<int>();

        maxHeap.Enqueue((n - 1, n - 1), -(a[n - 1] + b[n - 1]));
        visited.Add((n - 1, n - 1));

        while (k-- > 0 && maxHeap.Count > 0)
        {
            var (i, j) = maxHeap.Dequeue();
            result.Add(a[i] + b[j]);

            if (i > 0 && !visited.Contains((i - 1, j)))
            { maxHeap.Enqueue((i - 1, j), -(a[i - 1] + b[j])); visited.Add((i - 1, j)); }
            if (j > 0 && !visited.Contains((i, j - 1)))
            { maxHeap.Enqueue((i, j - 1), -(a[i] + b[j - 1])); visited.Add((i, j - 1)); }
        }
        return result;
    }
}

// --- Problem 4: Find Median from Data Stream ---
// OPTIMAL: Two heaps — maxHeap (left half) + minHeap (right half). O(log n) per add.
public class MedianFinder
{
    private PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((a, b) => b - a)); // left half
    private PriorityQueue<int, int> minHeap = new(); // right half

    public void AddNum(int num)
    {
        maxHeap.Enqueue(num, num);
        minHeap.Enqueue(maxHeap.Peek(), maxHeap.Peek());
        maxHeap.Dequeue();

        if (maxHeap.Count < minHeap.Count)
        { maxHeap.Enqueue(minHeap.Peek(), minHeap.Peek()); minHeap.Dequeue(); }
    }

    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count) return maxHeap.Peek();
        return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
    }
}
// NOTES: maxHeap.Count >= minHeap.Count always. Median from tops.

// --- Problem 5: Merge K Sorted Arrays ---
// OPTIMAL: Min-heap of (value, arrayIdx, elementIdx). O(nk * log k)
public class MergeKSortedArrays
{
    public List<int> Optimal(int[][] arrays)
    {
        var minHeap = new PriorityQueue<(int arr, int idx), int>();
        for (int i = 0; i < arrays.Length; i++)
            if (arrays[i].Length > 0) minHeap.Enqueue((i, 0), arrays[i][0]);

        var result = new List<int>();
        while (minHeap.Count > 0)
        {
            var (arr, idx) = minHeap.Dequeue();
            result.Add(arrays[arr][idx]);
            if (idx + 1 < arrays[arr].Length)
                minHeap.Enqueue((arr, idx + 1), arrays[arr][idx + 1]);
        }
        return result;
    }
}
// NOTES: Heap of size k. Each pop + push is O(log k). Total elements = n*k → O(nk log k).

// --- Problem 6: K Most Frequent Elements ---
// Input: nums=[1,1,1,2,2,3], k=2 → Output: [1,2]
// OPTIMAL: Count frequency with HashMap. Use min-heap of size k. O(n log k).
public class KMostFrequent
{
    public int[] Optimal(int[] nums, int k)
    {
        var freq = new Dictionary<int, int>();
        foreach (int n in nums) freq[n] = freq.GetValueOrDefault(n, 0) + 1;

        var minHeap = new PriorityQueue<int, int>();
        foreach (var kvp in freq)
        {
            minHeap.Enqueue(kvp.Key, kvp.Value);
            if (minHeap.Count > k) minHeap.Dequeue();
        }

        var result = new int[k];
        for (int i = 0; i < k; i++) result[i] = minHeap.Dequeue();
        return result;
    }
}
// NOTES: HashMap for frequency + min-heap of size k. O(n log k). Bucket sort → O(n).

// ============================================================
// QUICK REVISION NOTES (ALL HEAP PROBLEMS):
// - Kth Largest: Min-heap of size k. Top = kth largest.
// - K Max Sum: Max-heap + BFS-like exploration of (i-1,j), (i,j-1).
// - Stream Median: maxHeap (left) + minHeap (right). Balance sizes.
// - Merge K Sorted: Min-heap of size k, pop smallest, push its successor.
// - K Most Frequent: Frequency map + min-heap of size k.
// - C# PriorityQueue is min-heap by default. Use Comparer for max-heap.
// ============================================================
