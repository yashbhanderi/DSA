package LinkedLists;

class ReverseNodesInKGroup {

    public static LinkedList.Node[] reverseList(LinkedList.Node head, int K) {
        var ptr = head.next;
        var curr = head;
        var HEAD = curr;

        curr.next = null;

        while(head != null && ptr!=null && K>0) {
            head = ptr;
            ptr = ptr.next;
            head.next = curr;
            curr = head;
            K--;
        }

        return new LinkedList.Node[] {head, HEAD, ptr};
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
    
    public static LinkedList.Node reverseInKGroup(LinkedList.Node head, int K) {
        var ptr = head;
        int size = getSize(head);
        
        int totalReverse = size/K;
        
        LinkedList.Node lastTailNode = null;
        LinkedList.Node lastHeadNode = null;
        LinkedList.Node lastNextNode = null;
        
        while (ptr != null && totalReverse>0) {
            var temp = ptr;
            var reverseNodes = reverseList(temp, K-1);
            var headNode = reverseNodes[0];
            var tailNode = reverseNodes[1];
            var nextNode = reverseNodes[2];
            
            if(lastTailNode == null) {
                lastTailNode = tailNode;
                lastTailNode.next = null;
            }
            else {
                lastTailNode.next = headNode;
                lastTailNode = tailNode;
            }
            
            if(lastHeadNode == null) {
                lastHeadNode = headNode;
            }

            lastNextNode = nextNode;
            ptr = nextNode;
            totalReverse--;
        }
        
        lastTailNode.next = lastNextNode;
        
        return  lastHeadNode;
    }

    public static void printList(LinkedList.Node head) {
        var ptr = head;

        while(ptr != null) {
            System.out.print(ptr.data+ " ");
            ptr = ptr.next;
        }
    }
    
    public static void main(String[] args) {
        LinkedList list = new LinkedList();
        
        list.insertAtLast(list, 1);
        list.insertAtLast(list, 2);
        list.insertAtLast(list, 3);
        list.insertAtLast(list, 4);
        list.insertAtLast(list, 5);

        LinkedList.Node head = reverseInKGroup(list.head, 5);
        
        printList(head);
    }
}