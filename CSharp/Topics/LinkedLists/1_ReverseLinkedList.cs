namespace CSharp.Topics.LinkedLists
{
    public class ReverseLinkedList
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

        public static void Run()
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            LinkedListHelper.PrintList(head);

            var reveresedList = ReverseList(head);

            LinkedListHelper.PrintList(reveresedList);
        }
    }
}