namespace Arrays;

public class TwoSum
{

    public static int[] Solve(int[] arr, int target)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            int val = target - arr[i];

            if (map.ContainsKey(val))
            {
                return [map.GetValueOrDefault(val), i];
            }

            map.TryAdd(arr[i], i);
        }

        return [];
    }

    public static void Run()
    {
        var arr = new[] { 2, 7, 11, 15 };
        var target = 9;

        System.Console.WriteLine(string.Join(",", Solve(arr, target)));
    }
}