// ============================================================
// Problem: Search in a 2D Matrix
// Topic: Arrays III
// ============================================================
// PROBLEM STATEMENT:
//   Given an m x n matrix where each row is sorted and the first
//   element of each row is greater than the last element of the
//   previous row, search for a target value.
//
//   Input:  matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
//   Output: true
// ============================================================

using System;

public class SearchIn2DMatrix
{
    // APPROACH 1: BRUTE FORCE — Linear scan
    // Time: O(m * n)  |  Space: O(1)
    public bool BruteForce(int[][] matrix, int target)
    {
        foreach (var row in matrix)
            foreach (int val in row)
                if (val == target) return true;
        return false;
    }

    // APPROACH 2: BETTER — Binary search on each row
    // Time: O(m * log n)  |  Space: O(1)
    public bool Better(int[][] matrix, int target)
    {
        foreach (var row in matrix)
        {
            int left = 0, right = row.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (row[mid] == target) return true;
                else if (row[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
        }
        return false;
    }

    // APPROACH 3: OPTIMAL — Treat as flattened sorted array
    // Idea: The entire matrix is sorted if read row-by-row.
    //       Map 1D index to 2D: row = idx/n, col = idx%n.
    //       Do single binary search on [0, m*n - 1].
    // Time: O(log(m * n))  |  Space: O(1)
    public bool Optimal(int[][] matrix, int target)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int left = 0, right = m * n - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int row = mid / n;
            int col = mid % n;
            int val = matrix[row][col];

            if (val == target) return true;
            else if (val < target) left = mid + 1;
            else right = mid - 1;
        }

        return false;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Flatten m×n matrix into 1D sorted array conceptually.
// - Index mapping: row = mid / n, col = mid % n.
// - Single binary search on [0, m*n-1]. O(log(m*n)) time.
// - Works because first element of each row > last element of previous row.
// - Interview tip: If rows are sorted but NOT globally sorted, use staircase search (top-right corner) instead → O(m+n).
// ============================================================
