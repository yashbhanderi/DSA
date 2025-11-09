namespace CSharp.Topics.Arrays;

public class MaximumSubarray
{
    public static int MaxSubarray(int[] arr)
    {
        var n = arr.Length;
        var largestSumTillNow = int.MinValue;
        var currentLargestSum = 0;

        foreach (var e in arr)
        {
            currentLargestSum += e;

            if (currentLargestSum >= largestSumTillNow)
            {
                largestSumTillNow = currentLargestSum;
            }

            if (currentLargestSum < 0) currentLargestSum = 0;
        }

        return largestSumTillNow;
    }

    public static void Run()
    {
        var arr = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        System.Console.WriteLine(MaxSubarray(arr));
    }
}