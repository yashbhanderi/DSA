namespace CSharp.Topics.TwoPointers
{
    public class RemoveDuplicatesFromSortedArray
    {

        public static int RemoveDuplicates(int[] nums) {
            int currentPtr = 0, mainPtr = 0;

            int n = nums.Length;

            while(currentPtr < n)
            {
                while(currentPtr+1 < n && nums[currentPtr] == nums[currentPtr+1]) currentPtr++;

                nums[mainPtr++] = nums[currentPtr++];
            }

            return mainPtr;
        }

        public static void Run()
        {
            var arr = new int[] {0,0,0};
            System.Console.WriteLine(RemoveDuplicates(arr));
        }
    }
}