namespace neetcode.Arrays
{
    public class MoveZeroes
    {
        public static void MoveZero(int[] nums)
        {
            var n = nums.Length;
            var ptr = 0;

            for (var i = 0; i < n; i++)
            {
                if (nums[i] != 0)
                {
                    nums[ptr++] = nums[i];
                }
            }

            for (var i = ptr; i < n; i++)
            {
                nums[ptr++] = 0;
            }
        }

        public static void Main()
        {
            var arr = new int[] { 0, 1, 0, 3, 12 };
            MoveZero(arr);

            System.Console.WriteLine(string.Join(",", arr));
        }
    }
}