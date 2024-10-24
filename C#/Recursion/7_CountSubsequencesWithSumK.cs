namespace Recursion;

public class _7_CountSubsequencesWithSumK
{
    public static int SUM = 0, Count = 0;
    public const int MOD = 1000000007;
    
    /* Check If any subsequence with K sum

        public static bool Subsets(int index, List<int> list, int sum)
        {
            if (index >= list.Count)
            {
                if(SUM == sum) {
                    Count = (Count + 1) % MOD;
                    return true;
                }

                return false;
            }

            sum += list[index];
            
            if(Subsets(index + 1, list, sum)) {
                return true;
            }
            
            sum -= list[index];

            if(Subsets(index + 1, list, sum)) {
                return true;
            }

            return false;
        }
    */


    // Count of all subsequences with sum K 
    public static void Subsets(int index, List<int> list, int sum)
    {
        if (index >= list.Count)
        {
            if(SUM == sum) Count = (Count + 1) % MOD;
            return;
        }

        sum += list[index];
        
        Subsets(index + 1, list, sum);
        
        sum -= list[index];

        Subsets(index + 1, list, sum);
    }

    public static int GenerateSubsets(List<int> list)
    {
        Subsets(0, list, 0);

        return Count;
    }

    public static void Run()
    {
        var arr = new List<int> { 9 ,7 ,0 ,3 ,9 ,8 ,6 ,5 ,7 ,6 };

        SUM = 31;
        var ans = GenerateSubsets(arr);

        System.Console.WriteLine("Total Count - " + ans);        
    }
}