// ============================================================
// Problem: Remove Duplicates from Sorted Array
// Topic: Two Pointers
// ============================================================
// PROBLEM STATEMENT:
//   Remove duplicates in-place from a sorted array. Return count of unique elements.
//   Input:  [1,1,2] → Output: 2, nums = [1,2,...]
// ============================================================

public class RemoveDuplicates
{
    // APPROACH: Two Pointers (slow writer, fast scanner)
    // Idea: slow tracks position to write next unique element.
    //       fast scans ahead. When fast finds a new unique element, copy to slow+1.
    // Time: O(n)  |  Space: O(1)
    public int Optimal(int[] nums)
    {
        if (nums.Length == 0) return 0;
        int slow = 0;

        for (int fast = 1; fast < nums.Length; fast++)
        {
            if (nums[fast] != nums[slow])
            {
                slow++;
                nums[slow] = nums[fast];
            }
        }

        return slow + 1;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Two pointers: slow = last unique position, fast = scanner.
// - Only copy when nums[fast] != nums[slow].
// - O(n) time, O(1) space. Array is already sorted.
// - Returns count of unique elements.
// ============================================================
