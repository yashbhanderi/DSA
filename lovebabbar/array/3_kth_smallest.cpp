#include <bits/stdc++.h>

using namespace std;

// Method 1: Sorting

// Method 2: Priority Queue

// Here, Priority Queue implement the Max Heap

// {7, 1, 2, 9, 10, 5, 2, 8, 4}

// Here, Max Heap says top of heap must be maximum
// inside is sorted or not | doesn't matter
// ONLY AND ONLY TOP MUST BE BIGGEST

// AND... Why Max Heap Here..
// We want kth smallest -> Means -> Biggest in [1, k] range

// Operation example
// 1) [7]
// 2) [1, 7]
// 3) [1, 2, 7]
// 4) [1, 2, 7, 9]
// 5) [1, 2, 7, 9, 10]  <- more than k => Remove 10
// 6) [1, 2, 5, 7, 9]   <- remove 9 <==SEEE.. Here explains why we have to push before pop
//  I know size is already equal to k
// But upcoming elements we don't know
// like here.. 5 is inside the heap -> 7 become peek instead of 9

// 7) [1, 2, 2, 5, 7] <- remove 7
// 8) [1, 2, 2, 5, 8] <- remove 8
// 9) [1, 2, 2, 4, 5] <- remove 5

// Answer: [1, 2, 2, 4] <- 4 : 4th smallest, and biggest in [1, 4]

// SO... We JUST HAVE TO DO 2 STEPS
// 1) Create Max Heap
// 2) If size gets more than k -> pop the element i.e. maintain Heap size equals to k

// Time: O(n*long[k]) Better than n*logn (sorting time)

int kth_smallest(vector<int> vi, int k) {
    priority_queue<int> pq;
    int n = vi.size();

    for (int i = 0; i < n; i++) {
        pq.push(vi[i]);  // Before pop..because this element may smaller than top
        if (pq.size() > k) pq.pop();
    }

    return pq.top();
}

// Method 3: Quick Select (Randomized Quick Sort)

int partition(vector<int>& arr, int low, int high) {
    int n = arr.size();

    int idx = low-1;
    int random = low + rand()%(high-low);
    swap(arr[random], arr[high]);
    
    for(int i=low; i<high; i++) {
        if(arr[i] <= arr[high]) {
            idx++;
            swap(arr[i], arr[idx]);
        }
    }

    idx++;
    swap(arr[idx], arr[high]);
    return idx;
}

int find_kth_smallest(vector<int>& arr, int low, int high, int k) {
    while(low <= high) {
        int pivot = partition(arr, low, high);

        if(pivot < k-1) {
            low = pivot+1;
        }
        // 5  |   4
        else if(pivot > k-1) {
            high = pivot-1;
        }
        else return arr[pivot];
    }

    return 0;
}

int main() {
    vector<int> arr = {7, 1, 2, 9, 10, 5, 2, 8, 4, 3};

    int n = arr.size();

    // for(int i=0; i<n; i++)
    cout << find_kth_smallest(arr, 0, n-1, 2) << " ";
    // cout << "Hello";

    return 0;
}