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
 
 
-- IN CASE OF DUPLICATES

-> We just need to check only one corner case scenario
where, low, mid, high ALL ARE EQUAL
In this case, we can't be able to know where should we go.
In all the other cases, we can able to identify whether we should check LEFT OR RIGHT.

----> SO, For [low = mid = high]
----> We'll update low++, high-- [So, that we can just ignore both the duplicates and narrow down our search]

- WORST CASE TIME: O(n/2) [In case, 3,3,3,3,2,3,3,3,3,3]

- AVERAGE TIME: O(logn) [After getting rid of duplicates at ALL 3 PLACES......]

*/

class SearchInRotatedSortedArrayWithDuplicates {
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

            // incase of duplicates at both side 
            // [3, ..., 3(mid), ..., 3]
            else if(arr[low]==arr[mid] && arr[mid]==arr[high]) {
                low++;
                high--;
            }
            
            // Left half sorted
            else if(arr[low] <= arr[mid]) {
                
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