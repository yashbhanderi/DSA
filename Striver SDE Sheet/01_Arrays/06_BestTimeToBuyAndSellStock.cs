// ============================================================
// Problem: Best Time to Buy and Sell Stock
// Topic: Arrays I
// ============================================================
// PROBLEM STATEMENT:
//   Given an array where prices[i] is the stock price on day i,
//   find the maximum profit from one buy and one sell (buy before sell).
//   Return 0 if no profit possible.
//
//   Input:  prices = [7, 1, 5, 3, 6, 4]
//   Output: 5  (buy at 1, sell at 6)
// ============================================================

using System;

public class BestTimeToBuyAndSellStock
{
    // APPROACH 1: BRUTE FORCE — Check all pairs
    // Idea: For each day, check all future days for max profit.
    // Time: O(n^2)  |  Space: O(1)
    public int BruteForce(int[] prices)
    {
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                int profit = prices[j] - prices[i];
                maxProfit = Math.Max(maxProfit, profit);
            }
        }

        return maxProfit;
    }

    // APPROACH 2: OPTIMAL — Track minimum price so far
    // Idea: As we scan left to right, keep track of the minimum price seen.
    //       At each day, the potential profit = current price - min price.
    //       Track the maximum of all such profits.
    // Time: O(n)  |  Space: O(1)
    public int Optimal(int[] prices)
    {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices)
        {
            minPrice = Math.Min(minPrice, price);        // best buy day so far
            maxProfit = Math.Max(maxProfit, price - minPrice); // best profit so far
        }

        return maxProfit;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Track minPrice so far, compute profit at each step.
// - maxProfit = max(maxProfit, currentPrice - minPrice).
// - One pass, O(n) time, O(1) space.
// - Only ONE transaction allowed (buy once, sell once).
// - If prices only decrease, profit = 0 (never buy).
// - Interview tip: Very common warm-up. Mention Kadane's connection.
// ============================================================
