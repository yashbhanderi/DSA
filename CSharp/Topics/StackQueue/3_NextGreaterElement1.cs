namespace CSharp.Topics.StackQueue
{
    public class NextGreaterElement1
    {
        public static int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var map = new Dictionary<int, int>();
            var stack = new Stack<int>();

            int n = nums2.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                // Loop until we get any element greater than current element
                while (stack.Count > 0 && stack.Peek() <= nums2[i])
                {
                    // We won't need smaller elements than current element
                    // Since, we're finding next greater element
                    // So, elements before than current element will have next greater element = current
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    map[nums2[i]] = stack.Peek();
                }

                stack.Push(nums2[i]);
            }

            var result = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                if (map.TryGetValue(nums1[i], out var nextGraterElement))
                {
                    result[i] = nextGraterElement;
                }
                else
                {
                    result[i] = -1;
                }
            }

            return result;

            // ------------ 2) Two Stack

            // var mainStack = new Stack<int>();
            // var tempStack = new Stack<int>();

            // foreach (var e in nums2)
            // {
            //     mainStack.Push(e);
            // }

            // var nGEArray = new int[nums1.Length];
            // for (int i = 0; i < nums1.Length; i++)
            // {
            //     // Keep track of highest element value until we find the exact element
            //     int nextGraterElement = nums1[i];
            //     while (mainStack.Count > 0 && mainStack.Peek() != nums1[i])
            //     {
            //         var peekElement = mainStack.Pop();
            //         if (peekElement > nums1[i])
            //         {
            //             nextGraterElement = peekElement;
            //         }
            //         tempStack.Push(peekElement);
            //     }

            //     // Set the next greater element for this array index element
            //     nGEArray[i] = nextGraterElement == nums1[i] ? -1 : nextGraterElement;

            //     // Push elements from temp stack to original main stack
            //     while (tempStack.Count > 0)
            //     {
            //         mainStack.Push(tempStack.Pop());
            //     }
            // }

            // return nGEArray;
        }

        public static void Run()
        {
            var nums1 = new int[] { 4, 1, 2 };
            var nums2 = new int[] { 1, 3, 4, 2 };

            var ans = NextGreaterElement(nums1, nums2);
            foreach (var e in ans)
            {
                System.Console.WriteLine(e);
            }
        }
    }
}