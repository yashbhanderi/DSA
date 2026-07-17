namespace DSA.Graph
{
    public class WordLadder
    {

        public static void Main()
        {
            var beginWord = "hit";
            var endWord = "cog";
            string[] wordList = ["hot", "dot", "dog", "lot", "log", "cog"];

            System.Console.WriteLine(LadderLength(beginWord, endWord, wordList));
        }

        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
            {
                return 0;
            }

            var adjList = BuildAdjList(wordList);

            var queue = new Queue<(string, int)>();
            var visited = new HashSet<string>();

            queue.Enqueue((beginWord, 1));

            while (queue.Count > 0)
            {
                var currentItem = queue.Dequeue();
                var currentWord = currentItem.Item1;
                var distance = currentItem.Item2;

                if (currentWord.Equals(endWord, StringComparison.Ordinal)) return distance;

                for (int i = 0; i < currentWord.Length; i++)
                {
                    var pattern = string.Concat(currentWord.AsSpan(0, i), "*", currentWord.AsSpan(i + 1));

                    if (adjList.TryGetValue(pattern, out List<string>? list))
                    {
                        foreach (var str in list)
                        {
                            if (!visited.Contains(str))
                            {
                                queue.Enqueue((str, distance + 1));
                                visited.Add(str);
                            }
                        }

                        adjList[pattern].Clear();
                    }
                }
            }

            return 0;
        }

        public static Dictionary<string, List<string>> BuildAdjList(IList<string> wordList)
        {
            var patternMap = new Dictionary<string, List<string>>();

            foreach (var word in wordList)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    var pattern = string.Concat(word.AsSpan(0, i), "*", word.AsSpan(i + 1));

                    if (!patternMap.TryGetValue(pattern, out List<string>? value))
                    {
                        value = [];
                        patternMap[pattern] = value;
                    }

                    value.Add(word);
                }
            }

            return patternMap;
        }
    }
}