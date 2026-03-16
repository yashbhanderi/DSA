// ============================================================
// Problem: Grid Unique Paths
// Topic: Arrays III
// ============================================================
// PROBLEM STATEMENT:
//   A robot is at top-left of an m x n grid. It can only move
//   right or down. Count the number of unique paths to reach
//   the bottom-right corner.
//
//   Input:  m = 3, n = 7
//   Output: 28
// ============================================================

using System;

public class GridUniquePaths
{
    // APPROACH 1: BRUTE FORCE — Recursion
    // Idea: At each cell, go right or down. Count all paths.
    // Time: O(2^(m+n))  |  Space: O(m + n) stack
    public int BruteForce(int m, int n)
    {
        return Recurse(0, 0, m, n);
    }

    private int Recurse(int i, int j, int m, int n)
    {
        if (i == m - 1 && j == n - 1) return 1;
        if (i >= m || j >= n) return 0;
        return Recurse(i + 1, j, m, n) + Recurse(i, j + 1, m, n);
    }

    // APPROACH 2: BETTER — DP (Memoization or Tabulation)
    // Time: O(m * n)  |  Space: O(m * n)
    public int Better(int m, int n)
    {
        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++) dp[i, 0] = 1; // first column
        for (int j = 0; j < n; j++) dp[0, j] = 1; // first row

        for (int i = 1; i < m; i++)
            for (int j = 1; j < n; j++)
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];

        return dp[m - 1, n - 1];
    }

    // APPROACH 3: OPTIMAL — Combinatorics
    // Idea: Total steps = (m-1) down + (n-1) right = (m+n-2) steps.
    //       Choose which (m-1) are down (or (n-1) are right).
    //       Answer = C(m+n-2, m-1) = C(m+n-2, n-1).
    // Time: O(min(m, n))  |  Space: O(1)
    public int Optimal(int m, int n)
    {
        int totalSteps = m + n - 2;
        int choose = Math.Min(m - 1, n - 1); // smaller for fewer multiplications

        long result = 1;
        for (int i = 0; i < choose; i++)
        {
            result = result * (totalSteps - i) / (i + 1);
        }

        return (int)result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Total moves: (m-1) down + (n-1) right = m+n-2 total moves.
// - Answer = C(m+n-2, m-1). Compute using step-multiply to avoid overflow.
// - DP: dp[i][j] = dp[i-1][j] + dp[i][j-1], base case: first row/col = 1.
// - Combinatorics is O(min(m,n)) with O(1) space. DP is O(m*n).
// - Interview tip: Show all 3 approaches, emphasize combinatorics insight.
// ============================================================
