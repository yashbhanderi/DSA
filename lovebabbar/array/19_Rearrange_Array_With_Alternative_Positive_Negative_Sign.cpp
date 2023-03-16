#include <bits/stdc++.h>

using namespace std;

int main() {

    // ********************  O(N) SPACE | O(N) TIME | ORDER 👍 

    // SINCE WE CAN USE EXTRA ARRAY
    // START WTIH POSITIVE
    // EQUAL NO. OF POSITIVE AND NEGATIVE
    // LENGTH OF ARRAY = EVEN

    // positiveIndex = 0, negeativeIndex = 1
    // 👌 SIMPLE : i=0 -> N
    // IF POSITIVE -> ANS[positiveIndex] = arr[i] | positiveIndex += 2 <-----------
    // IF NEGATIVE -> ANS[negativeIndex] = arr[i] | negativeIndex += 2 <-----------


    // ******************** O(1) SPACE | O(N*N) TIME | ORDER 👍

    // { -5, 5, -2, 2, ->4, 7, 1, 8, 0, -8 } , 4 is out of place.
    // { -5, 5, -2, 2, 4, 7, 1, 8, 0,-> -8 } =>-8 is of different sign 
    // SHIIFFFTTTINGGG :  { -5, 5, -2, 2, -8, 4, 7, 1, 8, 0 } => after performing right rotation between 4 to -8

    // BUT IT TAKES WORST -> O(N*N) TIME

    // ******************* O(1) SPACE | O(N*LOGN) | ORDER ❌ 
    // SORT ARRAY
    // NOW, SWAP ELEMENT AT THEIR RESPODING INDEX | i.e POSITIVE, NEG, POS by SWAPPINGGG

    // ******************* O(1) SPACE | O(N) | ORDER ❌ 

    // SHIFT ALL NEGATIVES -----------> ONE END
    // NOW, SWAP ELEMENT AT THEIR RESPODING INDEX | i.e POSITIVE, NEG, POS by SWAPPINGGG

    vector<int> arr = {3,1,-2,-5,2,-4};

    int n = arr.size();

    vector<int> ans(n, 0);

    int positiveIndex = !(arr[0] > 0), negativeIndex = !(arr[0] < 1);

    for(int i=0; i<n; i++) {
        if(arr[i] > 0) {
            ans[positiveIndex] = arr[i];
            positiveIndex += 2;
        }
        else {
            ans[negativeIndex] = arr[i];
            negativeIndex += 2;
        }
    }

    for(auto it: ans) cout << it << " ";

    return 0;
}