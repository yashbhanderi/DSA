// ============================================================
// Problem: Clone Linked List with Random Pointer
// Topic: Two Pointers
// ============================================================
// PROBLEM STATEMENT:
//   Deep copy a linked list where each node has next and random pointers.
//
//   Input:  [[7,null],[13,0],[11,4],[10,2],[1,0]]
//   Output: Deep copy of the same structure
// ============================================================

using System.Collections.Generic;

public class RandomNode
{
    public int val;
    public RandomNode next, random;
    public RandomNode(int val) { this.val = val; }
}

public class CloneLinkedList
{
    // APPROACH 1: BETTER — HashMap
    // Time: O(n)  |  Space: O(n)
    public RandomNode Better(RandomNode head)
    {
        if (head == null) return null;
        var map = new Dictionary<RandomNode, RandomNode>();

        RandomNode curr = head;
        while (curr != null)
        {
            map[curr] = new RandomNode(curr.val);
            curr = curr.next;
        }

        curr = head;
        while (curr != null)
        {
            map[curr].next = curr.next != null ? map[curr.next] : null;
            map[curr].random = curr.random != null ? map[curr.random] : null;
            curr = curr.next;
        }

        return map[head];
    }

    // APPROACH 2: OPTIMAL — Interleave, set randoms, separate
    // Idea: Step 1: Insert cloned nodes between originals (A→A'→B→B'→...)
    //       Step 2: Set random pointers for cloned nodes.
    //       Step 3: Separate the two lists.
    // Time: O(n)  |  Space: O(1) (excluding result)
    public RandomNode Optimal(RandomNode head)
    {
        if (head == null) return null;

        // Step 1: Interleave — insert clones after originals
        RandomNode curr = head;
        while (curr != null)
        {
            RandomNode clone = new RandomNode(curr.val);
            clone.next = curr.next;
            curr.next = clone;
            curr = clone.next;
        }

        // Step 2: Set random pointers for clones
        curr = head;
        while (curr != null)
        {
            if (curr.random != null)
                curr.next.random = curr.random.next;
            curr = curr.next.next;
        }

        // Step 3: Separate original and cloned lists
        RandomNode cloneHead = head.next;
        curr = head;
        while (curr != null)
        {
            RandomNode clone = curr.next;
            curr.next = clone.next;
            clone.next = clone.next?.next;
            curr = curr.next;
        }

        return cloneHead;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - HashMap: O(n) space. Map old→new nodes. Set next and random from map.
// - Interleave: O(1) space. 3 passes: interleave, set randoms, separate.
// - Step 2 key: clone.random = original.random.next (clone of random target).
// - Step 3: Restore original list while extracting clone list.
// - Interview tip: Interleave approach is elegant but harder to code cleanly.
// ============================================================
