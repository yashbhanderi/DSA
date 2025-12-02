namespace CSharp.Topics.StackQueue
{
    public class TrappingRainWater
    {
        private static int[] NextGreaterElementLeft(int[] height)
        {
            var n = height.Length;
            var stack = new Stack<int>();
            var nextGreaterElementLeftArray = new int[n];

            for (var i = 0; i < n; i++)
            {
                while (stack.Count > 0 && stack.Peek() <= height[i])
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    nextGreaterElementLeftArray[i] = stack.Peek();
                }
                else
                {
                    nextGreaterElementLeftArray[i] = -1;
                    stack.Push(height[i]);
                }

            }

            return nextGreaterElementLeftArray;
        }

        private static int[] NextGreaterElementRight(int[] height)
        {
            var n = height.Length;
            var stack = new Stack<int>();
            var nextGreaterElementRightArray = new int[n];

            for (var i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= height[i])
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    nextGreaterElementRightArray[i] = stack.Peek();
                }
                else
                {
                    nextGreaterElementRightArray[i] = -1;
                    stack.Push(height[i]);
                }
            }

            return nextGreaterElementRightArray;
        }

        public static int Trap(int[] height)
        {
            var n = height.Length;
            var nextGreaterElementLeftArray = NextGreaterElementLeft(height);
            var nextGreaterElementRightArray = NextGreaterElementRight(height);

            var trappedWater = 0;
            for (var i = 0; i < n; i++)
            {
                var leftCapacity = nextGreaterElementLeftArray[i];
                var rightCapacity = nextGreaterElementRightArray[i];
                var trappingCapacity = Math.Min(leftCapacity, rightCapacity);

                if(trappingCapacity != -1 && trappingCapacity - height[i] > 0)
                {
                    trappedWater += trappingCapacity - height[i];
                }
            }

            return trappedWater;
        }

        public static void Run()
        {
            var height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            System.Console.WriteLine(Trap(height));
        }
    }
}