// ============================================================
// Binary Tree Part III — 7 problems
// Topic: Binary Tree III
// ============================================================
// Problems: Max Path Sum, Construct BT from Pre+In, Construct BT from In+Post,
//           Symmetric Tree, Flatten BT to Linked List, Check Mirror, Children Sum
// ============================================================

using System;
using System.Collections.Generic;

public class BinaryTreeIII
{
    // P1: Maximum Path Sum — Path can start/end at any node.
    private int maxPathResult = int.MinValue;
    public int MaxPathSum(TreeNode root) { maxPathResult = int.MinValue; MaxGain(root); return maxPathResult; }
    private int MaxGain(TreeNode node)
    {
        if (node == null) return 0;
        int left = Math.Max(0, MaxGain(node.left));   // ignore negative paths
        int right = Math.Max(0, MaxGain(node.right));
        maxPathResult = Math.Max(maxPathResult, left + right + node.val); // path through node
        return node.val + Math.Max(left, right); // return best single branch
    }

    // P2: Construct BT from Preorder and Inorder
    public TreeNode BuildFromPreIn(int[] preorder, int[] inorder)
    {
        var inMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) inMap[inorder[i]] = i;
        int preIdx = 0;
        return BuildPreIn(preorder, ref preIdx, 0, inorder.Length - 1, inMap);
    }
    private TreeNode BuildPreIn(int[] pre, ref int preIdx, int inStart, int inEnd, Dictionary<int, int> map)
    {
        if (inStart > inEnd) return null;
        var node = new TreeNode(pre[preIdx++]);
        int inIdx = map[node.val];
        node.left = BuildPreIn(pre, ref preIdx, inStart, inIdx - 1, map);
        node.right = BuildPreIn(pre, ref preIdx, inIdx + 1, inEnd, map);
        return node;
    }

    // P3: Construct BT from Inorder and Postorder
    public TreeNode BuildFromInPost(int[] inorder, int[] postorder)
    {
        var inMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) inMap[inorder[i]] = i;
        int postIdx = postorder.Length - 1;
        return BuildInPost(postorder, ref postIdx, 0, inorder.Length - 1, inMap);
    }
    private TreeNode BuildInPost(int[] post, ref int postIdx, int inStart, int inEnd, Dictionary<int, int> map)
    {
        if (inStart > inEnd) return null;
        var node = new TreeNode(post[postIdx--]);
        int inIdx = map[node.val];
        node.right = BuildInPost(post, ref postIdx, inIdx + 1, inEnd, map); // RIGHT first!
        node.left = BuildInPost(post, ref postIdx, inStart, inIdx - 1, map);
        return node;
    }

    // P4: Symmetric Tree — Mirror of itself
    public bool IsSymmetric(TreeNode root) => root == null || IsMirror(root.left, root.right);
    private bool IsMirror(TreeNode a, TreeNode b)
    {
        if (a == null && b == null) return true;
        if (a == null || b == null) return false;
        return a.val == b.val && IsMirror(a.left, b.right) && IsMirror(a.right, b.left);
    }

    // P5: Flatten BT to Linked List (Preorder using right pointers)
    public void Flatten(TreeNode root)
    {
        TreeNode curr = root;
        while (curr != null)
        {
            if (curr.left != null)
            {
                TreeNode pred = curr.left;
                while (pred.right != null) pred = pred.right;
                pred.right = curr.right;
                curr.right = curr.left;
                curr.left = null;
            }
            curr = curr.right;
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Max Path Sum: At each node, max(0, left) + max(0, right) + val. Return best single branch.
// - Build from Pre+In: Preorder gives root. Inorder splits left/right subtrees.
// - Build from In+Post: Postorder gives root (last element). Build RIGHT subtree first!
// - Symmetric: Compare left.left↔right.right AND left.right↔right.left.
// - Flatten: Morris-like. Find predecessor of left subtree, connect right, shift left to right.
// ============================================================
