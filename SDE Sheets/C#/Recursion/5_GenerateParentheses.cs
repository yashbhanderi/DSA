using System;

namespace Recursion;

public class _5_GenerateParentheses
{

	public static List<string> strings = [];
	public static int N = 3;
	public static void GenerateParantheses(int left, int right, string str) {
		if(left > N || right > N || left < right) return;	

		if(left == N && right == N) {
			strings.Add(str);
			return;
		}
		
		GenerateParantheses(left+1, right, str + '(');
		GenerateParantheses(left, right+1, str + ')');
	}

    public static void Run() {
		int n = 3;

		GenerateParantheses(0, 0, "");

		foreach(var e in strings) {
			System.Console.WriteLine(e);
		}
    }
}
