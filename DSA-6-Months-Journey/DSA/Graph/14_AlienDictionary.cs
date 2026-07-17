public class AlienDictionary
{

    public static void Main()
    {
        string[] words = ["z", "z"];

        System.Console.WriteLine(ForeignDictionary(words));
    }

    public static string ForeignDictionary(string[] words)
    {
        int N = words.Length;
        var adjList = new Dictionary<char, HashSet<char>>();
        var inDegree = new Dictionary<char, int>();
        foreach (var word in words)
        {
            foreach (var ch in word)
            {
                adjList.TryAdd(ch, []);
                inDegree.TryAdd(ch, 0);
            }
        }
        for (int i = 0; i < N - 1; i++)
        {
            string word1 = words[i];
            string word2 = words[i + 1];
            int minLen = Math.Min(word1.Length, word2.Length);
            int j = 0;

            while (j < minLen && word1[j] == word2[j])
            {
                j++;
            }

            if (j == minLen && word1.Length > word2.Length) return "";

            if (j<minLen && adjList[word1[j]].Add(word2[j]))
            {
                inDegree[word2[j]]++;
            }
        }

        var queue = new Queue<char>();
        foreach (var e in inDegree)
        {
            if (e.Value == 0)
            {
                queue.Enqueue(e.Key);
            }
        }

        var result = "";
        while (queue.Count != 0)
        {
            var top = queue.Dequeue();
            result += top;

            foreach (var e in adjList[top])
            {
                if (inDegree[e] != 0)
                {
                    inDegree[e]--;

                    if (inDegree[e] == 0)
                    {
                        queue.Enqueue(e);
                    }
                }
            }
        }

        if (result.Length != inDegree.Count)
        {
            return "";
        }

        return result;
    }
}