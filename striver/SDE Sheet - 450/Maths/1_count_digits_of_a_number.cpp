#include<bits/stdc++.h>
 
using namespace std;
 
int countDigits(int num) {

    // *** Method 1:

/*
    Time: O(n), Space: O(1)
    
    Divide the number by 10 until it becomes zero
    Meanwhile keep track the count 

    int val = num;
    int count = 0;
    
    while(val != 0) {
        val /= 10;
        count++;
    }

    return count;
*/
    
    
    // *** Method 2:

/*
    Time: O(1), Space: O(1)

    Convert number into string
    Return the size of the string

    string val = to_string(num);

    return val.size();
*/


    // *** Method 3:    (Recommended)

/* 
    Time: O(1), Space: O(1)

    Take the log base 10 of the number
    Num of digits = Upper bound of the log(10)
*/
    
    int count = floor(log10(num) + 1);

    return count;
}

int main() {
 
   int num = 22134;

   cout << countDigits(num);
 
   return 0;
}