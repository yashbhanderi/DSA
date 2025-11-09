// https://leetcode.com/problems/sort-colors/description/

package Arrays;

import java.util.Arrays;

class SortColors {

// dutch national flag algorithm

    // Here, We are keeping theee pointer on array
    // low, mid, high
    // [start->low] = 0
    // [high->end] = 2
    // middle = 1

    // only 3 points to remember
    // 1) If 2 -> swap with high pointer and high--
    // 2) If 0 -> swap with low and low++, curr++ <- curr is because INDEX GOT HIS RIGHT ELEMENT
    // So just get over
    // 3) If 1 -> curr++  <- bcz we've maintained position for 0(low) and2(high).. 
    // So 1 will be automatically keep in right position

    // 1 0 2 2 1 0
    // ^         ^
    // L         H
    // M

    // Mid != 0 || 2
    // Mid++

    // 1 0 2 2 1 0
    // ^ ^       ^
    // L M       H

    // Mid == 0
    // Swap Low and Mid
    // Mid++
    // Low++

    // 0 1 2 2 1 0
    //   ^ ^     ^
    //   L M     H

    // Mid == 2
    // Swap High and Mid
    // High--

    // 0 1 0 2 1 2
    //   ^ ^   ^
    //   L M   H

    // Mid == 0
    // Swap Low and Mid
    // Mid++
    // Low++

    // 0 0 1 2 1 2
    //     ^ ^ ^
    //     L M H

    // Mid == 2
    // Swap High and Mid
    // High--

    // 0 0 1 1 2 2
    //     ^ ^
    //     L M
    //       H

    // Mid <= High is our exit case

    public static void main(String[] args) {
        var arr = new int[] {1,2,0};

        int n = arr.length;

        int i=0, k=n-1, j=0;


        // curr==high is valid bczzz...there may be possible 
        // to have 0 on curr==high ..like in these case (2, 0, 1)   
        // In 2nd step: (1,  0,  2)
        //               L   M,   H
        while(j<=k) {

            if(arr[j]==2) {
                arr[j]=arr[k];
                arr[k]=2;
                k--;
            }

            else if(arr[j]==0) {
                arr[j]=arr[i];
                arr[i]=0;
                i++;
                j++;
            }

            else j++;
        }

        System.out.println(Arrays.toString(arr));
    }
}