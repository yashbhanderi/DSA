namespace CSharp.Topics.BinarySearch
{
    public class CapacityToShipPackagesWithinDDays
    {
        public static int MinDaysNeededToShipPackages(int[] weights, int loadLimit)
        {
            int daysNeeded = 0, i = 0, n = weights.Length;

            while (i < n)
            {
                int totalLoad = 0;
                while (i < n && totalLoad + weights[i] <= loadLimit)
                {
                    totalLoad += weights[i];
                    i++;
                }

                if (totalLoad > 0)
                {
                    daysNeeded++;
                }
                else
                {
                    return -1;
                }
            }

            return daysNeeded;
        }

        public static int ShipWithinDays(int[] weights, int days)
        {
            int left = 1, right = weights.Sum(), minDaysNeeded = days;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                int minDays = MinDaysNeededToShipPackages(weights, mid);

                if (minDays != -1 && minDays <= days)
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
            var weights = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var days = 5;

            System.Console.WriteLine(ShipWithinDays(weights, days));
        }
    }
}