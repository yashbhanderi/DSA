#include <bits/stdc++.h>

using namespace std;

int main() {

    //  Array:     [1, 5, 7, 1, 5]
    //  Frequency: [1 -> 2, 5 -> 2, 7 -> 1]

    // Now, Sum = 6
    // 👉 Problem: Suppose, We thought -> ( 1-> 2, 5 -> 2 ) => 2*2 = 4
    // It's right ! BUT FOR NOWWW...
    // Ex. (1, 1, 1, 1) , Sum = 2 | ANSWER = 6 | Every one of them Pairs with everyone
    // [1->4] <-------------------- How it is possible to answer 6

    // SOO... ITERATE THROUGH MAP | Freq Multiplication ❌ 

    // 👉 Solution:
    // GREEDY | Take and count each Pair on the array | If counted -> Remove from array

    // FOR I = 0 ---> N

    // 1, 5, 7, 1, 5 | sum = 6
    // i == 0 | elem = 1, req = 5 | freq = 2
    // SO, COUNT += 2
    // freq [ 1 ] -= 1 <--------- REMOVING arr[0]'s FROM ARRAY | BCZ IT's PAIRS ARE COUNTED


    // !! Now You thinking what happends to --------------> i=3
    // req = sum - 1 = 5
    // But 5 is before it's index | SO IT IS REMOVED ALREADY
    // 👉 ANSWER: AT TIME OF 5 -> REQ VALUE = 6 - 5 = 1
    // SOOOO... INDEX 3's 1 <---- IS ALREADY COUNTED.....⭐ 

    vector<int> arr = {1, 5, 7, 1};

    int n = arr.size(), K = 6, pairs = 0;

    map<int, int> mp;

    for(int i=0; i<n; i++) {
        mp[arr[i]]++;
    }

    for(int i=0; i<n; i++) {
        int req_value = K - arr[i];

        if(mp.find(req_value) != mp.end()) {
            mp[arr[i]]--;
            pairs += mp[req_value];
        }
    }

    cout << pairs;

    return 0;
}