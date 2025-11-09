// https://leetcode.com/problems/maximum-subarray/description/

package Arrays;

/*

- Idea is simple
- [-2,1,-3,4,-1,2,1,-5,4]

- Here, we have to find maximum subarray
- If somehow we can neglact negative answer and zero, our problem will become easier
- We'll have two variable
1. curr_max (maintain sum of current pointing element in array)
2. max_so_far (maintain final answer which is maximum sum subarray) 

1) Every element, we'll add into curr_max
2) If curr_max > max_so_far = Update max_so_far with curr_max
3) If curr_max < 0 (Here, it'll handle both nagative and zero sum)
    then curr_max = 0
    WHY?
    Bcz it's showing we've start with 0 and now we're even less than that
    which means sum of elements till now, HAS NOTHING BENIFIT TO ADD INTO FINAL SUM
    Because they are worthless!!
    
    NOW, what if they all are negative 
    
    THEN, we already have 2nd step -> They'll come to know if they're answer
     
    So, we'll set curr_max = 0 
*/

class MaximumSubarray {
    public static void main(String[] args) {
        
        var arr = new int[] {-2,1,-3,4,-1,2,1,-5,4};
        int n = arr.length;
        
        int max_so_far = Integer.MIN_VALUE, curr_max = 0;
        int curr_start_index = 0;
        int start_index = 0, end_index = n-1;
        
        for(int i=0; i<n; i++) {
            
            curr_max += arr[i];
            
            if(curr_max > max_so_far) {
                max_so_far = curr_max;
                start_index = curr_start_index;
                end_index = i;
            }
            
            if(curr_max < 0) {
                curr_max = 0;
                curr_start_index = i+1;
            }
        }

        // Length of Maximum Subarray Sum
        System.out.println(max_so_far);
        
        // Elements of Maximum Subarray Sum
        for(int i=start_index; i<=end_index; i++) System.out.print(arr[i]+" ");
    }
}
