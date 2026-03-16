// ============================================================
// Problem: Single Element in Sorted Array
// Topic: Binary Search
// ============================================================
// PROBLEM STATEMENT:
//   In a sorted array where every element appears exactly twice
//   except one, find the single element.
//   Input: [1,1,2,3,3,4,4,8,8] → Output: 2
// ============================================================

using System;

public class SingleElementInSorted
{
    // APPROACH 1: XOR all elements → O(n)
    // APPROACH 2: OPTIMAL — Binary Search
    // Idea: Before the single element, pairs are at (even, odd) indices.
    //       After it, pairs shift to (odd, even). Binary search on this property.
    // Time: O(log n)  |  Space: O(1)
    public int Optimal(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            // Ensure mid is even (pair should start at even index)
            if (mid % 2 == 1) mid--;

            if (nums[mid] == nums[mid + 1])
                left = mid + 2;  // pair is intact → single is on right
            else
                right = mid;     // pair broken → single is on left (or at mid)
        }

        return nums[left];
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Before single: pairs at (even, odd). After: pairs at (odd, even).
// - Make mid even. If nums[mid] == nums[mid+1] → single is on right.
// - O(log n) binary search. Better than O(n) XOR for this specific structure.
// - Key: The array is SORTED. XOR works but doesn't use sorted property.
// ============================================================
