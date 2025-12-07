namespace CSharp.Topics.BinarySearch
{
    public class KokoEatingBananas
    {
        public static int TotalHoursNeeded(int[] piles, int speed)
        {
            int totalHoursNeeded = 0;

            foreach (var pile in piles)
            {
                totalHoursNeeded += pile / speed + (pile % speed != 0 ? 1 : 0);
            }

            return totalHoursNeeded > 0 ? totalHoursNeeded : -1;
        }

        public static int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1, right = -1;
            foreach (var e in piles) right = Math.Max(right, e);

            int minEatingSpeed = right;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                int totalHoursNeeded = TotalHoursNeeded(piles, mid);

                if (totalHoursNeeded != -1 && totalHoursNeeded <= h)
                {
                    minEatingSpeed = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return minEatingSpeed;
        }

        public static void Run()
        {
            int[] piles = new int[] { 805306368, 805306368, 805306368 };
            int h = 1000000000;

            System.Console.WriteLine(MinEatingSpeed(piles, h));
        }
    }
}