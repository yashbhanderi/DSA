namespace CSharp.Topics.Recursion
{
    public class Subsets
    {
        public static HashSet<IList<int>> SubsetsWithDup(int index, int[] nums, List<int> subArray, HashSet<IList<int>> list)
        {
            if (index == nums.Length)
            {
                list.Add([.. subArray]);
                return list;
            }

            subArray.Add(nums[index]);
            SubsetsWithDup(index + 1, nums, subArray, list);

            subArray.RemoveAt(subArray.Count - 1);
            SubsetsWithDup(index + 1, nums, subArray, list);
            
            return list;
        }

        public static void Run()
        {
            var nums = new int[] { 1, 2, 2 };

            HashSet<IList<int>> list = [];
            List<int> subArray = [];

            IList<IList<int>> result = SubsetsWithDup(0, nums, subArray, list).ToList();

            foreach (var e in result)
            {
                System.Console.WriteLine(string.Join(",", e));
            }
        }
    }
}