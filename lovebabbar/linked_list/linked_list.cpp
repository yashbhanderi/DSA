#include <bits/stdc++.h>

using namespace std;

class Node {
   public:
    int data;
    Node* next;

    Node(int data) {
        this->data = data;
        this->next = NULL;
    }
};

class LinkedList {
   public:
    Node* head;

    LinkedList() {
        head = NULL;
    }

    Node* createNode(int data) {
        return new Node
    }

    void insertLast(int data) {
        Node* newNode = new Node(data);

        if (head == NULL) {
            head = newNode;
            return;
        }

        Node* top = head;
        while (top->next != NULL) top = top->next;

        top->next = newNode;
    }

    void insertFirst(int data) {
        Node* newNode = new Node(data);

        if (head == NULL) {
            head = newNode;
            return;
        }

        Node* top = head;
        newNode->next = top;
        head = newNode;

        return;
    }

    void insertAfter(int data, int K) {
        Node* newNode = new Node(data);

        if (head == NULL) {
            head = newNode;
            return;
        }

        if (K == 0) {
            insertFirst(data);
            return;
        }

        Node* top = head;
        int cnt = K - 1;
        while (top->next != NULL && cnt--) {
            top = top->next;
        }

        if (top == NULL) {
            cout << "Enter valid value\n";
            return;
        }

        newNode->next = top->next;
        top->next = newNode;
        return;
    }

    void removeLast() {
        if (head == NULL) {
            cout << "There is no node in the linked list!\n";
            return;
        }

        if (head->next == NULL) {
            head = NULL;
            return;
        }

        Node* top = head;
        while (top->next->next != NULL) {
            top = top->next;
        }

        top->next = NULL;
    }

    void removeFirst() {
        if (head == NULL) {
            cout << "There is no node in the linked list!\n";
            return;
        }

        if (head->next == NULL) {
            head = NULL;
            return;
        }

        head = head->next;
        return;
    }

    void removeAfter(int K) {
        if (head == NULL) {
            cout << "Linked List is empty!";
            return;
        }

        if (K == 0) {
            removeFirst();
            return;
        }

        Node* top = head;
        int cnt = K - 1;
        while (top->next->next != NULL && cnt--) {
            top = top->next;
        }

        if (top == NULL || cnt>0) {
            cout << "Enter valid value\n";
            return;
        }

        Node* temp = top->next->next;

        top->next = temp;
        return;
    }

    void printList() {
        Node* top = head;

        cout << "\n";

        while (top != NULL) {
            cout << top->data << " ";
            top = top->next;
        }

        cout << "\n\n";
        return;
    }
};

// int main() {
//     return 0;
// }