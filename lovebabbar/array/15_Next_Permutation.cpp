#include <bits/stdc++.h>

using namespace std;

int main() {

    // 👉 STEP: 1
    // First Find ----> PIVOT ELEMENT <--- That has arr[i] < arr[i+1]

    //       2 <--- PIVOT
    //    3     5
    // 1           4 <--- FIRST, Which is greater than PIVOT

    // 👉 STEP: 2
    // SWAP PIVOT <-> First element from end which is GREATER THAN PIVOT
    // HERE...4

    // 👉 STEP: 3
    // REVERSE BOTH ELEMENTS

    // 👉 STEP: 4
    // REVERSE THE ARRAY -> After PIVOT to end

    vector<int> arr = {1,2,3};

    int n = arr.size();

    int pivot = -1;

    for(int i=n-2; i>=0; i--) {
        if(arr[i] < arr[i+1]) {
            pivot = i;
            break;
        }
    }

    if(pivot==-1) {
        reverse(arr.begin(), arr.end());
    }

    else {

        int successor = -1;

        for(int i=n-1; i>=0; i--) {
            if(arr[i]>arr[pivot]) {
                successor = i;
                break;
            }
        }

        swap(arr[pivot], arr[successor]);

        reverse(arr.begin()+pivot, arr.end());
    }
    
    return 0;
}