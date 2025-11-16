namespace CSharp.Topics.TwoPointers
{
    public class ContainerWithMostWater
    {

        public static int MaxArea(int[] height)
        {
            int n = height.Length;
            int start = 0, end = n - 1;
            int maxArea = int.MinValue;

            while (start < end)
            {
                int lowerArea = height[start] <= height[end] ? height[start] : height[end];
                int currentArea = (end - start) * lowerArea;

                maxArea = Math.Max(currentArea, maxArea);

                if (height[start] == lowerArea)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }

            return maxArea;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 1 };
            System.Console.WriteLine(MaxArea(arr));
        }
    }
}