using System.Collections.Generic;
using System.Linq;

namespace neetcode.Arrays
{
    public class TopKFrequentElements
    {

        /*
        ✅ The ONE rule of PriorityQueue

        ONLY the priority is used to build and maintain the heap.

        That’s it.

        What this means in practice

        In:

        PriorityQueue<TElement, TPriority>


        TPriority → used for ordering (heap structure)

        TElement → just stored data (payload)

        The heap does not care what TElement is.

        Your example again
        ((pair.Key, pair.Value), -pair.Value)


        Element: (key, value)

        Priority: -value

        Heap comparisons look like this internally:

        Compare(-8, -5, -3)


        ✔ Nothing else is checked
        ✔ Not key
        ✔ Not value
        ✔ Not tuple order

        Visual mental model (important)

        Think of every element like this:

        [ DATA | PRIORITY ]


        The heap only looks at:

        PRIORITY


        The data is carried along.

        What if two priorities are equal?

        Example:

        ((1,5), -5)
        ((2,5), -5)


        Then:

        Heap order between them is undefined

        Either can come first

        Heap is NOT stable

        This is expected behavior.

        What happens if you change priority logic?
        Priority expression	Result
        priority = value	Min value first
        priority = -value	Max value first
        priority = abs(value)	Closest to zero
        priority = timestamp	Earliest first

        Heap behavior changes only because priority changed.
        */

        public static int[] TopKFrequent(int[] nums, int k)
        {
            var resultList = new int[k];

            var frequencyMapping = new Dictionary<int, int>();

            foreach (var e in nums)
            {
                frequencyMapping[e] = frequencyMapping.GetValueOrDefault(e) + 1;
            }

            var pq = new PriorityQueue<(int, int), int>(
                frequencyMapping.Select(pair => ((pair.Key, pair.Value), -pair.Value))
            );

            while (k > 0)
            {
                resultList[k - 1] = pq.Dequeue().Item1;
                k--;
            }

            return resultList;
        }

        public static void Main()
        {
            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            var k = 2;

            System.Console.WriteLine(string.Join(",", TopKFrequent(nums, k)));
        }
    }
}