namespace CSharp.Topics.SlidingWindow
{
    public class PermutationInString
    {
        public static bool CheckInclusion(string s1, string s2)
        {
            var map1 = new Dictionary<char, int>();
            foreach (var c in s1)
            {
                map1[c] = map1.GetValueOrDefault(c) + 1;
            }

            int n = s2.Length, left = 0, windowLength = s1.Length;
            var map2 = new Dictionary<char, int>();

            for (int right = 0; right < n; right++)
            {
                var currentChar = s2[right];
                map2[currentChar] = map2.GetValueOrDefault(currentChar) + 1;

                while (right - left + 1 > windowLength)
                {
                    map2[s2[left]]--;
                    left++;
                }

                if (map1.All(kvp => map2.ContainsKey(kvp.Key) && map2[kvp.Key] == kvp.Value))
                {
                    return true;
                }
            }

            return false;
        }

        public static void Run()
        {
            string s1 = "dca", s2 = "dcda";
            System.Console.WriteLine(CheckInclusion(s1, s2));
        }
    }
}