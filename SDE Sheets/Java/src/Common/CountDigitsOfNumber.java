package Common;

public class CountDigitsOfNumber {

    public static void main(String[] args) {

        int n = 100234;

        int count = (int) (Math.log10(n) + 1);

        System.out.println(count);

    }
}
