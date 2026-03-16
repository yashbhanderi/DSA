// ============================================================
// Problem: Maximum Subarray Sum (Kadane's Algorithm)
// Topic: Arrays I
// ============================================================
// PROBLEM STATEMENT:
//   Given an integer array, find the contiguous subarray with
//   the largest sum and return that sum.
//
//   Input:  nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
//   Output: 6  (subarray [4, -1, 2, 1])
// ============================================================

using System;

public class KadanesAlgorithm
{
    // APPROACH 1: BRUTE FORCE — Check all subarrays
    // Idea: Try every possible subarray, compute sum, track max.
    // Time: O(n^2)  |  Space: O(1)
    public int BruteForce(int[] nums)
    {
        int maxSum = int.MinValue;

        for (int i = 0; i < nums.Length; i++)
        {
            int currentSum = 0;
            for (int j = i; j < nums.Length; j++)
            {
                currentSum += nums[j];
                maxSum = Math.Max(maxSum, currentSum);
            }
        }

        return maxSum;
    }

    // APPROACH 2: OPTIMAL — Kadane's Algorithm
    // Idea: Maintain a running sum. If it drops below 0, reset to 0.
    //       At each step, update the global maximum.
    //       Intuition: A negative prefix can never help a future subarray.
    // Time: O(n)  |  Space: O(1)
    public int Optimal(int[] nums)
    {
        int maxSum = int.MinValue;
        int currentSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            currentSum += nums[i];
            maxSum = Math.Max(maxSum, currentSum);

            if (currentSum < 0)
                currentSum = 0; // Reset: negative prefix hurts future sums
        }

        return maxSum;
    }

    // FOLLOW-UP: Print the subarray with maximum sum
    public int OptimalWithSubarray(int[] nums)
    {
        int maxSum = int.MinValue;
        int currentSum = 0;
        int start = 0, ansStart = 0, ansEnd = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (currentSum == 0)
                start = i; // potential start of new subarray

            currentSum += nums[i];

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                ansStart = start;
                ansEnd = i;
            }

            if (currentSum < 0)
                currentSum = 0;
        }

        Console.WriteLine($"Max subarray: [{ansStart}..{ansEnd}]");
        return maxSum;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Kadane's: Keep running sum, reset to 0 when it goes negative.
// - Key insight: Negative prefix never helps → discard it.
// - To track subarray indices: note start when sum resets, update answer when max changes.
// - Edge case: All negatives → Kadane's still works (maxSum updates before reset).
// - Follow-up: If asked "max sum must be > 0", return 0 for all-negative arrays.
// - Interview tip: This is THE most asked array question. Know it cold.
// ============================================================
