// ============================================================
// Problem: Rotate Image (Rotate Matrix 90° Clockwise)
// Topic: Arrays II
// ============================================================
// PROBLEM STATEMENT:
//   Given an n x n 2D matrix representing an image,
//   rotate it by 90 degrees clockwise in-place.
//
//   Input:  [[1,2,3],[4,5,6],[7,8,9]]
//   Output: [[7,4,1],[8,5,2],[9,6,3]]
// ============================================================

using System;

public class RotateImage
{
    // APPROACH 1: BRUTE FORCE — Use extra matrix
    // Idea: Create a new matrix. Element at (i,j) goes to (j, n-1-i).
    // Time: O(n^2)  |  Space: O(n^2)
    public int[][] BruteForce(int[][] matrix)
    {
        int n = matrix.Length;
        int[][] result = new int[n][];
        for (int i = 0; i < n; i++) result[i] = new int[n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                result[j][n - 1 - i] = matrix[i][j];

        return result;
    }

    // APPROACH 2: OPTIMAL — Transpose + Reverse each row
    // Idea: Step 1: Transpose the matrix (swap matrix[i][j] with matrix[j][i])
    //       Step 2: Reverse each row
    //       This gives a 90° clockwise rotation in-place.
    // Time: O(n^2)  |  Space: O(1)
    public void Optimal(int[][] matrix)
    {
        int n = matrix.Length;

        // Step 1: Transpose
        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);

        // Step 2: Reverse each row
        for (int i = 0; i < n; i++)
            Array.Reverse(matrix[i]);
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - 90° clockwise = Transpose + Reverse each row
// - 90° counter-clockwise = Transpose + Reverse each column
// - 180° = Reverse each row + Reverse each column
// - Transpose: swap (i,j) with (j,i) — only upper triangle!
// - O(n^2) time, O(1) space for in-place.
// - Interview tip: Don't confuse with spiral traversal.
// ============================================================
