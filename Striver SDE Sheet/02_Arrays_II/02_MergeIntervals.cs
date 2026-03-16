// ============================================================
// Problem: Merge Overlapping Intervals
// Topic: Arrays II
// ============================================================
// PROBLEM STATEMENT:
//   Given an array of intervals where intervals[i] = [start, end],
//   merge all overlapping intervals and return non-overlapping intervals.
//
//   Input:  [[1,3],[2,6],[8,10],[15,18]]
//   Output: [[1,6],[8,10],[15,18]]
// ============================================================

using System;
using System.Collections.Generic;

public class MergeIntervals
{
    // APPROACH 1: OPTIMAL — Sort + Merge
    // Idea: Sort intervals by start time. Iterate and merge overlapping ones.
    //       Two intervals overlap if current.start <= previous.end.
    // Time: O(n log n) for sort  |  Space: O(n) for result
    public int[][] Optimal(int[][] intervals)
    {
        if (intervals.Length <= 1) return intervals;

        // Sort by start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();
        int[] current = intervals[0];
        merged.Add(current);

        foreach (var interval in intervals)
        {
            if (interval[0] <= current[1])
            {
                // Overlapping — extend the end
                current[1] = Math.Max(current[1], interval[1]);
            }
            else
            {
                // Non-overlapping — start new interval
                current = interval;
                merged.Add(current);
            }
        }

        return merged.ToArray();
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort by start time first → O(n log n).
// - Overlap condition: current.start <= previous.end.
// - When overlapping, extend end = max(end, current.end).
// - When not overlapping, push current interval to result.
// - Edge case: single interval → return as-is.
// - Interview tip: This pattern is reused in Meeting Rooms, Insert Interval, etc.
// ============================================================
