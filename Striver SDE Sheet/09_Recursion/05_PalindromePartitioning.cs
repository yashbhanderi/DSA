// ============================================================
// Problem: Palindrome Partitioning
// Topic: Recursion
// ============================================================
// PROBLEM STATEMENT:
//   Partition a string such that every substring is a palindrome.
//   Return all possible palindrome partitions.
//   Input:  "aab" → Output: [["a","a","b"],["aa","b"]]
// ============================================================

using System;
using System.Collections.Generic;

public class PalindromePartitioning
{
    // APPROACH: Backtracking
    // Idea: Try every possible prefix. If it's a palindrome,
    //       recursively partition the rest.
    // Time: O(n * 2^n)  |  Space: O(n) depth
    public IList<IList<string>> Optimal(string s)
    {
        var result = new List<IList<string>>();
        Backtrack(s, 0, new List<string>(), result);
        return result;
    }

    private void Backtrack(string s, int start, List<string> current, List<IList<string>> result)
    {
        if (start == s.Length)
        {
            result.Add(new List<string>(current));
            return;
        }

        for (int end = start; end < s.Length; end++)
        {
            if (IsPalindrome(s, start, end))
            {
                current.Add(s.Substring(start, end - start + 1));
                Backtrack(s, end + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left++] != s[right--]) return false;
        }
        return true;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - For each position, try all prefixes. If palindrome → recurse on rest.
// - Base: start == s.Length → valid partition found.
// - IsPalindrome check: O(n) per check. Could optimize with DP precomputation.
// - Related: "Palindrome Partitioning II" asks for MIN cuts → use DP.
// - Time: O(n * 2^n). Each substring checked + 2^n possible partitions.
// ============================================================
