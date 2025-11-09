package LinkedLists;

class MiddleNode {

    public static int getSize(LinkedList.Node head) {
        LinkedList.Node ptr = head;
        int cnt = 0;

        while(ptr != null) {
            cnt++;
            ptr = ptr.next;
        }

        return cnt;
    }
    
    public static void main(String[] args) {
        LinkedList list = new LinkedList();

        int size = getSize(list.head);

        int mid = size/2;

        LinkedList.Node ptr = list.head;

        while(mid > 0) {
            ptr = ptr.next;
            mid--;
        }

        System.out.println(ptr.data);
    }
}