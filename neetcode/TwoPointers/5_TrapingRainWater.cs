using System;
using System.Collections.Generic;

namespace neetcode.TwoPointers
{
    public class TrapingRainWater
    {
        public static int Trap(int[] height)
        {
            var NextGreatestElementsLeft = NextGreatestLeft(height);
            var NextGreatestElementsRight = NextGreatestRight(height);
            var trappedWater = 0;

            for (var i = 0; i < height.Length; i++)
            {
                var NextGreatestOnLeft = NextGreatestElementsLeft[i];
                var NextGreatestOnRight = NextGreatestElementsRight[i];

                if (NextGreatestOnLeft > height[i] && NextGreatestOnRight > height[i])
                {
                    trappedWater += Math.Min(NextGreatestOnLeft, NextGreatestOnRight) - height[i];
                }
            }

            return trappedWater;
        }

        // Next Greater Element on Right
        public static int[] NextGreatestRight(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];
            result[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                result[i] = Math.Max(result[i + 1], arr[i]);
            return result;
        }

        // Next Greater Element on Left
        public static int[] NextGreatestLeft(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];
            result[0] = arr[0];
            for (int i = 1; i < n; i++)
                result[i] = Math.Max(result[i - 1], arr[i]);
            return result;
        }

        public static void Main()
        {
            var heights = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            System.Console.WriteLine(Trap(heights));
        }
    }
}