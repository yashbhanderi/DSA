#include<bits/stdc++.h>
 
using namespace std;
 
int main() {
 
        int N = 14;

        int num = (int)(log2(N));

        int binary = bitset<64>(N).to_string().substr(64 - num
                                                  - 1);
        string arr = to_string(binary);
        cout << num << " " << arr;
        
        int ans = 0;
        int i = 0, n = arr.size(); 

        while(i<n) {
            int cnt = 0;
            while(i<n && arr[i]==1) {
                cnt++;
                i++;
            }
            i++;
            ans = max(ans, cnt);
        }

        return ans;
 
   return 0;
}