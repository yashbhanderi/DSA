#include <bits/stdc++.h>

using namespace std;

// 1: Use Map and store frequency
// 2: Sort both array, Two pointer on both array
// 3: this method

int main() {
    vector<int> v1 = {1, 2, 2, 1}, v2 = {2, 2};

    vector<int> visited(1001, 0);

    for (int i = 0; i < v1.size(); i++) {
        visited[v1[i]] = 1;
    }

    for (int i = 0; i < v2.size(); i++) {
        if (visited[v2[i]]) {
            visited[v2[i]] = 0;
            cout << v2[i] << " ";
        }
    }

    return 0;
}