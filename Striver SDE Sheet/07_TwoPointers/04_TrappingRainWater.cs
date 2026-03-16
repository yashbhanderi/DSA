// ============================================================
// Problem: Trapping Rain Water
// Topic: Two Pointers
// ============================================================
// PROBLEM STATEMENT:
//   Given elevation map (array of non-negative ints), compute
//   how much water it can trap after raining.
//   Input:  [0,1,0,2,1,0,1,3,2,1,2,1] → Output: 6
// ============================================================

using System;

public class TrappingRainWater
{
    // APPROACH 1: BRUTE FORCE — For each bar, find water above it
    // Idea: Water at i = min(maxLeft, maxRight) - height[i]
    // Time: O(n^2)  |  Space: O(1)
    public int BruteForce(int[] height)
    {
        int water = 0;
        for (int i = 0; i < height.Length; i++)
        {
            int leftMax = 0, rightMax = 0;
            for (int j = 0; j <= i; j++) leftMax = Math.Max(leftMax, height[j]);
            for (int j = i; j < height.Length; j++) rightMax = Math.Max(rightMax, height[j]);
            water += Math.Min(leftMax, rightMax) - height[i];
        }
        return water;
    }

    // APPROACH 2: BETTER — Precompute prefix and suffix max arrays
    // Time: O(n)  |  Space: O(n)
    public int Better(int[] height)
    {
        int n = height.Length;
        int[] leftMax = new int[n], rightMax = new int[n];

        leftMax[0] = height[0];
        for (int i = 1; i < n; i++) leftMax[i] = Math.Max(leftMax[i - 1], height[i]);

        rightMax[n - 1] = height[n - 1];
        for (int i = n - 2; i >= 0; i--) rightMax[i] = Math.Max(rightMax[i + 1], height[i]);

        int water = 0;
        for (int i = 0; i < n; i++)
            water += Math.Min(leftMax[i], rightMax[i]) - height[i];
        return water;
    }

    // APPROACH 3: OPTIMAL — Two Pointers
    // Idea: Maintain leftMax and rightMax. Move the pointer with smaller max.
    //       Water depends on the SMALLER of the two maxes.
    // Time: O(n)  |  Space: O(1)
    public int Optimal(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int water = 0;

        while (left < right)
        {
            if (height[left] <= height[right])
            {
                if (height[left] >= leftMax) leftMax = height[left];
                else water += leftMax - height[left];
                left++;
            }
            else
            {
                if (height[right] >= rightMax) rightMax = height[right];
                else water += rightMax - height[right];
                right--;
            }
        }

        return water;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Water at i = min(leftMax, rightMax) - height[i].
// - Brute: O(n^2). Better: Prefix arrays O(n). Optimal: Two pointers O(1).
// - Two pointers: Move the side with smaller height. Water depends on smaller boundary.
// - Key insight: If height[left] < height[right], water at left is bounded by leftMax.
// - Interview tip: Very popular. Master the two-pointer approach.
// ============================================================
