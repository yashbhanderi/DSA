// ============================================================
// Problem: Set Matrix Zeroes
// Topic: Arrays I
// ============================================================
// PROBLEM STATEMENT:
//   Given an m x n matrix, if an element is 0, set its entire
//   row and column to 0. Do it in place.
//
//   Input:  A 2D integer matrix of size m x n
//   Output: Modified matrix where rows and columns containing 0
//           are entirely set to 0
//
//   Example:
//   Input:  [[1,1,1],[1,0,1],[1,1,1]]
//   Output: [[1,0,1],[0,0,0],[1,0,1]]
// ============================================================

using System;
using System.Collections.Generic;

public class SetMatrixZeroes
{
    // APPROACH 1: BRUTE FORCE
    // Idea: For each 0 found, mark its entire row/col with a sentinel
    //       value (-1 or similar), then convert sentinels to 0.
    //       Problem: fails if matrix contains the sentinel value.
    // Time: O(m * n * (m + n))  |  Space: O(1)
    public void BruteForce(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;

        // We'll store positions of zeroes first
        var zeroPositions = new List<(int row, int col)>();

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i][j] == 0)
                    zeroPositions.Add((i, j));

        // For each zero, set entire row and column to 0
        foreach (var (row, col) in zeroPositions)
        {
            for (int j = 0; j < n; j++) matrix[row][j] = 0; // set row
            for (int i = 0; i < m; i++) matrix[i][col] = 0; // set col
        }
    }

    // APPROACH 2: BETTER — Use extra arrays to track zero rows/cols
    // Idea: Use two boolean arrays to mark which rows and columns
    //       need to be zeroed, then iterate and apply.
    // Time: O(m * n)  |  Space: O(m + n)
    public void Better(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        bool[] zeroRow = new bool[m];
        bool[] zeroCol = new bool[n];

        // Pass 1: find and mark zero positions
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i][j] == 0)
                {
                    zeroRow[i] = true;
                    zeroCol[j] = true;
                }

        // Pass 2: apply the zeroing
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (zeroRow[i] || zeroCol[j])
                    matrix[i][j] = 0;
    }

    // APPROACH 3: OPTIMAL — Use first row and first col as markers
    // Idea: Instead of extra arrays, use the matrix's own first row
    //       and first column as markers. Use a separate variable for
    //       the first column's status.
    // Time: O(m * n)  |  Space: O(1)
    public void Optimal(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        bool firstColZero = false;

        // Use first row and first col as markers
        for (int i = 0; i < m; i++)
        {
            if (matrix[i][0] == 0) firstColZero = true;

            for (int j = 1; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0; // mark row
                    matrix[0][j] = 0; // mark col
                }
            }
        }

        // Zero out cells based on markers (go bottom-right to top-left)
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 1; j--)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            }
            if (firstColZero) matrix[i][0] = 0;
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Brute: Store zero positions → set rows/cols. O(m*n*(m+n))
// - Better: Two boolean arrays for rows/cols. O(m+n) space.
// - Optimal: Use first row & col as markers + one bool for col0.
//   Process BOTTOM-UP to avoid overwriting markers prematurely.
// - Key trap: The first column needs special handling (separate bool).
// - Interview tip: Start with brute, explain trade-offs, jump to optimal.
// ============================================================
