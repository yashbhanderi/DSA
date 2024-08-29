package BinarySearch;

import java.util.Arrays;

/*

Same problem like Koko eating bananas

* But main points

    - We have to find less than or equal to days
    - On a particular day, we CAN NOT SHIP load more than it's weight
    
    Ex. In Koko eating banana, If pile = 20, speed = 10
    Then we can count two times.
    
    BUT HERE, If capacity = 20, then we have to SHIP LOAD <=20, 
    Not more than 20.
 
*/

class CapacityToShipPackagesInDDays {

    public static boolean canShip(int[] arr, int total, int days) {
        int D = 0;

        int i=0, n = arr.length;
        while(i<n) {
            if(arr[i] > total) {
                return false;
            }
            else {
                int sum = 0;
                while(i<n && sum+arr[i]<=total) {
                    sum += arr[i];
                    i++;
                }
                D++;
            }
        }

        return D<=days;
    }
    
    public static void main(String[] args) {
        var arr = new int[] {1,2,3,4,5,6,7,8,9,10};
        
        int D = 10;
        
        int low = 0, high = Arrays.stream(arr).sum();

        while(low <= high) {
            int mid = low + ((high-low)/2);
            
            if(canShip(arr, mid, D)) {
                high = mid-1;
            }
            else {
                low = mid+1;
            }
        }

        System.out.println(low);
    }
}