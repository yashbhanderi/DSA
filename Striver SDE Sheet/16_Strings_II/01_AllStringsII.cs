// ============================================================
// Strings II — All 6 problems
// Topic: Strings Part II
// ============================================================
// Problems: Z-Function, KMP Algorithm, Min Chars for Palindrome,
//           Check Anagrams, Count and Say, Compare Version Numbers
// ============================================================

using System;
using System.Collections.Generic;
using System.Text;

// --- P1: Z-Function ---
// Z[i] = length of longest substring starting at i that matches prefix of s.
public class ZFunction
{
    public int[] Optimal(string s)
    {
        int n = s.Length;
        int[] z = new int[n];
        int l = 0, r = 0;
        for (int i = 1; i < n; i++)
        {
            if (i < r) z[i] = Math.Min(r - i, z[i - l]);
            while (i + z[i] < n && s[z[i]] == s[i + z[i]]) z[i]++;
            if (i + z[i] > r) { l = i; r = i + z[i]; }
        }
        return z;
    }
}
// Use for pattern matching: Concatenate pattern + "$" + text. Z[i] == m → match at i-m-1.

// --- P2: KMP Algorithm (Longest Prefix Suffix / Pi array) ---
public class KMPAlgorithm
{
    public int Search(string text, string pattern)
    {
        int[] lps = BuildLPS(pattern);
        int i = 0, j = 0;
        while (i < text.Length)
        {
            if (text[i] == pattern[j]) { i++; j++; }
            if (j == pattern.Length) return i - j;
            else if (i < text.Length && text[i] != pattern[j])
            { if (j != 0) j = lps[j - 1]; else i++; }
        }
        return -1;
    }

    private int[] BuildLPS(string pat)
    {
        int[] lps = new int[pat.Length];
        int len = 0, i = 1;
        while (i < pat.Length)
        {
            if (pat[i] == pat[len]) { lps[i++] = ++len; }
            else { if (len != 0) len = lps[len - 1]; else lps[i++] = 0; }
        }
        return lps;
    }
}
// NOTES: LPS array = failure function. Avoids redundant comparisons. O(n+m).

// --- P3: Minimum Characters to Make String Palindrome ---
// Prepend minimum characters. Use KMP/LPS on s + "$" + reverse(s).
public class MinCharsForPalindrome
{
    public int Optimal(string s)
    {
        string rev = new string(s.ToCharArray().Reverse().ToArray());
        string combined = s + "$" + rev;
        int[] lps = new int[combined.Length];
        int len = 0, i = 1;
        while (i < combined.Length)
        {
            if (combined[i] == combined[len]) { lps[i++] = ++len; }
            else { if (len != 0) len = lps[len - 1]; else lps[i++] = 0; }
        }
        return s.Length - lps[^1]; // chars to prepend
    }
}

// --- P4: Check Anagrams ---
public class CheckAnagrams
{
    public bool Optimal(string s, string t)
    {
        if (s.Length != t.Length) return false;
        int[] count = new int[26];
        for (int i = 0; i < s.Length; i++) { count[s[i] - 'a']++; count[t[i] - 'a']--; }
        foreach (int c in count) if (c != 0) return false;
        return true;
    }
}

// --- P5: Count and Say ---
// 1 → "1", 2 → "11", 3 → "21", 4 → "1211", ...
public class CountAndSay
{
    public string Optimal(int n)
    {
        string s = "1";
        for (int i = 2; i <= n; i++)
        {
            var sb = new StringBuilder();
            int count = 1;
            for (int j = 1; j < s.Length; j++)
            {
                if (s[j] == s[j - 1]) count++;
                else { sb.Append(count).Append(s[j - 1]); count = 1; }
            }
            sb.Append(count).Append(s[^1]);
            s = sb.ToString();
        }
        return s;
    }
}

// --- P6: Compare Version Numbers ---
// "1.01" vs "1.001" → 0 (equal). "1.0" vs "1.0.0" → 0.
public class CompareVersionNumbers
{
    public int Optimal(string v1, string v2)
    {
        var parts1 = v1.Split('.'); var parts2 = v2.Split('.');
        int maxLen = Math.Max(parts1.Length, parts2.Length);
        for (int i = 0; i < maxLen; i++)
        {
            int p1 = i < parts1.Length ? int.Parse(parts1[i]) : 0;
            int p2 = i < parts2.Length ? int.Parse(parts2[i]) : 0;
            if (p1 < p2) return -1;
            if (p1 > p2) return 1;
        }
        return 0;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Z-Function: Z[i] = longest match with prefix starting at i. O(n). Pattern matching.
// - KMP: LPS/Pi array. On mismatch, jump to lps[j-1] (not start). O(n+m).
// - Min Chars for Palindrome: LPS on s+"$"+reverse(s). Answer = n - lps[last].
// - Anagrams: Frequency count with int[26]. O(n).
// - Count & Say: Iteratively build next term by "reading" previous.
// - Version Compare: Split by '.'. Compare each part as integer. Handle unequal lengths.
// ============================================================
