// https://leetcode.com/problems/missing-number/description/

package Arrays;

class FindMissingNumber {
    public static void main(String[] args) {
        var arr = new int[] {3, 0, 1};

        // Method 1: Maths Formula

        var n = arr.length;

        var expected_sum = (n*(n+1))/2;

        var actual_sum = 0;
        for(var i: arr) actual_sum += i;

        var missing_number = expected_sum - actual_sum;

        System.out.println(missing_number);

        // Method 2: XOR Bit operator


        // 4^4 = 0 <--- XOR Operation

        // Here, i=0 to n
        // For every element, there will be same index so they will be zero out
        // Only one number remains, which is not present

        int res = arr.length;
        for(int i=0; i<arr.length; i++){
            res ^= i;
            res ^= arr[i];
        }

        System.out.println(res);
    }
}