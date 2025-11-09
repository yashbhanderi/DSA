namespace Leetcode;

public class SumofDigitsofStringAfterConvert {

    public static int GetLucky(string str, int k) {
        if(str.Length == 0) return 0;

        int sum = 0;
        while(k-- > 0) {
            sum = 0;
            var ans = "";

            foreach(char c in str) {
                if(c - 'a' >= 0) {
                    ans += c - 'a' + 1;
                } 
                else {
                    ans += c - '0';
                }
            }   

            foreach(var c in ans) {
                sum += c - '0';
            }
        
            str = sum.ToString();
        }

        return sum;
    }

    public static void Run() {
        var str = "leetcode";

        System.Console.WriteLine(GetLucky(str, 2));
    }
}