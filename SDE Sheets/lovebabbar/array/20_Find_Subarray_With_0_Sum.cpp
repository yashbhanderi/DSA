#include <bits/stdc++.h>

using namespace std;

int main() {

    vector<int> arr = {4, 2, -3, 1, 6};

    int n = arr.size();

    map<int, int> mp;

    bool ans = false;
    int sum = 0;

    for(int i=0; i<n; i++) {
        sum += arr[i];

        if(mp.find(sum) != mp.end()) {
            mp[sum] ++;
        }

        else {
            ans = true;
        }
    }

    cout << ans;

    return 0;
}