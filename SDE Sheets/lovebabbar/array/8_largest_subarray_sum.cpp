#include <bits/stdc++.h>

using namespace std;

// kadane's algorithm

//      -2, 1, -3, 4, -1, 2, 1, -5, 4

// only 2 step:
// 1)  max_till_here += arr[i] |  max_till_so_far = max(max_till_so_far, max_till_here)
// 2) If max_till_here < 0 => max_till_here = 0

// Explanation:
// max_till_here = 0
// 1) First we are adding current elem -> max_till_here
//  SOO... If current_sum = 5 | and next elem = 2 ===> Sum Will INCREASEEEE 👍 
//  And that's why we are checking 
//  current_sum > max_sum

// 2) If current sum become negative <-- make current_sum = 0
// BCZZZZ If we have ANY TIMES LARGEST VALUE
// ADDING INTO NEGATIVE -> DECREASEEEE!! 👎 
// SO... WE ARE MAKING VALUE ------> 0  NEUTRAL

// -2, 1, -3, 4, -1, 2, 1, -5, 4
//     ->  -2 ||  max_till_here = -2, max_so_far = -2, max_till_here = 0
//     ->  1  ||  max_till_here = 1, max_so_far = 1, max_till_here = 1
//     ->  -3 ||  max_till_here = -2, max_so_far = 1, max_till_here = 0
//     ->  4  ||  max_till_here = 4, max_so_far = 4, max_till_here = 4
//     ->  -1 ||  max_till_here = 3, max_so_far = 4, max_till_here = 3
//     ->  2  ||  max_till_here = 5, max_so_far = 5, max_till_here = 5
//     ->  1  ||  max_till_here = 6, max_so_far = 6, max_till_here = 6
//     ->  -5 ||  max_till_here = 1, max_so_far = 6, max_till_here = 1
//     ->  4  ||  max_till_here = 5, max_so_far = 6, max_till_here = 5

int main() {
    vector<int> arr = {-2, 1, -3, 4, -1, 2, 1, -5, 4};

    int n = arr.size();

    int max_till_here = 0;
    int max_till_so_far = INT_MIN;

    for (int i = 0; i < n; i++) {
        max_till_here += arr[i];

        if (max_till_here > max_till_so_far) {
            max_till_so_far = max_till_here;
        }

        if (max_till_here < 0) max_till_here = 0;
    }

    cout << max_till_so_far;

    return 0;
}