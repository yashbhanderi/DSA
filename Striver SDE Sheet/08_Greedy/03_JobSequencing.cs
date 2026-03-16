// ============================================================
// Problem: Job Sequencing Problem
// Topic: Greedy
// ============================================================
// PROBLEM STATEMENT:
//   Given jobs with deadlines and profits, schedule jobs to maximize
//   profit. Each job takes 1 unit of time. One job per time slot.
//   Input: jobs = [(1,4,20),(2,1,10),(3,1,40),(4,1,30)]
//   Output: 2 jobs, profit = 60 (jobs 3 and 1)
// ============================================================

using System;

public class JobSequencing
{
    // APPROACH: Greedy — Sort by profit descending, assign latest available slot
    // Idea: Sort jobs by profit (highest first). For each job, find
    //       the latest available slot before its deadline. Assign it.
    // Time: O(n^2) or O(n log n) with DSU  |  Space: O(maxDeadline)
    public (int count, int profit) Optimal(int[][] jobs)
    {
        // Sort by profit descending
        Array.Sort(jobs, (a, b) => b[2].CompareTo(a[2]));

        // Find max deadline
        int maxDeadline = 0;
        foreach (var job in jobs) maxDeadline = Math.Max(maxDeadline, job[1]);

        bool[] slot = new bool[maxDeadline + 1]; // 1-indexed
        int count = 0, totalProfit = 0;

        foreach (var job in jobs)
        {
            // Find latest available slot before deadline
            for (int j = job[1]; j >= 1; j--)
            {
                if (!slot[j])
                {
                    slot[j] = true;
                    count++;
                    totalProfit += job[2];
                    break;
                }
            }
        }

        return (count, totalProfit);
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Sort by profit descending (greedy: take most profitable first).
// - For each job, assign to LATEST available slot ≤ deadline.
// - Why latest slot? Keeps earlier slots free for tighter deadlines.
// - O(n * maxDeadline) basic. Can optimize to O(n log n) with Disjoint Set Union.
// - Interview tip: Explain why greedy works (exchange argument).
// ============================================================
