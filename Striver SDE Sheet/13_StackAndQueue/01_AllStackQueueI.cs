// ============================================================
// Stack and Queue I — All 7 problems
// Topic: Stack & Queue Part I
// ============================================================
// Problems: Stack Using Array, Queue Using Array, Stack Using Queue,
//           Queue Using Stack, Valid Parentheses, Next Greater Element, Sort Stack
// ============================================================

using System;
using System.Collections.Generic;

// --- P1: Implement Stack Using Array ---
public class StackUsingArray
{
    private int[] arr;
    private int top = -1;
    public StackUsingArray(int size) { arr = new int[size]; }
    public void Push(int val) { arr[++top] = val; }
    public int Pop() => arr[top--];
    public int Peek() => arr[top];
    public bool IsEmpty() => top == -1;
}

// --- P2: Implement Queue Using Array ---
public class QueueUsingArray
{
    private int[] arr;
    private int front = 0, rear = -1, count = 0, size;
    public QueueUsingArray(int size) { this.size = size; arr = new int[size]; }
    public void Enqueue(int val) { rear = (rear + 1) % size; arr[rear] = val; count++; }
    public int Dequeue() { int val = arr[front]; front = (front + 1) % size; count--; return val; }
    public bool IsEmpty() => count == 0;
}

// --- P3: Implement Stack Using Queues ---
// Push O(n): push to queue, then rotate n-1 elements.
public class StackUsingQueue
{
    private Queue<int> q = new Queue<int>();
    public void Push(int val)
    {
        q.Enqueue(val);
        for (int i = 0; i < q.Count - 1; i++) q.Enqueue(q.Dequeue());
    }
    public int Pop() => q.Dequeue();
    public int Top() => q.Peek();
}

// --- P4: Implement Queue Using Stacks ---
// Amortized O(1) per operation using two stacks.
public class QueueUsingStacks
{
    private Stack<int> pushStack = new(), popStack = new();
    public void Enqueue(int val) => pushStack.Push(val);
    public int Dequeue()
    {
        if (popStack.Count == 0)
            while (pushStack.Count > 0) popStack.Push(pushStack.Pop());
        return popStack.Pop();
    }
}

// --- P5: Valid Parentheses ---
// Input: "()[]{}" → true.  "([)]" → false.
public class ValidParentheses
{
    public bool Optimal(string s)
    {
        var stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{') stack.Push(c);
            else
            {
                if (stack.Count == 0) return false;
                char top = stack.Pop();
                if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                    return false;
            }
        }
        return stack.Count == 0;
    }
}

// --- P6: Next Greater Element ---
// Input: [4,5,2,10,8] → [5,10,10,-1,-1]
// OPTIMAL: Traverse right to left. Use stack to track candidates. O(n).
public class NextGreaterElement
{
    public int[] Optimal(int[] arr)
    {
        int n = arr.Length;
        int[] result = new int[n];
        var stack = new Stack<int>();

        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && stack.Peek() <= arr[i]) stack.Pop();
            result[i] = stack.Count > 0 ? stack.Peek() : -1;
            stack.Push(arr[i]);
        }
        return result;
    }
}

// --- P7: Sort a Stack ---
// Using recursion (or another stack). O(n^2) time, O(n) space.
public class SortStack
{
    public void Optimal(Stack<int> stack)
    {
        if (stack.Count == 0) return;
        int top = stack.Pop();
        Optimal(stack);         // sort remaining
        InsertSorted(stack, top); // insert in sorted position
    }

    private void InsertSorted(Stack<int> stack, int val)
    {
        if (stack.Count == 0 || stack.Peek() <= val) { stack.Push(val); return; }
        int top = stack.Pop();
        InsertSorted(stack, val);
        stack.Push(top);
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Stack using Queue: Push O(n) by rotating queue after each push.
// - Queue using Stacks: Two stacks, lazy transfer. Amortized O(1).
// - Valid Parentheses: Stack-based matching. Must be empty at end.
// - Next Greater Element: Monotonic stack, traverse RIGHT to LEFT. O(n).
// - Sort Stack: Recursive. Pop top, sort rest, insert top in sorted position.
// ============================================================
