// ============================================================
// Dynamic Programming Part I — 7 problems
// Topic: Dynamic Programming
// ============================================================
// Problems: Max Product Subarray, LIS, LCS, 0/1 Knapsack,
//           Edit Distance, Max Sum Increasing Subsequence, MCM
// ============================================================

using System;
using System.Collections.Generic;

// --- P1: Maximum Product Subarray ---
// Track maxProduct and minProduct (min can become max when multiplied by negative).
public class MaxProductSubarray
{
    public int Optimal(int[] nums)
    {
        int maxProd = nums[0], minProd = nums[0], result = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < 0) (maxProd, minProd) = (minProd, maxProd); // swap
            maxProd = Math.Max(nums[i], maxProd * nums[i]);
            minProd = Math.Min(nums[i], minProd * nums[i]);
            result = Math.Max(result, maxProd);
        }
        return result;
    }
}
// NOTES: Swap max/min before negative number. O(n) time, O(1) space.

// --- P2: Longest Increasing Subsequence ---
// dp[i] = length of LIS ending at i. Or use binary search for O(n log n).
public class LIS
{
    // O(n^2) DP
    public int DPApproach(int[] nums)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        int maxLen = 1;
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
                if (nums[j] < nums[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
            maxLen = Math.Max(maxLen, dp[i]);
        }
        return maxLen;
    }

    // O(n log n) using patience sorting / binary search
    public int Optimal(int[] nums)
    {
        var tails = new List<int>(); // tails[i] = smallest tail of increasing subsequence of length i+1
        foreach (int num in nums)
        {
            int pos = tails.BinarySearch(num);
            if (pos < 0) pos = ~pos;
            if (pos == tails.Count) tails.Add(num);
            else tails[pos] = num;
        }
        return tails.Count;
    }
}

// --- P3: Longest Common Subsequence ---
public class LCSProblem
{
    public int Optimal(string s1, string s2)
    {
        int m = s1.Length, n = s2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
            for (int j = 1; j <= n; j++)
                dp[i, j] = s1[i - 1] == s2[j - 1] ? dp[i - 1, j - 1] + 1 : Math.Max(dp[i - 1, j], dp[i, j - 1]);
        return dp[m, n];
    }
}
// NOTES: dp[i][j] = LCS of s1[0..i-1] and s2[0..j-1]. O(m*n).

// --- P4: 0/1 Knapsack ---
public class Knapsack01
{
    public int Optimal(int[] weights, int[] values, int W)
    {
        int n = weights.Length;
        int[,] dp = new int[n + 1, W + 1];
        for (int i = 1; i <= n; i++)
            for (int w = 0; w <= W; w++)
            {
                dp[i, w] = dp[i - 1, w]; // don't take
                if (weights[i - 1] <= w)
                    dp[i, w] = Math.Max(dp[i, w], dp[i - 1, w - weights[i - 1]] + values[i - 1]); // take
            }
        return dp[n, W];
    }
}
// NOTES: dp[i][w] = max value using first i items with capacity w. O(n*W).

// --- P5: Edit Distance ---
public class EditDistance
{
    public int Optimal(string word1, string word2)
    {
        int m = word1.Length, n = word2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i <= m; i++) dp[i, 0] = i;
        for (int j = 0; j <= n; j++) dp[0, j] = j;
        for (int i = 1; i <= m; i++)
            for (int j = 1; j <= n; j++)
                dp[i, j] = word1[i - 1] == word2[j - 1] ? dp[i - 1, j - 1]
                    : 1 + Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1]));
        return dp[m, n];
    }
}
// NOTES: 3 ops: insert(dp[i][j-1]), delete(dp[i-1][j]), replace(dp[i-1][j-1]). O(m*n).

// --- P6: Maximum Sum Increasing Subsequence ---
public class MaxSumIS
{
    public int Optimal(int[] arr)
    {
        int n = arr.Length;
        int[] dp = new int[n];
        Array.Copy(arr, dp, n);
        int maxSum = dp[0];
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
                if (arr[j] < arr[i]) dp[i] = Math.Max(dp[i], dp[j] + arr[i]);
            maxSum = Math.Max(maxSum, dp[i]);
        }
        return maxSum;
    }
}

// --- P7: Matrix Chain Multiplication ---
// dp[i][j] = min cost to multiply matrices i..j.
public class MCM
{
    public int Optimal(int[] dims)
    {
        int n = dims.Length - 1; // n matrices
        int[,] dp = new int[n, n];
        for (int len = 2; len <= n; len++)
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                dp[i, j] = int.MaxValue;
                for (int k = i; k < j; k++)
                    dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] + dims[i] * dims[k + 1] * dims[j + 1]);
            }
        return dp[0, n - 1];
    }
}
// NOTES: Try all split points k. Cost = left + right + multiplication cost. O(n^3).

// ============================================================
// QUICK REVISION NOTES:
// - Max Product: Track max AND min (negative flip). Swap on negative.
// - LIS: O(n^2) DP or O(n log n) with binary search on tails array.
// - LCS: dp[i][j] = match→dp[i-1][j-1]+1, else max(dp[i-1][j], dp[i][j-1]).
// - 0/1 Knapsack: Take or skip. dp[i][w] = max(skip, take). O(n*W).
// - Edit Distance: ins/del/replace. 3-way min + 1. O(m*n).
// - MCM: Interval DP. Try all splits. dp[i][j] = min over k of left+right+cost.
// ============================================================
