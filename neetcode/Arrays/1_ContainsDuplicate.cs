using System.Collections.Generic;

namespace neetcode.Arrays
{
    public class ContainsDuplicate
    {
        public static bool HasDuplicate(int[] nums)
        {
            var set = new HashSet<int>(nums);

            return set.Count != nums.Length;
        }

        public static void Main()
        {
            var nums = new int[] { 1, 2, 3, 4 };
            System.Console.WriteLine(HasDuplicate(nums));
        }
    }
}