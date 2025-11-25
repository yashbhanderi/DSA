namespace CSharp.Topics.LinkedLists
{

// Another good approach - STACK
    // public boolean isPalindrome(ListNode head)
    // {
    //     Stack<Integer> stack = new Stack();
    //     ListNode curr = head;
    //     while (curr != null)
    //     {
    //         stack.push(curr.val);
    //         curr = curr.next;
    //     }
    //     curr = head;
    //     while (curr != null && curr.val == stack.pop())
    //     {
    //         curr = curr.next;
    //     }
    //     return curr == null;
    // }

    public class PalindromeLinkedList
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

        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) return false;

            var middleNode = MiddleNode(head);
            var head2 = ReverseList(middleNode);

            while (head != middleNode && head2 != null)
            {
                if (head.val != head2.val) return false;

                head = head.next;
                head2 = head2.next;
            }

            return true;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 2 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            System.Console.WriteLine(IsPalindrome(head));
        }
    }
}