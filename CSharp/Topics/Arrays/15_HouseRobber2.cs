namespace CSharp.Topics.Arrays;

public class HouseRobber2
{
    public static int Rob(int[] nums)
    {
        var n = nums.Length;

        if (n <= 3)
        {
            return nums.Max();
        }
        
        var maxSumTillNowArray = (int[])nums.Clone();
        var maxAmount = 0;
        
        for (var i = 0; i < n; i++)
        {
            int current = i, nextPossible = (i + 2) % n;

            if (current >= n - 2)
            {
                maxSumTillNowArray[current] =
                    Math.Max(maxAmount, maxSumTillNowArray[current] + nums[nextPossible]);
            }
            else
            {
                maxSumTillNowArray[current] =
                    Math.Max(maxAmount, maxSumTillNowArray[current] + maxSumTillNowArray[nextPossible]);
            }

            maxAmount = Math.Max(maxAmount, maxSumTillNowArray[current]);
        }

        return maxAmount;
    }

    public static void Run()
    {
        var arr = new int[] { 4,1,2,7,5,3,1 };
        Console.WriteLine(Rob(arr));
    }
}