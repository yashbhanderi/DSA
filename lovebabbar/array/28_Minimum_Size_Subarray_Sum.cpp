#include <bits/stdc++.h>

using namespace std;

//! Problem Description:
// Given an array of positive integers nums and a positive integer target, return the minimal length of a 
// subarray
//  whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.

// Input: target = 7, nums = [2,3,1,2,4,3]
// Output: 2
// Explanation: The subarray [4,3] has the minimal length under the problem constraint.

//? Solution

//* SLIDING WINDOW PROBLEM

//! i, j
//! {2,3,1,2,4,3}

//@ Take two pointer, i=0, j=1
//@ Calculate sum
//@ If sum >= target ---> update minSubarrayLen ---> sum -= a[i] --> i++
//@ Else Sum < target ---> sum += a[j] --> j++

int minSubArrayLen(int target, vector<int>& arr) {
    int n = arr.size();

    int i = 0, j = 1;
    int window_sum = arr[i];

    if (window_sum >= target) return 1;

    int minLen = INT_MAX;

    while (j < n && i < n) {
        if (window_sum + arr[j] >= target) {
            minLen = min(minLen, j - i + 1);
            window_sum -= arr[i];
            i++;
        } else {
            window_sum += arr[j];
            j++;
        }
    }

    return minLen == INT_MAX ? 0 : minLen;
}

int main() {
    vector<int> arr = {2, 3, 1, 2, 4, 3};

    int target = 7;

    cout << minSubArrayLen(target, arr);

    return 0;
}