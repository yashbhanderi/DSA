namespace CSharp.Topics.LinkedLists
{
    public class SortList
    {
        // Main MergeSort function
        public static ListNode MergeSort(ListNode head)
        {
            // Base case: if list is empty or has one node, it's already sorted
            if (head == null || head.next == null)
                return head;

            // Step 1: Find the middle and split the list
            ListNode prev = null, slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            prev.next = null; // Cut the connection to split into two halves

            // Step 2: Recursively sort both halves
            ListNode l1 = MergeSort(head);
            ListNode l2 = MergeSort(slow);

            // Step 3: Merge the sorted halves
            return Merge(l1, l2);
        }

        // Helper function to merge two sorted lists
        private static ListNode Merge(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0); // Dummy node to simplify head logic
            ListNode current = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }

            // Attach remaining nodes (if any)
            if (l1 != null) current.next = l1;
            if (l2 != null) current.next = l2;

            return dummy.next;
        }

        public static void Run()
        {
            var arr = new int[] { 5, 3, 1, 6, 2, 4 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            var list = MergeSort(head);

            LinkedListHelper.PrintList(list);
        }
    }
}