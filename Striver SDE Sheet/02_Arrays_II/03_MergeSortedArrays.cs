// ============================================================
// Problem: Merge Two Sorted Arrays Without Extra Space
// Topic: Arrays II
// ============================================================
// PROBLEM STATEMENT:
//   Given two sorted arrays arr1[] and arr2[], merge them
//   such that arr1 contains first m smallest and arr2 contains
//   remaining, both sorted. Do it without extra space.
//
//   Input:  arr1 = [1,3,5,7], arr2 = [0,2,6,8,9]
//   Output: arr1 = [0,1,2,3], arr2 = [5,6,7,8,9]
// ============================================================

using System;

public class MergeSortedArrays
{
    // APPROACH 1: BRUTE FORCE — Merge into temp array, copy back
    // Idea: Use a temporary array, merge like merge sort, copy back.
    // Time: O(m + n)  |  Space: O(m + n)
    public void BruteForce(int[] arr1, int[] arr2)
    {
        int m = arr1.Length, n = arr2.Length;
        int[] temp = new int[m + n];
        int i = 0, j = 0, k = 0;

        while (i < m && j < n)
            temp[k++] = arr1[i] <= arr2[j] ? arr1[i++] : arr2[j++];
        while (i < m) temp[k++] = arr1[i++];
        while (j < n) temp[k++] = arr2[j++];

        Array.Copy(temp, 0, arr1, 0, m);
        Array.Copy(temp, m, arr2, 0, n);
    }

    // APPROACH 2: BETTER — Swap and Sort (GAP Method / Shell Sort Idea)
    // Idea: Use Gap algorithm (gap = ceil((m+n)/2)). Compare elements
    //       that are 'gap' apart and swap if needed. Keep halving gap.
    // Time: O((m+n) * log(m+n))  |  Space: O(1)
    public void Optimal(int[] arr1, int[] arr2)
    {
        int m = arr1.Length, n = arr2.Length;
        int totalLen = m + n;
        int gap = (totalLen + 1) / 2; // ceil(totalLen / 2)

        while (gap > 0)
        {
            int left = 0, right = left + gap;

            while (right < totalLen)
            {
                // Case 1: Both in arr1
                if (left < m && right < m)
                {
                    if (arr1[left] > arr1[right])
                        (arr1[left], arr1[right]) = (arr1[right], arr1[left]);
                }
                // Case 2: left in arr1, right in arr2
                else if (left < m && right >= m)
                {
                    if (arr1[left] > arr2[right - m])
                        (arr1[left], arr2[right - m]) = (arr2[right - m], arr1[left]);
                }
                // Case 3: Both in arr2
                else
                {
                    if (arr2[left - m] > arr2[right - m])
                        (arr2[left - m], arr2[right - m]) = (arr2[right - m], arr2[left - m]);
                }

                left++;
                right++;
            }

            if (gap == 1) break;
            gap = (gap + 1) / 2;
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Gap Method: Shell sort inspired, gap = ceil(total/2), halve each iteration.
// - Compare elements 'gap' apart, swap if out of order.
// - Handle 3 cases: both in arr1, one in each, both in arr2.
// - O((m+n)log(m+n)) time, O(1) space.
// - Alternative: Start from end of arr1 and start of arr2, swap if arr1[end] > arr2[start], then re-sort both. Simpler but O(nlogn).
// - Interview tip: Explain Gap method but mention simpler swap approach too.
// ============================================================
