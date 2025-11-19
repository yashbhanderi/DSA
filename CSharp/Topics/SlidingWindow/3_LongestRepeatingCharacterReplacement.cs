namespace CSharp.Topics.SlidingWindow
{
    public class LongestRepeatingCharacterReplacement
    {
        public static int CharacterReplacement(string str, int k)
        {
            int n = str.Length, left = 0, longestSubstring = 0, maxCount = 0;
            var map = new Dictionary<char, int>();

            for (int right = 0; right < n; right++)
            {
                var currentChar = str[right];
                map[currentChar] = map.GetValueOrDefault(currentChar) + 1;

                // It current char freq is not max, we still have last max count frequency
                // This say we do not need to worry about current char is main character/highest occured char in 
                // current window or not, why this is important?
                // If we get to know that given char freq is max in the window -> then we can directly know limit is reached or not

                /*
                The genius part: We don't care if maxCount represents a character that's actually still in the window at its old frequency. We only use it as a theoretical upper bound to shrink the window. Once maxCount is set, it's an optimistic estimate that never gets revised downward.

Why it's safe: By keeping maxCount high, we ensure the window shrinks conservatively. We never expand into an invalid state because the condition remains appropriately restrictive.

So yes—maxCount can represent outdated information, but that's intentional and correct. It's a clever optimization trick that avoids the overhead of recalculating the true max frequency every iteration.
                */

                maxCount = Math.Max(maxCount, map[currentChar]);

                while (right - left + 1 - maxCount > k)
                {
                    map[str[left]]--;
                    left++;
                }

                longestSubstring = Math.Max(right - left + 1, longestSubstring);
            }

            return longestSubstring;
        }

        public static void Run()
        {
            var s = "AABABBA";
            var k = 1;

            System.Console.WriteLine(CharacterReplacement(s, k));
        }
    }
}