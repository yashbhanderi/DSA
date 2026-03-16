// ============================================================
// Problem: Max Consecutive Ones
// Topic: Two Pointers
// ============================================================
// PROBLEM STATEMENT:
//   Find the maximum number of consecutive 1's in a binary array.
//   Input:  [1,1,0,1,1,1] → Output: 3
// ============================================================

using System;

public class MaxConsecutiveOnes
{
    // APPROACH: Single pass counter
    // Time: O(n)  |  Space: O(1)
    public int Optimal(int[] nums)
    {
        int maxCount = 0, count = 0;

        foreach (int num in nums)
        {
            if (num == 1)
            {
                count++;
                maxCount = Math.Max(maxCount, count);
            }
            else
            {
                count = 0;
            }
        }

        return maxCount;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Simple counter: increment on 1, reset on 0, track max.
// - O(n) time, O(1) space. Straightforward.
// - Follow-up: "Max Consecutive Ones II" allows flipping one 0.
//   Use sliding window with at most one 0 inside window.
// ============================================================
