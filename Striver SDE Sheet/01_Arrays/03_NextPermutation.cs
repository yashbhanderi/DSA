// ============================================================
// Problem: Next Permutation
// Topic: Arrays I
// ============================================================
// PROBLEM STATEMENT:
//   Given an array of integers, rearrange it to the next
//   lexicographically greater permutation. If already the
//   largest, rearrange to the smallest (sorted ascending).
//
//   Input:  nums = [1, 2, 3]
//   Output: [1, 3, 2]
//
//   Input:  nums = [3, 2, 1]
//   Output: [1, 2, 3]
// ============================================================

using System;

public class NextPermutation
{
    // APPROACH 1: BRUTE FORCE
    // Idea: Generate all permutations, sort them, find current one,
    //       return the next. If last, return first.
    // Time: O(n! * n)  |  Space: O(n!)
    // NOT practical — only for understanding.

    // APPROACH 2: OPTIMAL — Standard Algorithm
    // Idea:
    //   Step 1: Find the largest index i such that nums[i] < nums[i+1].
    //           (Find the "breakpoint" from the right)
    //   Step 2: Find the largest index j > i such that nums[j] > nums[i].
    //   Step 3: Swap nums[i] and nums[j].
    //   Step 4: Reverse the suffix starting at nums[i+1].
    //   If no breakpoint found (descending array), just reverse entire array.
    // Time: O(n)  |  Space: O(1)
    public void Optimal(int[] nums)
    {
        int n = nums.Length;
        int breakpoint = -1;

        // Step 1: Find breakpoint (rightmost i where nums[i] < nums[i+1])
        for (int i = n - 2; i >= 0; i--)
        {
            if (nums[i] < nums[i + 1])
            {
                breakpoint = i;
                break;
            }
        }

        if (breakpoint == -1)
        {
            // Entire array is descending → reverse to get smallest
            Array.Reverse(nums);
            return;
        }

        // Step 2: Find rightmost element greater than nums[breakpoint]
        for (int j = n - 1; j > breakpoint; j--)
        {
            if (nums[j] > nums[breakpoint])
            {
                // Step 3: Swap
                (nums[breakpoint], nums[j]) = (nums[j], nums[breakpoint]);
                break;
            }
        }

        // Step 4: Reverse everything after breakpoint
        Array.Reverse(nums, breakpoint + 1, n - breakpoint - 1);
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Find breakpoint: rightmost index where nums[i] < nums[i+1].
// - If none → array is fully descending → reverse it.
// - Swap breakpoint with the smallest larger element to its right.
// - Reverse the suffix after breakpoint to get the next permutation.
// - All 4 steps run in O(n) with O(1) space.
// - Key insight: The suffix after breakpoint is always descending.
// - Interview tip: Walk through [1,3,5,4,2] → bp=1(3), swap with 4 → [1,4,5,3,2], reverse suffix → [1,4,2,3,5].
// ============================================================
