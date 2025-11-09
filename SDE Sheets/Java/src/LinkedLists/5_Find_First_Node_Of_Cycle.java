package LinkedLists;

import java.util.HashSet;

class FirstNodeOfCycle {

    // OR OTHER WAY:
    // We can just set all the visited node value with INT_MIN
    // Because It's obvious that first node of cycle will set INT_MIN very first time
    // So, during the traversal, whenever we see any node with INT_MIN value, it is the very first node
    
    public static LinkedList.Node firstNodeOfCycle(LinkedList list) {
        if (list.head == null || list.head.next == null) return null;

        if (list.head.next == list.head) return list.head;

        var slow = list.head;
        var fast = list.head.next;
        var set = new HashSet<LinkedList.Node>();
        boolean hasCycle = false;

        while (slow != null && fast != null) {
            if (slow.next == slow) return slow;
        
            if (slow == fast) {
                hasCycle = true;
                break;
            }

            slow = slow.next;

            if (fast.next == null) return null;

            fast = fast.next.next;
        }

        if (!hasCycle) return null;

        var ptr = slow.next;

        while (ptr != slow) {
            set.add(ptr);
            ptr = ptr.next;
        }

        while (true) {
            if (set.contains(list.head)) {
                return list.head;
            }
            list.head = list.head.next;
        }
    }

    public static void main(String[] args) {
        LinkedList list = new LinkedList();

        list.insertAtLast(list, 1);
        list.insertAtLast(list, 2);
        list.insertAtLast(list, 3);
        list.insertAtLast(list, 4);
        list.insertAtLast(list, 5);
        list.insertAtLast(list, 6);

        var ptr1 = list.head;
        var ptr2 = list.head;

        while (ptr2.next != null) {
            ptr2 = ptr2.next;
        }
        ptr2.next = ptr1;

        var firstNode = firstNodeOfCycle(list);

        System.out.println(firstNode.data);
    }
}