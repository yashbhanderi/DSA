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



Node* insertAfter(Node* head, int data) {
    
    Node* newNode = new Node(data);
    
    if(head==NULL) {
        head = newNode;
        return head;
    }

    while(head->next != NULL) {
        head = head->next;
    }

    head->next = newNode;
    return head;
}

Node* insertBefore(Node* head, int data) {
    Node* newNode = new Node(data);
    
    if(head==NULL) {
        head = newNode;
        return head;
    }

    newNode->next = head;
    head = newNode;
    return head;
}   

void printList(Node* head) {
    cout << "\n:::Linked List:::\n";
    while(head != NULL) {
        cout << head->data << " ";
        head = head->next;
    }
    cout << "\n";
}

int main() {

    Node* head = NULL;

    char flag;

    do {
        cout << "Enter 0 for insert Before\nEnter 1 for insert After\n";
        
        bool position = 0;
        cin >> position;

        cout << "\nEnter data: ";
        int data; cin>>data;

        if(position==0) {
            head = insertBefore(head, data);
        }
        
        else {
            head = insertAfter(head, data);
        }
        printList(head);

        
        cout << "Do you want to continue: ?";
        cin >> flag;

    } while(flag=='y');

    return 0;
}