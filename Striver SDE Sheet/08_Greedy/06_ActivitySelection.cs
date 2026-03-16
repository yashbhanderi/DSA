// ============================================================
// Problem: Activity Selection (Same as N Meetings in One Room)
// Topic: Greedy
// ============================================================
// PROBLEM STATEMENT:
//   Select maximum number of activities that don't overlap.
//   Same as N Meetings problem — see 01_NMeetingsInOneRoom.cs
//
//   Input:  start=[1,3,0,5,8,5], end=[2,4,6,7,9,9]
//   Output: 4 (activities that don't overlap)
// ============================================================

using System;
using System.Collections.Generic;

public class ActivitySelection
{
    // APPROACH: Greedy — Sort by end time, pick non-overlapping
    // (Identical to N Meetings in One Room)
    // Time: O(n log n)  |  Space: O(n)
    public List<int> Optimal(int[] start, int[] end)
    {
        int n = start.Length;
        var activities = new List<(int end, int start, int idx)>();
        for (int i = 0; i < n; i++) activities.Add((end[i], start[i], i));

        activities.Sort((a, b) => a.end.CompareTo(b.end));

        var selected = new List<int> { activities[0].idx };
        int lastEnd = activities[0].end;

        for (int i = 1; i < n; i++)
        {
            if (activities[i].start > lastEnd)
            {
                selected.Add(activities[i].idx);
                lastEnd = activities[i].end;
            }
        }

        return selected;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Same as N Meetings / Activity Selection — canonical greedy problem.
// - Sort by finish time. Greedily pick earliest finishing non-overlapping activity.
// - O(n log n) time. Greedy proof: exchange argument.
// - Variant: If asked to return the actual activities (indices), track them.
// ============================================================
