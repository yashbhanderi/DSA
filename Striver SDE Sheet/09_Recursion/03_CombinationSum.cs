// ============================================================
// Problem: Combination Sum
// Topic: Recursion
// ============================================================
// PROBLEM STATEMENT:
//   Given candidates[] and target, find all unique combinations
//   where candidates sum to target. Same number can be used unlimited times.
//   Input: candidates=[2,3,6,7], target=7 → Output: [[2,2,3],[7]]
// ============================================================

using System;
using System.Collections.Generic;

public class CombinationSum
{
    // APPROACH: Backtracking with reuse allowed
    // Idea: At each index, pick current element (stay at same index)
    //       or skip to next index. This allows unlimited reuse.
    // Time: O(2^target)  |  Space: O(target) depth
    public IList<IList<int>> Optimal(int[] candidates, int target)
    {
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
        if (remaining < 0) return;

        for (int i = start; i < candidates.Length; i++)
        {
            current.Add(candidates[i]);
            // Pass i (not i+1) to allow reuse of same element
            Backtrack(candidates, i, remaining - candidates[i], current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Key difference from Combination Sum II: pass `i` not `i+1` to allow reuse.
// - Base: remaining == 0 → valid combination. remaining < 0 → prune.
// - No duplicates in candidates (per problem). If duplicates exist, see CombSumII.
// - Time is exponential but pruned by remaining < 0.
// ============================================================
