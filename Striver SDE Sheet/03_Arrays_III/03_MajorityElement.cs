// ============================================================
// Problem: Majority Element (> N/2 times) — Boyer-Moore Voting
// Topic: Arrays III
// ============================================================
// PROBLEM STATEMENT:
//   Find the element that appears more than n/2 times.
//   Guaranteed to exist.
//
//   Input:  nums = [2, 2, 1, 1, 1, 2, 2]
//   Output: 2
// ============================================================

using System;
using System.Collections.Generic;

public class MajorityElement
{
    // APPROACH 1: BRUTE FORCE — Count each element
    // Time: O(n^2)  |  Space: O(1)
    public int BruteForce(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
                if (nums[j] == nums[i]) count++;
            if (count > n / 2) return nums[i];
        }
        return -1;
    }

    // APPROACH 2: BETTER — HashMap
    // Time: O(n)  |  Space: O(n)
    public int Better(int[] nums)
    {
        var freq = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            freq[num] = freq.GetValueOrDefault(num, 0) + 1;
            if (freq[num] > nums.Length / 2) return num;
        }
        return -1;
    }

    // APPROACH 3: OPTIMAL — Boyer-Moore Voting Algorithm
    // Idea: Maintain a candidate and a count. For each element:
    //       If count == 0, set current as candidate.
    //       If element == candidate, count++; else count--.
    //       The last surviving candidate is the majority element.
    // Time: O(n)  |  Space: O(1)
    public int Optimal(int[] nums)
    {
        int candidate = 0, count = 0;

        // Phase 1: Find candidate
        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
                count = 1;
            }
            else if (num == candidate)
                count++;
            else
                count--;
        }

        // Phase 2: Verify (if not guaranteed)
        // count = 0;
        // foreach (int num in nums) if (num == candidate) count++;
        // if (count > nums.Length / 2) return candidate;
        // return -1;

        return candidate; // guaranteed to exist per problem statement
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Boyer-Moore Voting: Keep candidate + count.
// - count=0 → new candidate. Same→count++. Different→count--.
// - Majority element (>n/2) can never be fully "cancelled out."
// - O(n) time, O(1) space. Add verification pass if not guaranteed.
// - For >N/3 version, use TWO candidates (see next problem).
// - Interview tip: Explain WHY it works — majority survives all cancellations.
// ============================================================
