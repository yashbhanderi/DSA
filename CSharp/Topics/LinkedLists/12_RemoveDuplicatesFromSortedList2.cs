namespace CSharp.Topics.LinkedLists
{
    public class RemoveDuplicatesFromSortedList2
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            var ptr = head;
            ListNode resulHead = null;
            ListNode resulPtr = null;

            while (ptr != null)
            {
                bool isContainsDuplicate = false;
                var currentNode = ptr;

                while (ptr.next != null && currentNode.val == ptr.next.val)
                {
                    isContainsDuplicate = true;
                    ptr = ptr.next;
                }

                if (!isContainsDuplicate)
                {
                    if (resulHead is null)
                    {
                        resulHead = currentNode;
                    }
                    else
                    {
                        resulPtr.next = currentNode;
                    }
                    resulPtr = currentNode;
                }
                ptr = ptr.next;
            }

            resulPtr.next = ptr;

            return resulHead;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 1, 2, 2, 3, 4, 5, 6, 6, 6 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            var resultList = DeleteDuplicates(head);

            LinkedListHelper.PrintList(resultList);
        }
    }
}