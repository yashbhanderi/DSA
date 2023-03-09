#include<bits/stdc++.h>
 
using namespace std;

int getMinDiff(vector<int> arr, int n, int k) {
        // code here
        
        map<int, bool> mp;

        for(int i=0; i<n; i++) {
            if(arr[i]-k < 0) {
                arr[i] += k;
                mp[arr[i]] = 1;
            }
            else mp[arr[i]] = 0;
        }

        auto startPointer = mp.begin();
        auto endPointer = prev(mp.end(), 1);
        int x,y;

        if(startPointer->second!=1) x = startPointer->first + k;
        if(endPointer->second!=1) y = endPointer->first - k;

        return max(x,y) - min(x, y);
    }
 
int main() {
    
    vector<int> arr = {1,3,5,10};
    int n = arr.size();

    cout << getMinDiff(arr, n, 2);
    
    return 0;
}