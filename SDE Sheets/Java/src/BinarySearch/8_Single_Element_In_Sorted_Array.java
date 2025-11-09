package BinarySearch;

/*

[1,1,2,3,3,4,4,8,8]

mid =    ^

[1,1,2,2,3,3,4,4,8]
 
mid =    ^

-> If, mid is not answer -> THEN DUPLICATE CAN BE ON LEFT | RIGHT SIDE

-> IF LEFT : [1,1,2,3,3,4,4,8,8]

    - THEN we have to remove it first, then count 
    
    [1,1,2]
    If ODD -> SINGLE ELEMENT HERE.
    
    [1,1,2,2]
    IF EVEN -> SINGLE ELEMENT ON OTHER SIDE
    
   Here,... SINGLE ELEMENT IS ON LEFT SIDE
   
   So.. High = low - 2 [We've remove both 3,3 from our searching area]
   
 === SAME PROCESS FOR RIGHT SIDE ===
 
 IF EVEN COUNT (other than mid pair) ------> ALL OKAYYYYYY !!
 IF ODD COUNT (other than mid pair)  ------> SINGLE ELEMENT HEREEEE!!!....

*/

class SingleElementInSortedArray {
    public static void main(String[] args) {
        var arr = new int[] {1};
        
        int n = arr.length;
        
        int low = 0, high = n-1;
        
        while(low<=high) {
            int mid = low + ((high-low)/2);

            boolean duplicateOnLeftSide = (mid-1>=0 && arr[mid] == arr[mid-1]);
            boolean duplicateOnRightSide = (mid+1<n && arr[mid] == arr[mid+1]);
            
            if(!duplicateOnLeftSide && !duplicateOnRightSide) {
                System.out.println(arr[mid]);
                return;
            }
            
            if(duplicateOnLeftSide) {
                if((mid-low-1) % 2 == 0) {
                    low = mid+1;
                }
                else {
                    high = mid-2;
                }
            }
            else {
                if((high-mid-1) % 2 == 0) {
                    high = mid-1;
                }
                else {
                    low = mid+2;
                }
            }
            
        }

        System.out.println(arr[low]);
    }
}