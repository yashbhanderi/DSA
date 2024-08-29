package LinkedLists;

class DeleteNode {
    
    /*
    
    We'll do this in 2 steps:
    
    [1, 0x] -> [2, 1x] -> [3, 2x]
                   ^
                  PTR
    
     - Suppose, out pointer is on 2nd node, that we have to delete
     
     1. Swap this node's value with next node
     2. Make next node null
     
     NOTE: WE CAN'T Do this program for Tail Node
        - And All the values in the list MUST BE UNIQUE
     
    */
    
    public static LinkedList DeleteNode(LinkedList.Node node, int data) {
        LinkedList.Node nextNode = node.next;

        int temp = nextNode.data;
        nextNode.data = node.data;
        node.data = temp;

        node.next = nextNode.next;
        return null;
    }
    
    public static void main(String[] args) {
        LinkedList list = new LinkedList();
        
        list.insertAtLast(list, 1);
        list.insertAtLast(list, 2);
        list.insertAtLast(list, 3);
        list.insertAtLast(list, 4);
        list.insertAtLast(list, 5);
        
//        DeleteNode(list, 3);
        
        list.printList(list);
    }
}