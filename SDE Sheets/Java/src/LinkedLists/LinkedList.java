package LinkedLists;
import java.io.*;

public class LinkedList {

    Node head;
    
    static class Node {

        int data;
        Node next;

        Node(int d)
        {
            data = d;
            next = null;
        }
    }
    
    int size() {
        Node ptr = head;
        int cnt = 0;
        
        while(ptr!=null) {
            ptr = ptr.next;
            cnt++;
        }
        return cnt;
    }

    public LinkedList insertAtLast(LinkedList list, int data)
    {
        Node new_node = new Node(data);
        
        if (list.head == null) {
            list.head = new_node;
        }
        else {
            Node last = list.head;
            while (last.next != null) {
                last = last.next;
            }

            last.next = new_node;
        }

        return list;
    }
    
    public LinkedList insertAtFirst(LinkedList list,  int data) {
        Node new_node = new Node(data);

        if (list.head == null) {
            list.head = new_node;
        }
        else {
            new_node.next = list.head;
            list.head = new_node;
        }

        return list;
    }

    public LinkedList insertAfterNthNode(LinkedList list, int data, int position) {
        Node new_node = new Node(data);

        if (list.head == null) {
            list.head = new_node;
        }
        else if(position==0) {
            insertAtFirst(list, data);
        }
        else if(position == list.size()) {
            insertAtLast(list, data);
        }
        else {
            
            Node ptr = list.head;
            int cnt = position-1;
            while(cnt > 0 && ptr != null) {
                ptr = ptr.next;
                cnt--;
            }
            
            new_node.next = ptr.next;
            ptr.next = new_node;
        }

        return list;
    }

    public LinkedList deleteLast(LinkedList list) {
        if(list.head == null) return list;
        else if(list.head.next == null) {
            list.head = null;
            return list;
        }
        else {
            Node ptr = list.head;
            
            while(ptr.next.next!=null) {
                ptr = ptr.next;
            }
            
            ptr.next = null;
            return list;
        }
    }

    public LinkedList deleteFirst(LinkedList list) {
        if(list.head == null) return list;
        else if(list.head.next == null) {
            list.head = null;
            return list;
        }
        else {
            list.head = list.head.next;
            return list;
        }
    }

    public LinkedList deleteNthNode(LinkedList list, int position) {
        if(list.head == null) return list;
        else if(position == 0) {
            list.head = null;
            return list;
        }
        else {
            list.head = list.head.next;
            return list;
        }
    }
    
    public void printList(LinkedList list)
    {
        Node currNode = list.head;

        System.out.print("LinkedList: ");

        while (currNode != null) {
            System.out.print(currNode.data + " ");
            currNode = currNode.next;
        }
    }

    public static void main(String[] args)
    {
        LinkedList list = new LinkedList();

        list = list.insertAtLast(list, 1);
        list = list.insertAtLast(list, 2);
//        list = insertAtLast(list, 3);
//        list = deleteFirst(list);
        list = list.deleteNthNode(list, 2);
        
        list.printList(list);
    }
}
