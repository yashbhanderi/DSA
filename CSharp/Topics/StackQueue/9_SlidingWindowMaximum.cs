namespace CSharp.Topics.StackQueue
{
    public class SlidingWindowMaximum
    {
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var n = nums.Length;
            var deque = new Deque<int>();
            var ans = new int[n - k + 1];

            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (i >= k)
                {
                    var currentMax = deque.PeekFront();
                    if(cnt == deque.PeekFront())
                    {
                        deque.PopFront();
                    }
                    ans[cnt++] = nums[currentMax];
                }

                while (!deque.IsEmpty() && nums[i] > nums[deque.PeekRear()])
                {
                    deque.PopRear();
                }

                deque.PushRear(i);
            }
            ans[cnt] = nums[deque.PeekFront()];

            return ans;
        }

        public static void Run()
        {
            var nums = new int[] { 9, 10, 9, -7, -4, -8, 2, -6 };
            var k = 5;

            System.Console.WriteLine(string.Join(",", MaxSlidingWindow(nums, k)));
        }
    }
}