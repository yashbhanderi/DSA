namespace CSharp.Topics.SlidingWindow
{
    public class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            var map1 = new Dictionary<char, int>();
            foreach (var c in t)
            {
                map1[c] = map1.GetValueOrDefault(c) + 1;
            }

            int n = s.Length, left = 0, windowLength = t.Length;
            var map2 = new Dictionary<char, int>();
            int minWindowSubstring = int.MaxValue;
            int startIndex = -1, endIndex = -1;

            for (int right = 0; right < n; right++)
            {
                var currentChar = s[right];
                map2[currentChar] = map2.GetValueOrDefault(currentChar) + 1;

                while (right - left + 1 >= windowLength && map1.All(kvp => map2.ContainsKey(kvp.Key) && map2[kvp.Key] >= kvp.Value))
                {
                    if (minWindowSubstring > right - left + 1)
                    {
                        minWindowSubstring = right - left + 1;
                        startIndex = left; endIndex = right;
                    }
                    map2[s[left]]--;
                    left++;
                }
            }

            if (startIndex != -1 && endIndex != -1)
            {
                return s.Substring(startIndex, endIndex - startIndex + 1);
            }
            else
            {
                return "";
            }
        }

        public static void Run()
        {
            string s = "a", t = "aa";
            System.Console.WriteLine(MinWindow(s, t));
        }
    }
}


// 1.  * *Problem Explanation: **The core concept was explained simply as finding the "smallest slice" (substring) of a **Big String** (S) that contains all characters of a **Target String** (T).
// 2.  **Analogy:**The * *Sliding Window** technique was introduced using the "Elastic Band" analogy:
// ***Stretch(Expand Right):**To include all necessary characters.
//     * **Release (Shrink Left):**To minimize the window length while maintaining validity.
// 3.  **Code Request:**The user requested the solution in **C#**.
// 4.  **C# Solution:** An optimized C# implementation was provided using a fixed-size `int[] map` (array) instead of a `Dictionary` for character frequency tracking, achieving $O(N)$ time complexity.
// 5.  **Follow-up Question:**The user asked a crucial question about the shrinking phase: **"How do you ensure the character being removed (`lChar`) is a character from the target string?" * *
// 6.  * *Detailed Answer: **The final response clarified the **"Secret Sauce"** of the algorithm:
//     *The `if (map[lChar] > 0)` check* automatically* filters out "junk" characters.
//     * For **Target Characters**, removing one causes `map[lChar]` to go from `0` to **`1`**, triggering the `count++` logic, which invalidates the window and forces the right pointer to find a replacement.
//     * For **Junk Characters**, removing one causes `map[lChar]` to go from `-1` to **`0`**, which is not greater than zero, so the `count` remains unchanged, and the window remains valid (or invalid if it was already invalid).

// Optimized OG Code
// public class Solution
// {
//     public string MinWindow(string s, string t)
//     {
//         // Edge case: If strings are empty, return nothing
//         if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

//         // 1. Create the frequency map for the Target string
//         int[] map = new int[128];
//         foreach (char c in t)
//         {
//             map[c]++;
//         }

//         // 2. Initialize pointers and variables
//         int left = 0;
//         int right = 0;
//         int count = t.Length; // Total characters we need to find
//         int minLen = int.MaxValue;
//         int startIndex = 0;

//         // 3. Start the Sliding Window (Expand Right)
//         while (right < s.Length)
//         {
//             char rChar = s[right];

//             // If map[rChar] > 0, it means this is a character we NEED.
//             // So we decrease the total 'count' of missing chars.
//             if (map[rChar] > 0)
//             {
//                 count--;
//             }

//             // Decrease frequency in map (it can go negative if we have extras)
//             map[rChar]--;
//             right++;

//             // 4. Optimize the Window (Shrink Left)
//             // While 'count' is 0, our window is valid (contains all chars).
//             while (count == 0)
//             {
//                 // Check if this is the new smallest window
//                 if (right - left < minLen)
//                 {
//                     minLen = right - left;
//                     startIndex = left;
//                 }

//                 char lChar = s[left];

//                 // We are about to remove lChar from the window, so add it back to map
//                 map[lChar]++;

//                 // If map[lChar] becomes > 0, it means we just removed a NEEDED char.
//                 // So our window is no longer valid, and we must increase 'count'.
//                 if (map[lChar] > 0)
//                 {
//                     count++;
//                 }

//                 left++;
//             }
//         }

//         // Return result
//         if (minLen == int.MaxValue) return "";
//         return s.Substring(startIndex, minLen);
//     }
// }