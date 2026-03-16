// ============================================================
// Problem: Pow(x, n) — Power Function
// Topic: Arrays III
// ============================================================
// PROBLEM STATEMENT:
//   Implement pow(x, n) which calculates x raised to power n.
//
//   Input:  x = 2.0, n = 10 → Output: 1024.0
//   Input:  x = 2.0, n = -2 → Output: 0.25
// ============================================================

using System;

public class PowXN
{
    // APPROACH 1: BRUTE FORCE — Multiply n times
    // Time: O(n)  |  Space: O(1)
    public double BruteForce(double x, int n)
    {
        long power = n;
        if (power < 0) { x = 1.0 / x; power = -power; }

        double result = 1.0;
        for (long i = 0; i < power; i++)
            result *= x;
        return result;
    }

    // APPROACH 2: OPTIMAL — Binary Exponentiation (Fast Power)
    // Idea: If n is even: x^n = (x^2)^(n/2)
    //       If n is odd:  x^n = x * x^(n-1)
    //       This reduces n by half each step → O(log n).
    // Time: O(log n)  |  Space: O(1)
    public double Optimal(double x, int n)
    {
        long power = n; // use long to handle int.MinValue
        if (power < 0) { x = 1.0 / x; power = -power; }

        double result = 1.0;
        while (power > 0)
        {
            if (power % 2 == 1) // odd power
            {
                result *= x;
                power--;
            }
            else // even power
            {
                x *= x;
                power /= 2;
            }
        }

        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Binary Exponentiation: Square x and halve n each step.
// - If n is odd, multiply result by x, then decrement n.
// - Handle negative n: invert x, make n positive.
// - Use long for n to avoid overflow with int.MinValue.
// - O(log n) time, O(1) space.
// - This is also used in modular exponentiation in competitive programming.
// ============================================================
