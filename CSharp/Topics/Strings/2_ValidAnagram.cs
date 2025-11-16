namespace CSharp.Topics.Strings
{
    public class ValidAnagram
    {
        public static bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            var map = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                var c1 = s1[i];
                var c2 = s2[i];
                map[c1] = map.GetValueOrDefault(c1) + 1;
                map[c2] = map.GetValueOrDefault(c2) - 1;
            }

            foreach (var val in map.Values)
            {
                if (val != 0) return false;
            }

            return true;
        }

        public static void Run()
        {
            var s1 = "anagram";
            var s2 = "nagaram";

            System.Console.WriteLine(IsAnagram(s1, s2));
        }
    }
}