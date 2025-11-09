package Arrays;

import java.util.*;

/*

**** Process:

-- Brute O(N! * N)

We can generate all the permutation of the array
Then select the next one permutation of given array

Time: N! to generate all the permutations
N = Traversing time over array 

-- Better O(N! * N)

We can use C++ STL's library function next_permutation() to generate the answer

-- Best  O(N)

This is standard algorithm.

First of all given array: 
[2, 1, 5, 4, 3, 0, 0]

Here, we'll use LONGEST PREFIX MATCH

What is this???

-- Suppose, you have a phonebook

raj     123
rav     124 
vaj     211

Here, next means IT WILL ALWAYS GREATER THAN PREVIOUS ONES.
BUT we have to find VERY NEXT.

For given ques, 

0: 2,1,5,4,3,0  0   [Nothing will change, bcz It will make number smaller]
0: 2,1,5,4,3    0,0   [Nothing will change, bcz It will make number smaller]
0: 2,1,5,4      3,0,0   [Nothing will change, bcz It will make number smaller i.e 0,3,0 OR 0,0,3]

Here, 0,0,3 makes overall number smaller -> WE DON'T WANT SMALLER.

0: 2,1,5,       4,3,0,0   [Nothing will change, bcz It will make number smaller]
0: 2,1          5,4,3,0,0   [Nothing will change, bcz It will make number smaller]
0: 2            1,5,4,3,0,0

              5    
  PIVOT ->  1   4
                  3
                    0
                      0

   Prefix elements array:  [5,4,3,0,0]

NOWWW!!! Things may change -> Bcz [ 1 < 5 ]

So, we can make 1,5,4,3,0,0 -> 5,... (anything will bigger bcz of 5)
In summary, we have to find any number which is smaller than it's next number in array

NOW, we can change any number which is very next bigger than PIVOT element
SO that we can replace it and can get very next bigger number

NOTE: Here this pyramid thing can also happen in ahead or in-between array
BUT we should only take from behind -> so that we can get very next number

Here, 3 is smallest element which is bigger than 1

SO, SWAP(1, 3)

NOW: [2, 3, 5, 4, 1, 0, 0]

Here, We'll reverse the array till PIVOT INDEX

WHY??
So that we can get smallest next 

reversed array from PIVOT till end: [2, 3, 0, 0, 1, 4, 5]
compare to [2, 3, 5, 4, 1, 0, 0]

Both are almost near, BUT [2, 3, 0, 0, 1, 4, 5] is VERY NEXT.
So answer is same.
*/

class NextPermutation {

    static void reverseArray(int[] arr, int start, int end) {
        while (start < end) {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;

            start++;
            end--;
        }
    }

    static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    
    public static void main(String[] args) {
        var arr = new int[] {2,1,5,4,0};
        
        int n = arr.length;
        
        int i=n-1;
        
        for(i=n-2; i>=0; i--) {
            if(arr[i]<arr[i+1]) break;
        }
        
        if(i==-1) {
            reverseArray(arr, 0, n-1);
            System.out.println(Arrays.toString(arr));
        }
        
        else {
            for(int j = n-1; j > i; j--) {
                if(arr[j] > arr[i]) {
                    swap(arr, j, i);
                    break;
                }
            }
            
            reverseArray(arr, i+1, n-1);
            
            System.out.println(Arrays.toString(arr));
        }
    }
}