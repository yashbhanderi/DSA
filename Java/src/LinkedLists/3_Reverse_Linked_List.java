package LinkedLists;;

class ReverseLinkedList {
    
    public static LinkedList reverseList(LinkedList list) {
        if(list.size()<=1) 
            return list;
        
        var ptr = list.head.next;
        var curr = list.head;
        
        curr.next = null;
        
        while(list.head != null && ptr!=null) {
            list.head = ptr;
            ptr = ptr.next;
            list.head.next = curr;
            curr = list.head;
        }
        
        return list;
    }
    
    public static void main(String[] args) {
        
        LinkedList list = new LinkedList();
        
        list.insertAtLast(list, 1);
        list.insertAtLast(list, 2);
//        list.insertAtLast(list, 3);
//        list.insertAtLast(list, 4);
//        list.insertAtLast(list, 5);
        
        list.printList(list);
        var reversedList = reverseList(list);
        list.printList(reversedList);
    }
}