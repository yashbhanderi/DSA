// ============================================================
// Problem: Pascal's Triangle
// Topic: Arrays I
// ============================================================
// PROBLEM STATEMENT:
//   Given an integer numRows, return the first numRows of
//   Pascal's Triangle. Each number is the sum of the two
//   numbers directly above it.
//
//   Input:  numRows = 5
//   Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]
//
//   Variations asked:
//   1. Generate entire triangle up to row N
//   2. Find element at row r, col c
//   3. Print specific row N
// ============================================================

using System;
using System.Collections.Generic;

public class PascalTriangle
{
    // APPROACH 1: BRUTE FORCE — Element at (r, c) using nCr formula
    // Idea: Pascal[r][c] = C(r, c) = r! / (c! * (r-c)!)
    //       Compute factorial each time (wasteful for full triangle).
    // Time: O(r) per element  |  Space: O(1)
    public int GetElement(int row, int col)
    {
        // C(r, c) = r! / (c! * (r-c)!)
        // Optimized: multiply/divide step-by-step to avoid overflow
        long result = 1;
        for (int i = 0; i < col; i++)
        {
            result = result * (row - i);
            result = result / (i + 1);
        }
        return (int)result;
    }

    // APPROACH 2: BETTER — Generate a specific row N
    // Idea: Use the property that each element in a row can be
    //       derived from the previous one: C(n,k) = C(n,k-1) * (n-k+1)/k
    // Time: O(n)  |  Space: O(n)
    public IList<int> GetRow(int rowIndex)
    {
        var row = new List<int> { 1 };

        for (int col = 1; col <= rowIndex; col++)
        {
            // Derive next element from previous
            long val = (long)row[col - 1] * (rowIndex - col + 1) / col;
            row.Add((int)val);
        }

        return row;
    }

    // APPROACH 3: OPTIMAL — Generate entire Pascal's Triangle
    // Idea: Build row by row. Each row starts and ends with 1.
    //       Middle elements = sum of two elements from previous row.
    // Time: O(n^2)  |  Space: O(n^2) for the result
    public IList<IList<int>> Optimal(int numRows)
    {
        var triangle = new List<IList<int>>();

        for (int i = 0; i < numRows; i++)
        {
            var row = new List<int>();

            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    row.Add(1); // first and last element always 1
                }
                else
                {
                    // sum of two elements above
                    row.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
                }
            }

            triangle.Add(row);
        }

        return triangle;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - 3 variations: (a) element at (r,c), (b) specific row, (c) full triangle
// - Element at (r,c) = C(r,c). Compute using step multiply/divide to avoid overflow.
// - Single row trick: next = prev * (n-k+1) / k → O(n) per row.
// - Full triangle: Build iteratively, each cell = sum of above two.
// - 0-indexed: row 0 = [1], row 1 = [1,1], etc.
// - Interview tip: Clarify which variation is asked before coding.
// ============================================================
