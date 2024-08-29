// https://leetcode.com/problems/move-zeroes/

package Arrays;

class MoveZeroesToEnd {

    public static void swap(int[] arr, int i, int j) {
        int temp = arr[j];
        arr[j] = arr[i];
        arr[i] = arr[j];
    }

    public static void main(String[] args) {

        var arr = new int[] {1, 0, 0, 0, 6, 0, 2, 2, 9};

        int n = arr.length, k = 0, cnt = 0;

        for(int i=0; i<n; i++) {
            if(arr[i]!=0 && k<n) {
                arr[k++] = arr[i];
                cnt++;
            }
        }

        for(int i=cnt; i<n; i++) {
            arr[i] = 0;
        }

        for(var i: arr) System.out.print(i+" ");
    }

}