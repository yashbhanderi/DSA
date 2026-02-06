using System;
using System.Collections.Generic;

namespace neetcode.SlidingWindow
{
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;

            var cnt = 0;
            var map = new Dictionary<char, int>();
            var longestUniqueSubstring = 0;
            var left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                var currentChar = s[right];
                map[currentChar] = map.GetValueOrDefault(currentChar) + 1;

                if (map[currentChar] == 1)
                {
                    cnt++;
                }

                while ((right - left + 1) != cnt && left < right)
                {
                    var leftChar = s[left];
                    map[leftChar]--;

                    if (map[leftChar] == 0) cnt--;

                    left++;
                }

                longestUniqueSubstring = Math.Max(right - left + 1, longestUniqueSubstring);
            }

            return longestUniqueSubstring;
        }

        public static void Main()
        {
            var s = "bbbbb";
            System.Console.WriteLine(LengthOfLongestSubstring(s));
        }
    }
}