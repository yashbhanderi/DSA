// https://leetcode.com/problems/check-if-array-is-sorted-and-rotated/

package Arrays;

class IsArraySorted {

    public static void main(String[] args) {

        Integer[] arr = {1, 3, 4, 8, 9};

        System.out.println(isArraySorted(arr));

    }

    private static boolean isArraySorted(Integer[] arr) {

        for(int i=0; i<arr.length-1; i++) {
            if(arr[i] > arr[i+1]) return false;
        }

        return true;
    }
}
