namespace Arrays;

/*
 * Group Anagrams Solution Logic:
 * 1. Key Insight: Anagrams have the same character frequency count
 * 2. For each string:
 *    - Create a count array of size 26 (for a-z)
 *    - Count frequency of each character
 *    - Convert count array to string key (e.g., "1-0-2..." means 1 'a', 0 'b', 2 'c'...)
 * 3. Use this key in dictionary:
 *    - Same key = anagrams go to same group
 *    - Different key = different character frequencies = not anagrams
 * 
 * Example: "eat", "tea" both give key "1-0-0-0-1-0-0-0-0-0-0-0-0-0-0-0-0-0-0-1-0-0-0-0-0-0"
 * Time: O(n * k) where n = number of strings, k = max length of string
 * Space: O(n * k) for storing all strings in groups
 */

public class GroupAnagrams
{
    public static IList<IList<string>> Solve(string[] strs)
    {
        var map = new Dictionary<string, IList<string>>();

        IList<IList<string>> result = [];
        foreach (var str in strs)
        {
            var charList = Enumerable.Repeat(0, 26).ToList();
            for (int i = 0; i < str.Length; i++)
            {
                var currentCharIndex = str[i] - 'a';
                charList[currentCharIndex]++;
            }

            var charListKey = string.Join("-", charList);
            if (map.TryGetValue(charListKey, out var oldList))
            {
                oldList.Add(str);
            }
            else
            {
                map[charListKey] = [str];
            }
        }

        foreach (var r in map.Values)
        {
            result.Add(r);
        }

        return result;
    }

    public static void Run()
    {

        var strs = new[] { "bdddddddddd", "bbbbbbbbbbc" };

        var r = Solve(strs);
        foreach (var s in r)
        {
            System.Console.WriteLine(string.Join(",", s));
        }
    }
}