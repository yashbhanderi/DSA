namespace CSharp.Topics.Arrays
{
    public class BestTimeToBuyAndSellStock
    {

        public static int Solve(int[] stockPrices)
        {
            int lowestPriceTillNow = int.MaxValue;
            int maxProfit = 0;

            foreach (var price in stockPrices)
            {
                lowestPriceTillNow = Math.Min(price, lowestPriceTillNow);
                maxProfit = Math.Max(price - lowestPriceTillNow, maxProfit);
            }

            return maxProfit;
        }

        public static void Run()
        {
            var arr = new int[] { 7, 1, 5, 3, 6, 4 };

            System.Console.WriteLine(Solve(arr));
        }
    }
}