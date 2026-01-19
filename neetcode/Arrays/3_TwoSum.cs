using System;
using System.Collections.Generic;

namespace neetcode.Arrays
{
    public class TwoSum
    {
        public static int[] FindTwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var neededElement = target - nums[i];
                if (map.TryGetValue(neededElement, out var neededElementIndex))
                {
                    return [i, neededElementIndex];
                }
                map.TryAdd(nums[i], i);
            }

            return [];
        }

        public static void Main()
        {
            var nums = new int[] { 2, 7, 7, 15 };
            var target = 13;

            System.Console.WriteLine(string.Join(",", FindTwoSum(nums, target)));
        }
    }
}