package Arrays;

import java.util.HashMap;

/*

Brute Force:

- Traverse two for loops
and take all the subarrays to check sum is equal to K and count them

Complexity: O(n^2)

Optimal:

-> One approach was that, we can use sliding window technique

[ 1,2,3,3,1,4,1,1,1,2,1 ]

Here, we can make window of the size of K
Now, If Window sum == K -> Count++
    If Window sum < K -> Sum += arr[j++]
    If Window sum > K -> Sum -= arr[i++];
    
    BUTTT!!! Here is a problem, What if array contains negative values.
    Now, If sum < K and we are trying to add the next number which is negative
    We'll end up with more lesser value
    
    SOO!! This method only works If there are no negatives!
    
BEST Approach: --> PREFIX SUM <--

        [ 1,    2,      3,      -3,     1,      1,      1,      4,      2,      -3 ]
SUM:   0, 1,    3,      6,       3,     4,      5,      6,      10,     12,      9     
                                                        ^ At this point
                                                        Sum = 6 - K = 3 <- Check how many times 3 came before!
        <----------  3 ----------> | <------- 3 -------->                               
        <-- 3 --> | <-------------  3  ----------------->
        
        Here, what it looks like that, At given point
        - Sum - K, (6-3=3) comes two times
        - Which tells [1,2] & [3,-3,1,1,1] = 3
                    [1,2,3,-3][1,1,1] = 3
            why sum - k checking everytime
            because we want subarray with sum = K, 
            
            Sum = (Sum - K) + K  
            
            Sum till now is made of (sum-K) and K
            At particular point, from 0 to X, we have two values (sum-K) and (K)
            If we want to find whether there is subarray with sum K
            we can check wethere there is subarray with (sum-K) -> It'll auto leads to subarray with sum K
            
            
            So, we can store every element's prefix sum in Hashmap with count 
            If (sum-K) is in the hashmap, we'll add into our answer
            
- What is the need of (0, 1) at the initial level?

=> suppose, 
K = 0 
array = [1, -1, 0]

Now, at -1 => Prefix sum = 0 & K = 0

If we check (sum - K) = (0 - 0) = 0 in hashmap, it'll not will be there && IT MUST need to add into count
Because It is eqaul to to SUM
SO, we have to add one 

 
                 
*/

class SubarraySum { 
    public static void main(String[] args) {
        var arr = new int[] {1,-1,0};
        
        int n = arr.length, K=0, cnt = 0, sum = 0;

        var mp = new HashMap<Integer, Integer>();
        mp.put(0, 1);
        
        for(var e: arr) {
            sum+=e;

            if(mp.containsKey(sum-K)) {
                cnt += mp.get(sum-K);
            }
            
            mp.put(sum, mp.getOrDefault(sum, 0)+1);
        }

        System.out.println(cnt);
    }
}