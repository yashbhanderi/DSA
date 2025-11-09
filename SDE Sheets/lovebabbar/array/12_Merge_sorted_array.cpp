#include <bits/stdc++.h>

using namespace std;

int main() {

    // It is bit tricky in Constant Memory ---> O(1) Space
    // Trick:

    // 👉 Start from end
    // Fill the space from Back
    
    // Because If we start from front -----> Surely at some place | Array will become unsorted | 😐
    // Soooo...We'll make TWO POINTER and third to FILL ELEMENTS 3️⃣

    // Compare elements and start filling from back

    //     i     k
    // 6,7,8,0,0,0

    //     j
    // 1,9,13

    vector<int> arr1 = {4, 0, 0, 0, 0, 0}, arr2 = {1, 2, 3, 5, 6};

    int M = 1, N = arr2.size();
    int i=M-1, j=N-1, k=M+N-1;

    while(i>=0 && j>=0) {
        if(arr1[i] >= arr2[j]) {
            arr1[k--] = arr1[i--];
        }
        else {
            arr1[k--] = arr2[j--];
        }
    }

    while(j>=0) arr1[k--] = arr2[j--];

    for(auto it: arr1) cout << it << " ";

    return 0;
}