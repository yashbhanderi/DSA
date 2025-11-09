// https://leetcode.com/problems/two-sum/description/

package Arrays;
import java.util.Arrays;
import java.util.HashMap;

class TwoSum {

    public static int binarySearch(int[] arr, int low, int high, int key) {
        
        while(low <= high) {

            int mid = low + ((high-low)/2);

            if(arr[mid]==key) return mid;

            else if(arr[mid] > key) high = mid-1;

            else low = mid+1;
        }

        return -1;
    }

    public static void main(String[] args) {

        var arr = new int[] { 2, 7, 11, 15 };
        int n = arr.length, target = 17;

        // Method 1: Sort & Binary Search

        Arrays.sort(arr);

        for(int i=0; i<n-1; i++) {
            int K = target - arr[i];

            int ans = binarySearch(arr, i+1, n-1, K);

            if(ans != -1) {
                System.out.println(i+", "+ans);
                break;
            }
        }

        // Method 2: Hashing

        var mp = new HashMap<Integer, Integer>();

        for(int i=0; i<n; i++) {
            int K = target - arr[i];

            if(mp.containsKey(K)) {
                System.out.println(new int[] {arr[i], mp.get(K)});
                break;
            }

            mp.put(arr[i], i);
        }


    }

}