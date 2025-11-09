package Arrays;

class MaximumProductSubarray {
    public static void main(String[] args) {
        
        var arr = new int[] {2,3,-2,4};
        
        int n = arr.length;
        
        int product_till_now = 1, product_till_so_far = 0;
        boolean flag = false;
        
        for(int i=0; i<n; i++) {
            
            product_till_now *= arr[i];
            
            if(product_till_now > product_till_so_far) {
                product_till_so_far = product_till_now;
                flag = true;
            }
            
        }
    }
}