#include<bits/stdc++.h>
 
using namespace std;

pair<int, int> res {INT_MIN, INT_MAX};

pair<int, int> findMaxMin(vector<int> vi, int start, int end) {

    if(end-start==1) {
        int _max = max(vi[start], vi[end]);
        int _min = min(vi[start], vi[end]);
        res.first = max(res.first, _max);
        res.second = min(res.second, _min);
        return res;
    }

    int mid = start + ((end-start)/2);
    res = findMaxMin(vi, start, mid);
    res = findMaxMin(vi, mid, end);

    return res;
}

int main() {
 
   vector<int> vi = {3,2,1,2,5,8,0};

    // 1) : Linear Search
    // Just check and maintain two variable max and min by comparing every elements
    // Time: O(n)

    // 2) : Tournament Method
    // Divide in half...Check both side's max and min and compare them
    

    // pair<int, int> ans = findMaxMin(vi, 0, vi.size()-1);

    // cout << ans.first << " " << ans.second << endl;


    // Space: O(logn)

    // 3) : Compare in pairs
    // Check every elements pair wise
    // So It takes equal time as second method
    // Total half comparison than linear method

   return 0;
}