// ============================================================
// Problem: Flattening a Linked List
// Topic: Linked List II
// ============================================================
// PROBLEM STATEMENT:
//   Given a linked list where each node has next (right) and
//   bottom pointers. Flatten it into a single sorted linked list
//   using bottom pointers.
//
//   5 → 10 → 19 → 28
//   |    |    |    |
//   7   20   22   35
//   |         |    |
//   8        50   40
//   |              |
//   30             45
//   Output: 5→7→8→10→19→20→22→28→30→35→40→45→50
// ============================================================

using System;

public class BottomNode
{
    public int val;
    public BottomNode next;   // right pointer
    public BottomNode bottom; // down pointer
    public BottomNode(int val) { this.val = val; }
}

public class FlattenLinkedList
{
    // APPROACH: Merge from right to left
    // Idea: Start from rightmost two lists, merge them (like merge sorted lists).
    //       Then merge result with next-left list. Repeat until done.
    // Time: O(n * m) where n = total nodes  |  Space: O(1)
    public BottomNode Optimal(BottomNode head)
    {
        if (head == null || head.next == null) return head;

        // Recursively flatten from right
        head.next = Optimal(head.next);

        // Merge current list with flattened right
        head = MergeSorted(head, head.next);

        return head;
    }

    private BottomNode MergeSorted(BottomNode a, BottomNode b)
    {
        if (a == null) return b;
        if (b == null) return a;

        BottomNode result;

        if (a.val <= b.val)
        {
            result = a;
            result.bottom = MergeSorted(a.bottom, b);
        }
        else
        {
            result = b;
            result.bottom = MergeSorted(a, b.bottom);
        }

        result.next = null; // important: disconnect right pointer
        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Merge from right to left: flatten right sublists first, then merge.
// - Uses merge-sorted-lists logic but with "bottom" pointers.
// - Set result.next = null to disconnect right pointers.
// - Time: O(sum of all nodes * merging passes).
// - This is a unique linked list problem — not on LeetCode, common on GFG.
// - Interview tip: Recognize it as repeated "merge two sorted lists" pattern.
// ============================================================
