// ============================================================
// Problem: Count Inversions (Using Merge Sort)
// Topic: Arrays II
// ============================================================
// PROBLEM STATEMENT:
//   Given an array, count the number of inversions. An inversion
//   is a pair (i, j) where i < j but arr[i] > arr[j].
//
//   Input:  arr = [5, 3, 2, 4, 1]
//   Output: 7  (pairs: (5,3),(5,2),(5,4),(5,1),(3,2),(3,1),(2,1))
// ============================================================

using System;

public class CountInversions
{
    // APPROACH 1: BRUTE FORCE — Check all pairs
    // Idea: For each pair (i, j) where i < j, check if arr[i] > arr[j].
    // Time: O(n^2)  |  Space: O(1)
    public long BruteForce(int[] arr)
    {
        long count = 0;
        int n = arr.Length;

        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                if (arr[i] > arr[j])
                    count++;

        return count;
    }

    // APPROACH 2: OPTIMAL — Merge Sort Based
    // Idea: During merge sort, when merging two halves, if arr[left] > arr[right],
    //       then ALL remaining elements in the left half also form inversions
    //       with arr[right] (since left half is sorted).
    //       count += mid - leftIndex + 1
    // Time: O(n log n)  |  Space: O(n) for temp array
    private long _count;

    public long Optimal(int[] arr)
    {
        _count = 0;
        int[] temp = new int[arr.Length];
        MergeSort(arr, temp, 0, arr.Length - 1);
        return _count;
    }

    private void MergeSort(int[] arr, int[] temp, int low, int high)
    {
        if (low >= high) return;

        int mid = (low + high) / 2;
        MergeSort(arr, temp, low, mid);
        MergeSort(arr, temp, mid + 1, high);
        Merge(arr, temp, low, mid, high);
    }

    private void Merge(int[] arr, int[] temp, int low, int mid, int high)
    {
        int left = low, right = mid + 1, k = low;

        while (left <= mid && right <= high)
        {
            if (arr[left] <= arr[right])
            {
                temp[k++] = arr[left++];
            }
            else
            {
                // Inversion found: all elements from left to mid are > arr[right]
                _count += (mid - left + 1);
                temp[k++] = arr[right++];
            }
        }

        while (left <= mid) temp[k++] = arr[left++];
        while (right <= high) temp[k++] = arr[right++];

        Array.Copy(temp, low, arr, low, high - low + 1);
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Modified Merge Sort: Count inversions during the merge step.
// - When arr[left] > arr[right] during merge, inversions += (mid - left + 1).
// - Why? Left half is sorted, so ALL remaining elements in left > arr[right].
// - O(n log n) time, O(n) space. Same as merge sort.
// - This pattern is reused in "Reverse Pairs" problem.
// - Interview tip: Clearly explain why the count formula works during merge.
// ============================================================
