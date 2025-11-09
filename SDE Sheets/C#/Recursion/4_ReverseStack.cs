using System;

namespace Recursion;

public class _4_ReverseStack
{

	public static void Reverse(Stack<int> stack, int top) {
		if(stack.Count == 0) {
			stack.Push(top);
			return;	
		};

		var peek = stack.Pop();
		
		Reverse(stack, top);

		stack.Push(peek);
	}

	public static void ReverseStack(Stack<int> stack) {
		if(stack.Count == 0) return;

		var top = stack.Pop();

		ReverseStack(stack);
		
		Reverse(stack, top);
	}

    public static void Run() {
		var stack = new Stack<int>();

        stack.Push(41);
        stack.Push(3);
        stack.Push(32);
        stack.Push(2);
        stack.Push(11);

        ReverseStack(stack);
        while (stack.Count > 0)
        {
            System.Console.Write(stack.Pop() + " ");
        }
	}
}
