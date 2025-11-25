namespace CSharp.Topics.LinkedLists
{
    public class AddTwoNumbers
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

        public static ListNode AddTwoNumber(ListNode l1, ListNode l2)
        {
            ListNode ptr1 = l1, ptr2 = l2;
            int carry = 0;
            ListNode resultHead = null;
            ListNode resultPtr = null;

            while (ptr1 != null || ptr2 != null)
            {
                int num1 = 0, num2 = 0;
                if (ptr1 != null)
                {
                    num1 = ptr1.val;
                    ptr1 = ptr1.next;
                }

                if (ptr2 != null)
                {
                    num2 = ptr2.val;
                    ptr2 = ptr2.next;
                }

                int sum = num1 + num2 + carry;
                var newNode = new ListNode(sum % 10);
                carry = sum / 10;

                if (resultHead is null)
                {
                    resultHead = resultPtr = newNode;
                }
                else
                {
                    resultPtr.next = newNode;
                    resultPtr = newNode;
                }
            }

            if (carry > 0)
            {
                resultPtr.next = new ListNode(carry);
            }

            return resultHead;
        }

        public static void Run()
        {
            var list1 = new int[] { 0 };
            var list2 = new int[] { 0 };
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

            var resultList = AddTwoNumber(head1, head2);
            LinkedListHelper.PrintList(resultList);
        }
    }
}