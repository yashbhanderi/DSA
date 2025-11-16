namespace CSharp.Topics.Strings
{
    public class LongestSubstringWithoutRepeatingCharacters
    {

        public static int LengthOfLongestSubstring(string str)
        {
            int lengthOfLongestSubstring = 0;
            var lastIndexMapping = new Dictionary<char, int>();

            int n = str.Length;
            int left = 0, right = 0;

            while (right < n)
            {

                if (lastIndexMapping.TryGetValue(str[right], out var lastIndex) && left <= lastIndex)
                {
                    left = lastIndex + 1;
                }

                lastIndexMapping[str[right]] = right;
                lengthOfLongestSubstring = Math.Max(right - left + 1, lengthOfLongestSubstring);
                right++;
            }

            return lengthOfLongestSubstring;
        }

        public static void Run()
        {
            var s = "abba";
            System.Console.WriteLine(LengthOfLongestSubstring(s));
        }
    }
}