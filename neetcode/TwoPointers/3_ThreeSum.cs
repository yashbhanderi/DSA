using System;
using System.Collections.Generic;

namespace neetcode.TwoPointers
{
    public class ThreeSum
    {
        public static IList<IList<int>> ThreeSums(int[] nums)
        {
            if (nums.Length == 0) return [];

            var triplets = new List<IList<int>>();

            Array.Sort(nums);

            int n = nums.Length;
            for (int i = 0; i < n - 2; i++)
            {
                int target = 0 - nums[i];
                int j = i + 1, k = n - 1;

                while (j < k)
                {
                    int currentSum = nums[j] + nums[k];
                    if (currentSum == target)
                    {
                        triplets.Add([nums[i], nums[j], nums[k]]);

                        while (j + 1 < k && nums[j] == nums[j + 1]) j++;
                        while (k - 1 > j && nums[k] == nums[k - 1]) k--;

                        j++;
                        k--;
                    }
                    else if (currentSum < target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }

                while (i + 1 < n - 2 && nums[i] == nums[i + 1]) i++;
            }

            return triplets;
        }

        public static void Main()
        {
            var arr = new int[] { -1, 0, 1, 2, -1, -4 };
            var ans = ThreeSums(arr);

            foreach (var e in ans)
            {
                System.Console.WriteLine(string.Join(",", e));
            }
        }
    }
}