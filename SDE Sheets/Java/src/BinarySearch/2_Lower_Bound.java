package BinarySearch;

/*

What is lower bound?

- Return an index to a element which is equal to or next greater than given element
- If given target exists multiple times, or next greater element exists multiple times
return smallest index of it.

ex. [5,7,7,7,8,9], target = 7
Answer = 1
 
ex. [5,7,7,7,9,9], target = 8
Answer = 4
*/

class LowerBound {

    public static int lowerBound(int arr[], int l, int r, int target) {

        while(l<r) {
            int mid = l + ((r-l)/2);

            if(arr[mid] < target)
                l = mid+1;

            else
                r = mid;
        }

        if(l < arr.length && target > arr[l]) {
            l++;
        }

        return l;
    }
    
    public static void main(String[] args) {
        var arr = new int[] {1, 2, 3, 3, 4};
        
        int n = arr.length;
        
        int lower_bound = lowerBound(arr, 0, n-1, 2);

        System.out.println(lower_bound);
    }
}