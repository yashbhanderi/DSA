#include <bits/stdc++.h>

using namespace std;

int main() {
    // Here, Why _max = MAX(_max, arr[i]*_max)

    // ----> It tells two paths are from here
    // 1) Either I am taking current element
    // 2) Or I am continue prev subarray

    // NOWWW !!
    // WHY SWAPPINGGG ????
    // [-2, -2, -3, 5]

    // Here, i=2
    // _min = MIN(_min, arr[i]*_min) <-----  WE ARE CREATING MINIMUM possible value from i

    // SO..when there is NEGATIVE element
    // NEG -> POS
    // POS -> NEG

    // SO,, When We swap ->>> Max , Min
    // MAX WILL BE -------------> MORE LARGER

    vector<int> arr = {-2, -2, -3, 5};

    int n = arr.size();
    long long _max = 1, _min = 1, ans = INT_MIN;

    for (int i = 0; i < n; i++) {
        if (arr[i] < 0) swap(_max, _min);

        _max = max((long long)arr[i], _max * arr[i]);
        _min = min((long long)arr[i], _min * arr[i]);

        ans = max(_max, _min);
    }

    cout << ans;

    return 0;
}