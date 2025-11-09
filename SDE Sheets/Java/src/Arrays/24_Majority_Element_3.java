package Arrays;

import java.util.ArrayList;

/*

Brute Force: O(n^2)

- Just traverse loop and count the frequency

Better: Time O(N), Space ON)

- We can use hash map
- We can count frequency of element in the map

Best: Space O(1)

- We can use moore voting algorithm
- We can manage two candidate and their voting 

*/

class MajorityElement3 {
    public static void main(String[] args) {
        var arr = new int[] {2,1,1,3,1,4,5,6};
        
        int n = arr.length;
        
        int vote1 = 0, vote2 = 0;
        int candidate1 = Integer.MIN_VALUE, candidate2 = Integer.MIN_VALUE;
        
        for(int i=0; i<n; i++) {
            if(candidate1==arr[i]) {
                vote1++;
            }
            else if(candidate2==arr[i]) {
                vote2++;
            }
            else if(vote1==0) {
                candidate1 = arr[i];
                vote1++;
            }
            else if(vote2==0) {
                candidate2 = arr[i];
                vote2++;
            }
            else {
                vote1--;
                vote2--;
            }
        }
        
        var ans = new ArrayList<Integer>();
        int cnt1 = 0, cnt2 = 0;
        for(var e: arr) {
            if(e==candidate1) cnt1++;
            if(e==candidate2) cnt2++;
        }

        if(cnt1 > n/3) ans.add(candidate1);
        if(cnt2 > n/3) ans.add(candidate2);
            
        System.out.println(ans);
    }
}