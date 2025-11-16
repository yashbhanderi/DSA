namespace CSharp.Topics.Strings
{
    public class LongestPalindromicSubstring
    {

        public static bool IsPalindrome(string s, int start, int end)
        {
            for (; start < end; start++, end--)
            {
                if (s[start] != s[end]) return false;
            }

            return true;
        }

        public static string LongestPalindrome(string str)
        {
            string longestPalindromeString = str[0].ToString();

            int left = 0, right = 1;
            while (right < str.Length)
            {
                if (IsPalindrome(str, left, right))
                {
                    longestPalindromeString = str.Substring(left, right - left + 1);
                }
                else
                {
                    left++;
                }

                right++;
            }

            return longestPalindromeString;
        }

        public static void Run()
        {
            var str = "babad";
            System.Console.WriteLine(LongestPalindrome(str));
        }
    }
}