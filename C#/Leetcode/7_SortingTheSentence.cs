using System;

namespace Leetcode;

public class _7_SortingTheSentence
{
    public static void Run() {
        var str = "is2 sentence4 This1 a3";

        var map = new SortedDictionary<int, string>();

        var s = "";
        foreach(var c in str) {
            int digit = c - '0';
            if(digit >= 1 && digit <= 9) {
                map.Add(digit, s.Trim());
                s = "";
            }
            else {
                s += c;
            }
        }

        var ans = "";
        foreach(var result in map.Values) {
            ans += result + " ";
        }

        System.Console.WriteLine(ans);
    }
}
