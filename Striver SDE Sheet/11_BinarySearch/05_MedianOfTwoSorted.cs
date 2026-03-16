// ============================================================
// Problem: Median of Two Sorted Arrays
// Topic: Binary Search
// ============================================================
// PROBLEM STATEMENT:
//   Given two sorted arrays nums1 and nums2, return their median.
//   Time complexity must be O(log(min(m,n))).
//   Input: nums1=[1,3], nums2=[2] → Output: 2.0
// ============================================================

using System;

public class MedianOfTwoSortedArrays
{
    // APPROACH: Binary Search on the smaller array
    // Idea: Partition both arrays such that left half has (m+n+1)/2 elements.
    //       Binary search on smaller array to find correct partition.
    //       At correct partition: maxLeft1 <= minRight2 AND maxLeft2 <= minRight1.
    // Time: O(log(min(m,n)))  |  Space: O(1)
    public double Optimal(int[] nums1, int[] nums2)
    {
        // Ensure nums1 is the smaller array
        if (nums1.Length > nums2.Length)
            return Optimal(nums2, nums1);

        int m = nums1.Length, n = nums2.Length;
        int low = 0, high = m;

        while (low <= high)
        {
            int cut1 = (low + high) / 2;           // partition in nums1
            int cut2 = (m + n + 1) / 2 - cut1;     // partition in nums2

            int left1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
            int left2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];
            int right1 = cut1 == m ? int.MaxValue : nums1[cut1];
            int right2 = cut2 == n ? int.MaxValue : nums2[cut2];

            if (left1 <= right2 && left2 <= right1)
            {
                // Correct partition found
                if ((m + n) % 2 == 0)
                    return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                else
                    return Math.Max(left1, left2);
            }
            else if (left1 > right2)
                high = cut1 - 1;
            else
                low = cut1 + 1;
        }

        return 0.0;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Binary search on SMALLER array. Partition both so left side has (m+n+1)/2 elements.
// - Valid partition: maxLeft1 ≤ minRight2 AND maxLeft2 ≤ minRight1.
// - Use INT_MIN/MAX for boundary cases (cut at 0 or at length).
// - Odd total: median = max(left1, left2). Even: average of max(lefts) and min(rights).
// - O(log(min(m,n))). One of the hardest binary search problems.
// - Interview tip: Draw the partition diagram. Practice the edge cases.
// ============================================================
