package StackQueue;

import java.util.HashMap;
import java.util.Stack;

class TrappingRainWater {
    public static int[] prevGreaterElement(int[] arr) {
        int n = arr.length;
        
        var prevGreatest = new int[n];
        prevGreatest[0] = 0;    
        var curr = -1;
        
        for(int i=1; i<n; i++) {
            curr = Math.max(curr, arr[i-1]);
            prevGreatest[i] = curr;
        }

        return prevGreatest;
    }

    public static int[] nextGreatestElement(int[] arr) {
        int n = arr.length;

        var nextGreatest = new int[n];
        nextGreatest[n-1] = 0;
        var curr = -1;

        for(int i=n-2; i>=0; i--) {
            curr = Math.max(curr, arr[i+1]);
            nextGreatest[i] = curr;
        }

        return nextGreatest;
    }

    public static void main(String[] args) {
        var arr = new int[]{0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};

        var ans = prevGreaterElement(arr);
        var ans1 = nextGreatestElement(arr);

        int trappingWater = 0;

        for (int i = 0; i < arr.length; i++) {
            trappingWater += Math.max(Math.min(ans[i], ans1[i]) - arr[i], 0);
        }
//
//        for (var e : ans) 
//            System.out.print(e + " ");

//        System.out.println();
            System.out.println(trappingWater);
    }
}