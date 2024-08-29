package Arrays;

import java.util.ArrayList;
import java.util.List;

class PascalTriangle {
    public static void main(String[] args) {
        
        int n = 5;
        
        var arr = new int[n][n];
        List<List<Integer>> list = new ArrayList<>();
        
        
        for(int i=0; i<n; i++) {
            var sublist = new ArrayList<Integer>();
            for(int j = 0; j<=i; j++) {
                if(j==0 || j==i) {
                    arr[i][j]=1;
                    sublist.add(1);
                }
                else {
                    arr[i][j] = arr[i-1][j] + arr[i-1][j-1];
                    sublist.add(arr[i][j]);
                }
            }
            list.add(sublist);
        }
        
        for(var e: list) {
            System.out.println(e);
        }
    }
    
}