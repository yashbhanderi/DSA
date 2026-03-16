// ============================================================
// Problem: Allocate Minimum Number of Pages (Book Allocation)
// Topic: Binary Search
// ============================================================
// PROBLEM STATEMENT:
//   Given N books with pages[i] and M students, allocate books such
//   that max pages assigned to any student is minimized.
//   Each student gets contiguous books. All books must be allocated.
//   Input: pages=[12,34,67,90], m=2 → Output: 113
// ============================================================

using System;

public class AllocatePages
{
    // APPROACH: Binary Search on answer
    // Idea: Answer lies in [max(pages), sum(pages)].
    //       Binary search: for each mid, check if allocation is feasible
    //       with at most m students, where no student reads > mid pages.
    // Time: O(n * log(sum-max))  |  Space: O(1)
    public int Optimal(int[] pages, int m)
    {
        if (m > pages.Length) return -1;

        int low = 0, high = 0;
        foreach (int p in pages) { low = Math.Max(low, p); high += p; }

        int result = high;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (IsFeasible(pages, m, mid))
            {
                result = mid;
                high = mid - 1;
            }
            else
                low = mid + 1;
        }

        return result;
    }

    private bool IsFeasible(int[] pages, int m, int maxPages)
    {
        int students = 1, currentPages = 0;
        foreach (int p in pages)
        {
            if (currentPages + p > maxPages)
            {
                students++;
                currentPages = p;
                if (students > m) return false;
            }
            else
                currentPages += p;
        }
        return true;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Binary search on answer: [max(pages), sum(pages)].
// - Feasibility check: Greedily assign pages. Count students needed.
// - If students needed ≤ m → feasible (try smaller mid).
// - Same pattern: Painter's Partition, Split Array Largest Sum.
// - O(n * log(sum-max)). Classic "minimize the maximum" binary search.
// ============================================================
