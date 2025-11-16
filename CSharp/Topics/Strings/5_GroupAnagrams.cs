public class GroupAnagrams  {

    public static IList<IList<string>> GroupAnagram(string[] strs)
    {
        IList<IList<string>> result = [];
        var map = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var charList = Enumerable.Repeat(0, 26).ToList();
            for (int i = 0; i < str.Length; i++)
            {
                var currentCharIndex = str[i] - 'a';
                charList[currentCharIndex]++;
            }

            var charListKey = string.Join("-", charList);
            if (map.TryGetValue(charListKey, out var oldList))
            {
                oldList.Add(str);
            }
            else
            {
                map[charListKey] = [str];
            }
        }

        foreach (var r in map.Values)
        {
            result.Add(r);
        }

        return result;
    }

    public static void Run() {
        var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

        var groupedAnagrams = GroupAnagram(strs);
        foreach(var groupedAnagram in groupedAnagrams)
        {
            System.Console.WriteLine(string.Join(",", groupedAnagram));
        }
    }
}