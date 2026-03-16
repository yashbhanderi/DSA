// ============================================================
// Problem: Subsets II (Unique subsets from array with duplicates)
// Topic: Recursion
// ============================================================
// PROBLEM STATEMENT:
//   Given an array that may contain duplicates, return all unique subsets.
//   Input:  [1,2,2] → Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]
// ============================================================

using System;
using System.Collections.Generic;

public class SubsetsII
{
    // APPROACH: Sort + Skip duplicates during recursion
    // Idea: Sort array. When iterating choices at each recursion level,
    //       skip duplicate elements to avoid generating duplicate subsets.
    // Time: O(2^n * n)  |  Space: O(2^n * n)
    public IList<IList<int>> Optimal(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();
        Backtrack(nums, 0, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] nums, int start, List<int> current, List<IList<int>> result)
    {
        result.Add(new List<int>(current));

        for (int i = start; i < nums.Length; i++)
        {
            // Skip duplicates at same recursion level
            if (i > start && nums[i] == nums[i - 1]) continue;

            current.Add(nums[i]);
            Backtrack(nums, i + 1, current, result);
            current.RemoveAt(current.Count - 1); // backtrack
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort array first to group duplicates together.
// - Skip condition: if (i > start && nums[i] == nums[i-1]) → skip.
// - This avoids duplicate subsets without using a HashSet.
// - Same pattern used in Combination Sum II, Permutations II.
// - Key: "i > start" ensures we skip at the SAME level, not across levels.
// ============================================================
