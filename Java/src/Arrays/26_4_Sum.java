package Arrays;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class FourSum {
    public static void main(String[] args) {

        var arr = new int[] {1000000000,1000000000,1000000000,1000000000};

        int n = arr.length, target = -294967296;

        Arrays.sort(arr);

        List<List<Integer>> ans = new ArrayList<>();

        Arrays.sort(arr);
        
        for(int p=0; p<n-3; p++) {

            if(p>0 && arr[p]==arr[p-1]) continue;
        
            for(int i=p+1; i<n-2; i++) {

                if(i-1>p && arr[i]==arr[i-1]) continue;
                
                int j=i+1, k=n-1;
    
                while(j<k) {
    
                    long sum = (long) ((long)arr[i]+(long)arr[j]+(long)arr[k]+(long)arr[p]);
    
                    if(sum == target) {
                        ans.add(Arrays.asList(arr[p], arr[i], arr[j], arr[k]));
    
                        while(j<k && arr[j]==arr[j+1]) j++;
                        while(j<k && arr[k]==arr[k-1]) k--;
    
                        j++;
                        k--;
                    }
                    else if(sum < target) j++;
                    else k--;
                }
            }
        }

        for(var e: ans) {
            System.out.println(e);
        }
        
    }
}