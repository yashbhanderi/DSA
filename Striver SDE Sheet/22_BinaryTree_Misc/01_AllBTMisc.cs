// ============================================================
// Binary Tree Miscellaneous — 6 problems
// Topic: Binary Trees [Miscellaneous]
// ============================================================
// Problems: BT to DLL, Median in Stream, Kth Largest in Stream,
//           Distinct Numbers in Window, Kth Largest in Unsorted, Flood Fill
// ============================================================

using System;
using System.Collections.Generic;

// P1: Binary Tree to Doubly Linked List (Inorder-based)
// Perform inorder traversal, link nodes left=prev, right=next.

// P2: Find Median in a Stream — Already covered in Heaps (Two heaps approach).

// P3: Kth Largest in Stream — Min-heap of size k. Top = kth largest.
public class KthLargestInStream
{
    private PriorityQueue<int, int> minHeap = new();
    private int k;
    public KthLargestInStream(int k, int[] nums) { this.k = k; foreach (int n in nums) Add(n); }
    public int Add(int val)
    {
        minHeap.Enqueue(val, val);
        if (minHeap.Count > k) minHeap.Dequeue();
        return minHeap.Peek();
    }
}

// P4: Distinct Numbers in Window — Use HashMap with sliding window.
public class DistinctInWindow
{
    public List<int> Optimal(int[] arr, int k)
    {
        var result = new List<int>();
        var map = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            map[arr[i]] = map.GetValueOrDefault(arr[i], 0) + 1;
            if (i >= k)
            {
                map[arr[i - k]]--;
                if (map[arr[i - k]] == 0) map.Remove(arr[i - k]);
            }
            if (i >= k - 1) result.Add(map.Count);
        }
        return result;
    }
}

// P5: Kth Largest in Unsorted Array — Same as Heap problem. QuickSelect or min-heap.

// P6: Flood Fill — BFS/DFS from source pixel.
public class FloodFill
{
    public int[][] Optimal(int[][] image, int sr, int sc, int color)
    {
        int original = image[sr][sc];
        if (original == color) return image;
        DFS(image, sr, sc, original, color);
        return image;
    }
    private void DFS(int[][] img, int r, int c, int orig, int color)
    {
        if (r < 0 || r >= img.Length || c < 0 || c >= img[0].Length) return;
        if (img[r][c] != orig) return;
        img[r][c] = color;
        DFS(img, r + 1, c, orig, color); DFS(img, r - 1, c, orig, color);
        DFS(img, r, c + 1, orig, color); DFS(img, r, c - 1, orig, color);
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - BT to DLL: Inorder traversal, link as doubly linked list (left=prev, right=next).
// - Stream Median: Two heaps (maxHeap left, minHeap right). O(log n) per add.
// - Kth Largest Stream: Min-heap of size k. O(log k) per add.
// - Distinct in Window: HashMap sliding window. Track count. O(n).
// - Flood Fill: DFS/BFS from source pixel. Change color. Check bounds + original color.
// ============================================================
