namespace CSharp.Topics.TwoPointers
{
    public class MoveZeroes
    {

        public static void MoveZeroesInArray(int[] nums)
        {
            int currentPtr = 0, mainPtr = 0;
            int n = nums.Length;

            while(currentPtr < n)
            {
                if(nums[currentPtr] != 0)
                {
                    nums[mainPtr++] = nums[currentPtr];
                }
                currentPtr++;
            }

            while(mainPtr < n)
            {
                nums[mainPtr++] = 0;
            }
        }

        public static void Run()
        {
            var arr = new int[] { 0, 1, 0, 3, 12 };
            MoveZeroesInArray(arr);
            System.Console.WriteLine(string.Join(",", arr));
        }   
    }
}