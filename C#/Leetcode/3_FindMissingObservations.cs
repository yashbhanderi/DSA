public class FindMissingObservations {

    public static int[] MissingRolls(int[] rolls, int mean, int n) {
        var ans = new List<int>();

        if(rolls.Length == 0) return [..ans];

        int total = 0;
        foreach(var roll in rolls) {
            total += roll;
        }

        var sum = ((rolls.Length + n)*mean) - total;

        if(sum > n*6 || sum < n) return [..ans];

        int avgValue = sum/n;
        int remain = sum%n;

        int j = n;
        while(j > 0) {
            ans.Add(avgValue);
            j--;
        }

        int i = 0;
        while(remain > 0 && i < n) {
            if(ans[i] < 6) {
                ans[i]++;
                remain--;
            }
            i++;
        }

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