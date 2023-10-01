#include <bits/stdc++.h>

using namespace std;

int main() {
    vector<int> arr = {3, 4, 5, 1, 2};

    map<int, int> mp;

    for (auto it : arr) mp[it]++;

    auto itr = mp.begin();

    for (int i = 0; i < mp.size(); i++) {
        arr[i] = itr->first;
        itr++;
    }

    return mp.size();
}