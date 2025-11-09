#include <bits/stdc++.h>

using namespace std;

int main() {
    vector<int> arr = {1, 2, 3, 4, 5, 6, 7};
    int k = 3, n = arr.size();
    k = k % n;  // k can be 0<=k<=10^5

    for (auto it : arr) cout << it << " ";
    cout << "\n";

    // 1,2,3,4,5,6,7    <-- we'll divide array into two part by n-k
    // If k=3 => 7-3=4 => 1,2,3,4 || 5,6,7

    // Bcz We wanting Last k ----> Ahead    || And Out couting start from beginning
    // So we have to use n-k

    // Now..                    1,2,3,4 || 5,6,7
    // Reverse both parts       4,3,2,1 || 7,6,5
    // Reverse whole part       5,6,7   || 1,2,3,4  <===ANSWER !! ⭐

    reverse(arr.begin(), arr.begin() + (n - k));
    reverse(arr.begin() + (n - k), arr.end());
    reverse(arr.begin(), arr.end());

    for (auto it : arr) cout << it << " ";

    return 0;
}