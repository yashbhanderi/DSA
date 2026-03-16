// ============================================================
// Dynamic Programming Part II — 8 problems
// Topic: Dynamic Programming Part II
// ============================================================
// Problems: Minimum Path Sum, Coin Change, Subset Sum, Rod Cutting,
//           Egg Dropping, Word Break (DP), Palindrome Partitioning II, Partition Equal Subset Sum
// ============================================================

using System;
using System.Collections.Generic;

// --- P1: Minimum Path Sum in Grid ---
public class MinPathSum
{
    public int Optimal(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0) continue;
                else if (i == 0) grid[i][j] += grid[i][j - 1];
                else if (j == 0) grid[i][j] += grid[i - 1][j];
                else grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
            }
        return grid[m - 1][n - 1];
    }
}

// --- P2: Coin Change ---
// Min coins to make amount. dp[i] = min coins for amount i.
public class CoinChange
{
    public int Optimal(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1); // infinity
        dp[0] = 0;
        for (int i = 1; i <= amount; i++)
            foreach (int coin in coins)
                if (coin <= i) dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
        return dp[amount] > amount ? -1 : dp[amount];
    }
}

// --- P3: Subset Sum ---
// Can we form a subset with given sum? dp[i][s] = can first i elements form sum s?
public class SubsetSum
{
    public bool Optimal(int[] nums, int target)
    {
        bool[] dp = new bool[target + 1];
        dp[0] = true;
        foreach (int num in nums)
            for (int s = target; s >= num; s--) // iterate backwards for 0/1
                dp[s] = dp[s] || dp[s - num];
        return dp[target];
    }
}

// --- P4: Rod Cutting ---
// Maximize profit by cutting rod of length n. price[i] = price for length i+1.
public class RodCutting
{
    public int Optimal(int[] price, int n)
    {
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
            for (int j = 0; j < i; j++)
                dp[i] = Math.Max(dp[i], price[j] + dp[i - j - 1]);
        return dp[n];
    }
}

// --- P5: Egg Dropping ---
// Min trials with k eggs and n floors. Binary search optimization.
public class EggDrop
{
    public int Optimal(int k, int n)
    {
        int[,] dp = new int[k + 1, n + 1];
        for (int i = 1; i <= k; i++) for (int j = 1; j <= n; j++) dp[i, j] = j; // worst case
        for (int i = 2; i <= k; i++)
            for (int j = 2; j <= n; j++)
            {
                dp[i, j] = int.MaxValue;
                int lo = 1, hi = j;
                while (lo <= hi)
                {
                    int mid = (lo + hi) / 2;
                    int breaks = dp[i - 1, mid - 1];     // egg breaks
                    int survives = dp[i, j - mid];         // egg survives
                    int worst = 1 + Math.Max(breaks, survives);
                    dp[i, j] = Math.Min(dp[i, j], worst);
                    if (breaks < survives) lo = mid + 1;
                    else hi = mid - 1;
                }
            }
        return dp[k, n];
    }
}

// --- P6: Word Break (DP) --- Already in Backtracking folder. dp[i] = can s[0..i-1] be segmented.

// --- P7: Palindrome Partitioning II (Min Cuts) ---
public class PalindromePartitioningII
{
    public int MinCut(string s)
    {
        int n = s.Length;
        bool[,] isPalin = new bool[n, n];
        for (int len = 1; len <= n; len++)
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                isPalin[i, j] = s[i] == s[j] && (len <= 2 || isPalin[i + 1, j - 1]);
            }

        int[] dp = new int[n]; // dp[i] = min cuts for s[0..i]
        for (int i = 0; i < n; i++)
        {
            if (isPalin[0, i]) { dp[i] = 0; continue; }
            dp[i] = int.MaxValue;
            for (int j = 1; j <= i; j++)
                if (isPalin[j, i]) dp[i] = Math.Min(dp[i], dp[j - 1] + 1);
        }
        return dp[n - 1];
    }
}

// --- P8: Partition Equal Subset Sum ---
// Can array be partitioned into two subsets with equal sum?
// = Subset Sum problem with target = totalSum / 2.
public class PartitionEqualSubsetSum
{
    public bool Optimal(int[] nums)
    {
        int sum = 0;
        foreach (int n in nums) sum += n;
        if (sum % 2 != 0) return false;
        int target = sum / 2;
        bool[] dp = new bool[target + 1];
        dp[0] = true;
        foreach (int num in nums)
            for (int s = target; s >= num; s--)
                dp[s] = dp[s] || dp[s - num];
        return dp[target];
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Min Path Sum: dp[i][j] += min(top, left). In-place possible. O(m*n).
// - Coin Change: Unbounded knapsack. dp[i] = min coins for amount i. O(amount * coins).
// - Subset Sum: 0/1 knapsack. Iterate backwards to avoid reuse. O(n * target).
// - Rod Cutting: Unbounded knapsack variant. dp[i] = max profit for length i.
// - Egg Drop: Binary search optimization on classic DP. O(k * n * log n).
// - Min Palindrome Cuts: Precompute isPalin[][]. dp[i] = min cuts for s[0..i].
// - Equal Partition: Subset Sum with target = sum/2. If sum is odd → false.
// ============================================================
