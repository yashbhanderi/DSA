// ============================================================
// Problem: Subset Sums
// Topic: Recursion
// ============================================================
// PROBLEM STATEMENT:
//   Given an array, return all possible subset sums in sorted order.
//   Input:  arr = [2, 3] → Output: [0, 2, 3, 5]
// ============================================================

using System;
using System.Collections.Generic;

public class SubsetSums
{
    // APPROACH: Recursion — Pick or Not Pick
    // Idea: At each index, either include or exclude the element.
    //       When we reach end, add the current sum to result.
    // Time: O(2^n)  |  Space: O(2^n) for result
    public List<int> Optimal(int[] arr)
    {
        var result = new List<int>();
        Generate(arr, 0, 0, result);
        result.Sort();
        return result;
    }

    private void Generate(int[] arr, int index, int sum, List<int> result)
    {
        if (index == arr.Length)
        {
            result.Add(sum);
            return;
        }

        // Include current element
        Generate(arr, index + 1, sum + arr[index], result);
        // Exclude current element
        Generate(arr, index + 1, sum, result);
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Pick/Not-pick pattern: include or exclude each element.
// - 2^n subsets → 2^n sums. Sort at end if required.
// - Base case: index == n → add current sum.
// - This is foundation for subset sum DP problems.
// ============================================================
