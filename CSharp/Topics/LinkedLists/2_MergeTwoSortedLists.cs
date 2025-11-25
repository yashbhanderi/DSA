namespace CSharp.Topics.LinkedLists
{
    public class MergeTwoSortedLists
    {
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = null;

            if (list1 == null && list2 is null) return head;
            else if (list1 == null) return list2;
            else if (list2 == null) return list1;

            ListNode ptr = null;
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    if (head == null)
                    {
                        ptr = new ListNode(list1.val);
                        head = ptr;
                    }
                    else
                    {
                        ptr.next = new ListNode(list1.val);
                        ptr = ptr.next;
                    }
                    list1 = list1.next;
                }
                else
                {
                    if (head == null)
                    {
                        ptr = new ListNode(list2.val);
                        head = ptr;
                    }
                    else
                    {
                        ptr.next = new ListNode(list2.val);
                        ptr = ptr.next;
                    }
                    list2 = list2.next;
                }
            }

            while (list1 != null)
            {
                ptr.next = new ListNode(list1.val);
                list1 = list1.next;
            }

            while (list2 != null)
            {
                ptr.next = new ListNode(list2.val);
                list2 = list2.next;
            }

            return head;
        }

        public static void Run()
        {
            var list1 = new int[] { 1, 2, 3, 4, 5 };
            var list2 = new int[] { 1, 3, 6, 9, 10 };
            ListNode? head1 = null;
            ListNode? head2 = null;

            foreach (var e in list1)
            {
                head1 = LinkedListHelper.AddLast(e, head1);
            }
            foreach (var e in list2)
            {
                head2 = LinkedListHelper.AddLast(e, head2);
            }

            var mergeLists = MergeTwoLists(head1, head2);
            LinkedListHelper.PrintList(mergeLists);
        }
    }
}