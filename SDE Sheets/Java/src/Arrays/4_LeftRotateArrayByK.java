// https://leetcode.com/problems/rotate-array/
package Arrays;

class LeftRotateArrayByK {

    public static void reverse(int[] arr, int i, int j) {
        int li = i;
        int ri = j-1;

        while(li < ri){
            int temp = arr[li];
            arr[li] = arr[ri];
            arr[ri] = temp;

            li++;
            ri--;
        }
    }

    public static void rotate(int[] nums, int k) {
        k %= nums.length;
        reverse(nums, 0, nums.length);
        reverse(nums, k, nums.length);
        reverse(nums, 0, k);
    }

    public static void main(String[] args) {

        var arr = new int[] {1,2,3,4,5,6,7};

        int n = arr.length;
        int K = 3;

        rotate(arr, K);

        for(var i: arr) {
            System.out.print(i+" ");
        }
    }
}