package Arrays;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/*

Brute: O(N^3)

- First sort the array
- Run 3 loop to check every possible 3 element array to make sum = 0

Better: O(N^2)

- First sort the array
- Run 2 loop and inside second loop, run binary search algorithm to find out 3 element array
- Add array into Hashset to remove duplication

Best: O(N^2)

- First sort the array
- Run 2 loop
- Inside of first loop, use Two pointer algorithm  
- If element found, add into ans array
- And after that, increase and decrease pointer on both side to get rid of duplicate elements
 
*/

class ThreeSum {
    public static void main(String[] args) {
        var arr = new int[] {0,0,0};
        
        int n = arr.length;

        Arrays.sort(arr);
        
        /*
        var ans = new HashSet<List<Integer>>();
        
        for(int i=0; i<n-2; i++) {
            for(int j=i+1; j<n-1; j++) {
                int target = 0 - (arr[i] + arr[j]);
                
                int idx = Common.BinarySearch(arr, j+1, n-1, target);
                
                if(idx != -1) {
                    var list = new ArrayList<Integer>();
                    list.add(arr[i]);
                    list.add(arr[j]);
                    list.add(arr[idx]);
                    ans.add(list);
                }
            }
        }
        
        List<List<Integer>> lst = new ArrayList<>(ans);
        
        */

        List<List<Integer>> ans = new ArrayList<>();

        Arrays.sort(arr);

        for(int i=0; i<arr.length-2; i++) {

            if(i>0 && arr[i]==arr[i-1]) continue;

            int j=i+1, k=arr.length-1;

            while(j<k) {

                int sum = arr[i]+arr[j]+arr[k];

                if(sum == 0) {
                    ans.add(Arrays.asList(arr[i], arr[j], arr[k]));

                    while(j<k && arr[j]==arr[j+1]) j++;
                    while(j<k && arr[k]==arr[k-1]) k--;

                    j++;
                    k--;
                }
                else if(sum < 0) j++;
                else k--;
            }
        }
        
        for(var e: ans) {
            System.out.println(e);
        }
    }
}