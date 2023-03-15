#include <bits/stdc++.h>

using namespace std;

int main() {

    // Simple Approach

    // FIRST AND MOST IMP: SORT THE VECTOR

    //           👇 
    // ans: {{1, 3}}

    //       👇 
    // arr: {{2, 6}, {8, 10}}    

    // ans: {{1, 6}}

    // Compare, ans's LAST <-> element's FIRST
    // 1) IF ans's LAST is BIG ----> Update ANS's LAST based on two's LAST VALUES

    // 2) IF NOT : DIRECT PUSH TO ANSWER

    vector<pair<int, int>> arr = {{1, 3}, {2, 6}, {8, 10}, {15, 18}};

    sort(arr.begin(), arr.end());

    vector<pair<int, int>> ans;
    ans.push_back({arr[0].first, arr[0].second});

    int n = arr.size();

    for(int i=1; i<n; i++) {
        if(ans.back().second >= arr[i].first) {
            if(ans.back().second < arr[i].second) ans.back().second = arr[i].second;
        }
        else {
            ans.push_back(arr[i]);
        }
    }

    for(auto i: ans) cout << i.first << " " << i.second << endl;

    return 0;
}