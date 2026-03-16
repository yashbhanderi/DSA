// ============================================================
// Problem: Intersection of Two Linked Lists
// Topic: Linked List II
// ============================================================
// PROBLEM STATEMENT:
//   Find the node where two singly linked lists intersect.
//   Return null if no intersection.
//
//   Input:  A: 4→1→8→4→5, B: 5→6→1→8→4→5 (intersect at 8)
//   Output: Node 8
// ============================================================

using System;

public class IntersectionOfLinkedLists
{
    // APPROACH 1: BRUTE FORCE — For each node in A, search in B
    // Time: O(m * n)  |  Space: O(1)

    // APPROACH 2: BETTER — HashSet
    // Time: O(m + n)  |  Space: O(m)

    // APPROACH 3: OPTIMAL — Two pointer technique
    // Idea: Pointer A traverses A then B. Pointer B traverses B then A.
    //       Both travel the same total distance (m + n).
    //       They meet at intersection or both reach null together.
    // Time: O(m + n)  |  Space: O(1)
    public ListNode Optimal(ListNode headA, ListNode headB)
    {
        ListNode a = headA, b = headB;

        while (a != b)
        {
            a = (a != null) ? a.next : headB;
            b = (b != null) ? b.next : headA;
        }

        return a; // intersection node or null
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Two pointers: A goes A→B, B goes B→A. They meet at intersection.
// - Total distance for both: m + n. So they align at intersection.
// - If no intersection, both reach null simultaneously.
// - O(m+n) time, O(1) space. Elegant solution.
// - Alternative: Find length difference, advance longer by diff, then walk together.
// - Interview tip: Explain the "equal distance" insight.
// ============================================================
