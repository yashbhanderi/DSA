namespace CSharp.Topics.StackQueue
{
    public class LargestRectangleInHistogram
    {
        private static int[] NextSmallerElementLeft(int[] heights)
        {
            var n = heights.Length;
            var stack = new Stack<int>();
            var nextSmallerElementLeftArray = new int[n];

            for (var i = 0; i < n; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    // First index on left side where element at that index is smaller than current element
                    nextSmallerElementLeftArray[i] = stack.Peek();
                }
                else
                {
                    // No smaller element found till start of array, hence set it as first index
                    nextSmallerElementLeftArray[i] = -1;
                }

                stack.Push(i);
            }

            return nextSmallerElementLeftArray;
        }

        private static int[] NextSmallerElementRight(int[] heights)
        {
            var n = heights.Length;
            var stack = new Stack<int>();
            var nextSmallerElementRightArray = new int[n];

            for (var i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    // First index on left side where element at that index is smaller than current element
                    nextSmallerElementRightArray[i] = stack.Peek();
                }
                else
                {
                    // No smaller element found till start of array, hence set it as first index
                    nextSmallerElementRightArray[i] = n;
                }

                stack.Push(i);
            }

            return nextSmallerElementRightArray;
        }

        public static int LargestRectangleArea(int[] heights)
        {
            var n = heights.Length;
            var nextSmallerElementLeftArray = NextSmallerElementLeft(heights);
            var nextSmallerElementRightArray = NextSmallerElementRight(heights);
            var largestRectangleArea = int.MinValue;

            for (var i = 0; i < n; i++)
            {
                var height = heights[i];
                var width = 1; // own width

                // left side width
                width += (i - nextSmallerElementLeftArray[i]) - 1;

                // right side width
                width += (nextSmallerElementRightArray[i] - i) - 1;

                var finalRectangleArea = height * width;

                largestRectangleArea = Math.Max(finalRectangleArea, largestRectangleArea);
            }

            return largestRectangleArea;
        }

        public static void Run()
        {
            var heights = new int[] { 2, 4 };

            System.Console.WriteLine(LargestRectangleArea(heights));
        }
    }
}