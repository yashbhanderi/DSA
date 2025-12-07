namespace CSharp.Topics.BinarySearch
{
    public class MinimumNumberOfDaysToMakeMBouquets
    {
        public static bool IsPossibleToMakeBouquets(int[] bloomday, int m, int k, int minDaysNeeded)
        {
            int i = 0, n = bloomday.Length, bouguetsMade = 0;
            while (i < n)
            {
                int cnt = 0;
                while (i < n && bloomday[i] <= minDaysNeeded)
                {
                    cnt++;
                    i++;
                }

                bouguetsMade += cnt/k;

                if (bouguetsMade >= m)
                {
                    return true;
                }

                i++;
            }

            return bouguetsMade >= m;
        }

        public static int MinDays(int[] bloomDay, int m, int k)
        {
            if (m * k > bloomDay.Length) return -1;

            int left = int.MaxValue, right = int.MinValue, minDaysNeeded = -1;
            foreach (var e in bloomDay)
            {
                left = Math.Min(e, left);
                right = Math.Max(e, right);
            }

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (IsPossibleToMakeBouquets(bloomDay, m, k, mid))
                {
                    minDaysNeeded = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return minDaysNeeded;
        }

        public static void Run()
        {
            var bloomDay = new int[] { 1, 10, 2, 9, 3, 8, 4, 7, 5, 6 };
            var m = 4;
            var k = 2;

            System.Console.WriteLine(MinDays(bloomDay, m, k));
        }
    }
}