#include<bits/stdc++.h>
 
using namespace std;
 
int main() {

    // dutch national flag algorithm

    // Here, We are keeping theee pointer on array
    // low, mid, high
    // [start->low] = 0
    // [high->end] = 2
    // middle = 1

    // only 3 points to remember
    // 1) If 2 -> swap with high pointer and high--
    // 2) If 0 -> swap with low and low++, curr++ <- curr is because INDEX GOT HIS RIGHT ELEMENT
                                                    // So just get over
    // 3) If 1 -> curr++  <- bcz we've maintained position for 0(low) and2(high).. 
                            // So 1 will be automatically keep in right position

    // 1 0 2 2 1 0
    // ^         ^
    // L         H
    // M

    // Mid != 0 || 2
    // Mid++

    // 1 0 2 2 1 0
    // ^ ^       ^
    // L M       H

    // Mid == 0
    // Swap Low and Mid
    // Mid++
    // Low++

    // 0 1 2 2 1 0
    //   ^ ^     ^
    //   L M     H

    // Mid == 2
    // Swap High and Mid
    // High--

    // 0 1 0 2 1 2
    //   ^ ^   ^
    //   L M   H

    // Mid == 0
    // Swap Low and Mid
    // Mid++
    // Low++

    // 0 0 1 2 1 2
    //     ^ ^ ^
    //     L M H

    // Mid == 2
    // Swap High and Mid
    // High--

    // 0 0 1 1 2 2
    //     ^ ^
    //     L M
    //       H

    // Mid <= High is our exit case
 
   vector<int> a = {2, 0, 1};
   int n = a.size();

    int low = 0, high = n-1, curr = 0;

    while(curr<=high) {     // curr==high is valid bczzz...there may be possible 
                            // to have 0 on curr==high ..like in these case (2, 0, 1)   
                            // In 2nd step: (1,  0,  2)
                            //               L  M,H
        if(a[curr]==2) {
            swap(a[curr], a[high]);
            high--;
        }

        else if(a[curr]==0) {
            swap(a[curr], a[low]);
            low++;
            curr++;
        }
        else {
            curr++;
        }
    }

    for(auto i: a) {
        cout << i << " ";
    }
 
   return 0;
}