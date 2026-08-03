namespace DSA.Recursion
{
    public class Subsets
    {

        public static void Main()
        {
            int[] nums = [1, 2, 3];

            var subsets = ListSubsets(nums);
            foreach (var e in subsets)
            {
                System.Console.WriteLine(string.Join(",", e));
            }
        }

        public static IList<IList<int>> ListSubsets(int[] nums)
        {
            var resultList = new List<IList<int>>();
            var currentList = new List<int>();

            Solve(nums, resultList, currentList, 0);

            return resultList;
        }

        public static void Solve(int[] nums, List<IList<int>> resultList, List<int> currentList, int currentIndex)
        {
            if (currentIndex >= nums.Length || currentIndex < 0)
            {
                System.Console.WriteLine(string.Join(",", currentList));
                resultList.Add(currentList);
                return;
            }

            currentList.Add(nums[currentIndex]);
            Solve(nums, resultList, currentList, currentIndex + 1);

            currentList.Remove(nums[currentIndex]);
            Solve(nums, resultList, currentList, currentIndex + 1);
        }
    }
}