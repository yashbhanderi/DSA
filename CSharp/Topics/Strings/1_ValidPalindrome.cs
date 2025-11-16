namespace CSharp.Topics.Strings
{
    public class ValidPalindrome
    {
        public static bool IsAlphaNumeric(char c) => (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');

        public static bool IsPalindrome(string str)
        {
            str = str.ToLower();
            int n = str.Length;
            int start = 0, end = n - 1;

            while (start < end)
            {
                while (start < end && !IsAlphaNumeric(str[start]))
                {
                    start++;
                }
                while (end > start && !IsAlphaNumeric(str[end]))
                {
                    end--;
                }

                if (start < end && !str[start++].Equals(str[end--]))
                {
                    return false;
                }
            }

            return true;
        }

        public static void Run()
        {
            var str = "0P";
            System.Console.WriteLine(IsPalindrome(str));
        }
    }
}