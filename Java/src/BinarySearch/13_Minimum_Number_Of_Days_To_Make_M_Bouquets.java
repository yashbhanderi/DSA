package BinarySearch;

import java.util.Arrays;

class MinimumNumberOfDaysToMakeMBouquets {

    public static boolean canMakeBouquests(int[] arr, int days, int bouguests, int adj) {
        
        int i = 0, n = arr.length, cnt = 0;
        
        while(i<n) {
            int COUNT = 0;
            while(i<n && arr[i]<=days && COUNT<adj) {
                i++;
                COUNT++;
            }
            
            if(i<n && arr[i]>days)
                i++;
            
            cnt += COUNT==adj ? 1 : 0;
        }
        
        return cnt >= bouguests;
    }
    
    public static void main(String[] args) {
        var arr = new int[] {7,7,7,7,12,7,7};
        
        int m = 2, k = 3;
        
        int n = arr.length;

        int low = 0, high = Arrays.stream(arr).max().getAsInt();

        while(low <= high) {
            int mid = low + ((high-low)/2);

            if(canMakeBouquests(arr, mid, m, k)) {
                high = mid-1;
            }
            else {
                low = mid+1;
            }
        }

        System.out.println(low);
    }
}