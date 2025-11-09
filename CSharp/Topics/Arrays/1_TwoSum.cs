namespace CSharp.Topics.Arrays;

/*
 * PROBLEM: TWO SUM
 * ---------------
 * Hey there! Let's solve this together step by step! 🎯
 * 
 * THE TASK:
 * Given an array of numbers and a target sum, find TWO numbers that add up to the target.
 * We need to return their INDICES (positions), not the numbers themselves!
 * 
 * EXAMPLE:
 * Input: nums = [2,7,11,15], target = 9
 * Output: [0,1] WHY? Because nums[0] + nums[1] = 2 + 7 = 9
 * 
 * APPROACHES:
 * ----------
 * Method 1 (Brute Force) - O(n²):
 * - Try every possible pair with nested loops
 * - BUTT!! This is too slow for large arrays!
 * 
 * Method 2 (Optimal) - O(n):
 * - Use HashMap to store numbers we've seen
 * - For each number X, check if (target - X) exists
 * - Trade space for speed! 🚀
 * 
 * KEY INSIGHT:
 * If target = 9 and current number = 2,
 * we're really asking: "Have we seen 7 before?"
 * Because 2 + 7 = 9 (our target)
 * 
 * TIME:  O(n) - we look at each number once
 * SPACE: O(n) - HashMap might store all numbers
 */
public class TwoSum
{
    // Main solving function that implements our optimized approach
    public static int[] Solve(int[] arr, int target)
    {
        // STRATEGY: Use HashMap to store <number, index> pairs
        // WHY HashMap? O(1) lookups instead of O(n) searching!
        var map = new Dictionary<int, int>();

        // Iterate through each number ONCE - that's why O(n) time!
        for (int i = 0; i < arr.Length; i++)
        {
            // CRITICAL MATH: If a + b = target, then b = target - a
            // So for current number 'a', we need to find 'b' = (target - a)
            int val = target - arr[i];

            // CHECK: Have we seen the complement before?
            // If yes -> BINGO! We found our pair! 🎯
            if (map.ContainsKey(val))
            {
                // Return [previous_index, current_index]
                // NOTE: Order matters! Earlier index comes first
                return [map.GetValueOrDefault(val), i];
            }

            // IMPORTANT: Add current number AFTER checking!
            // WHY? To avoid using same number twice
            // Example: target=8, current=4 -> shouldn't match with itself!
            map.TryAdd(arr[i], i);
        }

        // If no solution found, return empty array
        // In C# 12, [] is shorthand for Array.Empty<int>()
        return [];
    }

    /*
     * EXAMPLE WALKTHROUGH:
     * -------------------
     * arr = [2,7,11,15], target = 9
     * 
     * Step 1: i=0, current=2
     * - map = {}
     * - val = 9-2 = 7 (looking for 7)
     * - 7 not in map
     * - Add {2:0} to map
     * 
     * Step 2: i=1, current=7
     * - map = {2:0}
     * - val = 9-7 = 2 (looking for 2)
     * - FOUND 2 in map!
     * - Return [map[2], 1] = [0,1]
     * 
     * EDGE CASES HANDLED:
     * - Same number can't use itself (add to map after check)
     * - Returns earliest indices first
     * - No solution? Returns empty array
     */
    public static void Run()
    {
        // Test case from the problem description
        var arr = new int[] { 2, 7, 11, 15 };
        var target = 9;

        // Print result as comma-separated indices
        System.Console.WriteLine(string.Join(",", Solve(arr, target)));
    }
}