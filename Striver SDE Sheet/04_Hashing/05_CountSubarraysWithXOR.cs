// ============================================================
// Problem: Count Subarrays with Given XOR
// Topic: Hashing
// ============================================================
// PROBLEM STATEMENT:
//   Given an array and a value K, count the number of subarrays
//   whose XOR equals K.
//
//   Input:  arr = [4, 2, 2, 6, 4], K = 6
//   Output: 4
// ============================================================

using System;
using System.Collections.Generic;

public class CountSubarraysWithXOR
{
    // APPROACH 1: BRUTE FORCE — Check all subarrays
    // Time: O(n^2)  |  Space: O(1)
    public int BruteForce(int[] arr, int k)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int xorSum = 0;
            for (int j = i; j < arr.Length; j++)
            {
                xorSum ^= arr[j];
                if (xorSum == k) count++;
            }
        }
        return count;
    }

    // APPROACH 2: OPTIMAL — Prefix XOR + HashMap
    // Idea: Similar to prefix sum technique.
    //       If prefixXOR[0..i] ^ prefixXOR[0..j] = K,
    //       then subarray (j+1..i) has XOR = K.
    //       So prefixXOR[0..j] = prefixXOR[0..i] ^ K.
    //       Count occurrences of (currentXOR ^ K) seen so far.
    // Time: O(n)  |  Space: O(n)
    public int Optimal(int[] arr, int k)
    {
        var map = new Dictionary<int, int>(); // prefixXOR → count
        int count = 0;
        int prefixXOR = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            prefixXOR ^= arr[i];

            if (prefixXOR == k)
                count++; // entire subarray 0..i has XOR = k

            int needed = prefixXOR ^ k;
            if (map.ContainsKey(needed))
                count += map[needed];

            map[prefixXOR] = map.GetValueOrDefault(prefixXOR, 0) + 1;
        }

        return count;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Prefix XOR + HashMap (analogous to prefix sum for subarray sum = K).
// - If prefixXOR ^ K exists in map, those many subarrays end here with XOR = K.
// - Property: A ^ B = K → A = B ^ K.
// - O(n) time, O(n) space.
// - Unlike sum, XOR is its own inverse: A ^ A = 0, A ^ 0 = A.
// - Interview tip: Show the connection to "subarray sum = K" pattern.
// ============================================================
