using System;

namespace Recursion;

public class _2_CountGoodNumbers
{

    public const int MOD = 1000000007;
    public static int ans = 1;

    public static int CountGoodNumbers(long n) {
        if(n == 0) return 1;

        if(n % 2 == 0) {
            return 4 * CountGoodNumbers(n-1) % MOD;
        }
        else {
            return 5 * CountGoodNumbers(n-1) % MOD;
        }
    }

    public static void Run() {
       var n = 50;

        System.Console.WriteLine(CountGoodNumbers(n));
    }
}
