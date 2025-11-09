// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/

/*

[7,1,5,3,6,4]

Here, we can buy on any one day
and can sell in future.

- WHICH MEANS we have to buy in CHEAPEST COST, sell at COSTLIEST 

-- What we need?

- we need to maintain lowest price of the stock till current index
- so that we can calculate the profit If we sell the stock at current index price

-- What we will do?

- During traversal, we'll maintaining one variable which contains smallest element till now
- We'll maintain one variable which contains MAX profit (curr - smallest) 

*/

package Arrays;

class StockBuyAndSell {
    public static void main(String[] args) {
        var arr = new int[] {7,1,5,3,6,4};
        
        int n = arr.length;
        
        // APPROACH 1
        
        var max_so_far = new int[n];
        var min_so_far = new int[n];
        max_so_far[n-1] = Integer.MIN_VALUE;
        min_so_far[0] = Integer.MAX_VALUE;
    
        for(int i=0, j=n-1; i<n && j>=0; i++, j--) {
            if(i==0) min_so_far[i] = Math.min(min_so_far[i], arr[i]);
            else min_so_far[i] = Math.min(min_so_far[i-1], arr[i]);
            
            if(j==n-1) max_so_far[j] = Math.max(max_so_far[j], arr[j]);
            else max_so_far[j] = Math.max(max_so_far[j+1], arr[j]);
        }
        
        int ans = -1;
        
        for(int i=0; i<n; i++) {
            ans = Math.max(ans, max_so_far[i]-min_so_far[i]);
        }

        System.out.println(ans);
        
        
        // APPROACH 2
        
        // Simpler
        
        var buy = Integer.MAX_VALUE;
        var sell = Integer.MIN_VALUE;
        
        for(int i=0; i<n; i++) {
            buy = Math.min(buy, arr[i]);
            sell = Math.max(sell, arr[i] - buy);
        }

        System.out.println(sell);
    }
}