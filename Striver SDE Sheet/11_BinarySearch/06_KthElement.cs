// ============================================================
// Problem: Kth Element of Two Sorted Arrays
// Topic: Binary Search
// ============================================================
// PROBLEM STATEMENT:
//   Given two sorted arrays, find the kth smallest element overall.
//   Input: arr1=[2,3,6,7,9], arr2=[1,4,8,10], k=5 → Output: 6
// ============================================================

using System;

public class KthElementOfTwoSorted
{
    // APPROACH: Binary Search (similar to Median of Two Sorted Arrays)
    // Idea: Binary search on smaller array. Partition such that left side has k elements.
    // Time: O(log(min(m, n)))  |  Space: O(1)
    public int Optimal(int[] arr1, int[] arr2, int k)
    {
        if (arr1.Length > arr2.Length) return Optimal(arr2, arr1, k);

        int m = arr1.Length, n = arr2.Length;
        int low = Math.Max(0, k - n), high = Math.Min(k, m);

        while (low <= high)
        {
            int cut1 = (low + high) / 2;
            int cut2 = k - cut1;

            int left1 = cut1 == 0 ? int.MinValue : arr1[cut1 - 1];
            int left2 = cut2 == 0 ? int.MinValue : arr2[cut2 - 1];
            int right1 = cut1 == m ? int.MaxValue : arr1[cut1];
            int right2 = cut2 == n ? int.MaxValue : arr2[cut2];

            if (left1 <= right2 && left2 <= right1)
                return Math.Max(left1, left2);
            else if (left1 > right2)
                high = cut1 - 1;
            else
                low = cut1 + 1;
        }

        return -1;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Same technique as Median of Two Sorted Arrays, but target is k elements on left.
// - low = max(0, k-n), high = min(k, m). Ensures valid partitions.
// - Answer = max(left1, left2) when valid partition found.
// - O(log(min(m,n))). Generalization of the median problem.
// ============================================================
