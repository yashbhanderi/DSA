using System.Linq;

namespace neetcode.TwoPointers
{
    public class ValidPalindrome
    {
        public static bool IsPalindrome(string s)
        {
            var str = s.ToLower();

            int left = 0, right = str.Length - 1;
            while (left < right)
            {
                if (!char.IsLetterOrDigit(str[left]))
                {
                    left++;
                    continue;
                }
                if (!char.IsLetterOrDigit(str[right]))
                {
                    right--;
                    continue;
                }
                if (str[left++] != str[right--]) return false;
            }

            return true;
        }

        public static void Main()
        {
            string s = "A man, a plan, a canal: Panama";
            System.Console.WriteLine(IsPalindrome(s));
        }
    }
}