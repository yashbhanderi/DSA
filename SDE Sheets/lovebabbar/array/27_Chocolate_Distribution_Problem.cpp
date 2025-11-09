#include <bits/stdc++.h>

using namespace std;

// Problem Description:
// Given an array A[ ] of positive integers of size N, where each value represents the number of chocolates in a packet. Each packet can have a variable number of chocolates. There are M students, the task is to distribute chocolate packets among M students such that :
// 1. Each student gets exactly one packet.
// 2. The difference between maximum number of chocolates given to a student and minimum number of chocolates given to a student is minimum.

//N = 8, M = 5
// A = {3, 4, 1, 9, 56, 7, 9, 12}
// Output: 6

//? Solution:

//! We want : Maximum - Minimum = Minimum <=> A - B = C
//! For C Min -> A Min

//* Soo.. If we SORT -> { 1, 3, 4, 7, 9, 9, 56 }

//@ Take M ----> 5 elements WINDOW <-----
//@ to minimize the max element

//@ For every window...Just find and update min Diff among (MAX-MIN)
//@ Now.. {1, 3, 4, 7, 9}
//@ {3, 4, 7, 9, 9} <-- ANSWER

long long findMinDiff(vector<long long> arr, long long n, long long m) {

    // code
    sort(arr.begin(), arr.end());

    long long minDiff = INT_MAX;

    int i = 0, j = m - 1;
    while (j < n) {
        long long currentDiff = arr[j] - arr[i];
        minDiff = min(minDiff, currentDiff);

        j++;
        i++;
    }

    return minDiff;
}

int main() {
    vector<long long> arr = {3, 4, 1, 9, 56, 7, 9, 12};

    int M = 5;

    cout << findMinDiff(arr, arr.size(), M);

    return 0;
}