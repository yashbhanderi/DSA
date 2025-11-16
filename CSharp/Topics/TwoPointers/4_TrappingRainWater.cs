namespace CSharp.Topics.TwoPointers
{
    public class TrappingRainWater
    {
        public static int Trap(int[] height)
        {
            int n = height.Length;
            var leftMostHeights = new int[n];
            var rightMostHeights = new int[n];

            // Left most heights
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    leftMostHeights[i] = height[i];
                }
                else
                {
                    leftMostHeights[i] = height[i] > leftMostHeights[i - 1] ? height[i] : leftMostHeights[i - 1];
                }
            }

            // Right most heights
            for (int j = n - 1; j >= 0; j--)
            {
                if (j == n - 1)
                {
                    rightMostHeights[j] = height[j];
                }
                else
                {
                    rightMostHeights[j] = height[j] > rightMostHeights[j + 1] ? height[j] : rightMostHeights[j + 1];
                }
            }

            // Calculate Rain Water
            int unitsOfRainWater = 0;
            for (int i = 0; i < n; i++)
            {
                int rightMostHeight = i + 1 < n ? rightMostHeights[i + 1] : rightMostHeights[i];
                int leftMostHeight = i - 1 >= 0 ? leftMostHeights[i - 1] : leftMostHeights[i];
                int area = Math.Min(leftMostHeight, rightMostHeight) - height[i];

                if (area > 0) unitsOfRainWater += area;
            }

            return unitsOfRainWater;
        }

        public static void Run()
        {
            var arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            System.Console.WriteLine(Trap(arr));
        }
    }
}