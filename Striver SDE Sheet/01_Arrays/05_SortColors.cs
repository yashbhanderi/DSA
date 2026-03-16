// ============================================================
// Problem: Sort Colors (Sort 0s, 1s, 2s) — Dutch National Flag
// Topic: Arrays I
// ============================================================
// PROBLEM STATEMENT:
//   Given an array with only 0s, 1s, and 2s, sort it in-place
//   without using a sorting algorithm. One-pass solution expected.
//
//   Input:  nums = [2, 0, 2, 1, 1, 0]
//   Output: [0, 0, 1, 1, 2, 2]
// ============================================================

using System;

public class SortColors
{
    // APPROACH 1: BRUTE FORCE — Count and overwrite
    // Idea: Count occurrences of 0, 1, 2. Then overwrite array.
    // Time: O(n) — two passes  |  Space: O(1)
    public void BruteForce(int[] nums)
    {
        int count0 = 0, count1 = 0, count2 = 0;

        // Pass 1: Count
        foreach (int num in nums)
        {
            if (num == 0) count0++;
            else if (num == 1) count1++;
            else count2++;
        }

        // Pass 2: Overwrite
        int idx = 0;
        while (count0-- > 0) nums[idx++] = 0;
        while (count1-- > 0) nums[idx++] = 1;
        while (count2-- > 0) nums[idx++] = 2;
    }

    // APPROACH 2: OPTIMAL — Dutch National Flag Algorithm (One Pass)
    // Idea: Use three pointers: low, mid, high.
    //   - [0..low-1] = all 0s
    //   - [low..mid-1] = all 1s
    //   - [mid..high] = unsorted
    //   - [high+1..n-1] = all 2s
    //   Process mid pointer:
    //     0 → swap with low, advance both
    //     1 → just advance mid
    //     2 → swap with high, shrink high (don't advance mid!)
    // Time: O(n) — single pass  |  Space: O(1)
    public void Optimal(int[] nums)
    {
        int low = 0, mid = 0, high = nums.Length - 1;

        while (mid <= high)
        {
            switch (nums[mid])
            {
                case 0:
                    (nums[low], nums[mid]) = (nums[mid], nums[low]);
                    low++;
                    mid++;
                    break;

                case 1:
                    mid++;
                    break;

                case 2:
                    (nums[mid], nums[high]) = (nums[high], nums[mid]);
                    high--;
                    // Don't increment mid — swapped element needs inspection
                    break;
            }
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Dutch National Flag: 3 pointers (low, mid, high).
// - mid encounters 0 → swap with low, move both forward.
// - mid encounters 1 → just move mid forward.
// - mid encounters 2 → swap with high, move high backward (NOT mid!).
// - Why not advance mid on 2? The swapped element from high is unknown.
// - Single pass, O(n) time, O(1) space.
// - Interview tip: Draw the pointer regions and walk through an example.
// ============================================================
