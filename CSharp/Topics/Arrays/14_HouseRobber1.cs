namespace CSharp.Topics.Arrays;

public class HouseRobber1
{
    public static int Rob(int[] nums)
    {
        int prev2 = 0; // dp[i-2], Money we got on prev to prev house, which we can use
        int prev1 = 0; // dp[i-1], Money we got on prev house

        foreach (int num in nums)
        {
            int curr = Math.Max(prev1, prev2 + num);    // Either we can rob current house OR skip it
            prev2 = prev1;
            prev1 = curr;
        }

        return prev1;
    }

    public static void Run()
    {
        var arr = new int[] { 4,1,2,7,5,3,1 };
        Console.WriteLine(Rob(arr));
    }
}