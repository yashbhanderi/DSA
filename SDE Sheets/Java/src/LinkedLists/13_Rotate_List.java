package LinkedLists;

class RotateList {

    public static void printList(LinkedList.Node head) {
        var ptr = head;

        while(ptr != null) {
            System.out.print(ptr.data+ " ");
            ptr = ptr.next;
        }
    }

    public static int getSize(LinkedList.Node head) {
        LinkedList.Node ptr = head;
        int cnt = 0;

        while(ptr!=null) {
            ptr = ptr.next;
            cnt++;
        }
        return cnt;
    }
    
    public static LinkedList.Node rotateList(LinkedList.Node head, int K) {
        int size = getSize(head);
        
        if(K==size || K==0 || size==1) return head;
        
        if(K > size) K = (K/size);
        
        K = size-K-1;
        
        var ptr1 = head;
        var ptr2 = head;
        
        while(K>0) {
            ptr1 = ptr1.next;
            K--;
        }
        
        ptr2 = ptr1.next;
        ptr1.next = null;

        LinkedList.Node temp = ptr2;
        
        while (temp.next != null) {
            temp = temp.next;
        }
        
        temp.next = head;
        
        return ptr2;
    }
    
    public static void main(String[] args) {
        LinkedList list = new LinkedList();

        list.insertAtLast(list, 0);
        list.insertAtLast(list, 1);
//        list.insertAtLast(list, 2);
//        list.insertAtLast(list, 3);
//        list.insertAtLast(list, 4);
//        list.insertAtLast(list, 5);

        LinkedList.Node head = rotateList(list.head, 3);

        printList(head);
    }
}