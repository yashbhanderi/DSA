#include <bits/stdc++.h>

using namespace std;

// [2, 3, 1, 1, 1, 0, 4]
// Here, Rule is simple
// We have to start from 0 index => And check => Can we reach the last index by jump

// Approach :
// See, Every element has it's area | it's kingdom | it's state boundry

// 👉 1) We'll check every one's area i.e boundry ------> To check Can it's area hit the LAST INDEX
// IF YESSS :::  Then we update our LAST POSITIVE SIGN = THIS AREA

// ::: We can check AREA by 2 methods ::

// 1. [2, 3, 1, 1, 1, 4]
// --> For i=1, arr[1] = 3, AREA = 3, [1, 1, 1]
// --> SO... arr[i]+i >= LAST_POSITIVE_SIGN
// -->        3+1 = 4 >=    2   <=============== IT's Okayyyy!!!

// But suppose.... [3,1,1,1,0,0,1,1,4]
// Here, AREA = 3, [1,1,1], LAST_POSITIVE_SIGN = 6
//              0+3 = 3 ❌ 6

// 2. [2, 5, 0, 0, 0, 4]    <-- Element IS BIGGER THAN LAST_INDEX_REQUIRED_VALUE
// i=1, arr[1] = 5
// Here, Even IF LAST_POSITIVE_SIGN ❌
// Still (n-1)-i <= arr[i]
//       (6-1)-1 = 4 <= 5   👍

// 👉 2) We have to check LAST_POSITIVE_SIGN = 0 or not
// Bcz If it become zero, =====> It means we can safely JUMP FROM FIRST TO LAST INDEX

bool canJump(vector<int>& arr) {
    int n = arr.size();

    if (n == 1) return 1;

    int last_positive_sign = n - 1;

    for (int i = n - 2; i >= 0; i--) {
        // OR WE CAN JUST CHECK IT'S MAX VALUE
        // if(i+A[i]>=last)last=i;

        if (((n - 1) - i <= arr[i]) || (arr[i] + i >= last_positive_sign)) {
            last_positive_sign = i;
        }
    }

    if (last_positive_sign != 0)
        return 0;
    else
        return 1;
}

int count_steps(vector<int> arr) {
    int n = arr.size();

    int last_min_steps_needed = INT_MAX;
    vector<int> min_steps(n, 0);
    int 
    int steps = 0;

    for(int i=n-2; i>=0; i--) {
        if(arr[i]+i >= n-1) {
            min_steps[i] = 1;
            last_minimum = min(last_minimum, min_steps[i]);
        }
        else {
            min_steps[i] = min_steps[i+arr[i]] + 1;
        }
    }
}

int main() {
    vector<int> arr = {2, 0, 0};

    // ::: Check If you can reach the LAST INDEX :::

    // cout << canJump(arr);

    return 0;
}