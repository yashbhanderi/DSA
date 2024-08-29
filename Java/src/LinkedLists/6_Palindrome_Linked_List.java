package LinkedLists;

class PalindromeLinkedList {
    
    public static LinkedList.Node reverseList(LinkedList.Node head, LinkedList.Node node) {
        var ptr = head.next;
        var curr = head;

        curr.next = node;
        node.next = null;

        while(head != null && ptr!=null) {
            head = ptr;
            ptr = ptr.next;
            head.next = curr;
            curr = head;
        }
        
        return head;
    }
    
    public static void main(String[] args) {
        LinkedList list = new LinkedList();
        
        list.insertAtLast(list, 1);
        list.insertAtLast(list, 2);
        list.insertAtLast(list, 3);
        list.insertAtLast(list, 1);
        
        int size = list.size();
        
        if(size > 3) {
            int mid = (size/2)-1;
            LinkedList.Node ptr = list.head;
            
            while(mid>0) {
                ptr = ptr.next;
                mid--;
            }
            
            LinkedList.Node reversePtr = reverseList(ptr.next, ptr);
            ptr = list.head;
            
            while(ptr != null && reversePtr != null) {
                if(ptr.data != reversePtr.data) {
                    System.out.println(false);
                    return;
                }
                ptr = ptr.next;
                reversePtr = reversePtr.next;
            }

            System.out.println(true);
        }
    }
}