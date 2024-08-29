package BinarySearch;

import java.util.Arrays;
import java.util.Scanner;

/*

- Idea is simple

- we just have to maintain a proper distance between two stalls

- So first we'll sort the array
then, from first element to largest element in given array,
we'll apply binary search

    - For every mid
    
    - We'll check If it is possible to put cows at proper distance
    - If yes, then low = mid+1
    BCZ, we want largest distance possible
 
*/

class AggressiveCows {
    
    public static boolean isMinimalDistance(int arr[], int dist, int cows) {
        int n = arr.length;
        
        int i=1, prev = arr[0], cnt = 1;
        while(i<n) {
            int diff = arr[i] - prev;
            
            if(diff >= dist) {
                prev = arr[i];
                cnt++;
            }
            
            i++;
        }
        
        return cnt >= cows;
    }
    
    public static void main(String[] args) {
        
        var sc = new Scanner(System.in);
        int tcs = sc.nextInt();
        
        while (tcs-- >= 0) {
            
            int n = sc.nextInt();
            int cows = sc.nextInt();
            
            var arr = new int[n];
            
            for(int i=0; i<n; i++) {
                arr[i] = sc.nextInt();
            }

            int low = 0, high = Arrays.stream(arr).max().getAsInt();

            while (low <= high) {
                int mid = low + ((high - low) / 2);

                if (isMinimalDistance(arr, mid, cows)) {
                    low = mid + 1;
                } else {
                    high = mid - 1;
                }
            }

            System.out.println(high);
        }
    }
}