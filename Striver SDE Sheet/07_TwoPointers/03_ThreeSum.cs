// ============================================================
// Problem: 3Sum
// Topic: Two Pointers
// ============================================================
// PROBLEM STATEMENT:
//   Find all unique triplets in the array that sum to zero.
//   Input:  [-1,0,1,2,-1,-4] → Output: [[-1,-1,2],[-1,0,1]]
// ============================================================

using System;
using System.Collections.Generic;

public class ThreeSum
{
    // APPROACH 1: BRUTE FORCE — Three nested loops + Set for dedup
    // Time: O(n^3)  |  Space: O(n)

    // APPROACH 2: OPTIMAL — Sort + Fix one + Two Pointers
    // Time: O(n^2)  |  Space: O(1) + result
    public IList<IList<int>> Optimal(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue; // skip dup
            if (nums[i] > 0) break; // optimization: can't sum to 0

            int left = i + 1, right = nums.Length - 1;
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;
                    left++; right--;
                }
                else if (sum < 0) left++;
                else right--;
            }
        }
        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort + fix one element + two pointers for other two. O(n^2).
// - Skip duplicates at all three levels.
// - Early break if nums[i] > 0 (can't sum to 0 with larger elements).
// - Same pattern for kSum: fix k-2 elements, two pointers for last 2.
// ============================================================
