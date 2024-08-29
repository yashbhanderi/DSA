package Arrays;

import java.util.*;

class SpiralMatrix {
    public static void main(String[] args) {
        var arr = new int[][] 
//                {{1,2,3}, {4,5,6}, {7,8,9}};
                {{1,2,3,4}, {5,6,7,8}, {9,10,11,12}};
//                {{1,2,3,4,5}, {6,7,8,9,10}, {11,12,13,14,15}, {16,17,18,19,20}, {21,22,23,24,25}};
        
        int m = arr.length, n = arr[0].length;
        
        int row_start = 0, col_start = 0, row_end = m-1, col_end = n-1, total = n*m, i = 0, j = 0;
        char state = 'R';
        var set = new ArrayList<Integer>();
        
        while(set.size() < total)  {
            if(state=='R') {
                i = col_start;
                while(i<=col_end) {
                    set.add(arr[row_start][i]);
                    i++;
                }
                row_start++;
                state = 'D';
            }
            else if(state=='D') {
                i = row_start;
                while(i<=row_end) {
                    set.add(arr[i][col_end]);
                    i++;
                }
                col_end--;
                state='L';
            }
            else if(state=='L') {
                i = col_end;
                while(i >= col_start) {
                    set.add(arr[row_end][i]);
                    i--;
                }
                row_end--;
                state = 'U';
            }
            if(state=='U') {
                i = row_end;
                while(i >= row_start) {
                    set.add(arr[i][col_start]);
                    i--;
                }
                col_start++;
                state='R';
            }
        }
        
        var list = new ArrayList<Integer>(set);
        System.out.println(list);
    }
}