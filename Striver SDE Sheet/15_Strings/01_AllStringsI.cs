// ============================================================
// Strings I — All 6 problems
// Topic: Strings Part I
// ============================================================
// Problems: Reverse Words, Longest Palindromic Substring, Roman to Integer,
//           ATOI, Longest Common Prefix, Rabin-Karp
// ============================================================

using System;
using System.Text;
using System.Collections.Generic;

// --- P1: Reverse Words in a String ---
// "the sky is blue" → "blue is sky the"
public class ReverseWords
{
    public string Optimal(string s)
    {
        var words = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);
        return string.Join(" ", words);
    }
    // Manual: Reverse entire string, then reverse each word. O(n), O(1) extra.
}

// --- P2: Longest Palindromic Substring ---
// "babad" → "bab" or "aba"
// OPTIMAL: Expand around center. Try each char (odd) and pair (even) as center. O(n^2).
public class LongestPalindromicSubstring
{
    public string Optimal(string s)
    {
        int start = 0, maxLen = 1;
        for (int i = 0; i < s.Length; i++)
        {
            Expand(s, i, i, ref start, ref maxLen);     // odd length
            Expand(s, i, i + 1, ref start, ref maxLen); // even length
        }
        return s.Substring(start, maxLen);
    }
    private void Expand(string s, int l, int r, ref int start, ref int maxLen)
    {
        while (l >= 0 && r < s.Length && s[l] == s[r]) { l--; r++; }
        if (r - l - 1 > maxLen) { start = l + 1; maxLen = r - l - 1; }
    }
}
// NOTES: Manacher's algorithm → O(n) but overkill for interviews.

// --- P3: Roman to Integer ---
// "MCMXCIV" → 1994. If smaller value before larger → subtract.
public class RomanToInteger
{
    public int Optimal(string s)
    {
        var map = new Dictionary<char, int> { ['I']=1,['V']=5,['X']=10,['L']=50,['C']=100,['D']=500,['M']=1000 };
        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length && map[s[i]] < map[s[i + 1]]) result -= map[s[i]];
            else result += map[s[i]];
        }
        return result;
    }
}

// --- P4: String to Integer (atoi) ---
public class MyAtoi
{
    public int Optimal(string s)
    {
        int i = 0, n = s.Length, sign = 1;
        while (i < n && s[i] == ' ') i++;
        if (i < n && (s[i] == '+' || s[i] == '-')) { sign = s[i] == '-' ? -1 : 1; i++; }
        long result = 0;
        while (i < n && char.IsDigit(s[i]))
        {
            result = result * 10 + (s[i] - '0');
            if (result * sign > int.MaxValue) return int.MaxValue;
            if (result * sign < int.MinValue) return int.MinValue;
            i++;
        }
        return (int)(result * sign);
    }
}

// --- P5: Longest Common Prefix ---
// ["flower","flow","flight"] → "fl"
public class LongestCommonPrefix
{
    public string Optimal(string[] strs)
    {
        if (strs.Length == 0) return "";
        string prefix = strs[0];
        for (int i = 1; i < strs.Length; i++)
        {
            while (!strs[i].StartsWith(prefix))
                prefix = prefix.Substring(0, prefix.Length - 1);
            if (prefix.Length == 0) return "";
        }
        return prefix;
    }
}

// --- P6: Rabin-Karp Algorithm ---
// String pattern matching using rolling hash. O(n+m) average.
public class RabinKarp
{
    public int Optimal(string text, string pattern)
    {
        int n = text.Length, m = pattern.Length;
        if (m > n) return -1;
        long patHash = 0, textHash = 0, power = 1, mod = 1000000007, d = 256;

        for (int i = 0; i < m - 1; i++) power = (power * d) % mod;
        for (int i = 0; i < m; i++)
        {
            patHash = (patHash * d + pattern[i]) % mod;
            textHash = (textHash * d + text[i]) % mod;
        }
        for (int i = 0; i <= n - m; i++)
        {
            if (patHash == textHash && text.Substring(i, m) == pattern) return i;
            if (i < n - m)
            {
                textHash = (d * (textHash - text[i] * power) + text[i + m]) % mod;
                if (textHash < 0) textHash += mod;
            }
        }
        return -1;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Reverse Words: Split + Reverse. Or reverse entire string, then reverse each word.
// - Longest Palindrome: Expand around center for both odd/even lengths. O(n^2).
// - Roman to Int: If current < next → subtract. Else add.
// - ATOI: Skip spaces → check sign → parse digits → clamp to INT range.
// - LCP: Shrink prefix from first string until all strings match.
// - Rabin-Karp: Rolling hash. Hash match → verify with actual comparison.
// ============================================================
