#include <bits/stdc++.h>

using namespace std;

// -> base condition
// think of smallest valid values among input
// n = 0 , weight = 0
// then both cases -> profit = 0...So return 0

// -> Choice Diagram
//              item weight
//                  |
//   item_W <= W            item_W > W
//  Taken  |  Not Taken         Not Taken

int Knapsack(vector<int> val, vector<int> wt, int W, int n) {
    // Recursion basic steps
    
    // base condition
    if (n == 0 || W == 0) return 0;

    // choice diagram

    if (wt[n - 1] <= W) {
        return max(val[n - 1] + Knapsack(val, wt, W - wt[n - 1], n - 1),  // Taken 👌
                   Knapsack(val, wt, W, n - 1));                          // Not Taken ❌
    }

    else if (wt[n - 1] > W) {                       // Weight is more than W
               return Knapsack(val, wt, W, n-1);    // Not Taken ❌
    }

}

int main() {
    vector<int> val = {60, 100, 120};
    vector<int> wt = {10, 20, 30};
    int W = 50;
    int n = 3;

    cout << Knapsack(val, wt, W, n);

    return 0;
}