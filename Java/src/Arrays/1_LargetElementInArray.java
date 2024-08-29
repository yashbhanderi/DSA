package Arrays;

import java.util.Arrays;
import java.util.Collections;

class LargetElementInArray {

    public static void main(String[] args) {

        Integer[] arr = {1, 3, 9, 3, 4, 2, 0, 6};

        // Method 1: Traverse the array

        int largest = -1;

        for(Integer e: arr) {
            if(e>largest) largest = e;
        }

        System.out.println(largest);

        // Method 2: Sort the array

        Arrays.sort(arr, Collections.reverseOrder());

        System.out.println(arr[0]);
    }

}
