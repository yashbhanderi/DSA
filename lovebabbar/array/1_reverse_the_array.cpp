#include <bits/stdc++.h>

using namespace std;

int main() {

    string str = "Yash Bhanderi";

    // 1) Reverse function <- O(n) 
    // 2) Store all char in new string from back <- Extra space
    // 3) Best : 

    // Take two pointer, from start and from end
    // swap pointer values
    // Increase start++
    // Decares end--
    // Go till half point

    int n = str.size();

    for(int i=0; i<n/2; i++) {
        swap(str[i], str[n-i-1]);
    }

    cout << str << endl;

    return 0;
}


