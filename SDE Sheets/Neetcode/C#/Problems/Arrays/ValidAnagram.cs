namespace Arrays;

public class ValidAnagram
{
    public static bool Solve(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;

        // Both strings will have equal length now.
        var map = new Dictionary<char, int>();

        for (int i = 0; i < s1.Length; i++)
        {
            var c1 = s1[i];
            var c2 = s2[i];
            map[c1] = map.GetValueOrDefault(c1) + 1;
            map[c2] = map.GetValueOrDefault(c2) - 1;
        }

        // If both strings are equal, then final value of each key must be 0
        // Because, we have added values with one string, and substracted with other 
        foreach (var val in map.Values)
        {
            if (val != 0) return false;
        }

        return true;
    }

    public static void Run()
    {
        var s1 = "aa";
        var s2 = "cc";

        System.Console.WriteLine(Solve(s1, s2));
    }
}