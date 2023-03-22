#include <bits/stdc++.h>

using namespace std;

int main() {
    //! Moore's Voting Algorithm

    //* Here, More than floor( n/2 ) <-- elements are there
    //* Intution first

    //! If votes = 0 --> WE CHOSE CANDIDATE | CURRENT ELEMENT & Votes = 1

    //* NOW.. If same elements --> Votes ++ | Else Votes --

    //! IF Votes Become 0 again ---> SAME PROCESS --> CHOSE CANDIDATE | CURRENT ELEMENT

    // todo NOOOWWW...PRROOOFF !!

    // todo WORST CASE POSITION OF MAJORITY ELEMENT | N=10
    // todo [ 1, 2, 1, 3, 1, 4, 1, 5, 1, 1]
    //* ALTERNATE POSTION | WILL REMOVE CANDIDATE IN VERY FAST | BCZ COUNT = 1 | WILL REMOVE BY NEXT ELEMENT
    //* NOW, THERE ARE MORE THAN N/2 | NOT EXACT N/2
    // todo IF EXACT N/2 -> THAN ABOVE ARRAY WILL BE THE EDGE CASE <---

    //* BUT MORE THAN N/2
    //* SO AT END TIME IN ARRAY <--- THERE WILL ALWAYS MAJORITY ELEMENT <--- CANDIDATE

    // todo ******************** N/2 **********************************
    
    vector<int> arr = {1, 2, 1, 1, 1, 2, 2, 1, 4, 3, 2, 2};
    // vector<int> arr = {2, 2, 1, 3};

    int n = arr.size();

    // int votes = 0;
    // int candidate = arr[0];

    // for (int i = 0; i < n; i++) {
    //     if (votes == 0) {
    //         candidate = arr[i];
    //     } else {
    //         if (arr[i] == candidate)
    //             votes++;
    //         else
    //             votes--;
    //     }
    // }

    // cout << candidate;

    // todo ******************** N/3 **********************************

    int vote1 = 0, vote2 = 0, candidate1 = 0, candidate2 = 0;

    for (int i = 0; i < n; i++) {
        if (vote1 == 0) {
            candidate1 = arr[i];
            vote1++;
        } 
        else if (arr[i] == candidate1) {
            vote1++;
        } 
        else if (vote2 == 0) {
            candidate2 = arr[i];
            vote2++;
        } 
        else if (arr[i] == candidate2) {
            vote2++;
        } 
        else {
            vote1--;
            vote2--;
        }
    }

    vector<int> ans;
    int cnt1 = 0, cnt2 = 0;
    for (int i = 0; i < n; i++) {
        if (arr[i] == candidate1) cnt1++;
        if (arr[i] == candidate2) cnt2++;
    }

    if (cnt1 > floor(n / 3)) ans.push_back(candidate1);
    if (cnt2 > floor(n / 3)) ans.push_back(candidate2);

    return 0;
}