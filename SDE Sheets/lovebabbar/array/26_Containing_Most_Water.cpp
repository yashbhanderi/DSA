#include <bits/stdc++.h>

using namespace std;

int main() {
    vector<int> arr = {7, 4, 0, 9};

    int n = arr.size();

    long long max_area = INT_MIN;
    int i=0, j=n-1;


    while(i<j) {
        int height = min(arr[i], arr[j]);
        int width = j-i;
        long long area = height*width;
        max_area = max(max_area, area);

        if(arr[i] < arr[j]) i++;
        else j--;
    }

    cout << max_area;

    return 0;
}