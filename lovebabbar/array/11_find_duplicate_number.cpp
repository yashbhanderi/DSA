#include <bits/stdc++.h>

using namespace std;

int main() {
    vector<int> arr = {3, 1, 3, 2, 5};

    int n = arr.size(), ans = -1;

    for (int i = 0; i < n; i++) {
        if (arr[i] <= n) {
            int ind_value = arr[arr[i] - 1];

            if (ind_value <= n) {
                arr[arr[i] - 1] += n;
            }
        }
    }

    for(auto i : arr) cout << i << " ";

    cout << ans;

    return 0;
}