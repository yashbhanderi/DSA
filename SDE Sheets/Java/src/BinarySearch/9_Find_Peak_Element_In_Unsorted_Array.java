package BinarySearch;

/*


What is peak element:
For any element: arr[i-1] < arr[i] > arr[i+1]

Here, is a TWIST:

-INF, [, , , , ] ,-INF
 
 Which means, both side, lower element will be there
 
 
--- [1,2,3,4,5,6,9,8]

If mid is eligible -> ANSWER

arr[mid] < arr[mid+1]  ------> ANSWER WILL BE 100% on RIGHT SIDE, LEFT SIDE ALSO POSSIBLE

WHY????

For ex. mid=4

[4,5,9,8]-INF   | Ans = 9
[4,5,8,9]-INF (sorted)  | Ans = 9
[4,9,8,7]-INF (unsorted)  | Ans = 9
 
If any combination can make, there will be always an answer, mainly bcz of -INF

----- AND THIS SAME FOR LEFT SIDE. 
 
*/

class FindPeakElementInArray {
    public static void main(String[] args) {
        var arr = new int[] {1,2,3,4,5,6,9,8};
        
        int n = arr.length;
        
        int low = 0, high = n-1;
        
        if(arr[0] > arr[1]) {
            System.out.println(0);
            return;
        }
        if(arr[n-1] > arr[n-2]) {
            System.out.println(n-1);
            return;
        }
        
        while(low<=high) {
            
            int mid = low + ((high-low)/2);
            
            if(arr[mid]>arr[mid-1] && arr[mid]>arr[mid+1]) {
                System.out.println(mid);
                return;
            }
            
            if(arr[mid] < arr[mid+1]) {
                low = mid;
            }
            else {
                high = mid;
            }
        }
    }
}