package BinarySearch;

import java.util.Arrays;

/*

* Simple approach:

Min answer = 1, Max answer = Max element of array

Koko can eat that count of banana every hour.

Now, we want to find minimum solution.
SO we'll apply BINARY SEARCH between [1, Max]

for every element, we'll check whether it is possible to eat all the bananas
If she take mid as a speed (banana per hour)
 
*/

class KokoEatingBananas {
    
    public static boolean canEatInTime(int[] arr, int cnt, int H) {
        if(cnt==0) return false;
        
        int hours = 0;
        
        for(var e: arr) {
            
            if(e < cnt) hours++;
            
            else {
                hours +=  (e/cnt) + ((e%cnt)==0 ? 0 : 1);
            }
        }
        
        return hours <= H;
    }
    
    public static void main(String[] args) {
        var arr = new int[] {3,6,7,11};
        
        int H = 8;
        
        int n = arr.length;

        int maxElement = Arrays.stream(arr).max().getAsInt();
     
        int low = 0, high = maxElement;
        
        while(low <= high) {
            int mid = low + ((high-low)/2);
            
            if(canEatInTime(arr, mid, H)) {
                high = mid-1;
            }
            else {
                low = mid+1;
            }
        }

        System.out.println(low);
    }
}