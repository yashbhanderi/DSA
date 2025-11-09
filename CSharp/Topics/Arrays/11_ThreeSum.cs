namespace CSharp.Topics.Arrays
{
    public class ThreeSum
    {
        public static IList<IList<int>> TripletsWithZeroSum(int[] arr)
        {
            Array.Sort(arr);

            int n = arr.Length;
            IList<IList<int>> tripletsWithZeroSum = [];

            for (int i = 0; i < n - 2; i++)
            {
                int targetSum = 0 - arr[i];

                int j = i + 1, k = n - 1;

                while (j < k)
                {
                    int currentSum = arr[j] + arr[k];

                    if (currentSum == targetSum)
                    {
                        var triplet = new List<int>() { arr[i], arr[j], arr[k] };
                        tripletsWithZeroSum.Add(triplet);

                        // To get rid of duplicate pairs
                        while (j + 1 < k && arr[j + 1] == arr[j]) j++;
                        while (k - 1 > j && arr[k - 1] == arr[k]) k--;

                        // we got one pair, now to check If we can found more by looking INSIDE the array.
                        j++;
                        k--;
                    }

                    else if (currentSum < targetSum)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }

                while (i + 1 < n && arr[i + 1] == arr[i]) i++;
            }

            return tripletsWithZeroSum;
        }

        public static void Run()
        {
            var arr = new int[] { -1, 0, 1, 2, -1, -4 };

            var result = TripletsWithZeroSum(arr);

            foreach(var triplet in result)
            {
                System.Console.WriteLine(string.Join(",", triplet));
            }
        }
    }
}