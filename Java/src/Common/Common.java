package Common;

import Trees.TreeNode;

public class Common {

    public static void reverseArray(int[] arr, int start, int end) {
        while (start < end) {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;

            start++;
            end--;
        }
    }

    public static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    
    public static int binarySearch(int[] arr, int start, int end, int x) {
        int l = start, r = end;
        while (l <= r) {
            int m = l + (r - l) / 2;

            if (arr[m] == x)
                return m;

            if (arr[m] < x) 
                l = m + 1;

            else 
                r = m - 1;
        }
        
        return -1;
    }

    public static int lowerBound(int arr[], int l, int r, int target) {

        while(l<r) {
            int mid = l + ((r-l)/2);

            if(arr[mid] < target)
                l = mid+1;

            else 
                r = mid;
        }

        if(l < arr.length && target > arr[l]) {
            l++;
        }

        return l;
    }

    public static int upperBound(int arr[], int l, int r, int target) {

        while(l<r) {
            int mid = l + ((r-l)/2);

            if(arr[mid] <= target)
                l = mid+1;

            else
                r = mid;
        }

        if(l < arr.length && target > arr[l]) {
            l++;
        }

        return l;
    }
    
    public static int heightOfBinaryTree(TreeNode root) {
        if(root == null) return 0;
        
        return 1 + Math.max(heightOfBinaryTree(root.left), heightOfBinaryTree(root.right));
    }
}
