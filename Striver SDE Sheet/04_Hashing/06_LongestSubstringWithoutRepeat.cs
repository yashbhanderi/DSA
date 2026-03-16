// ============================================================
// Problem: Longest Substring Without Repeating Characters
// Topic: Hashing
// ============================================================
// PROBLEM STATEMENT:
//   Given a string, find the length of the longest substring
//   without repeating characters.
//
//   Input:  s = "abcabcbb"
//   Output: 3  ("abc")
// ============================================================

using System;
using System.Collections.Generic;

public class LongestSubstringWithoutRepeat
{
    // APPROACH 1: BRUTE FORCE — Check all substrings
    // Time: O(n^2)  |  Space: O(n)
    public int BruteForce(string s)
    {
        int maxLen = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var seen = new HashSet<char>();
            for (int j = i; j < s.Length; j++)
            {
                if (seen.Contains(s[j])) break;
                seen.Add(s[j]);
                maxLen = Math.Max(maxLen, j - i + 1);
            }
        }
        return maxLen;
    }

    // APPROACH 2: OPTIMAL — Sliding Window + HashMap
    // Idea: Maintain a window [left, right]. Use a dictionary to store
    //       the last seen index of each character. When a repeat is found,
    //       jump left pointer past the previous occurrence.
    // Time: O(n)  |  Space: O(min(n, alphabet size))
    public int Optimal(string s)
    {
        var lastSeen = new Dictionary<char, int>(); // char → last index
        int maxLen = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];

            if (lastSeen.ContainsKey(c) && lastSeen[c] >= left)
            {
                // Move left past the previous occurrence
                left = lastSeen[c] + 1;
            }

            lastSeen[c] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sliding window: Expand right, shrink left on duplicate.
// - HashMap stores last seen INDEX (not just presence).
// - When duplicate found: left = max(left, lastSeen[c] + 1).
// - Check lastSeen[c] >= left (character might be outside current window).
// - O(n) time, O(min(n, 26)) space for lowercase English.
// - Interview tip: Classic sliding window. Know the template cold.
// ============================================================
