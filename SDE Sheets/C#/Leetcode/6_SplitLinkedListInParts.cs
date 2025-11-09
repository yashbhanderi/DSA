public class SplitLinkedListInParts {

    public static ListNode[] SplitIntoParts(ListNode head, int k) {
        var ans = new List<ListNode>( new ListNode[k] );

        if(head == null) return ans.ToArray();

        var sizeOfList = 0;
        var ptr = head;

        while(ptr != null) {
            sizeOfList++;
            ptr = ptr.next;
        }

        int parts = sizeOfList / k;
        int remain = sizeOfList % k;

        if(parts == 0) {
            int i = 0;
            while(head != null) {
                ans[i++] = new ListNode(head.val);
                head = head.next;
            }
        }
        else {
            int i = 0;
            while(i < k) {

                int part = parts;

                if(remain > 0) {
                    part++;
                    remain--;
                }       

                ListNode newList = null;
                ListNode newPtr = null;
                while(part-- > 0 && head != null) { 
                    var newNode = new ListNode(head.val);

                    if(newList == null) {
                        newList = newNode;
                        newPtr = newList;
                    }
                    else {
                        newPtr.next = newNode;
                        newPtr = newNode;
                    }
                    head = head.next;
                }

                ans[i++] = newList;
            }
        }
        
        return ans.ToArray();
    }

    public static void Run() {
        var list = new LinkedList();
        
        LinkedList.InsertAtLast(list, 1);
        LinkedList.InsertAtLast(list, 2);
        LinkedList.InsertAtLast(list, 3);
        LinkedList.InsertAtLast(list, 4);
        LinkedList.InsertAtLast(list, 5);
        LinkedList.InsertAtLast(list, 6);
        LinkedList.InsertAtLast(list, 7);
        LinkedList.InsertAtLast(list, 8);
        LinkedList.InsertAtLast(list, 9);
        LinkedList.InsertAtLast(list, 10);

        var ans = SplitIntoParts(list.head, 3);

        foreach(var e in ans) {
            var ptr = e;
            while(ptr != null) {
                System.Console.Write(ptr.val + " ");
                ptr = ptr.next;
            }
            System.Console.WriteLine();
        }    
    }
}