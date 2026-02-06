using System.Collections;
using System.Collections.Generic;

public class MinStack
{

    Stack<int> currentStack;
    Stack<int> minStack;

    public MinStack()
    {
        currentStack = new Stack<int>();
        minStack = new Stack<int>();
    }

    public void Push(int val)
    {
        currentStack.Push(val);
        if (minStack.Count == 0) minStack.Push(val);
        else if (val <= minStack.Peek()) minStack.Push(val);
    }

    public void Pop()
    {
        var top = currentStack.Pop();
        if (minStack.Count > 0 && minStack.Peek() == top) minStack.Pop();
    }

    public int Top()
    {
        return currentStack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }

    public static void Main()
    {

    }
}