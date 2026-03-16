// ============================================================
// Problem: Longest Consecutive Sequence
// Topic: Hashing
// ============================================================
// PROBLEM STATEMENT:
//   Given an unsorted array, find the length of the longest
//   consecutive elements sequence. Must run in O(n) time.
//
//   Input:  nums = [100, 4, 200, 1, 3, 2]
//   Output: 4  (sequence: [1, 2, 3, 4])
// ============================================================

using System;
using System.Collections.Generic;

public class LongestConsecutiveSequence
{
    // APPROACH 1: BRUTE FORCE — Sort and scan
    // Time: O(n log n)  |  Space: O(1)
    public int BruteForce(int[] nums)
    {
        if (nums.Length == 0) return 0;
        Array.Sort(nums);
        int maxLen = 1, currLen = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1]) continue; // skip duplicates
            if (nums[i] == nums[i - 1] + 1)
                currLen++;
            else
                currLen = 1;
            maxLen = Math.Max(maxLen, currLen);
        }

        return maxLen;
    }

    // APPROACH 2: OPTIMAL — HashSet
    // Idea: Put all elements in a HashSet. For each element, check if
    //       it's the START of a sequence (num-1 not in set). If yes,
    //       count consecutive elements forward.
    // Time: O(n)  |  Space: O(n)
    public int Optimal(int[] nums)
    {
        if (nums.Length == 0) return 0;

        var set = new HashSet<int>(nums);
        int maxLen = 0;

        foreach (int num in set)
        {
            // Only start counting from the beginning of a sequence
            if (!set.Contains(num - 1))
            {
                int current = num;
                int length = 1;

                while (set.Contains(current + 1))
                {
                    current++;
                    length++;
                }

                maxLen = Math.Max(maxLen, length);
            }
        }

        return maxLen;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - HashSet approach: Only start counting from sequence START (num-1 not in set).
// - This ensures each element is visited at most twice → O(n).
// - Don't start counting from every element (that would be O(n^2)).
// - Key insight: The "if !contains(num-1)" check is what makes it O(n).
// - Edge case: Empty array → return 0. Duplicates are handled by HashSet.
// - Interview tip: Explain why it's O(n) despite the while loop.
// ============================================================
