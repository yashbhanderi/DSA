package Arrays;

import java.util.HashMap;

class LargestSubarrayWithZeroSum {
    public static void main(String[] args) {
        var arr = new int[] {-375,-935,446,-178,-886,-347,-658,337,-341,207,714,-320,820,722,-938,941,706,-126,-983,-919,-421,397,631,-291,-671,-624,223,641,-897,299,-523,-208,820,-731,995,-378,274,-849,861,-578,-992,622,505,962,-325,945,-201,-783,843,-527,873,-957,-35,-752,-302,134,-889,-566,-367,501,-787,250,-302,364,254,-685,153,-974,-156,437,-413,461,-27,51,-555,-793,700,40,-427,501,648,-158,536,-338,-214,505,50,-284,344,178,-237};
        
        int n = arr.length;
        
        var mp = new HashMap<Integer, Integer>();
        mp.put(0, -1);
        
        int ans = -1, sum = 0;
        
        for(int i=0; i<n; i++) {
            
            sum += arr[i];
            
            if(mp.containsKey(sum)) {
                ans = Math.max(ans, i-mp.get(sum));
            }
            else {
                mp.put(sum, i);
            }
        }

        System.out.println(ans);
    }
}