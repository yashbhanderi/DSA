package LinkedLists;

class DetectLoop {
    
    public static boolean hasCycle(LinkedList list) {
        
        if(list.head.next == null) return false;
        
        LinkedList.Node slow = list.head;
        LinkedList.Node fast = list.head.next;
        
        while (slow != null && fast != null) {
            if(slow == fast) {
                return true;
            }
            
            slow = slow.next;
            
            if(fast.next == null) return false;
            
            fast = fast.next.next;
        }
        
        return false;
    }
    
    public static void main(String[] args) {
        LinkedList list = new LinkedList();

        list.insertAtLast(list, 1);
        list.insertAtLast(list, 2);
        list.insertAtLast(list, 3);
        list.insertAtLast(list, 4);
        list.insertAtLast(list, 5);
        list.insertAtLast(list, 6);

//        var ptr1 = list.head.next;
//        var ptr2 = list.head;
//
//        while (ptr2.next != null) {
//            ptr2 = ptr2.next;
//        }
//        ptr2.next = ptr1;

        System.out.println(hasCycle(list));
    }
}