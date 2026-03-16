// ============================================================
// Problem: N Meetings in One Room / Activity Selection
// Topic: Greedy
// ============================================================
// PROBLEM STATEMENT:
//   Given start[] and end[] times of N meetings, find the maximum
//   number of meetings that can be held in one room (no overlap).
//   Input:  start=[1,3,0,5,8,5], end=[2,4,6,7,9,9] → Output: 4
// ============================================================

using System;
using System.Collections.Generic;

public class NMeetingsInOneRoom
{
    // APPROACH: Greedy — Sort by end time, pick non-overlapping
    // Idea: Sort meetings by end time. Greedily pick the meeting that
    //       ends earliest and doesn't overlap with previous pick.
    // Time: O(n log n)  |  Space: O(n)
    public int Optimal(int[] start, int[] end)
    {
        int n = start.Length;
        var meetings = new List<(int end, int start, int idx)>();
        for (int i = 0; i < n; i++) meetings.Add((end[i], start[i], i));

        meetings.Sort((a, b) => a.end.CompareTo(b.end));

        int count = 1;
        int lastEnd = meetings[0].end;

        for (int i = 1; i < n; i++)
        {
            if (meetings[i].start > lastEnd)
            {
                count++;
                lastEnd = meetings[i].end;
            }
        }

        return count;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort by end time (greedy choice: earliest finish first).
// - Pick meeting if its start > last picked meeting's end.
// - Classic activity selection problem. O(n log n).
// - Why greedy works: Earliest finish leaves maximum room for future.
// ============================================================
