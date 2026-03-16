// ============================================================
// Problem: Majority Element II (> N/3 times)
// Topic: Arrays III
// ============================================================
// PROBLEM STATEMENT:
//   Find all elements appearing more than n/3 times.
//   At most 2 such elements can exist.
//
//   Input:  nums = [3, 2, 3]
//   Output: [3]
//
//   Input:  nums = [1, 1, 1, 3, 3, 2, 2, 2]
//   Output: [1, 2]
// ============================================================

using System;
using System.Collections.Generic;

public class MajorityElementII
{
    // APPROACH 1: BRUTE FORCE — HashMap
    // Time: O(n)  |  Space: O(n)
    public IList<int> BruteForce(int[] nums)
    {
        var freq = new Dictionary<int, int>();
        var result = new List<int>();
        int threshold = nums.Length / 3;

        foreach (int num in nums)
            freq[num] = freq.GetValueOrDefault(num, 0) + 1;

        foreach (var kvp in freq)
            if (kvp.Value > threshold)
                result.Add(kvp.Key);

        return result;
    }

    // APPROACH 2: OPTIMAL — Extended Boyer-Moore (2 candidates)
    // Idea: At most 2 elements can appear > n/3 times.
    //       Track two candidates with counts. Same logic as Boyer-Moore
    //       but with two pairs.
    // Time: O(n)  |  Space: O(1)
    public IList<int> Optimal(int[] nums)
    {
        int cand1 = int.MinValue, cand2 = int.MinValue;
        int count1 = 0, count2 = 0;

        // Phase 1: Find potential candidates
        foreach (int num in nums)
        {
            if (num == cand1)
                count1++;
            else if (num == cand2)
                count2++;
            else if (count1 == 0)
            {
                cand1 = num;
                count1 = 1;
            }
            else if (count2 == 0)
            {
                cand2 = num;
                count2 = 1;
            }
            else
            {
                count1--;
                count2--;
            }
        }

        // Phase 2: Verify candidates
        count1 = count2 = 0;
        foreach (int num in nums)
        {
            if (num == cand1) count1++;
            else if (num == cand2) count2++;
        }

        var result = new List<int>();
        int threshold = nums.Length / 3;
        if (count1 > threshold) result.Add(cand1);
        if (count2 > threshold) result.Add(cand2);

        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - At most 2 elements can be > n/3. (3 would need > n elements.)
// - Extended Boyer-Moore: 2 candidates, 2 counts.
// - Order of checks matters: match cand1 → match cand2 → replace empty → decrement both.
// - MUST verify candidates in a second pass (not guaranteed like >n/2).
// - O(n) time, O(1) space.
// - Generalization: For > n/k, track k-1 candidates.
// ============================================================
