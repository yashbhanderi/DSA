namespace CSharp.Topics.StackQueue
{
    public class DailyTemperatures
    {
        public static int[] DailyTemperaturesList(int[] temperatures)
        {
            var n = temperatures.Length;
            var stack = new Stack<(int, int)>();
            var result = new int[n];

            for (int i = n - 1; i >= 0; i--)
            {
                int days = 1;
                // Loop until we get any element greater than current element
                while (stack.Count > 0 && stack.Peek().Item1 <= temperatures[i])
                {
                    // What is Item2 = Days Diff, till actual answer
                    // This needs to be recorded, since we're popping out items here if less than current element
                    // So, now, elements before the current element, won't have any info regarding this popped out elemenet
                    // Hence, we're record from scratch, how many elements we needed
                    // Then later If some element reach till current elemenet in Stack, it can get how many elements it has removed till now. 
                    days += stack.Peek().Item2;
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    result[i] = days;
                }

                stack.Push((temperatures[i], days));
            }

            return result;

            // More Optimized:

            // int[] result = new int[temperatures.Length]; // Initialize the result array with zeros
            // Stack<int> stack = new Stack<int>(); // Stack to keep track of indices

            // for (int i = 0; i < temperatures.Length; i++)
            // {
            //     int val = temperatures[i];
            //     // While stack is not empty and current temperature is greater than
            //     // the temperature represented by the index at the top of the stack
            //     while (stack.Count > 0 && val > temperatures[stack.Peek()])
            //     {
            //         int index = stack.Pop(); // Pop from the stack
            //         result[index] = i - index; // Update the result
            //     }
            //     stack.Push(i); // Add current temperature index to the stack
            // }

            // return result;
        }

        public static void Run()
        {
            var temperatures = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
            System.Console.WriteLine(string.Join(",", DailyTemperaturesList(temperatures)));
        }
    }
}