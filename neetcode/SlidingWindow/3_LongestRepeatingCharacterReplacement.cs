using System;
using System.Collections.Generic;

namespace neetcode.SlidingWindow
{
    public class LongestRepeatingCharacterReplacement
    {
        public static int CharacterReplacement(string s, int k)
        {
            var bestLength = 0;

            var map = new Dictionary<char, int>();
            var left = 0;
            var maxCountTillNow = 0;
            for (var right = 0; right < s.Length; right++)
            {
                var currentChar = s[right];
                map[currentChar] = map.GetValueOrDefault(currentChar) + 1;

                maxCountTillNow = Math.Max(map[currentChar], maxCountTillNow);

                while ((right - left + 1) - maxCountTillNow > k && left < right)
                {
                    var leftChar = s[left];
                    map[leftChar]--;
                    
                    maxCountTillNow = Math.Max(map[currentChar], maxCountTillNow);

                    left++;
                }

                bestLength = Math.Max(right - left + 1, bestLength);
            }

            return bestLength;
        }

        public static void Main()
        {
            var s = "AABABBA";
            var k = 1;

            System.Console.WriteLine(CharacterReplacement(s, k));
        }
    }
}