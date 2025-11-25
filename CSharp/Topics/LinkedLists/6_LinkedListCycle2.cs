namespace CSharp.Topics.LinkedLists
{
    public class LinkedListCycle2
    {
        public static ListNode DetectCycle(ListNode head)
        {
            ListNode? slow = head, fast = head;

            while (slow != null && fast != null)
            {
                slow = slow.next;

                if (fast.next == null)
                {
                    // no cycle
                    return null;
                }

                fast = fast.next.next;

                if (slow == fast)
                {
                    break;
                }
            }

            if (fast == null) return null;

            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            return slow;
        }

        public static void Run()
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            ListNode? head = null;

            foreach (var e in arr)
            {
                head = LinkedListHelper.AddLast(e, head);
            }

            System.Console.WriteLine(DetectCycle(head));
        }
    }
}

// Finding the Cycle Start (Optional): If a cycle is detected (pointers meet), reset slowPointer back to the head of the linked list. Keep fastPointer at its current meeting point. Move both slowPointer and fastPointer one node at a time. The node where they meet again is the starting node of the cycle.

// It is definitely * *Math * *, not magic or coincidence!

// It works because of a very specific mathematical relationship between the speed of the pointers and the distances on the track.

// Here is the **super simple** breakdown of the proof.

// ---

// ### 1. The Setup (The Track)

// Imagine the linked list is a shape that looks like a **lasso** or a generic **"P" shape**.

// * **$L$**: The length of the straight part (from Head to the Start of the cycle).
// * **$C$**: The length of the full cycle (the circle).
// * **$X$**: The distance from the Start of the cycle to the spot where they met (Meeting Point).



// ### 2. The Race (The Math)

// When the **Slow Pointer (Tortoise)** and **Fast Pointer (Hare)** meet, they have been running for the same amount of time.

// * **Slow Pointer Distance:**It traveled the straight part ($L$) plus the distance into the cycle ($X$).
//     * $\text{Distance}_{\text{Slow}} = L + X$
// ***Fast Pointer Distance:**It traveled the straight part ($L$), plus the distance into the cycle ($X$), **PLUS** it ran some number of full laps around the circle (let's say $n$ laps) because it's faster.
//     * $\text{Distance}_{\text{Fast}} = L + X + (n \times C)$

// **The Key Rule:**
// Since the Fast Pointer moves at **2x speed**, it covered **2x distance**.

// $$2 \times (L + X) = L + X + nC$$

// ### 3. The Simplification (The "Aha!" Moment)

// Let's solve that equation to see what $L$ equals.

// 1.  $2L + 2X = L + X + nC$ (Expand the left side)
// 2.  $L + X = nC$ (Subtract $L$ and $X$ from both sides)
// 3.  **$L = nC - X$** (Subtract $X$)

// **What does $L = nC - X$ actually mean?**

// * **$L$** is the distance from the **Head** to the **Cycle Start**.
// * **$C - X$** is the distance from the **Meeting Point** to the **Cycle Start** (completing the rest of the loop).

// The math proves that **the distance required to reach the start of the cycle from the Head ($L$) is EXACTLY equal to the distance required to reach the start of the cycle from the Meeting Point ($C - X$).**

// *(Note: The "$n$" just means it might take a few full spins, but the meeting spot is the same).*

// ### 4. The Final Visual

// Because those two distances are equal:

// 1.You put one pointer at the **Head** (Distance to go: $L$).
// 2.  You leave the other pointer at the **Meeting Point** (Distance to go: effectively $L$).
// 3.  You move them both **1 step at a time**.
// 4.  Since they have the exact same distance to cover, they are guaranteed to collide right at the **Cycle Start**.

// ### Summary
// It works because the extra distance the Fast pointer ran (the laps) creates a perfect mathematical balance where the **"head start"** ($L$) equals the **"remaining loop"** ($C - X$).