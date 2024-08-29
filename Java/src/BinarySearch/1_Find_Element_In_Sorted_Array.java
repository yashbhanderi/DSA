package BinarySearch;

import Common.Common;

class FindElementInSortedArray {
    public static void main(String[] args) {
        var arr = new int[] {1,2,3,4,5,6,7,8,9};
        
        int n = arr.length;
        
        int target = 6;
        
        int idx = Common.binarySearch(arr, 0, n-1, target);
        if(idx == -1) System.out.println(-1);
        else System.out.println(idx);
    }
}