// ============================================================
// Problem: Delete Node in a Linked List (Given only that node)
// Topic: Linked List
// ============================================================
// PROBLEM STATEMENT:
//   Delete a given node from a linked list. You are NOT given
//   access to the head. You are given only the node to delete.
//   The node is guaranteed not to be the tail.
//
//   Input:  4→5→1→9, node = 5
//   Output: 4→1→9
// ============================================================

public class DeleteGivenNode
{
    // APPROACH: Copy next node's value, skip next node
    // Idea: Since we can't access previous node, copy next node's
    //       data into current node and delete the next node instead.
    // Time: O(1)  |  Space: O(1)
    public void Optimal(ListNode node)
    {
        node.val = node.next.val;   // copy next node's value
        node.next = node.next.next; // skip next node
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Trick: Can't delete current node directly (no access to prev).
// - Copy next node's value into current, then delete next node.
// - Only works if node is NOT the tail (guaranteed by problem).
// - O(1) time and space. Very simple but tricky concept.
// - Interview tip: This is a trick question. Explain the "copy" idea clearly.
// ============================================================
