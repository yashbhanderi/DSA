// https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/

package Arrays;
import java.util.HashMap;
import java.util.HashSet;

class RemoveDuplicatesFromSortedArray {

    public static void main(String[] args) {

        Integer[] arr = {1, 3, 5, 6, 9, 10, 3};

        // Method 1: Hashmap

        var mp = new HashMap<Integer, Integer>();

        for(Integer e: arr) {
            mp.put(e, mp.getOrDefault(e, 0)+1);
        }

        for(var e: mp.entrySet()) {
            if(e.getValue() > 1) {
                System.out.println(e.getKey() + " " + e.getValue());
            }
        }

        // Method 2: Hashset

        var set = new HashSet<Integer>();

        for(var e: arr) {
            set.add(e);
        }

        for(var e: set) {
            System.out.println(e);
        }
    }

}
