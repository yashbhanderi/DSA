package LinkedLists;

class AddTwoNumbers {

    public static LinkedList.Node reverseList(LinkedList.Node head) {
        var ptr = head.next;
        var curr = head;

        curr.next = null;

        while(head != null && ptr!=null) {
            head = ptr;
            ptr = ptr.next;
            head.next = curr;
            curr = head;
        }

        return head;
    }

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

    public static LinkedList.Node AddNumbers(LinkedList.Node headA, LinkedList.Node headB) {

        int sizeA = getSize(headA), sizeB = getSize(headB);

        if(sizeB > sizeA) {
            var temp = headA;
            headA = headB;
            headB = temp;
        }
        
        var num1 = headA;
        var num2 = headB;
        LinkedList.Node SUM = null;
        LinkedList.Node ptr = null;
        boolean carry = false;
        
        while(num2 != null) {
            int total = (num1.data + num2.data) + (carry ? 1 : 0);
            
            if(total > 9) {
                carry = true;
                total = total % 10;
            }
            else carry = false;
            
            var newNode = new LinkedList.Node(total);
            if(SUM == null) {
                SUM = newNode;
                ptr = SUM;
            }
            else {
                ptr.next = newNode;
                ptr = newNode;
            }
            
            num1 = num1.next;
            num2 = num2.next;
        }
        
        while (num1 != null) {
            int total = num1.data + (carry ? 1 : 0);

            if(total > 9) {
                carry = true;
                total = total % 10;
            }
            else carry = false;

            var newNode = new LinkedList.Node(total);
            if(SUM == null) {
                SUM = newNode;
                ptr = SUM;
            }
            else {
                ptr.next = newNode;
                ptr = newNode;
            }

            num1 = num1.next;
        }

        if(carry) {
            var newNode = new LinkedList.Node(1);
            ptr.next = newNode;
        }
        
        return SUM;
    }
    
    public static void main(String[] args) {
        LinkedList list1 = new LinkedList();
        LinkedList list2 = new LinkedList();
        
        list1.insertAtLast(list1, 2);
        list1.insertAtLast(list1, 4);
        list1.insertAtLast(list1, 9);
        
        list2.insertAtLast(list2, 5);
        list2.insertAtLast(list2, 6);
        list2.insertAtLast(list2, 4);
        list2.insertAtLast(list2, 9);

        LinkedList.Node head = AddNumbers(list1.head, list2.head);
        
        printList(head);
    }
}