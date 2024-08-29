package Arrays;

class RearrangeElementBySign {
    public static void main(String[] args) {
        var arr = new int[] {3,1,-2,-5,2,-4};

        int n = arr.length;

        var ans = new int[n];
        var curr_even_index = 0;
        var curr_odd_index = 1;

        for(int i=0; i<n; i++) {
            if(arr[i]%2==0) {
                if(curr_even_index < n) {
                    ans[curr_even_index] = arr[i];
                    curr_even_index += 2;
                }
            }
            else {
                if(curr_odd_index < n) {
                    ans[curr_odd_index] = arr[i];
                    curr_odd_index += 2;
                }
            }
        }
        
        for(var e: ans) System.out.print(e+" ");
    }
}