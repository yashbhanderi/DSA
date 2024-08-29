package BinarySearch;

class SqrtOfNumber {
    public static void main(String[] args) {
        int num = 25;

        int low = 1, high = num;
        
        while(low<=high) {
            int mid = (low+high)/2;
            
            long val = (mid*mid);
            
            if( val <= (long)num ) {
                low = mid+1;
            }
            
            else {
                high = mid-1;
            }
        }

        System.out.println(high);
    }
}