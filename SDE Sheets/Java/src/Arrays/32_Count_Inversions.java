package Arrays;

import java.util.Arrays;


class CountInversions {

    public static long first(long a[], long low, long high, long key)
    {
        long ans = -1;

        while (low <= high)
        {
            long mid = low + (high - low + 1) / 2;
            long midVal = (long)a[(int)mid];

            if (midVal < key)
            {
                low = mid + 1;
            }
            else if (midVal > key)
            {
                high = mid - 1;
            }
            else if (midVal == key)
            {
                ans = mid;
                high = mid - 1;
            }
        }
        return ans;
    }

    public static void main(String[] args) {
        
        var arr = new long[] {7, 2, 8, 10, 1, 6, 4, 5, 9, 3};
        
        int n = arr.length;

        long arr2[] = arr.clone();
        Arrays.sort(arr2);

        long inversionCount = 0;

        for(int i=0; i<n; i++) {
            long indexDiff = first(arr2, 0, n-1, arr[i]) - i;

            inversionCount += Math.abs(indexDiff);
        }
        System.out.println(inversionCount);
        
    }
}