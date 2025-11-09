package Common;

public class CheckPalindrome {

    public static void main(String[] args) {

        String str = "aajaa";

        System.out.println(isPalindrome(str));
    }

    private static boolean isPalindrome(String str) {

        int i=0, j=str.length()-1;

        while(i<j) {
            if(str.charAt(i) != str.charAt(j)) return false;

            i++;
            j--;
        }

        return true;
    }
}
