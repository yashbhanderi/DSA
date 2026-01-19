using System.Collections.Generic;

namespace neetcode.Arrays
{
    public class ValidAnagram
    {
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            // 1) Array of Alphabets to store frequency

            // 2) HashMap
            var map = new Dictionary<char, int>();
            foreach (var c in s)
            {
                map[c] = map.GetValueOrDefault(c) + 1;
            }

            foreach (var c in t)
            {
                map[c] = map.GetValueOrDefault(c) - 1;
            }

            foreach (var item in map)
            {
                if (item.Value != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main()
        {
            var s = "anagram";
            var t = "nagauram";

            System.Console.WriteLine(IsAnagram(s, t));
        }
    }
}