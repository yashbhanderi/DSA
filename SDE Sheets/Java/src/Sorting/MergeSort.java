package Sorting;

import java.util.ArrayList;
import java.util.Arrays;

class MergeSort {

    public static void mergeSort(int[] arr, int l, int r) {

        if(l<r) {
            int m = l + ((r-l)/2);
            mergeSort(arr, l, m);
            mergeSort(arr, m+1, r);
            merge(arr, l, m, r);
        }

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
    
    public static void main(String[] args) {
        
        var arr = new int[] {0,1,-9};

        int n = arr.length;

        System.out.println(Arrays.toString(arr));

        mergeSort(arr, 0, n-1);

        System.out.println(Arrays.toString(arr));
    }
}