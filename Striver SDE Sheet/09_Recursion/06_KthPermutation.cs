// ============================================================
// Problem: Kth Permutation Sequence
// Topic: Recursion
// ============================================================
// PROBLEM STATEMENT:
//   Given n and k, find the kth permutation sequence of [1..n].
//   Input:  n=3, k=3 → Output: "213"
//   (Permutations: 123,132,213,231,312,321 → 3rd is 213)
// ============================================================

using System;
using System.Collections.Generic;

public class KthPermutation
{
    // APPROACH 1: BRUTE FORCE — Generate all permutations, sort, pick kth
    // Time: O(n! * n)  |  Space: O(n!)

    // APPROACH 2: OPTIMAL — Math (Factorial number system)
    // Idea: Each position's digit can be determined using factorial.
    //       k-1 (0-indexed) / (n-1)! gives the index of the next digit.
    //       Update k = k % (n-1)! and repeat.
    // Time: O(n^2)  |  Space: O(n)
    public string Optimal(int n, int k)
    {
        var numbers = new List<int>();
        int factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            numbers.Add(i);
            factorial *= i;
        }

        k--; // convert to 0-indexed
        string result = "";

        for (int i = n; i >= 1; i--)
        {
            factorial /= i;
            int index = k / factorial;
            result += numbers[index].ToString();
            numbers.RemoveAt(index);
            k %= factorial;
        }

        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Factorial number system: position i determined by k / (n-1)!
// - Use 0-indexed k (subtract 1 first).
// - Maintain list of available numbers. Pick and remove by index.
// - O(n^2) due to list removal. Much better than O(n!) brute force.
// - Example: n=4, k=17 → factorial=[6,2,1], indices=[2,2,1,0] → "3421"
// - Interview tip: Walk through example step by step.
// ============================================================
