package Arrays;

class UnionOfTwoArrays {
    public static void main(String[] args) {

        var arr1 = new int[] {1, 2, 2, 9, 15};
        var arr2 = new int[] {1, 5, 6, 7, 7, 8, 9};

        int m = arr1.length, n = arr2.length;

        int i = 0, j = 0, k = 0, len = 0;

        var arr = new int[n+m];

        while(i<m && j<n) {
            if(arr1[i] < arr2[j]) {
                arr[k++] = arr1[i];

                while(i+1<m && arr1[i]==arr1[i+1]) i++;
                i++;
            }
            else if(arr1[i] > arr2[j]) {
                arr[k++] = arr2[j++];

                while(j+1<n && arr2[j]==arr2[j+1]) j++;
                j++;
            }
            else {
                arr[k++] = arr1[i];

                while(i+1<m && arr1[i]==arr1[i+1]) i++;
                while(j+1<n && arr2[j]==arr2[j+1]) j++;
                i++; j++;
            }
            len++;
        }

        while(i<m) {
            arr[k++] = arr1[i++];
            len++;
        }

        while(j<n) {
            arr[k++] = arr2[j++];
            len++;
        }


        for(int K=0; K<len; K++) {
            System.out.print(arr[K]+" ");
        }
    }
}