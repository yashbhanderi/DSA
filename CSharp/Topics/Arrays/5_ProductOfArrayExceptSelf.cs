namespace CSharp.Topics.Arrays
{
    public class ProductOfArrayExceptSelf
    {
        public static int[] ProductExceptSelf(int[] arr)
        {
            var n = arr.Length;

            var prefixArr = arr.ToArray();
            var suffixArr = arr.ToArray();

            for (int i = 0, j = n - 1; i < n && j >= 0; i++, j--)
            {
                prefixArr[i] = prefixArr[i] * (i == 0 ? 1 : prefixArr[i - 1]);
                suffixArr[j] = suffixArr[j] * (j == n - 1 ? 1 : suffixArr[j + 1]);
            }

            var result = new int[n];
            for (int i = 0; i < n; i++)
            {
                var firstElement = i - 1 >= 0 ? prefixArr[i - 1] : 1;
                var secondElement = i + 1 < n ? suffixArr[i + 1] : 1;

                result[i] = firstElement * secondElement;
            }

            return result;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 2, 3, 4 };
            System.Console.WriteLine(string.Join(",", ProductExceptSelf(arr)));
        }
    }
}