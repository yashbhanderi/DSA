using System.Collections.Generic;
using System.Linq;

namespace neetcode.StackQueue
{
    public class DailyTemperatures
    {
        public static int[] GetDailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] ans = new int[n];

            var nextGreaterElement = NextGreater(temperatures);

            System.Console.WriteLine(string.Join(",", nextGreaterElement));

            for (int i = n - 1; i >= 0; i--)
            {
                int nextGreaterElementIndex = nextGreaterElement[i];
                ans[i] = nextGreaterElement[i] == -1 ? 0 : (nextGreaterElement[i] - i);
            }

            return ans;
        }

        public static int[] NextGreater(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            var st = new Stack<int>(); // values

            for (int i = n - 1; i >= 0; i--)
            {
                while (st.Count > 0 && nums[st.Peek()] <= nums[i])
                    st.Pop();

                res[i] = st.Count == 0 ? -1 : st.Peek();
                st.Push(i);
            }

            return res;
        }

        public static void Main()
        {
            var arr = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
            System.Console.WriteLine(string.Join(",", GetDailyTemperatures(arr)));
        }
    }
}