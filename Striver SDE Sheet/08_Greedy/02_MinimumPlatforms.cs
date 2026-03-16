// ============================================================
// Problem: Minimum Platforms
// Topic: Greedy
// ============================================================
// PROBLEM STATEMENT:
//   Given arrival and departure times of trains, find the minimum
//   number of platforms required so that no train has to wait.
//   Input: arr=[0900,0940,0950,1100,1500,1800], dep=[0910,1200,1120,1130,1900,2000]
//   Output: 3
// ============================================================

using System;

public class MinimumPlatforms
{
    // APPROACH 1: BRUTE FORCE — For each train, count overlapping trains
    // Time: O(n^2)  |  Space: O(1)

    // APPROACH 2: OPTIMAL — Sort + Two Pointers
    // Idea: Sort both arrival and departure arrays independently.
    //       Use two pointers to simulate events chronologically.
    //       Arrival → need platform (count++). Departure → free platform (count--).
    // Time: O(n log n)  |  Space: O(1)
    public int Optimal(int[] arrival, int[] departure)
    {
        Array.Sort(arrival);
        Array.Sort(departure);

        int i = 0, j = 0, n = arrival.Length;
        int platforms = 0, maxPlatforms = 0;

        while (i < n)
        {
            if (arrival[i] <= departure[j])
            {
                platforms++;
                i++;
            }
            else
            {
                platforms--;
                j++;
            }
            maxPlatforms = Math.Max(maxPlatforms, platforms);
        }

        return maxPlatforms;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort arrivals and departures SEPARATELY.
// - Two pointers: if arrival <= departure → need new platform (i++).
//   Else → free a platform (j++).
// - Track max platforms at any point. O(n log n).
// - Key: We sort separately because we only care about events, not which train.
// ============================================================
