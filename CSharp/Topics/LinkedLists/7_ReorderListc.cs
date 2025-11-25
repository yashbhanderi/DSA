namespace CSharp.Topics.LinkedLists
{
    public class ReorderList
    {
        public static ListNode? ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode nextNode = null, prevNode = null;

            while (head.next != null)
            {
                nextNode = head.next;
                head.next = prevNode;
                prevNode = head;
                head = nextNode;
            }
            head.next = prevNode;

            return head;
        }

        public static ListNode MiddleNode(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode? slow = head, fast = head.next;

            while (slow != null && fast != null)
            {
                slow = slow.next;

                if (fast.next == null) return slow;

                fast = fast.next.next;
            }

            return slow;
        }

        public static void Reorder(ListNode? head)
        {
            if (head == null || head.next == null || head.next.next == null) return;

            // Split: Find middle of list and reverse the second half
            var secondHalfStart = MiddleNode(head);
            var reversedSecondHalf = ReverseList(secondHalfStart);

            // Merge: Interleave first half with reversed second half
            ListNode firstHalfCurrent = head;
            ListNode? firstHalfNext;
            ListNode secondHalfCurrent = reversedSecondHalf!;
            ListNode? secondHalfNext;

            while (secondHalfCurrent.next != null)
            {
                // Save next nodes before modifying pointers
                firstHalfNext = firstHalfCurrent.next;
                secondHalfNext = secondHalfCurrent.next;

                // Interleave: Insert second half node into first half
                firstHalfCurrent.next = secondHalfCurrent;
                firstHalfCurrent.next.next = firstHalfNext;

                // Move to next positions in both halves
                firstHalfCurrent = firstHalfNext!;
                secondHalfCurrent = secondHalfNext!;
            }
        }

        public static void Run()
        {
            var arr = new int[] { 1, 2, 3 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            Reorder(head);

            LinkedListHelper.PrintList(head);
        }
    }
}