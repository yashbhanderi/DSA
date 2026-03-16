// ============================================================
// Problem: Word Break
// Topic: Backtracking
// ============================================================
// PROBLEM STATEMENT:
//   Given a string s and dictionary of words, determine if s
//   can be segmented into space-separated dictionary words.
//   Input: s="leetcode", dict=["leet","code"] → Output: true
// ============================================================

using System;
using System.Collections.Generic;

public class WordBreak
{
    // APPROACH 1: BRUTE FORCE — Recursion
    // Idea: Try every prefix. If it's in dictionary, recurse on rest.
    // Time: O(2^n)  |  Space: O(n)

    // APPROACH 2: OPTIMAL — DP (Bottom-up)
    // Idea: dp[i] = true if s[0..i-1] can be segmented.
    //       For each i, check all j < i: if dp[j] && s[j..i] in dict → dp[i] = true.
    // Time: O(n^2 * m) where m = avg word length  |  Space: O(n)
    public bool Optimal(string s, IList<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true; // empty string

        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n];
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - DP: dp[i] = can s[0..i-1] be segmented into dictionary words?
// - dp[0] = true (empty string). dp[n] = answer.
// - Transition: dp[i] = any dp[j] where s[j..i] is in dictionary.
// - Use HashSet for O(1) word lookup.
// - O(n^2) transitions, each with O(n) substring → O(n^3) worst case.
// - Can optimize with Trie for prefix matching.
// - Follow-up: "Word Break II" asks for ALL valid segmentations.
// ============================================================
