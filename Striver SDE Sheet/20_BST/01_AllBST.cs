// ============================================================
// BST Part I — 7 problems
// Topic: Binary Search Tree
// ============================================================
// Problems: Populate Next Right, Search BST, Construct BST from Preorder,
//           Validate BST, LCA of BST, Predecessor/Successor, BST Iterator
// ============================================================

using System;
using System.Collections.Generic;

public class BSTProblems
{
    // P1: Search in BST — Binary search using BST property. O(h).
    public TreeNode SearchBST(TreeNode root, int val)
    {
        while (root != null && root.val != val)
            root = val < root.val ? root.left : root.right;
        return root;
    }

    // P2: Validate BST — Every node must be in valid range.
    public bool IsValidBST(TreeNode root) => Validate(root, long.MinValue, long.MaxValue);
    private bool Validate(TreeNode node, long min, long max)
    {
        if (node == null) return true;
        if (node.val <= min || node.val >= max) return false;
        return Validate(node.left, min, node.val) && Validate(node.right, node.val, max);
    }

    // P3: LCA of BST — Both in left → go left. Both in right → go right. Split → LCA.
    public TreeNode LCABST(TreeNode root, TreeNode p, TreeNode q)
    {
        while (root != null)
        {
            if (p.val < root.val && q.val < root.val) root = root.left;
            else if (p.val > root.val && q.val > root.val) root = root.right;
            else return root; // split point = LCA
        }
        return null;
    }

    // P4: Construct BST from Preorder
    private int preIdx = 0;
    public TreeNode BstFromPreorder(int[] preorder)
    {
        preIdx = 0;
        return Build(preorder, int.MaxValue);
    }
    private TreeNode Build(int[] pre, int bound)
    {
        if (preIdx >= pre.Length || pre[preIdx] > bound) return null;
        var node = new TreeNode(pre[preIdx++]);
        node.left = Build(pre, node.val);
        node.right = Build(pre, bound);
        return node;
    }

    // P5: Inorder Predecessor and Successor in BST
    public (TreeNode pred, TreeNode succ) FindPredSucc(TreeNode root, int key)
    {
        TreeNode pred = null, succ = null;
        while (root != null)
        {
            if (root.val < key) { pred = root; root = root.right; }
            else if (root.val > key) { succ = root; root = root.left; }
            else
            {
                // Predecessor: rightmost in left subtree
                if (root.left != null) { var t = root.left; while (t.right != null) t = t.right; pred = t; }
                // Successor: leftmost in right subtree
                if (root.right != null) { var t = root.right; while (t.left != null) t = t.left; succ = t; }
                break;
            }
        }
        return (pred, succ);
    }
}

// P6: BST Iterator — Inorder traversal using controlled stack.
public class BSTIterator
{
    private Stack<TreeNode> stack = new();
    public BSTIterator(TreeNode root) { PushLeft(root); }
    public int Next() { var node = stack.Pop(); PushLeft(node.right); return node.val; }
    public bool HasNext() => stack.Count > 0;
    private void PushLeft(TreeNode node) { while (node != null) { stack.Push(node); node = node.left; } }
}

// ============================================================
// QUICK REVISION NOTES:
// - Search BST: Go left if val < root, right if val > root. O(h).
// - Validate BST: Pass min/max range. Use long to handle INT_MIN/MAX edge cases.
// - LCA of BST: Iterative! If both < root → left. Both > root → right. Else → LCA.
// - BST from Preorder: Use upper bound technique. O(n).
// - Predecessor: Rightmost in left subtree. Successor: Leftmost in right subtree.
// - BST Iterator: Stack-based controlled inorder. Next() and HasNext() in O(1) amortized.
// ============================================================
