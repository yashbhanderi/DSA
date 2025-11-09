namespace Arrays;

public class ContainsDuplicate
{

    public static bool Solve(int[] arr)
    {
        var set = new HashSet<int>();

        foreach (var e in arr)
        {
            if (set.Contains(e)) return true;

            set.Add(e);
        }

        return false;
    }

    public static void Run()
    {
        var arr = new[] { 1, 2, 3, 1 };

        System.Console.WriteLine(Solve(arr));
    }
}