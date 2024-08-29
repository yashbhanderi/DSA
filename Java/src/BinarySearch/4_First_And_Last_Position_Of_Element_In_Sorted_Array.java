package BinarySearch;

import Common.Common;

import java.util.Arrays;

class FirstAndLastPositionOfElement {
    public static void main(String[] args) {
        var arr = new int[] {5,7,7,8,8,10};
        
        int n = arr.length-1, target = 8;
        
        int lowerBound = Common.lowerBound(arr, 0, n, target);

        if (lowerBound < 0 || lowerBound >= arr.length) {
            System.out.println(Arrays.toString(new int[]{-1, -1}));
        }

        if(arr[lowerBound] == target) {
            int upperBound = Common.upperBound(arr, 0, n, target);

            if(!(upperBound == n && arr[upperBound]==target)) upperBound--;

            System.out.println(Arrays.toString(new int[]{lowerBound, upperBound}));
        }
        else System.out.println(Arrays.toString(new int[]{-1, -1}));
    }
}