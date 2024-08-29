package Arrays;

import java.util.ArrayList;
import java.util.Arrays;

/*

Merge Sort: 

- Divide and Conquer

    [2,4,3,5,1,9,4,8]

[2,4,3,5]       [1,9,4,8]       
    
[2,4][3,5]      [1,9] [4,8]     

[2,3,4,5]       [1,4,8,9]       

    [1,2,3,4,4,5,8,9]
    
    
Steps:

1. Divide till single element or l<r
2. For every time, merge the given array
    - Add into another array to copy sorted elements
 
*/

class ReversePairs {
    public static void main(String[] args) {
        var arr = new int[] {2,4,3,5,1};
        
        int n = arr.length;

        System.out.println(Arrays.toString(arr));
        
        int cnt = mergeSort(arr, 0, n-1);
        
        System.out.println(Arrays.toString(arr));
        System.out.println(cnt);
    }

    public static int countPairs(int[] arr, int low, int mid, int high) {
        int right = mid + 1;
        int cnt = 0;
        for (int i = low; i <= mid; i++) {
            while (right <= high && arr[i] > (long)(2 *(long)arr[right])) right++;
            cnt += (right - (mid + 1));
        }
        return cnt;
    }

    public static int mergeSort(int[] arr, int low, int high) {
        int cnt = 0;
        if (low >= high) return cnt;
        int mid = (low + high) / 2 ;
        cnt += mergeSort(arr, low, mid);  // left half
        cnt += mergeSort(arr, mid + 1, high); // right half
        cnt += countPairs(arr, low, mid, high); //Modification
        merge(arr, low, mid, high);  // merging sorted halves
        return cnt;
    }

    public static void merge(int[] arr, int l, int m, int r) {

        int L = m-l+1;
        int R = r-m;
        int K = L+R;
        int i = 0, j = 0;

        var arrL = new ArrayList<Integer>(L);
        var arrR = new ArrayList<Integer>(R);
        var mergedArray = new ArrayList<Integer>(K);


        for(int p=l; p<=m; p++) {
            arrL.add(arr[p]);
        }
        for(int p=m+1; p<=r; p++) {
            arrR.add(arr[p]);
        }

        while(i<L && j<R) {
            if(arrL.get(i) <= arrR.get(j)) {
                mergedArray.add(arrL.get(i++));
            }
            else {
                mergedArray.add(arrR.get(j++));
            }
        }

        while(i<L) {
            mergedArray.add(arrL.get(i++));
        }

        while(j<R) {
            mergedArray.add(arrR.get(j++));
        }

        for(var e: mergedArray) {
            arr[l++] = e;
        }
    }
}