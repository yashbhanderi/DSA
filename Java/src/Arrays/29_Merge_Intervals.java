package Arrays;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class MergeIntervals {
    public static void main(String[] args) {
        var arr = new int[][] {{1,3},{2,6},{8,10},{15,18}};

        Arrays.sort(arr, (a, b) -> a[0] - b[0]);
        
        int n = arr.length, first = arr[0][0], second = arr[0][1], cnt = 0;
        List<List<Integer>> ans = new ArrayList<>();
        
        for(int i=1; i<n; i++) {
            if(arr[i][0] <= second) {
                second = Math.max(arr[i][1], second); 
            }
            else {
                var list = new ArrayList<Integer>();
                list.add(first);
                list.add(second);
                ans.add(list);
                first = arr[i][0];
                second = arr[i][1];
            }
        }

        var array = new int[ans.size()][2];

        for(int i=0; i<ans.size(); i++) {
            array[i][0] = ans.get(i).get(0);
            array[i][1] = ans.get(i).get(1);
        }
    }
}