package Arrays;

/*

2 ways: Extra space and Constant Space

1. Extra space

- Create two pointer on both the array and create an extra array
- Now, traverse through both the array and add into answer array based on the comparison

 i             j
[1,3,5,0,0,0] [1,2,4]

 k
[_, _, _, _, _, _]
 
 
2. Constant Space

- We'll start from the END.

- Problem: If we're having two pointer with constant space, we need to take care of answer array
- Because we'll comparing and adjusting in the same array

- SO, we'll start from end in all 3 pointer

     i     k       j
[1,3,5,0,0,0] [1,2,4]

- Why all 3 at last
- We don't need to take of conflicting of i and k, because at worst case i is not moving an inch,
    It'll sorted by default 
- And If i is moving, then we don't have a problem because it will keep distance between i and k which it should have.
 
*/

class MergeSortedArrays {
    public static void main(String[] args) {
        var nums1 = new int[] {4,5,6,0,0,0};
        var nums2 = new int[] {1,2,3};
        
        int m = 3, n = 3;
        int i = m - 1;
        int j = n - 1;
        int k = m + n - 1;

        while (j >= 0) {
            if (i >= 0 && nums1[i] > nums2[j]) {
                nums1[k--] = nums1[i--];
            } else {
                nums1[k--] = nums2[j--];
            }
        }
    }
}