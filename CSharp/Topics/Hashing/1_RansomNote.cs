namespace CSharp.Topics.Hashing
{
    public class RansomNote
    {

        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var ransomNoteMapping = new Dictionary<char, int>();

            foreach (var c in ransomNote)
            {
                ransomNoteMapping[c] = ransomNoteMapping.GetValueOrDefault(c) + 1;
            }

            foreach (var c in magazine)
            {
                if (ransomNoteMapping.TryGetValue(c, out var _))
                {
                    ransomNoteMapping[c]--;
                }
            }

            foreach (var c in ransomNoteMapping.Values)
            {
                if (c is not 0) return false;
            }

            return true;
        }

        public static void Run()
        {
            var ransomNote = "aa";
            var magazine = "aab";

            System.Console.WriteLine(CanConstruct(ransomNote, magazine));
        }
    }
}

/*

1 ms | Optimized

class Solution {
    public boolean canConstruct(String ransomNote, String magazine) {
		if (ransomNote.length() > magazine.length()) return false;
        int[] alphabets_counter = new int[26];
        
        for (char c : magazine.toCharArray())
            alphabets_counter[c-'a']++;

        for (char c : ransomNote.toCharArray()){
            if (alphabets_counter[c-'a'] == 0) return false;
            alphabets_counter[c-'a']--;
        }
        return true;
    }
}
*/