// ============================================================
// Problem: Aggressive Cows
// Topic: Binary Search
// ============================================================
// PROBLEM STATEMENT:
//   Given N stalls and C cows, place cows such that the minimum
//   distance between any two cows is maximized.
//   Input: stalls=[1,2,4,8,9], cows=3 → Output: 3 (at 1,4,9)
// ============================================================

using System;

public class AggressiveCows
{
    // APPROACH: Binary Search on answer (minimum distance)
    // Idea: Answer lies in [1, max-min]. Binary search: for each mid (min distance),
    //       check if we can place all cows with at least mid distance apart.
    // Time: O(n * log(max-min))  |  Space: O(1)
    public int Optimal(int[] stalls, int cows)
    {
        Array.Sort(stalls);
        int low = 1, high = stalls[^1] - stalls[0];
        int result = 0;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (CanPlace(stalls, cows, mid))
            {
                result = mid;
                low = mid + 1; // try larger distance
            }
            else
                high = mid - 1;
        }

        return result;
    }

    private bool CanPlace(int[] stalls, int cows, int minDist)
    {
        int placed = 1, lastPos = stalls[0];
        for (int i = 1; i < stalls.Length; i++)
        {
            if (stalls[i] - lastPos >= minDist)
            {
                placed++;
                lastPos = stalls[i];
                if (placed >= cows) return true;
            }
        }
        return false;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Binary search on answer: "maximize the minimum distance."
// - Sort stalls. For each candidate distance, greedily place cows.
// - If can place all cows → try larger distance. Else → smaller.
// - O(n * log(max-min)). Classic "maximize the minimum" binary search.
// - Inverse of Allocate Pages (minimize the max vs maximize the min).
// ============================================================
