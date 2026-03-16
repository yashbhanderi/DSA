// ============================================================
// Problem: Rat in a Maze
// Topic: Backtracking
// ============================================================
// PROBLEM STATEMENT:
//   Given an n×n maze (0 = blocked, 1 = open), find all paths from
//   top-left (0,0) to bottom-right (n-1,n-1). Can move D,L,R,U.
//   Input: maze = [[1,0,0,0],[1,1,0,1],[1,1,0,0],[0,1,1,1]]
//   Output: ["DDRDRR","DRDDRR"]
// ============================================================

using System;
using System.Collections.Generic;

public class RatInAMaze
{
    // APPROACH: Backtracking with all 4 directions
    // Time: O(4^(n*n))  |  Space: O(n*n)
    public List<string> Optimal(int[][] maze, int n)
    {
        var result = new List<string>();
        if (maze[0][0] == 0 || maze[n - 1][n - 1] == 0) return result;

        bool[,] visited = new bool[n, n];
        Solve(maze, n, 0, 0, "", visited, result);
        return result;
    }

    private void Solve(int[][] maze, int n, int row, int col, string path,
        bool[,] visited, List<string> result)
    {
        if (row == n - 1 && col == n - 1)
        {
            result.Add(path);
            return;
        }

        // Direction: Down, Left, Right, Up (lexicographic order)
        int[] dr = { 1, 0, 0, -1 };
        int[] dc = { 0, -1, 1, 0 };
        char[] dir = { 'D', 'L', 'R', 'U' };

        visited[row, col] = true;

        for (int i = 0; i < 4; i++)
        {
            int nr = row + dr[i], nc = col + dc[i];
            if (nr >= 0 && nr < n && nc >= 0 && nc < n
                && maze[nr][nc] == 1 && !visited[nr, nc])
            {
                Solve(maze, n, nr, nc, path + dir[i], visited, result);
            }
        }

        visited[row, col] = false; // backtrack
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - 4 directions (D,L,R,U) in lexicographic order for sorted output.
// - Use visited[][] to avoid revisiting cells in current path.
// - Backtrack: unmark visited after recursion returns.
// - Base: reached (n-1, n-1) → add path to result.
// - Check maze[0][0] and maze[n-1][n-1] are open before starting.
// ============================================================
