// ============================================================
// BST Part II — 8 problems
// Topic: Binary Search Tree Part II
// ============================================================
// Problems: Floor, Ceil, Kth Smallest, Kth Largest, Two Sum BST,
//           BST from Preorder, Largest BST in BT, Serialize/Deserialize
// ============================================================

using System;
using System.Collections.Generic;

public class BSTProblemsII
{
    // P1: Floor in BST — Largest value ≤ key
    public int Floor(TreeNode root, int key)
    {
        int floor = -1;
        while (root != null)
        {
            if (root.val == key) return key;
            if (root.val < key) { floor = root.val; root = root.right; }
            else root = root.left;
        }
        return floor;
    }

    // P2: Ceil in BST — Smallest value ≥ key
    public int Ceil(TreeNode root, int key)
    {
        int ceil = -1;
        while (root != null)
        {
            if (root.val == key) return key;
            if (root.val > key) { ceil = root.val; root = root.left; }
            else root = root.right;
        }
        return ceil;
    }

    // P3: Kth Smallest — Inorder traversal returns sorted. Stop at kth. O(h + k).
    public int KthSmallest(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        var curr = root;
        while (curr != null || stack.Count > 0)
        {
            while (curr != null) { stack.Push(curr); curr = curr.left; }
            curr = stack.Pop();
            if (--k == 0) return curr.val;
            curr = curr.right;
        }
        return -1;
    }

    // P4: Kth Largest — Reverse inorder (right, root, left). Stop at kth.
    public int KthLargest(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        var curr = root;
        while (curr != null || stack.Count > 0)
        {
            while (curr != null) { stack.Push(curr); curr = curr.right; }
            curr = stack.Pop();
            if (--k == 0) return curr.val;
            curr = curr.left;
        }
        return -1;
    }

    // P5: Two Sum in BST — BST Iterator from both ends. O(n) time, O(h) space.
    public bool FindTarget(TreeNode root, int k)
    {
        var inorder = new List<int>();
        InorderTraversal(root, inorder);
        int l = 0, r = inorder.Count - 1;
        while (l < r)
        {
            int sum = inorder[l] + inorder[r];
            if (sum == k) return true;
            if (sum < k) l++; else r--;
        }
        return false;
    }
    private void InorderTraversal(TreeNode node, List<int> list)
    { if (node == null) return; InorderTraversal(node.left, list); list.Add(node.val); InorderTraversal(node.right, list); }

    // P6: Largest BST in Binary Tree — For each node, check if subtree is BST.
    // Return (size, min, max, isBST). O(n).
    public int LargestBST(TreeNode root) { return LargestBSTHelper(root).size; }
    private (int size, int min, int max) LargestBSTHelper(TreeNode node)
    {
        if (node == null) return (0, int.MaxValue, int.MinValue);
        var left = LargestBSTHelper(node.left);
        var right = LargestBSTHelper(node.right);
        if (left.max < node.val && node.val < right.min)
            return (left.size + right.size + 1, Math.Min(left.min, node.val), Math.Max(right.max, node.val));
        return (Math.Max(left.size, right.size), int.MinValue, int.MaxValue); // not BST
    }
}

// P7: Serialize and Deserialize Binary Tree
public class Codec
{
    public string Serialize(TreeNode root)
    {
        if (root == null) return "null";
        return root.val + "," + Serialize(root.left) + "," + Serialize(root.right);
    }

    public TreeNode Deserialize(string data)
    {
        var queue = new Queue<string>(data.Split(','));
        return DeserializeHelper(queue);
    }
    private TreeNode DeserializeHelper(Queue<string> queue)
    {
        string val = queue.Dequeue();
        if (val == "null") return null;
        var node = new TreeNode(int.Parse(val));
        node.left = DeserializeHelper(queue);
        node.right = DeserializeHelper(queue);
        return node;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Floor: Largest ≤ key. Track candidate, go right if <, left if >.
// - Ceil: Smallest ≥ key. Track candidate, go left if >, right if <.
// - Kth Smallest: Iterative inorder, stop at k. O(h + k).
// - Kth Largest: Reverse inorder (go right first). O(h + k).
// - Two Sum BST: Inorder to sorted array + Two Pointers. O(n).
// - Largest BST: Bottom-up. Track (size, min, max). O(n).
// - Serialize: Preorder with "null" markers. Deserialize with queue.
// ============================================================
