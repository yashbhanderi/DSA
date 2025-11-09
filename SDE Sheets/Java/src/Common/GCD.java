package Common;

public class GCD {

    public static void main(String[] args) {

        int a = 56, b = 98;

        System.out.println(gcd(a, b));
    }

    private static int gcd(int a, int b) {

        if(b==0) return a;

        if(a < b) {
            a = (a + b) - (b = a);
        }

        return gcd(b, a%b);
    }
}
