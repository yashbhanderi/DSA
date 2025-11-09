namespace CSharp.Topics.Arrays
{
    public class SortArrayWith012
    {

        public static void DutchNationFlagAlgo(int[] arr)
        {
            var n = arr.Length;
            int zeroPtr = 0, onePtr = 0, twoPtr = n - 1;

            while (onePtr <= twoPtr)
            {
                if (arr[onePtr] == 2)
                {
                    var currentValueAtTwoPtr = arr[twoPtr];
                    arr[twoPtr--] = 2;
                    arr[onePtr] = currentValueAtTwoPtr;
                }
                else if (arr[onePtr] == 0)
                {
                    var currentValueAtZeroPtr = arr[zeroPtr];
                    arr[zeroPtr++] = 0;
                    arr[onePtr++] = currentValueAtZeroPtr;
                }
                else
                {
                    onePtr++;
                }
            }
        }

        public static void Run()
        {
            var arr = new int[] { 2, 0, 1 };

            DutchNationFlagAlgo(arr);
            System.Console.WriteLine(string.Join(",", arr));
        }
    }
}