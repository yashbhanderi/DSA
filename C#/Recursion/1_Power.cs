using System;

namespace C_.Recursion;

public class _1_Power
{

    /*
    
    Recurrance Relation

    If n == 0 -> 1
    If n == EVEN -> x^(n/2) * x^(n/2)
    If n == ODD -> x * x^(n-1)

    */

    public static double Power(double x, int n) {
        if(x == 0) {
            return 0;
        }

        // If n is negative, then first flip x from up to down, 
        // and make n positive by substracting 1 from it
        if(n < 0) return 1/x * Power(1/x, -(n+1));

        if(n == 0) {
            return 1;
        }
        else if(n % 2 == 0) {
            var e = Power(x, n/2);
            return e * e;
        }
        else {
            return x * Power(x, n-1);
        }    
    }

    public static void Run() {
        double x = 1.0000;
        int n = -2147483648;

        System.Console.WriteLine(Power(x, n));
    }
}
