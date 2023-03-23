#include <bits/stdc++.h>

using namespace std;

int main() {

    //? Very simple: Three sum = One pointer + Two Sum

    
    //! REPEAT FOR i = 0 -> N 
    //! -1 | Required Sum = 0 - (-1) = +1
    //! -> [] find PAIR WHOSE SUM ------> +1 in the array

    //* DUPLICATES ??

    //@ RUN the loop -> EVERY i and EVERY FOUND TRIPLET



    vector<int> arr = {-1,0,1,2,-1,-4};

    int n = arr.size();

    sort(arr.begin(), arr.end());

    vector<vector<int>> ans;

    for(int i=0; i<n; i++) {
        int j=i+1, k=n-1;
        int req_sum = 0 - arr[i];
        
        //! Two Sum
        while(j<k) {    
                
            if(arr[j]+arr[k]==req_sum) {
                vector<int> three_sum = {arr[i], arr[j], arr[k]};
                ans.push_back(three_sum);

                //! To remove SAME PAIR
                while(j+1<k && arr[j]==arr[j+1]) j++; 
                while(k-1>j && arr[k]==arr[k-1]) k--;

                j++;
                k--;
            }

            else if(arr[j]+arr[k] < req_sum) j++;
            else k--;
        }

        //! To remove SAME TRIPLET
        while(i+1<n && arr[i]==arr[i+1]) i++;
    }

    for(auto it: ans) {
        for(auto elem: it) cout << elem << " ";
        cout << "\n";
    }

    return 0;
}