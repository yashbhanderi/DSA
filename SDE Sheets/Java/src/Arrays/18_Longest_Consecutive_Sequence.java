package Arrays;

import java.util.HashMap;

/*

-- Method 1: 

Two patterns can be made

4, 3, 2, 1, 0
-1, 0, 1


Here, we'll check for every element below thing:

- Check for element less than one from current element
IF FOUND -> Search continue till zero found
ELSE go to next element

- Here, during searching
We'll mark every element visited with Integer.MIN_VALUE
AND Master element: from where everything started
Set it's value to 1(own count) + elements found during journey

- NOWW, suppose for 0,3,4,5,6,100,2

When we at 3: 
    We've out journey from 4 -> 5 -> 6
    Total count 1+ 3 = 4
    
    SO, 3-> 4
        4,5,6 -> Integer.MIN_VALUE
        
- NOW, when we come at 2 
    We DON"T HAVE TO GO AGAIN FROM 3 to 6
    BECAUSE IT IS ALREADY COVERED. ( O(N) Operation ensured!! )
    
    SO, 2: 1 + 4(3's Journey)  = 5 (Answer)



-- Method 2: We can count current element's prev and next element's journey

This method is one step better than Method 1
*/

class LongestConsecutiveSequence {
    public static void main(String[] args) {
        var arr = new int[] {1, 0, -1};
        
        int n = arr.length;
        
        var mp = new HashMap<Integer, Integer>();
        
        for(var e: arr) {
            mp.putIfAbsent(e, 0);
        }
        
        int ans = 0;
        for(var e: mp.keySet()) {
            if(mp.get(e) != Integer.MIN_VALUE) {
                int cnt = 1, num = e+1;
                while(mp.containsKey(num) && mp.get(num) != Integer.MIN_VALUE) {
                    if(mp.get(num) > 0) {
                        cnt += mp.get(num);
                        break;
                    }
                    else {
                        cnt++;
                        mp.put(num, Integer.MIN_VALUE);
                        num++;   
                    }
                }
                mp.put(e, cnt);
                ans = Math.max(ans, cnt);
            }
        }

        System.out.println(ans);
    }
}