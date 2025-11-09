namespace CSharp.Topics.Arrays
{
    public class MergeSortedArray
    {

        public static void MergeArray(int[] arr1, int arr1Length, int[] arr2, int arr2Length)
        {
            int ptr1 = arr1Length - 1, ptr2 = arr2Length - 1, currPtr = (arr1Length + arr2Length) - 1;

            while (ptr1 >= 0 && ptr2 >= 0)
            {
                if (arr1[ptr1] >= arr2[ptr2])
                {
                    arr1[currPtr--] = arr1[ptr1--];
                }
                else
                {
                    arr1[currPtr--] = arr2[ptr2--];
                }
            }

            while (ptr1 >= 0)
            {
                arr1[currPtr--] = arr1[ptr1--];
            }

            while (ptr2 >= 0)
            {
                arr2[currPtr--] = arr2[ptr2--];
            }
        }

        public static void Run()
        {

            var arr1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var arr1Length = 3;
            var arr2 = new int[] { 2, 5, 6 };
            var arr2Length = 3;

            MergeArray(arr1, arr1Length, arr2, arr2Length);
            System.Console.WriteLine(string.Join(",", arr1));
        }
    }
}