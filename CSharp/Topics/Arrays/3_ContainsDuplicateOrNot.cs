namespace CSharp.Topics.Arrays
{
    public class ContainsDuplicateOrNot
    {
        public static bool IsArrayContainsDuplicate(int[] arr)
        {
            var arrayWithDistinctElements = new HashSet<int>(arr);

            return arrayWithDistinctElements.Count != arr.Length;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 2, 3, 1 };

            System.Console.WriteLine(IsArrayContainsDuplicate(arr));
        }
    }
}