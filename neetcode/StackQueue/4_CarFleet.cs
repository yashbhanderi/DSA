using System;
using System.Collections.Generic;
using System.Linq;

namespace neetcode.StackQueue
{
    public class CarFleet
    {
        public static int GetCarFleet(int target, int[] position, int[] speed)
        {
            int n = position.Length;

            // Pair position with time to reach target
            var cars = new (int pos, double time)[n];
            for (int i = 0; i < n; i++)
            {
                cars[i] = (position[i], (double)(target - position[i]) / speed[i]);
            }

            // Sort by position descending (closest to target first)
            Array.Sort(cars, (a, b) => b.pos.CompareTo(a.pos));

            int fleets = 0;
            double lastTime = 0;

            foreach (var car in cars)
            {
                if (car.time > lastTime)
                {
                    fleets++;
                    lastTime = car.time;
                }
            }

            return fleets;
        }

        public static void Main()
        {
            int target = 12;
            int[] position = [10, 8, 0, 5, 3], speed = [2, 4, 1, 1, 3];

            System.Console.WriteLine(GetCarFleet(target, position, speed));
        }
    }
}

/*
Absolutely — here’s a **full-length, quick-revision summary** of the **Car Fleet** problem that you can read in **2–3 minutes before interviews or contests**.
It’s **concept-first**, **code-aware**, and **mistake-proof**.

---

# 🚗 Car Fleet — Complete Quick Revision Summary

---

## 1. What the problem is really about

* Cars are on a **single straight road**, moving toward a **target**
* Each car has:

  * a **starting position**
  * a **constant speed**
* **All cars start at the same time**
* **No car can pass another**

If a faster car catches a slower car:

* It **must slow down**
* They move together forever
* They form **one fleet**

👉 **Goal:**
Count how many **distinct fleets** reach the target.

---

## 2. The most important rule (hidden but critical)

> **Because cars cannot pass, a car can only interact with the nearest car or fleet in front of it.**

* You can’t skip cars
* You can’t affect cars farther ahead
* The **first obstacle blocks everything beyond it**

This single rule justifies:

* Why we only compare with **one fleet**
* Why a **stack / monotonic structure** works

---

## 3. Array order vs Reality (common trap)

❌ Input array order **does NOT matter**
✅ Physical **position order** matters

Cars must be considered by their **position on the road**, not by index.

> “Front” and “behind” are physical concepts, not array concepts.

---

## 4. Core concept: Arrival Time

For each car, think conceptually:

> **How long would this car take to reach the target if nothing blocks it?**

This “arrival time” fully determines:

* Whether it will catch another car
* Whether it will form a new fleet

You **never** need:

* Exact meeting point
* Exact meeting time
* Simulation step by step

Only **relative arrival times**.

---

## 5. How fleets form (the only decision rule)

When a car is behind another fleet:

### Compare arrival times:

* **Current arrival time ≤ front fleet arrival time**

  * It catches up
  * It merges
  * No new fleet

* **Current arrival time > front fleet arrival time**

  * It never catches up
  * Forms a **new fleet**

That’s the **only rule**.

---

## 6. Why stack logic works (without code)

* Fleets form **from front to back**
* Once a fleet is formed, it **never splits**
* A car can only interact with the **immediate fleet in front**
* This creates an **irreversible, one-directional process**

👉 This naturally maps to a **monotonic stack**

* Each stack entry = one final fleet
* Top of stack = **nearest fleet ahead**
* No need to check deeper elements

---

## 7. Why only the “top” matters

Because:

* Passing is forbidden
* The nearest fleet blocks all others
* If you can’t catch the nearest fleet, you can’t catch any

So:

> **The top of the stack fully determines the future.**

---

## 8. Why sorting by position is mandatory

To make “nearest in front” meaningful:

* Cars must be processed in **descending position order**
* Closest to target → farthest from target

This ensures:

* Every new car is **behind** all previous ones
* Stack always reflects physical reality

---

## 9. Implementation insight (mental model)

Even if you don’t write a stack:

* Tracking the **maximum arrival time seen so far**
* Counting when a car exceeds it

…is logically the **same as using a stack**.

---

## 10. Final mental model (lock this in 🔒)

> All cars start together.
> Order comes from position, not input.
> Cars cannot pass.
> A car only cares about the nearest fleet in front.
> Fleets are decided by comparing arrival times.

If you understand these lines, **Car Fleet is solved forever**.

---

## 11. Interview one-liner answer

> “Car Fleet works because cars can’t pass, so each car only compares its arrival time with the nearest fleet in front. If it arrives earlier, it merges; otherwise it forms a new fleet.”

---

If you want, I can also:

* Shrink this into a **30-second ultra-short cheat sheet**
* Give a **diagram-based memory trick**
* Compare this with other **monotonic stack problems**

Just say the word 🚀

*/