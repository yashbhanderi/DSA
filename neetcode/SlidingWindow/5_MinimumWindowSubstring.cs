using System.Collections.Generic;

namespace neetcode.SlidingWindow
{
    public class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            var map = new Dictionary<char, int>();
            var set = new HashSet<int>();
            foreach (var c in t)
            {
                map[c] = map.GetValueOrDefault(c) + 1;
                set.Add(c);
            }

            var cnt = 0;
            var left = 0;
            var minWindowString = "";
            for (var right = 0; right < s.Length; right++)
            {
                var currentChar = s[right];

                map[currentChar] = map.GetValueOrDefault(currentChar) - 1;

                if (map[currentChar] == 0)
                {
                    cnt++;
                }

                while (cnt == set.Count && left <= right)
                {
                    var currentSubstring = s.Substring(left, (right - left + 1));
                    if (minWindowString == "")
                    {
                        minWindowString = currentSubstring;
                    }
                    else if (currentSubstring.Length < minWindowString.Length)
                    {
                        minWindowString = currentSubstring;
                    }
                    System.Console.WriteLine(minWindowString);
                    var leftChar = s[left];
                    map[leftChar]++;

                    if (map[leftChar] > 0)
                    {
                        cnt--;
                    }

                    left++;
                }
            }

            return minWindowString;
        }

        public static void Main()
        {
            var s = "a";
            var t = "a";
            System.Console.WriteLine(MinWindow(s, t));
        }
    }
}