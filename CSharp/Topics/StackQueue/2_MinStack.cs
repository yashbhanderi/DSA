namespace CSharp.Topics.StackQueue
{
    public class MinStack
    {
        Stack<int> stack;
        Stack<int> minValueStack;

        public MinStack()
        {
            stack = new Stack<int>();
            minValueStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);

            if (minValueStack.Count == 0 || val <= minValueStack.Peek())
            {
                minValueStack.Push(val);
            }
        }

        public void Pop()
        {
            var val = stack.Pop();
            if (val == minValueStack.Peek())
            {
                minValueStack.Pop();
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minValueStack.Peek();
        }

        public static void Run()
        {

        }
    }
}