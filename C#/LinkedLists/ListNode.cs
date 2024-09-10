namespace LinkedLists;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode head = null;

    public int Size()
    {
        ListNode ptr = head;
        int cnt = 0;

        while (ptr != null)
        {
            ptr = ptr.next;
            cnt++;
        }
        return cnt;
    }

    public static ListNode InsertAtLast(ListNode list, int data)
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

        return list;
    }

    public static ListNode InsertAtFirst(ListNode list, int data)
    {
        ListNode new_node = new ListNode(data);

        if (list.head == null)
        {
            list.head = new_node;
        }
        else
        {
            new_node.next = list.head;
            list.head = new_node;
        }

        return list;
    }

    public static ListNode InsertAfterNthNode(ListNode list, int data, int position)
    {
        ListNode new_node = new ListNode(data);

        if (list.head == null)
        {
            list.head = new_node;
        }
        else if (position == 0)
        {
            InsertAtFirst(list, data);
        }
        else if (position == list.Size())
        {
            InsertAtLast(list, data);
        }
        else
        {

            ListNode ptr = list.head;
            int cnt = position - 1;
            while (cnt > 0 && ptr != null)
            {
                ptr = ptr.next;
                cnt--;
            }

            new_node.next = ptr.next;
            ptr.next = new_node;
        }

        return list;
    }

    public static ListNode DeleteLast(ListNode list)
    {
        if (list.head == null) return list;
        else if (list.head.next == null)
        {
            list.head = null;
            return list;
        }
        else
        {
            ListNode ptr = list.head;

            while (ptr.next.next != null)
            {
                ptr = ptr.next;
            }

            ptr.next = null;
            return list;
        }
    }

    public static ListNode DeleteFirst(ListNode list)
    {
        if (list.head == null) return list;
        else if (list.head.next == null)
        {
            list.head = null;
            return list;
        }
        else
        {
            list.head = list.head.next;
            return list;
        }
    }

    public static ListNode DeleteNthNode(ListNode list, int position)
    {
        if (list.head == null) return list;
        else if (position == 0)
        {
            list.head = null;
            return list;
        }
        else
        {
            list.head = list.head.next;
            return list;
        }
    }

    public static void PrintList(ListNode list)
    {
        ListNode currNode = list.head;

        System.Console.WriteLine("ListNode: ");

        while (currNode != null)
        {
            System.Console.Write(currNode.val + " ");
            currNode = currNode.next;
        }

        System.Console.WriteLine();
    }
}
