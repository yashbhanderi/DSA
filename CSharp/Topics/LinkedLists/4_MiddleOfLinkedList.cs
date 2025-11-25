namespace CSharp.Topics.LinkedLists
{
    public class MiddleOfLinkedList
    {
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

        public static void Run()
        {
            var arr = new int[] { 1, 2 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            System.Console.WriteLine(MiddleNode(head).val);
        }
    }
}