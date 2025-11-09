
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val)
    {
        this.val = val;
        this.next = null;
    }
}

public class LinkedList {

    public ListNode head;

    public static void PrintList(ListNode head)
    {
        ListNode currNode = head;

        System.Console.WriteLine("ListNode: ");

        while (currNode != null)
        {
            System.Console.Write(currNode.val + " ");
            currNode = currNode.next;
        }

        System.Console.WriteLine();
    }

    public static void InsertAtLast(LinkedList list, int data)
    {
        ListNode new_node = new ListNode(data);

        if (list.head == null)
        {
            list.head = new_node;
        }
        else
        {
            ListNode last = list.head;
            while (last.next != null)
            {
                last = last.next;
            }

            last.next = new_node;
        }
    }
    
}