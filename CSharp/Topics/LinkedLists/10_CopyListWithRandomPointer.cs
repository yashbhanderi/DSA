namespace CSharp.Topics.LinkedLists
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class CopyListWithRandomPointer
    {
        public Node CopyRandomList(Node head)
        {

            if (head == null) return null;

            var map = new Dictionary<Node, Node>();
            Node resultHead = null;

            Node ptr1 = head;
            Node ptr2 = null;

            while (ptr1 != null)
            {
                var newNode = new Node(ptr1.val);

                if (resultHead == null)
                {
                    resultHead = ptr2 = newNode;
                }
                else
                {
                    ptr2.next = newNode;
                    ptr2 = newNode;
                }

                map.Add(ptr1, newNode);
                ptr1 = ptr1.next;
            }

            ptr1 = head;
            ptr2 = resultHead;
            while (ptr1 != null)
            {
                if (ptr1.random != null)
                {
                    var randomNode = map.GetValueOrDefault(ptr1.random);
                    ptr2.random = randomNode;
                }
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            return resultHead;
        }

        public static void Run()
        {

        }
    }
}