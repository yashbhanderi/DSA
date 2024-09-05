public class FindMissingObservations {

    public static int[] MissingRolls(int[] rolls, int mean, int n) {
        var ans = new List<int>();

        if(rolls.Length == 0) return [..ans];

        int total = 0;
        foreach(var roll in rolls) {
            total += roll;
        }

        var sum = ((rolls.Length + n)*mean) - total;

        if(sum > n*6 || sum < n) return [..ans.c];

        int avgValue = sum/n;

        while(n-- > 1) {
            ans.Add(avgValue);
            sum -= avgValue;
        }

        ans.Add(sum);

        return [..ans];
    }

    public static void Run() {
        var rolls = new int[] {1,2,3,4}; 
        var mean = 6;
        var n = 4;

        var ans = MissingRolls(rolls, mean, n);
        System.Console.WriteLine(string.Join(", ", ans));
    }
}