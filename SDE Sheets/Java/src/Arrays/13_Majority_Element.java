// https://leetcode.com/problems/majority-element/description/

package Arrays;

class MajorityElement {
    public static void main(String[] args) {

        var arr = new int[] {4,2,2,4,4,2,2};

        var n = arr.length;
        var candidate = 1; var vote = 0;

        for(var e: arr) {
            if(vote==0) {
                candidate = e;
                vote++;
            }
            else if(e==candidate) {
                vote++;
            }
            else {
                vote=0;
            }
        }

        System.out.println(candidate);
    }
}
