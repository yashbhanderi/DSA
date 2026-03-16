using System.Collections.Generic;

namespace neetcode.SlidingWindow
{
    public class PermutationInString
    {
        public static bool CheckInclusion(string s1, string s2)
        {
            int n1 = s1.Length;
            int n2 = s2.Length;
            if (n1 > n2) return false;

            int[] s1Counts = new int[26];
            int[] windowCounts = new int[26];

            // 1. Build the target map and the first window
            for (int i = 0; i < n1; i++)
            {
                s1Counts[s1[i] - 'a']++;
                windowCounts[s2[i] - 'a']++;
            }

            // 2. Slide the window across s2
            for (int i = 0; i < n2 - n1; i++)
            {
                if (Matches(s1Counts, windowCounts)) return true;

                // Move window: Remove char at 'i', Add char at 'i + n1'
                windowCounts[s2[i] - 'a']--;
                windowCounts[s2[i + n1] - 'a']++;
            }

            // Check the very last window position
            return Matches(s1Counts, windowCounts);
        }

        private static bool Matches(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < 26; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }

        public static void Main()
        {
            var s1 = "adc";
            var s2 = "dcda";

            System.Console.WriteLine(CheckInclusion(s1, s2));
        }
    }
}