package Arrays;

import java.util.HashMap;

class CountNoOfSubarraysWithGivenXOR {
    public static void main(String[] args) {
        var arr = new int[] {4, 2, 2, 6, 4};
        
        int n = arr.length;
        int B = 6;
        
        var mp = new HashMap<Integer, Integer>();
        mp.put(0, 1);
        
        int xor = 0, cnt = 0;
        
        for(var e: arr) {
            
            xor ^= e;
            
            if(mp.containsKey(xor^B)) {
                cnt += mp.get(xor^B);
            }
            
            mp.put(xor, mp.getOrDefault(xor, 0)+1);
        }

        System.out.println(cnt);
    }
}