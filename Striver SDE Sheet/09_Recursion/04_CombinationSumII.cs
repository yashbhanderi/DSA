// ============================================================
// Problem: Combination Sum II
// Topic: Recursion
// ============================================================
// PROBLEM STATEMENT:
//   Given candidates[] (may have duplicates) and target, find all
//   unique combinations summing to target. Each number used at most once.
//   Input: candidates=[10,1,2,7,6,1,5], target=8
//   Output: [[1,1,6],[1,2,5],[1,7],[2,6]]
// ============================================================

using System;
using System.Collections.Generic;

public class CombinationSumII
{
    // APPROACH: Sort + Backtracking + Skip duplicates
    // Time: O(2^n)  |  Space: O(n)
    public IList<IList<int>> Optimal(int[] candidates, int target)
    {
        Array.Sort(candidates);
        var result = new List<IList<int>>();
        Backtrack(candidates, 0, target, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] candidates, int start, int remaining, List<int> current, List<IList<int>> result)
    {
        if (remaining == 0)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (candidates[i] > remaining) break; // prune: sorted, so rest are larger

            // Skip duplicates at same level
            if (i > start && candidates[i] == candidates[i - 1]) continue;

            current.Add(candidates[i]);
            Backtrack(candidates, i + 1, remaining - candidates[i], current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort + skip duplicates (i > start && nums[i] == nums[i-1]).
// - Pass i+1 (each element used at most once). Unlike CombSum I which passes i.
// - Prune: if candidates[i] > remaining → break (array is sorted).
// - Combination of Subsets II dedup pattern + CombSum I structure.
// ============================================================
