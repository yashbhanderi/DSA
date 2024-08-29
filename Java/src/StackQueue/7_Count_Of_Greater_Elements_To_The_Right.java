package StackQueue;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Stack;

class CountOfGreaterElementsToTheRight {
    
    public static ArrayList<Integer> countGreaterElementsToTheRight(Integer[] arr) {
        var stack = new Stack<Integer>();
        var ans = new ArrayList<Integer>();
        
        int n = arr.length;
        
        for(var i=n-1; i>=0; i--) {
            var temp = new Stack<Integer>();
            while (!stack.empty() && arr[i] >= stack.peek()) {
                temp.push(stack.pop());
            }
            
            ans.add(stack.size());
            stack.push(arr[i]);
            
            while(!temp.empty()) {
                stack.push(temp.pop());
            }
        }
        
        Collections.reverse(ans);
        
        return ans;
    }
    
    public static void main(String[] args) {
        var arr = new Integer[] {44,449,449,483,453,458,53,101,142,443,13,130,474,59,316,213,455,136,50,437,128,59,366,214,449,59,404,52,368,409,139,414,483,149,393,132,469,494,216,146,390,48,65,422,494,426,180,397,49,224};
        var query = new Integer[] {49,7,10,2,27,27,21,6,12,46,44,49,2,42,43,25,7,17,4,27,35,37,17,8,4,29,37,30,32,16,22,34,16,8,23,6,48,20,23,37,45};
        
        var ans = countGreaterElementsToTheRight(arr);
        
        for(var e: ans) {
            System.out.print(e + " ");
        }
        System.out.println();


        for(var e: query) {
            System.out.print(ans.get(e) + " ");
        }
    }
}