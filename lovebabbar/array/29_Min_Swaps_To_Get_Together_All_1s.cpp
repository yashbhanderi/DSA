#include <bits/stdc++.h>

using namespace std;

//? Problem Description

// A swap is defined as taking two distinct positions in an array and swapping the values in them.

// A circular array is defined as an array where we consider the first element and the last element to be adjacent.

// Given a binary circular array nums, return the minimum number of swaps required to group all 1's present in the array together at any location.

// Input: nums = [0,1,0,1,1,0,0]
// Output: 1

//* Solution:

//? SLIDING WINDOWWWWWWW........

int minSwaps(vector<int>& arr) {
    int n = arr.size();

    if (n == 1) {
        return 0;
    }

    int cnt = 0;

    for (auto e : arr) {
        if (e == 1) cnt++;
    }

    int ans = INT_MAX;
    int total_count = 0;

    for (int i = 0; i < cnt; i++) {
        if (arr[i] == 1) total_count++;
    }

    int start_ptr = 0;
    int end_ptr = cnt;

    ans = min(ans, cnt - total_count);

    // slide window and update total count
    while (start_ptr < n) {
        if (arr[start_ptr] == 1) {
            total_count--;
        }
        if (arr[end_ptr] == 1) {
            total_count++;
        }
        ans = min(ans, cnt - total_count);

        // slide window by moving pointers
        start_ptr++;
        end_ptr = (end_ptr + 1) % n;
    }

    return ans;
}

int main() {
    vector<int> arr = {0, 1, 0, 1, 1, 0, 0};

    int n = arr.size();

    cout << minSwaps(arr);

    return 0;
}