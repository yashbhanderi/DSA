namespace CSharp.Topics.LinkedLists
{
    public class RemoveDuplicatesFromSortedList1
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            var ptr = head;
            var currentNode = head;

            while (ptr != null)
            {
                if (ptr.val == currentNode.val)
                {
                    ptr = ptr.next;
                }
                else
                {
                    currentNode.next = ptr;
                    currentNode = ptr;
                    ptr = ptr.next;
                }
            }

            currentNode.next = ptr;

            return head;
        }

        public static void Run()
        {
            var arr = new int[] { 1 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            DeleteDuplicates(head);

            LinkedListHelper.PrintList(head);
        }
    }
}