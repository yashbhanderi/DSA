#include <bits/stdc++.h>

using namespace std;

bool is_sorted_and_rotated(vector<int>& arr) {
    /*

    * Approach 2:

    - Here, we'll check for only TWO condition

    - There MUST be only one ----> arr[i] > arr[i+1]
    - AND If that exist ---> CAN we rotate the array and make sorted??


    Ex. [3, 4, 5, 1, 2]

    --> for [5, 1] - arr[i] > arr[i+1]

    Now, Check 2 < 3 or not  <------------- ARRAY CAN ROTATE


    Ex. [2, 1, 3, 4]

    --> for [2, 1] - arr[i] > arr[i+1]

    Now, 4 < 2 NOOOO!!!!   <--------------ARRAY CAN'T ROTATE !!




        bool check(vector<int> & A) {
            for (int i = 0, k = 0; i < A.size(); ++i)
                if (A[i] > A[(i + 1) % A.size()] && ++k > 1)
                    return false;
            return true;
        }
    */

    /*

    * Approach 1:

    - check if already sorted or not
    - [3, 4, 5, 1, 2]

    Here, Check array is rotated or not
    for that, we can find one index [This is must condition] for which, arr[i] > arr[i+1]

    suppose that index = 2

    then we'll reverse array 3 times

    [3, 4, 5]   [1, 2]
    [5, 4, 3]   [2, 1]
    [1, 2, 3, 4, 5]

    - If final array is sorted -> YES
    else NO





        if (is_sorted(arr.begin(), arr.end())) return true;

        int k = 0, i = 0, n = arr.size();

        while (i + 1 < n && arr[i] <= arr[i + 1]) i++;

        reverse(arr.begin(), arr.begin() + i + 1);
        reverse(arr.begin() + i + 1, arr.end());
        reverse(arr.begin(), arr.end());

        if (is_sorted(arr.begin(), arr.end()))
            return true;
        else
            return false;

    */
}

int main() {
    vector<int> arr = {5, 5, 6, 6, 6, 9, 1, 2};

    cout << is_sorted_and_rotated(arr);

    return 0;
}