package StackQueue;
import java.util.HashMap;
import java.util.Stack;

class NextGreaterElement {

    public static int[] nextGreaterElement(int[] arr1, int[] arr2) {
        var st = new Stack<Integer>();
        var mp = new HashMap<Integer, Integer>();

        int m = arr1.length, n = arr2.length;

        for (int i = n - 1; i >= 0; i--) {
            if (st.empty()) {
                st.push(arr2[i]);
                mp.put(arr2[i], -1);
            } 
            else {
                while (!st.empty() && arr2[i] > st.peek()) {
                    st.pop();
                }

                if (st.empty()) mp.put(arr2[i], -1);
                else mp.put(arr2[i], st.peek());

                st.push(arr2[i]);
            }
        }

        var ans = new int[m];
        for (int i=0; i<m; i++) {
            ans[i] = mp.get(arr1[i]);
        }

        return ans;
    }

    public static void main(String[] args) {
        var arr1 = new int[]{4, 1, 2};
        var arr2 = new int[]{1, 3, 4, 2};

        var ans = nextGreaterElement(arr1, arr2);
        
        for (int ans2 : ans) {
            System.err.println(ans2);
        }
    }
}