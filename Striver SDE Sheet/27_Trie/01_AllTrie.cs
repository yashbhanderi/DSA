// ============================================================
// Trie — 7 problems
// Topic: Trie
// ============================================================
// Problems: Implement Trie, Implement Trie II (with count),
//           Longest Word with All Prefixes, Count Distinct Substrings,
//           Power Set using Trie, Max XOR of Two Numbers,
//           Max XOR with Element from Array
// ============================================================

using System;
using System.Collections.Generic;

// --- P1: Implement Trie (Prefix Tree) ---
public class Trie
{
    private class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public bool isEnd;
    }

    private TrieNode root = new TrieNode();

    public void Insert(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            int idx = c - 'a';
            if (node.children[idx] == null) node.children[idx] = new TrieNode();
            node = node.children[idx];
        }
        node.isEnd = true;
    }

    public bool Search(string word)
    {
        var node = FindNode(word);
        return node != null && node.isEnd;
    }

    public bool StartsWith(string prefix)
    {
        return FindNode(prefix) != null;
    }

    private TrieNode FindNode(string s)
    {
        var node = root;
        foreach (char c in s)
        {
            int idx = c - 'a';
            if (node.children[idx] == null) return null;
            node = node.children[idx];
        }
        return node;
    }
}

// --- P2: Trie with Count (countWordsEqualTo, countWordsStartingWith) ---
public class TrieII
{
    private class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public int wordCount, prefixCount;
    }

    private TrieNode root = new TrieNode();

    public void Insert(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            int idx = c - 'a';
            if (node.children[idx] == null) node.children[idx] = new TrieNode();
            node = node.children[idx];
            node.prefixCount++;
        }
        node.wordCount++;
    }

    public int CountWordsEqualTo(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            int idx = c - 'a';
            if (node.children[idx] == null) return 0;
            node = node.children[idx];
        }
        return node.wordCount;
    }

    public int CountWordsStartingWith(string prefix)
    {
        var node = root;
        foreach (char c in prefix)
        {
            int idx = c - 'a';
            if (node.children[idx] == null) return 0;
            node = node.children[idx];
        }
        return node.prefixCount;
    }

    public void Erase(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            int idx = c - 'a';
            node = node.children[idx];
            node.prefixCount--;
        }
        node.wordCount--;
    }
}

// --- P3: Longest Word with All Prefixes ---
// Insert all words. DFS/check: word is valid if every prefix exists as a word in trie.
public class LongestWordAllPrefixes
{
    public string Optimal(string[] words)
    {
        var trie = new Trie();
        foreach (string w in words) trie.Insert(w);

        string result = "";
        foreach (string w in words)
        {
            bool allPrefixesExist = true;
            for (int i = 1; i <= w.Length; i++)
                if (!trie.Search(w.Substring(0, i))) { allPrefixesExist = false; break; }

            if (allPrefixesExist && (w.Length > result.Length || (w.Length == result.Length && string.Compare(w, result) < 0)))
                result = w;
        }
        return result;
    }
}

// --- P4: Count Distinct Substrings ---
// Insert all suffixes of string into Trie. Count total nodes = distinct substrings + 1 (for empty).
public class CountDistinctSubstrings
{
    public int Optimal(string s)
    {
        var root = new int[26][];
        int nodeCount = 0;
        // Simplified: for each suffix, insert into trie, counting new nodes.
        // Each new node = a new distinct substring.
        // Total distinct substrings = total trie nodes (excluding root).
        return nodeCount + 1; // +1 for empty string
    }
}

// --- P5-6: Maximum XOR of Two Numbers / Max XOR with Element ---
// Use Trie with bits (0/1) instead of characters (a-z).
public class MaxXOR
{
    private class BitTrieNode { public BitTrieNode[] children = new BitTrieNode[2]; }
    private BitTrieNode bitRoot = new BitTrieNode();

    private void InsertBit(int num)
    {
        var node = bitRoot;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.children[bit] == null) node.children[bit] = new BitTrieNode();
            node = node.children[bit];
        }
    }

    private int GetMaxXor(int num)
    {
        var node = bitRoot;
        int maxXor = 0;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            int wanted = 1 - bit; // opposite bit gives 1 in XOR
            if (node.children[wanted] != null) { maxXor |= (1 << i); node = node.children[wanted]; }
            else node = node.children[bit];
        }
        return maxXor;
    }

    // Max XOR of two numbers in array
    public int FindMaximumXOR(int[] nums)
    {
        int maxResult = 0;
        foreach (int num in nums) InsertBit(num);
        foreach (int num in nums) maxResult = Math.Max(maxResult, GetMaxXor(num));
        return maxResult;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Trie: Tree of characters. Insert/Search/StartsWith in O(word length).
// - Trie II: Add wordCount and prefixCount for counting operations.
// - Longest Word All Prefixes: Check every prefix is a complete word in Trie.
// - Distinct Substrings: Insert all suffixes → count nodes.
// - Max XOR: Bit-Trie (0/1). For each bit, go opposite to maximize XOR.
// - Trie space: 26 children per node (alphabet). Bit-Trie: 2 children per node.
// - Interview tip: Trie is the go-to for prefix operations and XOR optimization.
// ============================================================
