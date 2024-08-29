package Common;

public class ReverseNumber {
    public static void main(String[] args) {

        Integer num = 12345;

        // Method 1: Convert into string

        // String str = num.toString();

        // System.out.println(str.length());

        // Method 2:

        int length = countLengthOfNumber(num);
        System.out.println(length);
    }

    private static int countLengthOfNumber(int n) {

        int count = 0;

        while(n!=0) {
            count++;
            n /= 10;
        }

        return count;
    }
}
