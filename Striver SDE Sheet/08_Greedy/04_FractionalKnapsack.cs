// ============================================================
// Problem: Fractional Knapsack
// Topic: Greedy
// ============================================================
// PROBLEM STATEMENT:
//   Given weights and values of items, fill a knapsack of capacity W
//   to get maximum value. You can take fractions of items.
//   Input: items=[(60,10),(100,20),(120,30)], W=50 → Output: 240
// ============================================================

using System;

public class FractionalKnapsack
{
    // APPROACH: Greedy — Sort by value/weight ratio descending
    // Idea: Take items with highest value-to-weight ratio first.
    //       If item fits entirely, take it. Else take fraction.
    // Time: O(n log n)  |  Space: O(1)
    public double Optimal(int[][] items, int capacity)
    {
        // items[i] = [value, weight]
        // Sort by value/weight ratio descending
        Array.Sort(items, (a, b) =>
            ((double)b[0] / b[1]).CompareTo((double)a[0] / a[1]));

        double totalValue = 0;
        int remaining = capacity;

        foreach (var item in items)
        {
            if (item[1] <= remaining)
            {
                // Take entire item
                totalValue += item[0];
                remaining -= item[1];
            }
            else
            {
                // Take fraction
                totalValue += (double)item[0] * remaining / item[1];
                break; // knapsack is full
            }
        }

        return totalValue;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort by value/weight ratio (descending). Greedy: best ratio first.
// - Take whole items if they fit, else take fractional part and stop.
// - O(n log n) for sort. Greedy works because fractions are allowed.
// - 0/1 Knapsack (no fractions) → use DP instead. Greedy FAILS for 0/1.
// - Interview tip: Clarify if fractions allowed (fractional=greedy, 0/1=DP).
// ============================================================
