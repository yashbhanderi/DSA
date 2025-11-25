namespace CSharp.Topics.LinkedLists
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class LinkedListHelper
    {
        public static ListNode AddLast(int val, ListNode? head = null)
        {
            var newNode = new ListNode(val);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var ptr = head;
                while (ptr.next != null)
                {
                    ptr = ptr.next;
                }

                ptr.next = newNode;
            }

            return head;
        }

        public static ListNode AddFirst(int val, ListNode? head = null)
        {
            var newNode = new ListNode(val);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }

            return head;
        }

        public static void PrintList(ListNode? head)
        {
            if (head == null)
            {
                return;
            }
            else
            {
                var ptr = head;
                while (ptr.next != null)
                {
                    System.Console.Write(ptr.val + ", ");
                    ptr = ptr.next;
                }
                System.Console.WriteLine(ptr.val);
            }
        }
    }
}