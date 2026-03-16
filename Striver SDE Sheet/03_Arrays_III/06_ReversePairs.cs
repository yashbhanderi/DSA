// ============================================================
// Problem: Reverse Pairs
// Topic: Arrays III
// ============================================================
// PROBLEM STATEMENT:
//   Given an integer array nums, return the number of reverse pairs.
//   A reverse pair is (i, j) where i < j and nums[i] > 2 * nums[j].
//
//   Input:  nums = [1, 3, 2, 3, 1]
//   Output: 2  (pairs: (3,1) and (3,1))
// ============================================================

using System;

public class ReversePairs
{
    // APPROACH 1: BRUTE FORCE — Check all pairs
    // Time: O(n^2)  |  Space: O(1)
    public int BruteForce(int[] nums)
    {
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
            for (int j = i + 1; j < nums.Length; j++)
                if (nums[i] > 2L * nums[j])
                    count++;
        return count;
    }

    // APPROACH 2: OPTIMAL — Merge Sort Based
    // Idea: Similar to Count Inversions, but count pairs BEFORE merging.
    //       For each element in left half, count elements in right half
    //       where nums[left] > 2 * nums[right] using two pointers.
    // Time: O(n log n)  |  Space: O(n)
    public int Optimal(int[] nums)
    {
        return MergeSort(nums, 0, nums.Length - 1);
    }

    private int MergeSort(int[] nums, int low, int high)
    {
        if (low >= high) return 0;

        int mid = (low + high) / 2;
        int count = MergeSort(nums, low, mid) + MergeSort(nums, mid + 1, high);

        // Count reverse pairs BEFORE merging
        count += CountPairs(nums, low, mid, high);

        // Standard merge
        Merge(nums, low, mid, high);
        return count;
    }

    private int CountPairs(int[] nums, int low, int mid, int high)
    {
        int count = 0;
        int right = mid + 1;

        // Both halves are sorted. For each left element, find how many right elements satisfy condition.
        for (int left = low; left <= mid; left++)
        {
            while (right <= high && nums[left] > 2L * nums[right])
                right++;
            count += (right - (mid + 1));
        }

        return count;
    }

    private void Merge(int[] nums, int low, int mid, int high)
    {
        int[] temp = new int[high - low + 1];
        int left = low, right = mid + 1, k = 0;

        while (left <= mid && right <= high)
            temp[k++] = nums[left] <= nums[right] ? nums[left++] : nums[right++];
        while (left <= mid) temp[k++] = nums[left++];
        while (right <= high) temp[k++] = nums[right++];

        Array.Copy(temp, 0, nums, low, temp.Length);
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Same merge sort pattern as Count Inversions.
// - Key difference: Count pairs SEPARATELY before merging (condition differs from sort order).
// - Use 2L * nums[right] to avoid integer overflow.
// - Two pointer counting works because both halves are sorted.
// - O(n log n) time, O(n) space.
// - Interview tip: Separate counting step from merging step for clarity.
// ============================================================
