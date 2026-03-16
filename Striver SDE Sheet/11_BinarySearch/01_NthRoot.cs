// ============================================================
// Problem: Nth Root of a Number
// Topic: Binary Search
// ============================================================
// PROBLEM STATEMENT:
//   Find the nth root of m (i.e., m^(1/n)). Return integer root or -1.
//   Input: n=3, m=27 → Output: 3 (3^3 = 27)
// ============================================================

using System;

public class NthRoot
{
    // APPROACH: Binary Search on answer
    // Idea: Search in [1, m]. At each mid, compute mid^n.
    //       If mid^n == m → found. If mid^n < m → go right. Else go left.
    // Time: O(n * log m)  |  Space: O(1)
    public int Optimal(int n, int m)
    {
        int low = 1, high = m;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            long power = Power(mid, n, m);

            if (power == m) return mid;
            else if (power < m) low = mid + 1;
            else high = mid - 1;
        }

        return -1; // no integer nth root exists
    }

    private long Power(int b, int exp, int limit)
    {
        long result = 1;
        for (int i = 0; i < exp; i++)
        {
            result *= b;
            if (result > limit) return limit + 1; // early exit to avoid overflow
        }
        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Binary search on answer space [1, m].
// - Compute mid^n with overflow protection (return early if > m).
// - O(n * log m). The "binary search on answer" pattern is very common.
// - Same pattern: square root, cube root, etc.
// ============================================================
