package LinkedLists;

class OddEvenLinkedList {
    
    /*
    
    Approach is very simple:
    
    - Suppose you have 7 nodes
    
    [1, 2, 3, 4, 5, 6, 7]
    
    Partition into 2
    
    oddHead   oddTail   evenHead    evenTail
    [1, 3, 5, 7]        [2,     4,   6] 
    
    Above is our answer
    
    - Now, we just have to maintain 4 nodes
    - Take one pointer on main list
    - If odd indices -> Push back into oddHead
        else Push back into evenHead
        
    - Now, Why oddTail 
        to connect ODD LIST -> EVEN LIST
        
        oddTail.next = evenHead
        
    - Now, why evenTail
        to make next pointer NULL - TO MARK END OF THE LIST
        
        evenTail.next = null
        
    
    
    */
    
    public static int getSizeOfLinkedList(LinkedList.Node head) {
        LinkedList.Node ptr = head;
        int cnt = 0;

        while(ptr!=null) {
            ptr = ptr.next;
            cnt++;
        }
        return cnt;
    }
    
    public static LinkedList.Node oddEvenLinkedList(LinkedList.Node head) {

        var ptr = head;
        
        LinkedList.Node oddHead = null;
        LinkedList.Node oddTail = null;
        LinkedList.Node evenHead = null;
        LinkedList.Node evenTail = null;
        
        boolean flag = true;
        while (ptr != null) {
            if(flag) {
                if(oddHead == null) {
                    oddHead = ptr;
                    oddTail = oddHead;
                }
                else {
                    oddTail.next = ptr;
                    oddTail = oddTail.next;
                }
            }
            else {
                if(evenHead == null) {
                    evenHead = ptr;
                    evenTail = evenHead;
                }
                else {
                    evenTail.next = ptr;
                    evenTail = evenTail.next;
                }
            }
            flag = !flag;
            ptr = ptr.next;
        }
        
        oddTail.next = evenHead;
        evenTail.next = null;
        
        return oddHead;
    }
    
    public static void main(String[] args) {
        LinkedList list = new LinkedList();
        
        list.insertAtLast(list, 1);
        list.insertAtLast(list, 2);
        list.insertAtLast(list, 3);
//        list.insertAtLast(list, 4);
//        list.insertAtLast(list, 5);
//        list.insertAtLast(list, 6);
//        list.insertAtLast(list, 7);

        list.printList(list);
        
        LinkedList.Node ptr = oddEvenLinkedList(list.head);
        
        System.out.println();
        
        while(ptr != null) {
            System.out.print(ptr.data+" ");
            ptr = ptr.next;
        }
    }
}