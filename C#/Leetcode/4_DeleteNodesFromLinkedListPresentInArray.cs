using LinkedLists;

public class DeleteNodesFromLinkedListPresentInArray
{

    public static ListNode DeleteNodes(ListNode head, int[] arr) {
        if(head == null) return null;

        var set = new HashSet<int>();

        foreach(var e in arr) set.Add(e);

        var ptr = head;
        ListNode newPtr = null, newhead = null;

        while(ptr != null) {
            if(!set.Contains(ptr.val)) {        
                if(newhead == null) {
                    newhead = new ListNode(ptr.val);
                    newPtr = newhead;
                }
                else {
                    var newNode = new ListNode(ptr.val);
                    newPtr.next = newNode;
                    newPtr = newNode;
                }
            }
            ptr = ptr.next;
        }

        return newhead;
    }    

    public static void Run()
    {
        var list = new LinkedList();
        
        LinkedList.InsertAtLast(list, 1);
        LinkedList.InsertAtLast(list, 2);
        LinkedList.InsertAtLast(list, 3);
        LinkedList.InsertAtLast(list, 4);
        LinkedList.InsertAtLast(list, 5);

        LinkedList.PrintList(list.head);
        System.Console.WriteLine();

        var ans = DeleteNodes(list.head, [2,3,4]);    

        LinkedList.PrintList(ans);
        System.Console.WriteLine();
    }
}