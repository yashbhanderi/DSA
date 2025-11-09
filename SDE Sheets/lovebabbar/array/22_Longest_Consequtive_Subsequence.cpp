#include <bits/stdc++.h>

using namespace std;

int main() {

    // Why Unordered_Set?
    // 1) Insertion -> O(1)
    // 2) Access eleement -> O(1)

    // SOOO...WE JUST WANTED TO STORE AND ACCESS IN BETTER TIME
    // ONLY ANSWER ----> HASH FUNCTION

    // set uses hash func by default

    // SO..For EVERY ELEMENT ONLY 2 steps:
    // Suppose elem = 5

    // 1) If 4 is already in set: 

    // -> It means it has already counted before (3, 4, 5, 6, ...) | OR | It will count after (4, 5, ..)
    // -> Either Way | 5 will be counted

    //**** SOO..IGNORE AND CONTINUE TO NEXT element

    // 2) If 4 is not in set: 

    // -> It means THIS IS STARTING POINTTTT
    // -> SO..START while loop from 5 and check how many after elements are in the set
    // -> Count and update the ANS LENGTH

    vector<int> arr = {100, 4, 200, 1, 3, 2};

    int n = arr.size();
    
    int longest_subsquence = INT_MIN;
    unordered_set<int> set;
    for(int elem: arr) set.insert(elem);

    for(int elem: arr) {
        
        // Suppose elem = 3
        // Basically this says --> IF 3-1 = 2 is in the set
        // Then DEFINETELY -> it has counted before (for 1 -> 1,2,3,4)
        // THIS IS SAVIOUR for -> O(N^2)
        if(!set.count(elem-1)) {

            int cnt = 1;
            while(set.count(elem + cnt)) cnt++;
            longest_subsquence = max(cnt, longest_subsquence);
        }       
        
    }

    cout << longest_subsquence;

    return 0;
}