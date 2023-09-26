#include<bits/stdc++.h>
 
using namespace std;
 
/*

* What is GCD?

- GCD stands for Greatest Common Divisor
- It means it is the highest common factor between two numbers

Ex. 36 = 2, 2, 3, 3
    60 = 2, 2, 3, 5

Here, GCD = 2*2*3 = 12 is the highest number by which we can divide both the number'

- It can reduce arithmatic complexity
- Factorization 

*/

int GCD(int a, int b) {

/*

* Method 1: Brute force

time: O(n), space: O(1)

    if(a > b) swap(a, b);

    if(b%a==0) return a;

    for(int i=a-1; i>0; i--) {
        if(a%i==0 && b%i==0) return i;
    }

    return 0;
*/

/*

Method 2: 

Euclidian Algorithm

    For a > b

    - GCD(a, b) = GCD(a-b, b)   <---------- This is the Euclidian principle

    Okay, so algorithm is simple
    Once substraction is Zero -> other number is GCD

    
    --- Using substraction

        if(b==0) return a;

        if(b > a) swap(a, b);

        return GCD(a-b, b);

    --- Using Modula Operator

        if(b==0) return a;

        return GCD(b, a%b);


*/

/*

Method 3: Built-in function

    return __gcd(a, b);

*/
}

int main() {
 
   int a = 60, b = 18;

   cout << GCD(a, b);
 
   return 0;
}