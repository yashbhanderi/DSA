// ============================================================
// Problem: Find the Duplicate Number
// Topic: Arrays II
// ============================================================
// PROBLEM STATEMENT:
//   Given array nums containing n+1 integers where each integer
//   is in [1, n], find the one duplicate number. Don't modify
//   the array and use only O(1) extra space.
//
//   Input:  nums = [1, 3, 4, 2, 2]
//   Output: 2
// ============================================================

using System;
using System.Collections.Generic;

public class FindDuplicate
{
    // APPROACH 1: BRUTE FORCE — HashSet
    // Idea: Use a set to track seen numbers. First repeat is the answer.
    // Time: O(n)  |  Space: O(n) — violates O(1) space constraint
    public int BruteForce(int[] nums)
    {
        var seen = new HashSet<int>();
        foreach (int num in nums)
        {
            if (seen.Contains(num)) return num;
            seen.Add(num);
        }
        return -1;
    }

    // APPROACH 2: OPTIMAL — Floyd's Tortoise and Hare (Cycle Detection)
    // Idea: Treat the array as a linked list where nums[i] points to the next node.
    //       Since there's a duplicate, there must be a cycle.
    //       Phase 1: Find intersection point (slow & fast pointers).
    //       Phase 2: Find the entrance of cycle (= the duplicate).
    // Time: O(n)  |  Space: O(1)
    public int Optimal(int[] nums)
    {
        // Phase 1: Detect cycle — find meeting point
        int slow = nums[0];
        int fast = nums[0];

        do
        {
            slow = nums[slow];          // move one step
            fast = nums[nums[fast]];    // move two steps
        } while (slow != fast);

        // Phase 2: Find entry point of cycle
        slow = nums[0];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast]; // both move one step now
        }

        return slow; // the duplicate number
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Floyd's Cycle Detection: Treat array as linked list (i→nums[i]).
// - Phase 1: slow=nums[slow], fast=nums[nums[fast]] until they meet.
// - Phase 2: Reset slow to start, both move one step. Meeting point = duplicate.
// - Why cycle exists: n+1 elements in [1,n] → pigeonhole + cycle in functional graph.
// - O(n) time, O(1) space. Does NOT modify array.
// - Interview tip: Explain the linked list analogy clearly.
// ============================================================
