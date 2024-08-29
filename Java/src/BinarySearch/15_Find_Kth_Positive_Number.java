package BinarySearch;

/*

Better Solution: O(n)

- Array is sorted, and start from 1

[4,6,7,9], K=2

Here, answer will be 2
Bcz 2<4, 
As number are starting from 1, and we want Kth number from this positive array
2 maybe Kth number, and it is also missing in the array
bcz 2 < arr[0] (array is sorted)

So, 2 will be the answer

Now, we'll do the same for other too.

[4,6,7,9], K=6

we'll count +1, If any number is lesser than or equal to K,

[1,2,3,4,5,6,7,8,9,10], ans = K+2 -> 8

Why directly add into K,

 1,2,3,4,5
[2,3,4,7,11]
 0,1,2,3,4
 
- No. of missing elements at an index = actual - current = arr[i] - (i+1)
    
   Suppose for element = 3,
   It's actual index = 1, but current index = 2 
   
- Now, We'll apply Binary Search based on this logic.

1. Count no. of missing elements at mid
2. If less than K -> low = mid+1
3. If greater than K -> high = mid-1

4. WHATTTTT IFFF ----> It's not found in array
Main logic here...

                                    low, high, mid
                    [2, 3,  4,  7,  11]   
Missing Elements:    1, 1,  1,  3,   6  
 
 - Low = Mid = High at index 4, element = 11, missing = 6 > (K=5)
 But... when we high--
 low <= high <-- BREAKS!!!!
 
 
 - SO, here [2, 3, 4, 7, 11] 
                         low - At this point, If we want Kth missing elements
                         4 elements are already there, plus another K elements before 11
                         SO... low + K
                         bcz, at 11, K = 6
                         Means answer is before 11
                         
- SOOOO -> answer = low + K
*/

class FindKthPositiveNumber {


    public static void main(String[] args) {
        var arr = new int[] {2,3,4,7,11};
        
        /* O(N)
        
        int n = arr.length;

        for(var e: arr) {
            if(e <= k) k++;
            else break;
        }

        return k;
         
        */
            
        int k = 5;
        
        int low = 0, high = arr.length-1;
        
        while(low<=high) {
            int mid = low + ((high-low)/2);

            int missingNumbersFromMid = arr[mid]-(mid+1);

            if(missingNumbersFromMid < k) {
                low = mid+1;
            }

            else {
                high = mid-1;
            }
        }

        System.out.println(low+k);

        System.out.println(low);
    }
}