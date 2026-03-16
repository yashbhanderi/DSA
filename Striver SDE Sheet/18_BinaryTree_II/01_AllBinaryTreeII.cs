// ============================================================
// Binary Tree Part II — 8 problems
// Topic: Binary Tree II
// ============================================================
// Problems: Height, Diameter, Balanced Check, LCA, Same Tree,
//           Zig-Zag Traversal, Boundary Traversal, Morris Traversal
// ============================================================

using System;
using System.Collections.Generic;

public class BinaryTreeII
{
    // P1: Height of Binary Tree — max(left height, right height) + 1. O(n).
    public int Height(TreeNode root) => root == null ? 0 : 1 + Math.Max(Height(root.left), Height(root.right));

    // P2: Diameter — Longest path between any two nodes (may not pass through root).
    // Track max of (leftHeight + rightHeight) at each node.
    private int diameter = 0;
    public int DiameterOfBinaryTree(TreeNode root) { diameter = 0; HeightForDiameter(root); return diameter; }
    private int HeightForDiameter(TreeNode root)
    {
        if (root == null) return 0;
        int lh = HeightForDiameter(root.left), rh = HeightForDiameter(root.right);
        diameter = Math.Max(diameter, lh + rh);
        return 1 + Math.Max(lh, rh);
    }

    // P3: Check Balanced — Height diff of left/right subtrees ≤ 1 for ALL nodes.
    public bool IsBalanced(TreeNode root) => CheckHeight(root) != -1;
    private int CheckHeight(TreeNode root)
    {
        if (root == null) return 0;
        int lh = CheckHeight(root.left); if (lh == -1) return -1;
        int rh = CheckHeight(root.right); if (rh == -1) return -1;
        if (Math.Abs(lh - rh) > 1) return -1;
        return 1 + Math.Max(lh, rh);
    }

    // P4: LCA of Binary Tree
    // If both p,q in left → LCA in left. Both in right → LCA in right. Split → current is LCA.
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q) return root;
        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);
        if (left != null && right != null) return root; // split = LCA
        return left ?? right;
    }

    // P5: Same Tree — Both null → true. One null → false. Compare val + recurse.
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;
        return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }

    // P6: Zig-Zag Level Order — BFS, alternate left-to-right and right-to-left.
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool leftToRight = true;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            var level = new int[size];
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                int idx = leftToRight ? i : size - 1 - i;
                level[idx] = node.val;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            result.Add(new List<int>(level));
            leftToRight = !leftToRight;
        }
        return result;
    }

    // P7: Boundary Traversal — Left boundary + Leaves + Right boundary (reversed).
    // P8: Morris Inorder — Threading-based O(1) space traversal.
    public IList<int> MorrisInorder(TreeNode root)
    {
        var result = new List<int>();
        TreeNode curr = root;
        while (curr != null)
        {
            if (curr.left == null) { result.Add(curr.val); curr = curr.right; }
            else
            {
                TreeNode pred = curr.left;
                while (pred.right != null && pred.right != curr) pred = pred.right;
                if (pred.right == null) { pred.right = curr; curr = curr.left; } // thread
                else { pred.right = null; result.Add(curr.val); curr = curr.right; } // unthread
            }
        }
        return result;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Height: max(leftH, rightH) + 1. O(n).
// - Diameter: max(lh+rh) at every node. Compute during height calculation.
// - Balanced: Return -1 (invalid) during height if |lh-rh| > 1. O(n).
// - LCA: Recurse. If split (found in both subtrees) → current node is LCA.
// - Same Tree: Both null→true, one null→false, val match + recurse.
// - Zig-Zag: BFS + alternate insertion direction per level.
// - Morris: Thread inorder predecessor's right to current. O(n) time, O(1) space.
// ============================================================
