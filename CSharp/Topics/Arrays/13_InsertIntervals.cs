namespace CSharp.Topics.Arrays
{
    public class InsertIntervals
    {
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            int i = 0;
            int n = intervals.Length;

            // 1. Process all intervals **BEFORE** the overlap
            while (i < n && intervals[i][1] < newInterval[0])
            {
                // Case 1: Existing end is less than new start -> NO OVERLAP
                result.Add(intervals[i]);
                i++;
            }

            // 2. Process all intervals **DURING** the overlap (The Merging Phase)
            while (i < n && intervals[i][0] <= newInterval[1])
            {
                // Case 3: Existing start is less than or equal to new end -> OVERLAP
                // Update the newInterval (Your towel gets bigger!)
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]); // New Start: Minimum of all starts
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]); // New End: Maximum of all ends
                i++;
            }

            // After the loop, the **merged** newInterval is finalized.
            // Add the single, merged towel to the result.
            result.Add(newInterval);

            // 3. Process all intervals **AFTER** the overlap
            while (i < n)
            {
                // Case 2: All remaining intervals are safely to the right
                result.Add(intervals[i]);
                i++;
            }

            return result.ToArray();
        }

        public static void Run()
        {
            // var intervals = new int[][] { [1, 2], [3, 5], [6, 7], [8, 10], [12, 16] };
            // var intervals = new int[][] { [1, 2], [3, 5], [6, 7], [8, 10], [12, 16] };
            // var newInterval = new int[] { 4, 8 };
            var intervals = new int[][] { [1, 5] };
            var newInterval = new int[] { 6, 8 };

            var mergedIntervals = Insert(intervals, newInterval);
            foreach (var interval in mergedIntervals)
            {
                System.Console.WriteLine(string.Join(",", interval));
            }
        }
    }
}