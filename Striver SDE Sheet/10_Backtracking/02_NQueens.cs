// ============================================================
// Problem: N-Queens
// Topic: Backtracking
// ============================================================
// PROBLEM STATEMENT:
//   Place n queens on an n×n chessboard so no two attack each other.
//   Return all distinct solutions.
//   Input: n=4 → Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
// ============================================================

using System;
using System.Collections.Generic;

public class NQueens
{
    // APPROACH: Backtracking with hash sets for O(1) conflict check
    // Idea: Place queens column by column. For each row, check if
    //       it's safe (no conflict in same row, diagonal, anti-diagonal).
    //       Use sets for O(1) lookup instead of O(n) board scanning.
    // Time: O(n!)  |  Space: O(n^2)
    public IList<IList<string>> Optimal(int n)
    {
        var result = new List<IList<string>>();
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++) { board[i] = new char[n]; Array.Fill(board[i], '.'); }

        var cols = new HashSet<int>();
        var diag = new HashSet<int>();     // row - col
        var antiDiag = new HashSet<int>(); // row + col

        Solve(board, 0, n, cols, diag, antiDiag, result);
        return result;
    }

    private void Solve(char[][] board, int row, int n, HashSet<int> cols,
        HashSet<int> diag, HashSet<int> antiDiag, List<IList<string>> result)
    {
        if (row == n)
        {
            var solution = new List<string>();
            foreach (var r in board) solution.Add(new string(r));
            result.Add(solution);
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (cols.Contains(col) || diag.Contains(row - col) || antiDiag.Contains(row + col))
                continue;

            // Place queen
            board[row][col] = 'Q';
            cols.Add(col); diag.Add(row - col); antiDiag.Add(row + col);

            Solve(board, row + 1, n, cols, diag, antiDiag, result);

            // Remove queen
            board[row][col] = '.';
            cols.Remove(col); diag.Remove(row - col); antiDiag.Remove(row + col);
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Backtracking: place queen row by row. Try each column.
// - Conflict check: same col, same diagonal (row-col), same anti-diagonal (row+col).
// - Use HashSets for O(1) conflict detection (better than scanning board).
// - Can also use boolean arrays indexed by col, row-col+n, row+col.
// - Time: ~O(n!). Pruning makes it much less in practice.
// - Interview tip: Explain the diagonal encoding (row-col and row+col constants).
// ============================================================
