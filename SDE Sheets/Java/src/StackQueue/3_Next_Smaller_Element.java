package StackQueue;

import java.util.HashMap;
import java.util.Stack;

class NextSmallerElement {

    public static int[] nextSmallerElement(int[] arr) {
        var st = new Stack<Integer>();
        var mp = new HashMap<Integer, Integer>();

        int n = arr.length;

        for (int i = 0; i<n; i++) {
            while (!st.empty() && arr[i] <= st.peek()) {
                st.pop();
            }

            if (st.empty()) mp.put(i, -1);
            else mp.put(i, st.peek());

            st.push(arr[i]);
        }
        
        var ans = new int[n];
        for (int i = 0; i < n; i++) {
            ans[i] = mp.get(i);
        }

        return ans;
    }

    public static void main(String[] args) {
        var arr = new int[]{100, 1, 11, 1, 120, 111, 123, 1, -1, -100};

        var ans = nextSmallerElement(arr);

        for (var e : ans) System.out.print(e + " ");
    }
}