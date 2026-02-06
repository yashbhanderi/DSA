using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neetcode.Arrays
{
    public class GroupAnagrams
    {
        public static IList<IList<string>> FindGroupAnagrams(string[] strs)
        {
            var map = new Dictionary<string, List<string>>();

            foreach (var s in strs)
            {
                Span<int> freq = stackalloc int[26];

                foreach (char c in s)
                    freq[c - 'a']++;

                var sb = new StringBuilder(52);

                for (int i = 0; i < 26; i++)
                {
                    sb.Append(freq[i]);
                    sb.Append('#');
                }

                string key = sb.ToString();

                if (!map.TryGetValue(key, out var list))
                {
                    list = [];
                    map[key] = list;
                }

                list.Add(s);
            }

            return [.. map.Values.Cast<IList<string>>()];
        }

        public static void Main()
        {
            var strs = new string[] { "bdddddddddd", "bbbbbbbbbbc" };

            var ans = FindGroupAnagrams(strs);

            foreach (var group in ans)
            {
                System.Console.WriteLine(string.Join(",", group));
            }
        }
    }
}