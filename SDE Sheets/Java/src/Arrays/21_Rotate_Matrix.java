package Arrays;
import java.util.Arrays;

/*

Standard method to Rotate the matrix:

-> Clockwise 90 Degree

Reverse Up to Down -> Swap the symmetry

    1 2 3     7 8 9     7 4 1
    4 5 6  => 4 5 6  => 8 5 2
    7 8 9     1 2 3     9 6 3

-> Anti-clockwise 90 Degree

Reverse Left to Right -> Swap the symmetry

    1 2 3     3 2 1     3 6 9
    4 5 6  => 6 5 4  => 2 5 8
    7 8 9     9 8 7     1 4 7

*/

class RotateMatix {
    public static void main(String[] args) {
        
        var arr = new int[][] {{1,2,3}, {4,5,6}, {7,8,9}};
        
        int n = arr.length;

        for(int k=0; k<n/2; k++) {
            for(int i=0; i<n; i++) {
                int temp = arr[k][i];
                arr[k][i] = arr[n-k-1][i];
                arr[n-k-1][i] = temp;
            }
        }

        for(var e: arr) {
            System.out.println(Arrays.toString(e));
        }
        System.out.println();
        
        for(int i=0; i<n; i++) {
            for(int j=i; j<n; j++) {
                int temp = arr[i][j];
                arr[i][j] = arr[j][i];
                arr[j][i] = temp;
            }
        }
        
        for(var e: arr) {
            System.out.println(Arrays.toString(e));
        }
    }
}