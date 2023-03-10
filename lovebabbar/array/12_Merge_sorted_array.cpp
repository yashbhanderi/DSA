#include <bits/stdc++.h>

using namespace std;

int main() {
    vector<int> arr1 = {4, 0, 0, 0, 0, 0}, arr2 = {1, 2, 3, 5, 6};
    int m = 1, n = 5;
    vector<int> ans(m + n, 0);

    int i = 0, j = 0, k = 0;
    while (i < m && j < n) {
        if (arr1[i] > arr2[j]) {
            ans[k++] = arr2[j++];
        } else {
            ans[k++] = arr1[i++];
        }
    }

    while (i < m) {
        ans[k++] = arr1[i++];
    }
    while (j < n) {
        ans[k++] = arr2[j++];
    }

    for (int i=0; i<m+n; i++) {
        arr1[i] = ans[i];
        cout << arr1[i] << " ";
    }

    return 0;
}