// ============================================================
// Problem: Heap Implementation
// Topic: Heaps
// ============================================================
// PROBLEM STATEMENT: Implement a Max Heap with insert, extractMax, and heapify operations.
// ============================================================

using System;
using System.Collections.Generic;

public class MaxHeap
{
    private List<int> heap = new List<int>();

    // Insert: Add to end, bubble up. Time: O(log n)
    public void Insert(int val)
    {
        heap.Add(val);
        BubbleUp(heap.Count - 1);
    }

    // Extract Max: Remove root, replace with last, bubble down. Time: O(log n)
    public int ExtractMax()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");
        int max = heap[0];
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);
        if (heap.Count > 0) BubbleDown(0);
        return max;
    }

    public int Peek() => heap.Count > 0 ? heap[0] : throw new InvalidOperationException();

    private void BubbleUp(int i)
    {
        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (heap[i] > heap[parent])
            {
                (heap[i], heap[parent]) = (heap[parent], heap[i]);
                i = parent;
            }
            else break;
        }
    }

    private void BubbleDown(int i)
    {
        int n = heap.Count;
        while (true)
        {
            int largest = i, left = 2 * i + 1, right = 2 * i + 2;
            if (left < n && heap[left] > heap[largest]) largest = left;
            if (right < n && heap[right] > heap[largest]) largest = right;
            if (largest == i) break;
            (heap[i], heap[largest]) = (heap[largest], heap[i]);
            i = largest;
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Max Heap: Parent ≥ children. Root = max element.
// - Insert: Add to end → bubble up. O(log n).
// - Extract: Remove root, put last at root → bubble down. O(log n).
// - Parent = (i-1)/2, Left = 2*i+1, Right = 2*i+2.
// - In C#, use PriorityQueue<T, TPriority> (.NET 6+) or SortedSet.
// - Build heap from array: call BubbleDown from n/2-1 to 0 → O(n).
// ============================================================
