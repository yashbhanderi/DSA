// ============================================================
// Problem: Minimum Number of Coins (Greedy)
// Topic: Greedy
// ============================================================
// PROBLEM STATEMENT:
//   Given coins of denominations and an amount, find minimum
//   number of coins to make that amount using greedy approach.
//   Coins: [1, 2, 5, 10, 20, 50, 100, 500, 1000]
//   Input:  amount = 49 → Output: 5 (20+20+5+2+2)
// ============================================================

using System;
using System.Collections.Generic;

public class MinimumCoins
{
    // APPROACH: Greedy — Use largest denomination first
    // Idea: Sort coins descending. Use as many of the largest coin
    //       as possible, then move to smaller denominations.
    // Time: O(amount)  |  Space: O(1)
    // NOTE: Greedy works for standard denominations only. For arbitrary
    //       denominations, DP is needed (Coin Change problem).
    public List<int> Optimal(int amount)
    {
        int[] coins = { 1000, 500, 100, 50, 20, 10, 5, 2, 1 };
        var result = new List<int>();

        foreach (int coin in coins)
        {
            while (amount >= coin)
            {
                result.Add(coin);
                amount -= coin;
            }
        }

        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Greedy: Pick largest denomination first. Works for Indian/US currency.
// - WARNING: Greedy FAILS for arbitrary denominations (e.g., coins=[1,3,4], amount=6).
//   Greedy gives 4+1+1=3 coins, but optimal is 3+3=2 coins.
// - For arbitrary denominations → use DP (Coin Change problem).
// - Interview tip: Mention when greedy works vs when DP is needed.
// ============================================================
