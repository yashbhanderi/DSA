package Arrays;

class LongestSubarrayWithGivenSum {
    
    public static void main(String[] args) {

        var arr = new int[] {2,3,5,1,9};

        int n = arr.length;
        int ans = -1, req_sum = 10;

        int i = 0, j = 0, curr_sum = 0, cnt = 0;

        while(j<n && i<j) {

            if(curr_sum == req_sum) {
                cnt++;
                curr_sum -= arr[i];
                i++;
            }

            while(curr_sum > req_sum && i<j) {
                curr_sum -= arr[i];
                i++;
            }

            while(curr_sum < req_sum && j<n) {
                curr_sum += arr[j];
                j++;
            }
        }

        System.out.println(cnt);
    }
}