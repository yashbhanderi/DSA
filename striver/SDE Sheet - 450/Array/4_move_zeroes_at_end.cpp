#include <bits/stdc++.h>

using namespace std;

int main() {
    vector<int> arr = {0, 1, 0, 3, 12};

    int n = arr.size();

    int i = 0, k = 0;

    while (i < n) {
        if (arr[i] > 0)
            swap(arr[i], arr[k++]);

        else
            i++;
    }

    return 0;
}