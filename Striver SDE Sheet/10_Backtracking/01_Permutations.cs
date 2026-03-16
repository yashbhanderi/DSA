// ============================================================
// Problem: Permutations
// Topic: Backtracking
// ============================================================
// PROBLEM STATEMENT:
//   Given an array of distinct integers, return all permutations.
//   Input:  [1,2,3] → Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
// ============================================================

using System;
using System.Collections.Generic;

public class Permutations
{
    // APPROACH 1: Using visited array
    // Time: O(n! * n)  |  Space: O(n)
    public IList<IList<int>> UsingVisited(int[] nums)
    {
        var result = new List<IList<int>>();
        bool[] visited = new bool[nums.Length];
        Backtrack(nums, visited, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] nums, bool[] visited, List<int> current, List<IList<int>> result)
    {
        if (current.Count == nums.Length) { result.Add(new List<int>(current)); return; }

        for (int i = 0; i < nums.Length; i++)
        {
            if (visited[i]) continue;
            visited[i] = true;
            current.Add(nums[i]);
            Backtrack(nums, visited, current, result);
            current.RemoveAt(current.Count - 1);
            visited[i] = false;
        }
    }

    // APPROACH 2: OPTIMAL — Swap-based (no extra space for visited)
    // Idea: Swap element at each index with current position, recurse.
    // Time: O(n! * n)  |  Space: O(n) recursion
    public IList<IList<int>> Optimal(int[] nums)
    {
        var result = new List<IList<int>>();
        SwapBacktrack(nums, 0, result);
        return result;
    }

    private void SwapBacktrack(int[] nums, int start, List<IList<int>> result)
    {
        if (start == nums.Length)
        {
            result.Add(new List<int>(nums));
            return;
        }

        for (int i = start; i < nums.Length; i++)
        {
            (nums[start], nums[i]) = (nums[i], nums[start]);
            SwapBacktrack(nums, start + 1, result);
            (nums[start], nums[i]) = (nums[i], nums[start]); // backtrack
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Approach 1: visited[] array + build current list. Classic but O(n) extra.
// - Approach 2: Swap-based. Swap nums[start] with each nums[i], recurse. No visited needed.
// - n! permutations total. Each takes O(n) to copy → O(n! * n).
// - For duplicates (Permutations II): sort + skip same elements at same level.
// ============================================================
