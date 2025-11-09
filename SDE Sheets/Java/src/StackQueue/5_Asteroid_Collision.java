package StackQueue;

import java.util.*;

class AsteroidCollision {

    public static ArrayList<Integer> collidedArray(int[] arr) {
        int n = arr.length;

        var stack = new Stack<Integer>();
        var ans = new ArrayList<Integer>();

        for(var e: arr) {
            if(e < 0 && stack.empty()) {
                ans.add(e);
            }
            else {
                if(e < 0) {
                    while(!stack.empty() && Math.abs(e) > stack.peek()) {
                        stack.pop();
                    }

                    if(stack.empty()) ans.add(e);
                    else if(stack.peek() == Math.abs(e)) {      // Equal Values
                        stack.pop();
                    }
                }
                else {
                    stack.push(e);
                }
            }
        }

        var temp = new ArrayList<Integer>();

        while (!stack.empty()) {
            temp.add(stack.pop());
        }

        Collections.reverse(temp);

        ans.addAll(temp);

        return ans;
    }
    
    public static void main(String[] args) {
        var arr = new int[] {-11, 10, -2, -5, 3, -8, 7, 1};
        
        var ans = collidedArray(arr);
        
        for(var e : ans) {
            System.out.print(e+" ");
        }
    }
}