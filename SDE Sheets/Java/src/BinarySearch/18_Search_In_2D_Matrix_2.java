package BinarySearch;

/*

- Very simple
- Instead of Binary Search : O(N*LogN)
    We can do this in O(M+N)
        
            
    DECREASE   Here, at 15, Starting Point      
   [1,4,7,11,15]    
   [2,5,8,12,19]        IN
   [3,6,9,16,22]        CR
   [10,13,14,17,24]     EA
   [18,21,23,26,30]     SE
 
 Our, main goal is, 
    If EQUAL    -> Return
    If GREATER  -> GO DOWN  (Row ++)
    If LESSER   -> GO LEFT  (Col --)
 
*/

class SearchIn2DMatrix2 {
    public static void main(String[] args) {
        var arr = new int[][] {{-1, 3}};
        
        int n = arr.length;
        
        int target = 13;
        
        int row = 0, col = arr[0].length-1;
        while(row<n && col>=0) {
            if(target == arr[row][col]) {
                System.out.println(row+" "+col);
                return;
            }
            else if(target < arr[row][col]) {
                col--;
            }
            else {
                row++;
            }
        }
    }
}