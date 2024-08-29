package BinarySearch;

/*

Idea is simple!!

- [4,5,6,7,0,1,2,3]
 
 -> If low < mid 
       : All good on left
       : Rotation on right OBV.
       
 -> if low < high
 
        : Array is SORTED.
        : Just return first element (LOW)
 
       
-> CODE:
       while (start<end) {
            if (num[start]<num[end])
                return num[start];
            
            int mid = (start+end)/2;
            
            if (num[mid]>=num[start]) {
                start = mid+1;
            } else {
                end = mid;
            }
        }
        
 
*/

class MinimumElementInRotatedSortedArray {
    public static void main(String[] args) {
        var arr = new int[] {2,1};
        
        int n = arr.length;
        
        int low = 0, high = n-1;
        
        while(low<=high) {
            int mid = low + ((high-low)/2);

            if(arr[low]<=arr[mid] && arr[mid]<=arr[high]) {
                System.out.println(arr[low]);
                return;
            }

            if(arr[low]>=arr[mid] && arr[mid]>=arr[high]) {
                System.out.println(arr[high]);
                return;
            }

            if(mid-1>=0 && arr[mid]<arr[mid-1]) {
                System.out.println(arr[mid]);
                return;
            }
            
            // Left side sorted
            if(arr[low]<arr[mid]) {
                low = mid+1;
            }
            
            // Right side sorted
            else {
                high = mid-1;
            }
        }
    }
}