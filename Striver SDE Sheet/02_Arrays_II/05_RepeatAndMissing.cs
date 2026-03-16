// ============================================================
// Problem: Repeat and Missing Number
// Topic: Arrays II
// ============================================================
// PROBLEM STATEMENT:
//   Given an array of size n containing numbers from 1 to n,
//   one number appears twice and one is missing. Find both.
//
//   Input:  arr = [3, 1, 2, 5, 3]
//   Output: Repeating = 3, Missing = 4
// ============================================================

using System;

public class RepeatAndMissing
{
    // APPROACH 1: BRUTE FORCE — Count frequency
    // Idea: Count frequency of each number from 1 to n. Frequency 2 = repeat, 0 = missing.
    // Time: O(n)  |  Space: O(n)
    public int[] BruteForce(int[] arr)
    {
        int n = arr.Length;
        int[] count = new int[n + 1];
        int repeating = -1, missing = -1;

        foreach (int num in arr) count[num]++;

        for (int i = 1; i <= n; i++)
        {
            if (count[i] == 2) repeating = i;
            if (count[i] == 0) missing = i;
        }

        return new int[] { repeating, missing };
    }

    // APPROACH 2: BETTER — Math (Sum and Sum of Squares)
    // Idea: Let x = repeating, y = missing.
    //       SumActual - SumExpected = x - y  ... (1)
    //       SumSqActual - SumSqExpected = x² - y² = (x-y)(x+y) ... (2)
    //       From (1) and (2): solve for x and y.
    // Time: O(n)  |  Space: O(1)
    public int[] Better(int[] arr)
    {
        long n = arr.Length;
        long sumExpected = n * (n + 1) / 2;
        long sumSqExpected = n * (n + 1) * (2 * n + 1) / 6;

        long sumActual = 0, sumSqActual = 0;
        foreach (int num in arr)
        {
            sumActual += num;
            sumSqActual += (long)num * num;
        }

        long diff = sumActual - sumExpected;       // x - y
        long sumDiff = sumSqActual - sumSqExpected; // x^2 - y^2
        long sum = sumDiff / diff;                  // x + y

        int repeating = (int)((diff + sum) / 2);
        int missing = (int)((sum - diff) / 2);

        return new int[] { repeating, missing };
    }

    // APPROACH 3: OPTIMAL — XOR Method
    // Idea: XOR all elements with 1 to n → result = x XOR y.
    //       Find a set bit (differentiating bit). Split numbers into
    //       two groups based on that bit. XOR each group to get x and y.
    // Time: O(n)  |  Space: O(1)
    public int[] Optimal(int[] arr)
    {
        int n = arr.Length;
        int xorAll = 0;

        // XOR all array elements and 1..n
        for (int i = 0; i < n; i++)
        {
            xorAll ^= arr[i];
            xorAll ^= (i + 1);
        }
        // xorAll = repeating ^ missing

        // Find rightmost set bit
        int rightmostBit = xorAll & (-xorAll);

        int group0 = 0, group1 = 0;

        // Split array elements
        foreach (int num in arr)
        {
            if ((num & rightmostBit) == 0) group0 ^= num;
            else group1 ^= num;
        }

        // Split 1..n
        for (int i = 1; i <= n; i++)
        {
            if ((i & rightmostBit) == 0) group0 ^= i;
            else group1 ^= i;
        }

        // Determine which is repeating and which is missing
        foreach (int num in arr)
        {
            if (num == group0) return new int[] { group0, group1 };
        }

        return new int[] { group1, group0 };
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Math approach: Use sum and sum-of-squares equations to solve.
//   x - y = sumActual - sumExpected
//   x + y = (sumSqActual - sumSqExpected) / (x - y)
// - XOR approach: XOR all + 1..n → x^y. Split by any set bit.
// - Both O(n) time, O(1) space. Math approach is easier to explain.
// - Edge case: Watch for overflow with sum-of-squares (use long).
// - Interview tip: Start with frequency array, optimize to math.
// ============================================================
