package BinarySearch;

import java.util.Arrays;

class SmallestDivisorGivenThreshold {

    public static boolean isSmallestDivisor(int[] arr, int divisor, int threshold) {

        long sum = 0;

        for(var e: arr) {
            sum += (int)Math.ceil((double) e /divisor);
        }

        return sum <= threshold;
    }
    
    public static void main(String[] args) {
        var arr = new int[] {44,22,33,11,1};
            
        int threshold = 5;
        
        int n = arr.length;

        int low = 0, high = Arrays.stream(arr).max().getAsInt();

        while(low <= high) {
            int mid = low + ((high-low)/2);

            if(isSmallestDivisor(arr, mid, threshold)) {
                high = mid-1;
            }
            else {
                low = mid+1;
            }
        }

        System.out.println(low);
    }
}