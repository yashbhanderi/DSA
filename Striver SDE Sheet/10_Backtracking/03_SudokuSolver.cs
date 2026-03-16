// ============================================================
// Problem: Sudoku Solver
// Topic: Backtracking
// ============================================================
// PROBLEM STATEMENT:
//   Solve a Sudoku puzzle by filling empty cells (denoted by '.').
//   Each row, column, and 3x3 box must contain digits 1-9 without repetition.
// ============================================================

using System;

public class SudokuSolver
{
    // APPROACH: Backtracking — Try digits 1-9, validate, recurse
    // Time: O(9^(empty cells))  |  Space: O(81)
    public void Optimal(char[][] board)
    {
        Solve(board);
    }

    private bool Solve(char[][] board)
    {
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                if (board[r][c] == '.')
                {
                    for (char digit = '1'; digit <= '9'; digit++)
                    {
                        if (IsValid(board, r, c, digit))
                        {
                            board[r][c] = digit;
                            if (Solve(board)) return true;
                            board[r][c] = '.'; // backtrack
                        }
                    }
                    return false; // no valid digit found → backtrack
                }
            }
        }
        return true; // all cells filled
    }

    private bool IsValid(char[][] board, int row, int col, char digit)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[row][i] == digit) return false;           // check row
            if (board[i][col] == digit) return false;           // check col
            // Check 3x3 box
            int boxRow = 3 * (row / 3) + i / 3;
            int boxCol = 3 * (col / 3) + i % 3;
            if (board[boxRow][boxCol] == digit) return false;
        }
        return true;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Find empty cell → try 1-9 → validate → recurse → backtrack.
// - Validation: check row, column, and 3x3 box.
// - Box formula: startRow = 3*(row/3), startCol = 3*(col/3).
// - Return false immediately when no digit works (triggers backtrack).
// - Optimization: Use bitmasking for faster validation.
// ============================================================
