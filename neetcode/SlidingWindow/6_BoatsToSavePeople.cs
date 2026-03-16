using System;

namespace neetcode.SlidingWindow
{
    public class BoatsToSavePeople
    {
        public static int NumRescueBoats(int[] people, int limit)
        {
            var n = people.Length;

            Array.Sort(people);

            var i = 0;
            var totalBoats = 0;
            while (i < n)
            {
                var currentWeight = 0;
                while (i < n && currentWeight + people[i] <= limit)
                {
                    currentWeight += people[i];
                    i++;
                }

                System.Console.WriteLine(currentWeight);
                if (currentWeight == 0) return totalBoats;

                totalBoats++;
            }

            return totalBoats;
        }

        public static void Main()
        {
            var arr = new int[] { 5, 1, 4, 2 };
            var limit = 6;

            System.Console.WriteLine(NumRescueBoats(arr, limit));
        }
    }
}