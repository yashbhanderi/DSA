namespace CSharp.Topics.LinkedLists
{
    public class IntersectionOfTwoLinkedLists
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode ptr1 = headA, ptr2 = headB;
            ListNode intersectionNode = null;

            while (ptr1 != null)
            {
                ptr1.val = -1 * (ptr1.val);
                ptr1 = ptr1.next;
            }

            while (ptr2 != null)
            {
                if (ptr2.val < 0 && intersectionNode is null)
                {
                    ptr2.val = Math.Abs(ptr2.val);
                    intersectionNode = ptr2;
                    break;
                }
                ptr2 = ptr2.next;
            }

            ptr1 = headA; ptr2 = headB;
            while (ptr1 != null)
            {
                ptr1.val = Math.Abs(ptr1.val);
                ptr1 = ptr1.next;
            }

            while (ptr2 != null)
            {
                ptr2.val = Math.Abs(ptr2.val);
                ptr2 = ptr2.next;
            }

            return intersectionNode;
        }

        public static void Run()
        {

        }
    }
}