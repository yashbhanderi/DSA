#include <bits/stdc++.h>

using namespace std;

bool isPalindrome(int x) {
    
    
    // *** Method 1:
/*
    convert the number into string
    take two pointer at both the side and traverse them
    if at any point arr[i] != arr[j] <--------------------FALSEEEEEE !!!
    otherwise TRUE.
*/

/*
    string str = to_string(x);

    int i=0, j=str.size()-1;

    while(i<j) {
        if(str[i++] != str[j--]) return false;
    }

    return true;
*/

    // *** Method 2:

    
/*  REVERSE THE NUMBER !!!

    suppose we have a variable rev = 0

    1214
    rev*0 + 4    = 4
    4*10 + 1     = 41
    41*10 + 2    = 412
    412*10 + 1   = 4121

    This is how we reverse the number.

    BUTTT !!
    Here, we'll only look upto half, then compare

    Here, we'll go till [ x  > rev  ]

    Ex. x = 78387

    x ->     7838    783     78
    rev->    7       78      783     We'll compare [ x == rev/10 ]

    Ex. x = 763387

    x->      76338   7633    763
    rev->    7       78      783     we'll compare [ x == rev ]

*/

    if (x < 0 || (x > 0 && x % 10 == 0)) return false;

    int rev = 0;
    while (x > rev) {
        rev = rev * 10 + x % 10;
        x /= 10;
    }

    return (x == rev || x == rev / 10);
}

int main() {
    int num = -1231;

    cout << isPalindrome(num);

    return 0;
}