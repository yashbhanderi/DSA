package BinarySearch;

/*

What is Upper Bound?

- Returns an index of element which is NEXT GREATER than the target element in the array
- If not found, return length of the array (length + 1, as we want index)

Ex. [1, 3, 3, 4, 5, 6, 9], target = 3
Answer = 3 (element 4)
 
*/

class UpperBound {
    
    public static int upperBound(int[] arr, int l, int r, int target) {
        
        while(l < r) {
            
            int mid = l + ((r-l)/2);
            
            if(arr[mid] > target)
                r = mid;
            
            else 
                l = mid+1;
        }
        
        return l;
    }
    
    public static void main(String[] args) {
        var arr = new int[] {5,7,7,8,8,10};
        
        int n = arr.length;

        int upper_bound = upperBound(arr, 0, n-1, 8);

        System.out.println(upper_bound);
    }
}