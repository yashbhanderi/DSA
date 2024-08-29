// https://leetcode.com/problems/max-consecutive-ones/description/

package Arrays;

class MaxConsecutiveOnces {
    public static void main(String[] args) {
        var arr = new int[] { 0};

        int n = arr.length;

        int ans = 0, i = 0;

        while(i<n) {
            int cnt = 0;
            while(i<n && arr[i]==1) {
                cnt++;
                i++;
            }

            ans = Math.max(ans, cnt);
            i++;
        }

        System.out.println(ans);
    }
}