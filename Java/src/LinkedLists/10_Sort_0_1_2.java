package LinkedLists;

class Sort012 {
    
    public static LinkedList.Node sortList(LinkedList.Node head) {
        LinkedList.Node zeroPtrHead = null;
        LinkedList.Node zeroPtrTail = null;
        LinkedList.Node onePtrHead = null;
        LinkedList.Node onePtrTail = null;
        LinkedList.Node twoPtrHead = null;
        LinkedList.Node twoPtrTail = null;

        var ptr = head;
        
        while(ptr != null) {
            if(ptr.data == 0) {
                if(zeroPtrHead == null) {
                    zeroPtrHead = ptr;
                    zeroPtrTail = zeroPtrHead;
                }
                else {
                    zeroPtrTail.next = ptr;
                    zeroPtrTail = zeroPtrTail.next;
                }
            }
            else if(ptr.data == 1) {
                if(onePtrHead == null) {
                    onePtrHead = ptr;
                    onePtrTail = onePtrHead;
                }
                else {
                    onePtrTail.next = ptr;
                    onePtrTail = onePtrTail.next;
                }
            }
            else {
                if(twoPtrHead == null) {
                    twoPtrHead = ptr;
                    twoPtrTail = twoPtrHead;
                }
                else {
                    twoPtrTail.next = ptr;
                    twoPtrTail = twoPtrTail.next;
                }
            }
            ptr = ptr.next;
        }
        
        zeroPtrTail.next = onePtrHead;
        onePtrTail.next = twoPtrHead;
        twoPtrTail.next = null;
        
        return zeroPtrHead;
    }
    
    public static void main(String[] args) {
        LinkedList list = new LinkedList();
        
        list.insertAtLast(list, 1);
        list.insertAtLast(list, 0);
        list.insertAtLast(list, 2);
        list.insertAtLast(list, 1);
        list.insertAtLast(list, 0);
        list.insertAtLast(list, 2);
        list.insertAtLast(list, 1);

        list.printList(list);
        
        LinkedList.Node head = sortList(list.head);
        
        var ptr = head;
        
        while(ptr != null) {
            System.out.println(ptr.data);
            ptr = ptr.next;
        }
    }
}