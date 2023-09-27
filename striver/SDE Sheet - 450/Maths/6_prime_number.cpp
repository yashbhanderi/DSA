#include <bits/stdc++.h>

using namespace std;

/*

* What is a Prime Number?

- A number which have only two factors: 1 and Number itself

- 1 is a prime number

* Applications

- cyber security
- encryption decryption
- complex arithmatic computations

*/

/*

Approach:

Naive: Loop from 1 to N, check if any number is divided by given number

Best:

We'll go only till square root of N

WHY????

- Number's all factors can find from 1 to square root

Ex. 36

    1 * 36
    2 * 18
    3 * 12
    4 * 9
    6 * 6

All the factors:    1, 2, 3, 4, 6

*/

bool isPrime(int n) {

    for (int i = 2; i <= sqrt(n); i++) {
        if (n % i == 0) return false;
    }

    return true;
}

int main() {
    int n = 11;

    cout << isPrime(n);

    return 0;
}