namespace CSharp.Topics.Arrays
{
    public class MergeIntervals
    {
        public static int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            int n = intervals.Length;
            var mergedIntervals = new List<int[]>();
            int lastSmall = intervals[0][0], lastLarge = intervals[0][1];
            var i = 1;

            while(i < n)
            {
                if(intervals[i][0] <= lastLarge)
                {
                    lastLarge = Math.Max(lastLarge, intervals[i][1]);
                }
                else
                {
                    mergedIntervals.Add([lastSmall, lastLarge]);
                    lastSmall = intervals[i][0];
                    lastLarge = intervals[i][1];
                }

                i++;
            }

            mergedIntervals.Add([lastSmall, lastLarge]);

            return [.. mergedIntervals];
        }

        public static void Run()
        {
            var intervals = new int[][] {[1, 3], [2, 6], [8, 10], [15, 18]};
            var mergedIntervals = Merge(intervals);

            foreach(var interval in mergedIntervals)
            {
                System.Console.WriteLine(string.Join(",", interval));
            }
        }
    }
}