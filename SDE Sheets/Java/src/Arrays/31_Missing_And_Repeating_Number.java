package Arrays;

import java.util.Arrays;

/*

Brute Force:    Time: O(N^2), Space: O(1)

- TWO FOR LOOP
- If any element comes two times, then it is answer
- Same check for missing number

Better: HashMap, or HashSet | Time: O(N), Space: O(N)

- Add elements into data structure like map or set
- Check which element's count is more than two
- And which element is missing from it's place which is our missing number

Best: Time: O(N), Space: O(1)

- For each element
    Add N into it's index value
 
 [3, 2, 5, 1, 2] 
 
 For i=0 -> [3, 2, 10, 1, 2] (add arr[arr[i]-1] + N )
 
 What if i=2, because it is 10  | Here, we have to substract IF ELEMENT IS GREATER THAN N
 TO GET THE INDEX
 ------> AT ONE TIME | WE HAVE TO SUBTRACT TWO TIMES | BCZ OF REPEATING NUMBER <-------------------
 
 After one loop, array will look like this : [8, 12, 10, 1, 7]
 Here, missing number = 4 (bcz it's index is not came for addition)
 Repeating number = 2 (Because even after subtraction of N -> It's value is still greater than N, 
                        means it got addition more than one time)
 
*/

class MissingAndRepeatingNumber {
    public static void main(String[] args) {
        var arr = new int[] {
                3,2,5,1,2
        };
        
        int n = arr.length, missingNumber = -1, repeatingNumber = -1;
        
        for(int i=0; i<n; i++) {
            if(arr[i] > n) {
                int temp = arr[i]-n > n ? arr[i]-(2*n) : arr[i]-n;
                arr[temp-1]+=n;
            }
            else {
                arr[arr[i]-1]+=n;
            }
        }
        
        for(int i=0; i<n; i++) {
            if(arr[i] <= n) {
                missingNumber = i+1;
            }
            if(arr[i]-n > n) {
                repeatingNumber = i+1;
            }
        }

        System.out.println(Arrays.toString(arr));
        
        System.out.println(missingNumber);
        System.out.println(repeatingNumber);
    }
}