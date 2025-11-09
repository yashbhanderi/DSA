package StackQueue;

import java.util.Stack;

class SumOfSubArrayMinimums {
    
    public static int[] getPLE(int[] arr) {
        int n = arr.length;
        
        var stack = new Stack<Integer>();
        var ple = new int[n];
        
        for(int i=0; i<n; i++) {
            var temp = new Stack<Integer>();
            while(!stack.empty() && arr[i] < arr[stack.peek()]) {
                temp.push(stack.pop());
            }
            ple[i] = !stack.empty() ? stack.peek() : -1;
            stack.push(i);
        }
        
        return ple;
    }
    
    public static int[] getNLE(int[] arr) {
        int n = arr.length;

        var stack = new Stack<Integer>();
        var nle = new int[n];

        for(int i=n-1; i>=0; i--) {
            var temp = new Stack<Integer>();
            while(!stack.empty() && arr[i] < arr[stack.peek()]) {
                temp.push(stack.pop());
            }
            nle[i] = !stack.empty() ? stack.peek() : -1;
            stack.push(i);
        }

        return nle;
    }
    
    public static int sumOfSubArrayMinimums(int[] arr) {
        var ple = getPLE(arr);
        var nle = getNLE(arr);
        
        int n = arr.length;
        long sum = 0;
        int modulo = 1000000007;
        
        for(int i=0; i<n; i++) {
            int prev = ple[i] == -1 ? (i+1) : (i-ple[i]);
            int next = nle[i] == -1 ? (n-i) : (nle[i]-i);
            sum += (((long) prev*next*arr[i]) % modulo);
        }
        
        return (int)(sum%modulo);
    }
    
    public static void main(String[] args) {
        var arr = new int[] {71,55,82,55};
        
        var sum = sumOfSubArrayMinimums(arr);

        System.out.println(sum);
    }
}