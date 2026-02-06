using System;
using System.Collections.Generic;

namespace neetcode.StackQueue
{
    public class LargestRectangeInHistogram
    {
        public static int LargestRectangleArea(int[] arr)
        {
            int n = arr.Length;

            if (n == 1) return arr[0];

            var nextSmaller = NextSmaller(arr);
            var prevSmaller = PrevSmaller(arr);

            int largestArea = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int nextSmallerIndex = nextSmaller[i] == -1 ? n : nextSmaller[i];
                int prevSmallerIndex = prevSmaller[i];

                int height = arr[i];
                int width = Math.Max(0, i - prevSmallerIndex - 1) + (nextSmallerIndex - i);
                System.Console.WriteLine($"Element: {arr[i]}, Prev: {prevSmallerIndex}, Next: {nextSmallerIndex}");
                int area = height * width;

                largestArea = Math.Max(largestArea, area);
            }

            return largestArea;
        }

        public static int[] NextSmaller(int[] a)
        {
            int n = a.Length;
            var res = new int[n];
            var st = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (st.Count > 0 && a[st.Peek()] >= a[i]) st.Pop();
                res[i] = st.Count == 0 ? -1 : st.Peek();
                st.Push(i);
            }
            return res;
        }

        public static int[] PrevSmaller(int[] a)
        {
            int n = a.Length;
            var res = new int[n];
            var st = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (st.Count > 0 && a[st.Peek()] >= a[i]) st.Pop();
                res[i] = st.Count == 0 ? -1 : st.Peek();
                st.Push(i);
            }
            return res;
        }


        public static void Main()
        {
            var arr = new int[] { 2, 1, 2 };
            System.Console.WriteLine(LargestRectangleArea(arr));
        }
    }
}