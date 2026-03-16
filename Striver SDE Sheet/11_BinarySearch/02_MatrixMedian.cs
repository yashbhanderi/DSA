// ============================================================
// Problem: Matrix Median
// Topic: Binary Search
// ============================================================
// PROBLEM STATEMENT:
//   Given a row-wise sorted matrix with odd total elements,
//   find the median. Each row is sorted independently.
//   Input: [[1,3,5],[2,6,9],[3,6,9]] → Output: 5
// ============================================================

using System;

public class MatrixMedian
{
    // APPROACH: Binary Search on value range
    // Idea: Median is the element with exactly (r*c/2) elements smaller.
    //       Binary search on value space [min, max]. For each mid, count
    //       elements ≤ mid across all rows using binary search per row.
    // Time: O(r * log(c) * log(max-min))  |  Space: O(1)
    public int Optimal(int[][] matrix)
    {
        int r = matrix.Length, c = matrix[0].Length;
        int low = int.MaxValue, high = int.MinValue;

        // Find global min and max
        for (int i = 0; i < r; i++)
        {
            low = Math.Min(low, matrix[i][0]);
            high = Math.Max(high, matrix[i][c - 1]);
        }

        int desired = (r * c + 1) / 2; // position of median

        while (low < high)
        {
            int mid = low + (high - low) / 2;
            int count = CountLessEqual(matrix, mid);

            if (count < desired)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }

    private int CountLessEqual(int[][] matrix, int target)
    {
        int count = 0;
        foreach (var row in matrix)
            count += UpperBound(row, target);
        return count;
    }

    private int UpperBound(int[] arr, int target)
    {
        int lo = 0, hi = arr.Length;
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (arr[mid] <= target) lo = mid + 1;
            else hi = mid;
        }
        return lo;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Binary search on VALUE (not index). Range: [global min, global max].
// - For each candidate mid, count elements ≤ mid using upper_bound per row.
// - Median position = (r*c+1)/2. Find smallest value with that many elements ≤ it.
// - O(r * log(c) * log(max-min)). Elegant use of binary search on answer.
// ============================================================
