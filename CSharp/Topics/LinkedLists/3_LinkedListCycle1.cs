namespace CSharp.Topics.LinkedLists
{
    public class LinkedListCycle1
    {
        public static bool HasCycle(ListNode head)
        {
            ListNode? slow = head, fast = head.next;

            while(slow != null && fast?.next != null)
            {
                if(slow == fast) return true;

                slow = slow.next;
                fast = fast.next.next;
            }

            return false;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            System.Console.WriteLine(HasCycle(head));
        }
    }
}