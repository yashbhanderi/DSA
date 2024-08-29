package Arrays;

import java.util.Arrays;

/*

-- Brute : SPACE O(M*N)

-> we can traverse through every element of the array
-> If current element is zero -> for every element, we will check for all the matrix to mark the row and column as zero. 

-- Better : SPACE O(M + N)

-> We can create set or map to mark the zero valued row and columns
-> now, if current element's row or column any one value is contain in set or map -> Then make that element value to ZERO!!!

-- BEST : Space O(1)

-- We can set first row and first column as a flag to check If that row or column contains any zero or not.


*/

class SetMatrixZeroes {
    public static void main(String[] args) {
        var arr = new int[][] 
//                {{0,1,2,0},{3,4,5,2},{1,3,1,5}};
         {{1,2,3,4},{5,0,7,8},{0,10,11,12},{13,14,15,0}};
        
        int n = arr.length;
        
        /* Method 2: Space O(M + N)
        
        var row = new HashSet<Integer>();
        var col = new HashSet<Integer>();
        
        for(int i=0; i<n; i++) {
            for(int j=0; j<arr[i].length; j++) {
                if(arr[i][j]==0) {
                    row.add(i);
                    col.add(j);
                }
            }
        }
        
        for(int i=0; i<arr.length; i++) {
            for(int j=0; j<arr[i].length; j++) {
                if(row.contains(i) || col.contains(j)) arr[i][j]=0;
            }
        }
        
        
        */
        
        /*
       
        Method 3: Space O(1)
        
        
        
        */
        
        boolean row = false, col = false;
        
        for(int i=0; i<n; i++) {
            for(int j=0; j<arr[i].length; j++) {
                if(arr[i][j]==0) {
                    if(i==0) row = true;
                    if(j==0) col = true;
                    arr[i][0] = 0;
                    arr[0][j] = 0;
                }
            }
        }
        
        for(int i=1; i<n; i++) {
            for(int j=1; j<arr[i].length; j++) {
                if(arr[i][0]==0 || arr[0][j]==0) {
                    arr[i][j]=0;
                }
            }
        }
        

        if(row) {
            for(int j=0; j<arr[0].length; j++) {
                arr[0][j] = 0;
            }
        }

        if(col) {
            for(int i=0; i<n; i++) {
                arr[i][0] = 0;
            }
        }
        
        for(var e: arr) {
            System.out.println(Arrays.toString(e));
        }
    }
}