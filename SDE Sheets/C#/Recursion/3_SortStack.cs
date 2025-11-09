using System;

namespace Recursion;

public class _3_SortStack
{

    // Recommended approach

    /*

        public Stack<Integer> sort(Stack<Integer> s)
        {
            if (s.empty() == true) {
                return s;
            }

            // Remove the top element
            int top = s.peek();
            s.pop();
            // Recursion for the remaining elements in the stack
            sort(s);
            // Insert the popped element back in the sorted stack
            sortedInsert(s, top);
            return s;
        }
        public static void sortedInsert(Stack<Integer> stack, int current) {
            if (stack.empty() == true || current > stack.peek()) {
                stack.push(current);
                return;
            }

            // Remove the top element
            int top = stack.peek();
            stack.pop();
            // Recursion for the remaining elements in the stack
            sortedInsert(stack, current);
            // Insert the popped element back in the stack
            stack.push(top);
        }

    */

    public static int IsSorted(Stack<int> stack)
    {
        var invalidElement = -1;

        var temp = new Stack<int>();

        while (stack.Count > 1)
        {

            var top = stack.Pop();
            temp.Push(top);

            if (top < stack.Peek())
            {
                invalidElement = stack.Pop();
                break;
            }
        }

        while (temp.Count > 0)
        {
            stack.Push(temp.Pop());
        }

        return invalidElement;
    }

    public static Stack<int> SortStack(Stack<int> stack)
    {
        var invalidElement = IsSorted(stack);

        if (invalidElement == -1) return stack;

        var temp = new Stack<int>();
        while (stack.Count > 0 && invalidElement <= stack.Peek())
        {
            temp.Push(stack.Pop());
        }

        stack.Push(invalidElement);

        while (temp.Count > 0)
        {
            stack.Push(temp.Pop());
        }

        return SortStack(stack);
    }

    public static void Run()
    {
        var stack = new Stack<int>();

        stack.Push(41);
        stack.Push(3);
        stack.Push(32);
        stack.Push(2);
        stack.Push(11);

        var ans = SortStack(stack);
        while (ans.Count > 0)
        {
            System.Console.Write(ans.Pop() + " ");
        }
    }
}
