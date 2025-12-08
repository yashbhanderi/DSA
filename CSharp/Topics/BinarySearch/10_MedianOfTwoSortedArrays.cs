namespace CSharp.Topics.BinarySearch
{
    public class MedianOfTwoSortedArrays
    {

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length, m = nums2.Length;

            if (n > m) return FindMedianSortedArrays(nums2, nums1);

            int left = 0, right = n;

            while (left <= right)
            {
                int cut1 = (left + right) / 2;
                int cut2 = (n + m + 1) / 2 - cut1;

                int left1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
                int right1 = cut1 == n ? int.MaxValue : nums1[cut1];

                int left2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];
                int right2 = cut2 == m ? int.MaxValue : nums2[cut2];

                if (left1 <= right2 && left2 <= right1)
                {
                    if ((n + m) % 2 == 0)
                    {
                        return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(left1, left2);
                    }
                }
                else if (left1 > right2)
                {
                    right = cut1 - 1;
                }
                else
                {
                    left = cut1 + 1;
                }
            }

            return -1;
        }

        public static void Run()
        {
            var a1 = new int[] { 1, 3, 8, 9 };
            var a2 = new int[] { 2, 7, 10, 12 };

            System.Console.WriteLine(FindMedianSortedArrays(a1, a2));
        }
    }
}

// Below is your * *final one - time, remember - forever summary** of the
// **Median of Two Sorted Arrays** problem — *complete*, *clean*, *compact*, and covering every question you asked.

// Keep this as your “permanent mental model.”

// ---

// # 🟦 **PROBLEM**

// Two sorted arrays A and B.
// Find the **median** of both arrays combined, **without merging**, in **O(log(min(n, m)))**.

// ---

// # 🟦 **CORE INTUITION (WHY BINARY SEARCH?)**

// If you merged A + B, the median sits at:

// ```
// leftCount = (n + m + 1) / 2
// ```

// We want to split the two arrays into:

// ```
// Left half = leftCount elements  
// Right half = remaining elements
// ```

// The median must come from the **end of the left half**.

// Instead of merging, we try to **choose how many elements to take from A**,
// and the rest automatically come from B.

// This is “partitioning” the arrays.

// ---

// # 🟦 **KEY IDEA**

// We binary-search on **cutA**, the number of elements we take from A.

// ```
// cutA can be 0 to n  (so high = n, NOT n-1)
// cutB = leftCount - cutA
// ```

// This ensures:

// ```
// cutA + cutB = leftCount
// ```

// So left side always has the correct number of elements.

// ---

// # 🟦 **THE FOUR VALUES THAT MAKE EVERYTHING WORK**

// After choosing cutA and cutB:

// ```
// leftA = A[cutA - 1] or -∞
// rightA = A[cutA]     or +∞

// leftB = B[cutB - 1] or -∞
// rightB = B[cutB]     or +∞
// ```

// These represent the **border elements** between the left and right halves.

// ---

// # 🟦 **VALID PARTITION CONDITION**

// We found the correct median partition when:

// ```
// leftA <= rightB  AND leftB <= rightA
// ```

// This means:

// *Every element on the left is <= every element on the right.
// * The cut is exactly in the correct place.

// ---

// # 🟦 **HOW MEDIAN IS DECIDED**

// ### Case 1: **total length is odd**

// ```
// median = max(leftA, leftB)
// ```

// Why?
// Left side has **one extra element** → that single element IS the median.

// (This answers: “Why take from left, not right?”
// Because median sits on the left side for odd length.)

// ---

// ### Case 2: **total length is even**

// ```
// median = ( max(leftA, leftB) + min(rightA, rightB) ) / 2
// ```

// Why?
// Median is the average of the two middle values.

// ---

// # 🟦 **WHY CUT FROM 0 TO n, NOT 0 TO n-1?**

// Because we are binary-searching on **cut positions**, not indices.

// Array of size n has **n+1 possible cuts**:

// ```
// | A0 | A1 | A2 | ... | An |
// 0    1    2        n
// ```

// So valid cuts are 0…n.
// Therefore:

// ```
// low = 0
// high = n
// ```

// ---

// # 🟦 **WHY cutB = (n + m + 1) / 2 - cutA ?**

// Because we must ensure:

// ```
// (left side size) = leftCount = (n + m + 1) / 2
// ```

// If A contributes cutA elements to the left side,
// then B must contribute:

// ```
// cutB = leftCount - cutA
// ```

// This keeps both sides balanced → median position is correct.

// ---

// # 🟦 **WHY DUPLICATES ARE ALLOWED?**

// We only compare `<=`, not strict `<`, so duplicates are perfectly valid.
// They do not break the partition logic.

// ---

// # 🟦 **WHY O(log(min(n,m)))?**

// Because we binary search only on the **smaller array**.

// Each binary search step does **O(1)** work (only 4 comparisons).
// So total = O(log(min(n, m))).

// ---

// # 🟦 **THE FINAL SOLUTION (THE ONE YOU MUST REMEMBER)**

// ```csharp
// public double FindMedianSortedArrays(int[] A, int[] B)
// {
//     if (A.Length > B.Length)
//         return FindMedianSortedArrays(B, A);   // A must be smaller

//     int n = A.Length, m = B.Length;
//     int low = 0, high = n;

//     while (low <= high)
//     {
//         int cutA = (low + high) / 2;
//         int cutB = (n + m + 1) / 2 - cutA;

//         int leftA = (cutA == 0) ? int.MinValue : A[cutA - 1];
//         int rightA = (cutA == n) ? int.MaxValue : A[cutA];

//         int leftB = (cutB == 0) ? int.MinValue : B[cutB - 1];
//         int rightB = (cutB == m) ? int.MaxValue : B[cutB];

//         if (leftA <= rightB && leftB <= rightA)
//         {
//             if ((n + m) % 2 == 0)
//                 return (Math.Max(leftA, leftB) + Math.Min(rightA, rightB)) / 2.0;
//             else
//                 return Math.Max(leftA, leftB);
//         }
//         else if (leftA > rightB)
//         {
//             high = cutA - 1;
//         }
//         else
//         {
//             low = cutA + 1;
//         }
//     }

//     return -1;
// }
// ```

// ---

// # 🟦 **THE ENTIRE LOGIC IN 5 SUPER-SHORT LINES**

// 1.Decide how many elements go to left side → leftCount = (n+m+1)/2
// 2. Binary search cutA = 0..n
// 3. cutB = leftCount - cutA
// 4. Check if leftA ≤ rightB AND leftB ≤ rightA
// 5. If valid → compute median from border values

// ---

// # 🟦 **FINAL MEMORY ANCHOR**

// > **You are NOT merging.
// > You are just finding where the middle of the merged array would be,
// > using binary search on cuts, not elements.**

// ---

// If you want, I can also create a **visual diagram** or **dry run** for your exact arrays so you understand the movement step-by-step.
