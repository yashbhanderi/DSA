package BinarySearch;

class SearchIn2DMatrix {
    public static void main(String[] args) {
        var arr = new int[][] {{1},{3}};
        
        int n = arr.length;
        
        int target = 3;
        
        for(int i=0; i<n; i++) {
            int low = 0, high = arr[i].length-1;
            
            while(low <= high) {
                int mid = low + ((high-low)/2);
                
                if(arr[i][mid]==target) {
                    System.out.println(i+" "+mid);
                    return;
                }
                
                else if(arr[i][mid] < target) {
                    low = mid+1;
                }
                
                else {
                    high = mid-1;
                }
            }
        }
    }
}