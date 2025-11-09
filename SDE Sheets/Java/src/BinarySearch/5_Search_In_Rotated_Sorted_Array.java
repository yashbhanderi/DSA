package BinarySearch;

/*

[4,5,6,7,0,1,2]

- Here, main problem is we can't apply normal binary search since array is not sorted.

- So, we have to somehow decide how much area on we want to apply binary search.

Ex. [4,5,6,7,0,1,2], target = 2

        mid = 7
 
-> Normal Binary Search:

    - 2 is less than 7, then it'll obv on LEFT
    - But, it'll not. Since array is not sorted. We don't know elements on the right side of
    mid are guaranteed BIGGER and left side are SMALLER
    
-> Rotated Binary Search:

    - WE'LL GO ON THE SIDE WHICH IS SORTED ONE ONLY.
    
    - How do we decide, which side is sorted?
    
    Just check with arr[low]
    
    Ex. [4,5,6,7,0,1,2], mid = 7
    
    if 4<=7 -> Sorted on LEFT SIDE
    
    Ex. [5,6,7,0,1,2,4], mid = 0
    
    if 5<=0 -> Sorted on RIGHT SIDE
 
 - By checking in only sorted part, we're ensuring a 100% Binary search efficiency. 
 
*/

class SearchInRotatedSortedArray {
    public static void main(String[] args) {
        var arr = new int[] {1,0,1,1,1};
        var target = 0;
        
        int n = arr.length;
        int low = 0, high = n-1;
        
        while(low<=high) {
            
            int mid = low + ((high-low)/2);
            
            if(arr[mid]==target) {
                System.out.println(mid);
                return;
            }
            
            // Left half sorted
            if(arr[low] <= arr[mid]) {
                
                if(arr[low] <= target && target <= arr[mid]) {
                    high = mid-1;
                }
                else {
                    low = mid+1;
                }
                
            }
            // Right half sorted
            else {
                
                if(arr[mid] <= target && target <= arr[high]) {
                    low = mid+1;
                }
                else {
                    high = mid-1;
                }
                
            }

        }
        
        System.out.println(-1);
    }
}