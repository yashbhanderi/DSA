// ============================================================
// Problem: Reverse Nodes in k-Group
// Topic: Linked List II
// ============================================================
// PROBLEM STATEMENT:
//   Reverse the nodes of a linked list k at a time.
//   Nodes left over at end (< k) remain as-is.
//
//   Input:  1→2→3→4→5, k = 2
//   Output: 2→1→4→3→5
// ============================================================

public class ReverseKGroup
{
    // APPROACH: Iterative with group counting
    // Idea: Count k nodes ahead. If k nodes exist, reverse them.
    //       Connect the reversed group to previous and next groups.
    // Time: O(n)  |  Space: O(1)
    public ListNode Optimal(ListNode head, int k)
    {
        if (head == null || k == 1) return head;

        ListNode dummy = new ListNode(0, head);
        ListNode prevGroupEnd = dummy;

        while (true)
        {
            // Check if k nodes exist
            ListNode kthNode = GetKthNode(prevGroupEnd, k);
            if (kthNode == null) break;

            ListNode nextGroupStart = kthNode.next;

            // Reverse k nodes
            ListNode prev = nextGroupStart;
            ListNode curr = prevGroupEnd.next;

            for (int i = 0; i < k; i++)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            // Connect: prevGroupEnd → reversed group start (kthNode)
            ListNode groupStart = prevGroupEnd.next; // will become group end after reversal
            prevGroupEnd.next = kthNode;
            prevGroupEnd = groupStart;
        }

        return dummy.next;
    }

    private ListNode GetKthNode(ListNode node, int k)
    {
        while (node != null && k > 0)
        {
            node = node.next;
            k--;
        }
        return node;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Count k nodes. If enough exist, reverse them. Else stop.
// - Key: Track prevGroupEnd (node before current group) and nextGroupStart.
// - After reversing: prevGroupEnd.next = kthNode (new start of reversed group).
// - The old first node becomes the last node of the reversed group.
// - O(n) time, O(1) space.
// - Interview tip: Draw the connections before and after reversal.
// ============================================================
