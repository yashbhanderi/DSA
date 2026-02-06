namespace neetcode.SlidingWindow
{
    public class BestTimeToBuyAndSellStocks
    {
        public static int MaxProfit(int[] arr)
        {
            int n = arr.Length;

            int maxProfit = 0;
            int minPriceTillNow = arr[0];

            for (int i = 1; i < n; i++)
            {
                int currentProfit = arr[i] - minPriceTillNow;

                if (currentProfit > maxProfit)
                {
                    maxProfit = currentProfit;
                }

                if (arr[i] < minPriceTillNow)
                {
                    minPriceTillNow = arr[i];
                }
            }

            return maxProfit;
        }

        public static void Main()
        {
            var arr = new int[] { 7, 6, 4, 3, 1 };
            System.Console.WriteLine(MaxProfit(arr));
        }
    }
}