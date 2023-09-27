#include <bits/stdc++.h>

using namespace std;

/*

What is armstrong number?

* Armstrong number of n digits = sum of cubes of its digits equal to the number itself

- abcd... = pow(a,n) + pow(b,n) + pow(c,n) + pow(d,n) + ....

* Application

- Encryption Decryption

*/



string isArmstrongNumber(int n) {
    int sum = 0, total = n;

    while (n > 0) {
        int N = n % 10;
        sum += (N * N * N);
        n /= 10;
    }

    return sum == total ? "Yes" : "No";
}

int main() {
    int x = 371;

    cout << isArmstrongNumber(x);

    return 0;
}