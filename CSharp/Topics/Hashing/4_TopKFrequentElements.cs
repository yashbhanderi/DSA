namespace CSharp.Topics.Hashing
{
    public class TopKFrequentElements
    {

        public static int[] TopKFrequent(int[] nums, int k)
        {
            var n = nums.Length;

            var frequencyMapping = new Dictionary<int, int>();
            foreach (var e in nums)
            {
                frequencyMapping[e] = frequencyMapping.GetValueOrDefault(e) + 1;
            }

            var pq = new PriorityQueue<(int key, int value), int>(
                frequencyMapping.Select(kv => ((kv.Key, kv.Value), -kv.Value))
            );

            var topKFrequentElements = new int[k];
            int i = 0;
            for (int j = 0; j < k; j++)
            {
                topKFrequentElements[i++] = pq.Dequeue().key;
            }

            return topKFrequentElements;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 2, 1, 2, 1, 2, 3, 1, 3, 2 };
            var k = 2;
            System.Console.WriteLine(string.Join(",", TopKFrequent(arr, k)));
        }
    }
}