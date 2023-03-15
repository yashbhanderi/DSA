#include <bits/stdc++.h>

using namespace std;

int main() {

    // ***************** Easy: [ONE TRANSACTION ONLY]

    // --------> {7,1,5,3,6,4}
    // Buy: 1, Sell: 6
    
    // Approach:

    // We just have to 👉 UPDATE MINIMUM BUYING PRICE EVERYDAY | 👉 Update PROFIT 
    // BCZ... We CAN SELL ONLY IN FUTURE
    // SO... SUPPOSE { 2, 9 } THEN {1, 13} <--- We'll Update our PROFIT

    // int min_buy_price = INT_MAX, max_profit = INT_MIN;

    // for(int i=0; i<n; i++) {
    //     min_buy_price = min(min_buy_price, arr[i]);
    //     max_profit = max(max_profit, arr[i]-min_buy_price);
    // }

    // *****************  Medium: [Multiple Transaction]
    // I can buy and sell multiple times
    // I can buy same stock on selling day <-----👌

    // 👉 Problems:
    // 1) Should I buy here and sell next some value,and buy again 
    // 2) should I wait for more bigger element, so that profit can be maximum. 
    
    // 👉 Solution:
    // 1) IF MINIMUM TRANSACTION: WAIT FOR BIGGER ELEMENT
    // 2) IF MAXIMUM PROFITL: BUY AND SELL MAXIMUM POSSIBLE TIMES
    
    // Approach:
    // 👉 GRRRRREEEEDDDDYYYYY | Buy and Sell every possible 
    // BCZ -----> [1, ...., 8] <-- There's 110% SURE => Buy and sell again PROFIT > (8-1)
    // Bcz WORST CASE [1, 2, 3, 4, 5, 6, 7, 8] <--- All big by 1 
    // BUUUTTT SINCE WE CAN BUY ON SAME SELLING DAY ----> SUM = 7 <----> [1-8]

    // SO... 👉 Updating MIN_BUY_PRICE EVERYDAY 
    // PROFIT <--- MIN_BUY_PRICE - NEXT_BIG_ELEMENT

    // 👉 CODE:

    // int min_buy_price = INT_MAX, profit = 0;

    // for(int i=0; i<n; i++) {
    //     min_buy_price = min(min_buy_price, arr[i]);

    //     if(arr[i] > min_buy_price) {
    //         profit += arr[i]-min_buy_price;
    //         min_buy_price = arr[i];
    //     }
    // }   

    vector<int> arr = {7,6,4,3,1};

    int n = arr.size();

    int min_buy_price = INT_MAX, profit = 0;

    for(int i=0; i<n; i++) {
        min_buy_price = min(min_buy_price, arr[i]);

        if(arr[i] > min_buy_price) {
            profit += arr[i]-min_buy_price;
            min_buy_price = arr[i];
        }
    }   

    cout << profit;

    return 0;
}