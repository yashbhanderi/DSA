// ============================================================
// Problem: Largest Subarray with 0 Sum
// Topic: Hashing
// ============================================================
// PROBLEM STATEMENT:
//   Given an array of integers, find the length of the longest
//   subarray having sum equal to 0.
//
//   Input:  arr = [15, -2, 2, -8, 1, 7, 10, 23]
//   Output: 5  (subarray [-2, 2, -8, 1, 7])
// ============================================================

using System;
using System.Collections.Generic;

public class LargestSubarrayZeroSum
{
    // APPROACH 1: BRUTE FORCE — Check all subarrays
    // Time: O(n^2)  |  Space: O(1)
    public int BruteForce(int[] arr)
    {
        int maxLen = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int sum = 0;
            for (int j = i; j < arr.Length; j++)
            {
                sum += arr[j];
                if (sum == 0)
                    maxLen = Math.Max(maxLen, j - i + 1);
            }
        }
        return maxLen;
    }

    // APPROACH 2: OPTIMAL — Prefix Sum + HashMap
    // Idea: If prefix_sum[i] == prefix_sum[j], then sum of subarray
    //       (i+1 to j) is 0. Store first occurrence of each prefix sum.
    //       Also, if prefix_sum itself is 0, subarray from 0..i has sum 0.
    // Time: O(n)  |  Space: O(n)
    public int Optimal(int[] arr)
    {
        var map = new Dictionary<int, int>(); // prefix_sum → first index
        int maxLen = 0;
        int prefixSum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            prefixSum += arr[i];

            if (prefixSum == 0)
            {
                maxLen = i + 1; // entire subarray from 0 to i
            }
            else if (map.ContainsKey(prefixSum))
            {
                maxLen = Math.Max(maxLen, i - map[prefixSum]);
            }
            else
            {
                map[prefixSum] = i; // store FIRST occurrence
            }
        }

        return maxLen;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Prefix sum trick: If prefixSum[i] == prefixSum[j], subarray (i+1..j) sums to 0.
// - Store FIRST occurrence of each prefix sum in HashMap.
// - If prefixSum becomes 0, the entire subarray 0..i is valid.
// - O(n) time, O(n) space.
// - This pattern extends to "subarray with given sum K" (prefixSum - K in map).
// - Interview tip: Draw prefix sum diagram to explain visually.
// ============================================================
