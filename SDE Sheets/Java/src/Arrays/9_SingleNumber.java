// https://leetcode.com/problems/single-number/

package Arrays;

class SingleNumber {
    public static void main(String[] args) {

        var arr = new int[] {1, 2, 3, 4, 3, 1, 2};

        int n = arr.length;
        int ans = 0;

        // Method 1:
        for(int i=0; i<n; i++) {
            ans ^= arr[i];
        }

        System.out.println(ans);
    }
}