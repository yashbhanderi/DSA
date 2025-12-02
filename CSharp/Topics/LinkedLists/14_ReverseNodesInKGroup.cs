namespace CSharp.Topics.LinkedLists
{
    public class ReverseNodesInKGroup
    {
        public static (ListNode, ListNode) ReverseList(ListNode head, ListNode end)
        {
            if (head == null || head.next == null) return (head, head);

            ListNode nextNode = null, prevNode = null, lastNode = head;

            while (head.next != end)
            {
                nextNode = head.next;
                head.next = prevNode;
                prevNode = head;
                head = nextNode;
            }
            head.next = prevNode;

            return (head, lastNode);
        }

        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode resultHead = null;
            ListNode resultPtr = null;

            while (head != null)
            {
                int window = k;
                var endNode = head;

                while (endNode != null && window > 0)
                {
                    endNode = endNode.next;
                    window--;
                }

                if (window > 0)
                {
                    break;
                }

                var result = ReverseList(head, endNode);
                if (resultHead is null)
                {
                    resultHead = result.Item1;
                    resultPtr = result.Item2;
                }
                else
                {
                    resultPtr.next = result.Item1;
                    resultPtr = result.Item2;
                }
                head = endNode;
            }
            
            if(resultHead is not null)
            {
                resultPtr.next = head;
            }
            else
            {
                resultHead = head;
            }

            return resultHead;
        }

        public static void Run()
        {
            var arr = new int[] { 1 };
            var k = 2;
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            var list = ReverseKGroup(head, k);

            LinkedListHelper.PrintList(list);
        }
    }
}