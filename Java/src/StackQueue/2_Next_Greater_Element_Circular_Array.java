package StackQueue;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Stack;

class NextGreaterElementCircularArray {

    public static int[] nextGreaterElement(int[] arr) {
        var st = new Stack<Integer>();
        var mp = new HashMap<Integer, Integer>();

        int n = arr.length;

        int cnt = 0; 
        while(cnt<2) 
        {
            for (int i = n - 1; i >= 0; i--)
            {
                while (!st.empty() && arr[i] >= st.peek()) {
                    st.pop();
                }

                if (st.empty()) mp.put(i, -1);
                else mp.put(i, st.peek());

                st.push(arr[i]);
            }
            cnt++;
        }
        
        var ans = new int[n];
        for (int i = 0; i < n; i++) {
            ans[i] = mp.get(i);
        }

        return ans;
    }

    public static void main(String[] args) {
        var arr = new int[]{100, 1, 11, 1, 120, 111, 123, 1, -1, -100};

        var ans = nextGreaterElement(arr);

        for (var e : ans) System.out.print(e + " ");
    }
}