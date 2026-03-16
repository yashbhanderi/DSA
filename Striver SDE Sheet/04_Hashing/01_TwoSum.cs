// ============================================================
// Problem: Two Sum
// Topic: Hashing
// ============================================================
// PROBLEM STATEMENT:
//   Given an array and a target sum, find two numbers that add up
//   to the target. Return their indices. Exactly one solution exists.
//
//   Input:  nums = [2,7,11,15], target = 9
//   Output: [0, 1]  (nums[0] + nums[1] = 9)
// ============================================================

using System;
using System.Collections.Generic;

public class TwoSum
{
    // APPROACH 1: BRUTE FORCE — Check all pairs
    // Time: O(n^2)  |  Space: O(1)
    public int[] BruteForce(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
            for (int j = i + 1; j < nums.Length; j++)
                if (nums[i] + nums[j] == target)
                    return new int[] { i, j };
        return new int[] { };
    }

    // APPROACH 2: OPTIMAL — HashMap (One-pass)
    // Idea: For each element, check if (target - element) exists in map.
    //       If yes, found the pair. If no, add current element to map.
    // Time: O(n)  |  Space: O(n)
    public int[] Optimal(int[] nums, int target)
    {
        var map = new Dictionary<int, int>(); // value → index

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.ContainsKey(complement))
                return new int[] { map[complement], i };

            map[nums[i]] = i;
        }

        return new int[] { };
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - HashMap approach: Look for (target - current) in map. O(n) / O(n).
// - One-pass: Check and add in same loop. Handles duplicates correctly.
// - If asked for VALUES (not indices) and array is sorted → use Two Pointers.
// - Interview tip: Clarify — return indices or values? Can elements repeat?
// ============================================================
