using System.Collections.Generic;

namespace neetcode.Arrays
{
    public class ValidSudoku
    {
        public static bool IsValidSudoku(char[][] board)
        {
            // 1) Check rows
            for (int i = 0; i < 9; i++)
            {
                var set = new HashSet<char>();
                for (int j = 0; j < 9; j++)
                {
                    var currentChar = board[i][j];
                    if (currentChar != '.')
                    {
                        if (set.Contains(currentChar))
                        {
                            System.Console.WriteLine($"1) false {i}, {j}");
                            return false;
                        }
                        set.Add(currentChar);
                    }
                }
            }

            // 2) Check columns
            for (int i = 0; i < 9; i++)
            {
                var set = new HashSet<char>();
                for (int j = 0; j < 9; j++)
                {
                    var currentChar = board[j][i];
                    if (currentChar != '.')
                    {
                        if (set.Contains(currentChar))
                        {
                            System.Console.WriteLine($"2) false {i}, {j}");
                            return false;
                        }
                        set.Add(currentChar);
                    }
                }
            }

            // 3) Check every sub-boards
            for (int x = 3; x <= 9; x += 3)
            {
                for (int y = 3; y <= 9; y += 3)
                {
                    System.Console.WriteLine($"X: {x}, Y: {y}");
                    var set = new HashSet<char>();
                    for (int i = x - 3; i < x; i++)
                    {
                        for (int j = y - 3; j < y; j++)
                        {
                            var currentChar = board[i][j];
                            if (currentChar != '.')
                            {
                                if (set.Contains(currentChar))
                                {
                                    System.Console.WriteLine($"3) false {i}, {j}, {x}, {y}");
                                    return false;
                                }
                                set.Add(currentChar);
                            }
                        }
                    }
                }
            }

            return true;
        }

        public static void Main()
        {
            char[][] board = new char[][]
            {
                new char[] {'.','.','.','.','5','.','.','1','.'},
                new char[] {'.','4','.','3','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','3','.','.','1'},

                new char[] {'8','.','.','.','.','.','.','2','.'},
                new char[] {'.','.','2','.','7','.','.','.','.'},
                new char[] {'.','1','5','.','.','.','.','.','.'},

                new char[] {'.','.','.','.','.','2','.','.','.'},
                new char[] {'.','2','.','9','.','.','.','.','.'},
                new char[] {'.','.','4','.','.','.','.','.','.'}
            };

            IsValidSudoku(board);
        }
    }
}