using System;
using System.Collections.Generic;
using System.Linq;

namespace neetcode.Arrays
{
    public class LongestConsecutiveSequence
    {
        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var set = new HashSet<int>(nums);
            int longest = 0;

            foreach (var num in set)
            {
                // start only if this is the beginning of a sequence
                if (!set.Contains(num - 1))
                {
                    int current = num;
                    int length = 1;

                    while (set.Contains(current + 1))
                    {
                        current++;
                        length++;
                    }

                    longest = Math.Max(longest, length);
                }
            }

            return longest;
        }

        public static void Main()
        {
            var arr = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            System.Console.WriteLine(LongestConsecutive(arr));
        }
    }
}