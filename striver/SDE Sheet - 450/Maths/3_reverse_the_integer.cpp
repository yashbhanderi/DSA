#include <bits/stdc++.h>

using namespace std;

/*

Process:

suppose we have a variable rev = 0

    1214

    rev*0 + 4    = 4
    4*10 + 1     = 41
    41*10 + 2    = 412
    412*10 + 1   = 4121

    This is how we reverse the number.


*/

int reverseInteger(int x) {
    
    long rev = 0;
    
    while (x) {
        rev = rev * 10 + x % 10;
        x /= 10;
    }

    if (rev > INT_MAX || rev < INT_MIN) return 0;
    return rev;
}

int main() {

    int num = -321;

    cout << reverseInteger(num);

    return 0;
}