// ============================================================
// Problem: Search in Rotated Sorted Array
// Topic: Binary Search
// ============================================================
// PROBLEM STATEMENT:
//   An sorted array is rotated at some pivot. Search for a target.
//   Input: nums=[4,5,6,7,0,1,2], target=0 → Output: 4
// ============================================================

using System;

public class SearchInRotated
{
    // APPROACH: Modified Binary Search
    // Idea: One half is always sorted. Determine which half is sorted,
    //       check if target lies in that half, adjust pointers accordingly.
    // Time: O(log n)  |  Space: O(1)
    public int Optimal(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target) return mid;

            // Left half is sorted
            if (nums[left] <= nums[mid])
            {
                if (target >= nums[left] && target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            // Right half is sorted
            else
            {
                if (target > nums[mid] && target <= nums[right])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }

        return -1;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - One half is ALWAYS sorted in a rotated sorted array.
// - Check nums[left] <= nums[mid] → left half sorted.
// - If target is in sorted half's range → search there. Else search other half.
// - O(log n) time, O(1) space. Very commonly asked.
// - Variant with duplicates: Add nums[left] == nums[mid] → left++ (worst case O(n)).
// ============================================================
