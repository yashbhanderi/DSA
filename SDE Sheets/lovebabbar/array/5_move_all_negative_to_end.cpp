#include <bits/stdc++.h>

using namespace std;

void merge(vector<int>& arr, int l, int m, int r) {
    int i = l, j = m + 1, k = 0;
    vector<int> temp(r - l + 1);

    // i to m   => n, p
    // j to end => n, n

    // temp => _, _, _, _

    // ⭐ First, We will fill temp with negative elements

    // first i -> mid, Bcz of Order maintain

    // temp => n, _, _, _
    while (i <= m && arr[i] < 0) {
        temp[k++] = arr[i++];
    }

    // Then mid -> end

    // temp => n, n, n, _
    while (j <= r && arr[j] < 0) {
        temp[k++] = arr[j++];
    }

    // ⭐ Remaining Positive Elements at back as it is

    // First i to mid <--- Bcz we have to maintain order
    
    // temp => n, n, n, p
    while (i <= m) {
        temp[k++] = arr[i++];
    }

    // Then mid -> end

    // temp => n, n, n, p
    while (j <= r) {
        temp[k++] = arr[j++];
    }
    for (i = l, k = 0; i <= r; i++, k++) {
        arr[i] = temp[k];
    }
}

void mergeSort(vector<int>& arr, int l, int r) {
    if (l < r) {
        int m = l + (r - l) / 2;
        mergeSort(arr, l, m);
        mergeSort(arr, m + 1, r);
        merge(arr, l, m, r);
    }
}

int main() {
    // An array contains both positive and negative numbers in random order. Rearrange the array elements so that all negative numbers appear before all positive numbers.

    vector<int> arr = {1, -1, 3, 2, -7, -5, 11, 6};
    int n = arr.size();


    // ➡️ Space: O(1) | Order: Not Important

    // 🔥 Method 1: douch national flag algorithm

    // int low = 0, mid = 0, high = n-1;

    // while(mid<=high) {
    //     if(arr[mid]<0) {
    //         swap(arr[mid], arr[high]);
    //         high--;
    //     }
    //     else if(arr[mid]>0) {
    //         swap(arr[mid], arr[low]);
    //         low++;
    //         mid++;
    //     }
    //     else mid++;
    // }

    // 🔥 Method 2: Two Pointer

    // int positivePointer = n - 1;
    // int negativePointer = 0;

    // while (negativePointer < positivePointer) {
    //     while (arr[negativePointer] > 0 && negativePointer < n) negativePointer++;
    //     while (arr[positivePointer] < 0 && positivePointer >= 0) positivePointer--;

    //     swap(arr[negativePointer++], arr[positivePointer--]);
    // }


    // ➡️ Space: O(n) | Order : important
    //     int k=0;
    //     int ans[n];
        
    //     for(int i=0; i<n; i++) {
    //         if(arr[i]>0) ans[k++] = arr[i];
    //     }
        
    //     for(int i=0; i<n; i++) {
    //         if(arr[i]<0) ans[k++] = arr[i];
    //     }
        
    //     for(int i=0; i<n; i++) arr[i] = ans[i];


    // ⭐ 
    // 🔥 Merge Sort <--- BESSSTTT !!! 
    //  Bcz... Time: O(n*logn) | Space: O(n) | Order maintained

    mergeSort(arr, 0, n-1);

    for(auto it: arr) cout << it << " ";

    return 0;
}