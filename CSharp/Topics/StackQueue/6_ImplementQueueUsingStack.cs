namespace CSharp.Topics.StackQueue
{
    public class ImplementQueueUsingStack
    {

        public class MyQueue
        {
            Stack<int> mainStack;
            Stack<int> tempStack;

            public MyQueue()
            {
                mainStack = new Stack<int>();
                tempStack = new Stack<int>();
            }

            public void Push(int x)
            {
                if (mainStack.Count == 0)
                {
                    mainStack.Push(x);
                }
                else
                {
                    while (mainStack.Count > 0)
                    {
                        tempStack.Push(mainStack.Pop());
                    }
                    mainStack.Push(x);
                    while (tempStack.Count > 0)
                    {
                        mainStack.Push(tempStack.Pop());
                    }
                }
            }

            public int Pop()
            {
                return mainStack.Pop();
            }

            public int Peek()
            {
                return mainStack.Peek();
            }

            public bool Empty()
            {
                return mainStack.Count == 0;
            }
        }
    }
}