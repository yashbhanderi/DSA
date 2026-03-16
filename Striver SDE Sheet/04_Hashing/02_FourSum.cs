// ============================================================
// Problem: 4Sum
// Topic: Hashing
// ============================================================
// PROBLEM STATEMENT:
//   Given an array nums and target, find all unique quadruplets
//   [a, b, c, d] such that a + b + c + d = target.
//
//   Input:  nums = [1,0,-1,0,-2,2], target = 0
//   Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
// ============================================================

using System;
using System.Collections.Generic;

public class FourSum
{
    // APPROACH 1: BRUTE FORCE — Four nested loops
    // Time: O(n^4)  |  Space: O(1) + result
    // Not practical for large inputs.

    // APPROACH 2: OPTIMAL — Sort + Two Pointers (Like 3Sum with extra loop)
    // Idea: Sort the array. Fix first two elements (i, j). Use two pointers
    //       for remaining two. Skip duplicates at each level.
    // Time: O(n^3)  |  Space: O(1) + result
    public IList<IList<int>> Optimal(int[] nums, int target)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        int n = nums.Length;

        for (int i = 0; i < n - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue; // skip duplicate i

            for (int j = i + 1; j < n - 2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue; // skip duplicate j

                int left = j + 1, right = n - 1;

                while (left < right)
                {
                    long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                    if (sum == target)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });

                        // Skip duplicates
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < target) left++;
                    else right--;
                }
            }
        }

        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort array. Fix two elements (i, j), use two pointers for rest.
// - Skip duplicates at all 4 levels to avoid duplicate quadruplets.
// - Use long for sum to avoid overflow.
// - O(n^3) time. Generalization of 3Sum.
// - kSum pattern: Fix k-2 elements, use two pointers for last 2.
// - Interview tip: Mention the kSum generalization.
// ============================================================
