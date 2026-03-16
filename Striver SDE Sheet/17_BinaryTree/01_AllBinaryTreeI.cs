// ============================================================
// Binary Tree Part I — 12 problems
// Topic: Binary Tree
// ============================================================
// Problems: Inorder, Preorder, Postorder (iterative+recursive),
//           Left View, Bottom View, Top View, 3-in-1 Traversal,
//           Vertical Order, Root to Node Path, Max Width,
//           Level Order, Right View
// ============================================================

using System;
using System.Collections.Generic;

public class TreeNode
{
    public int val;
    public TreeNode left, right;
    public TreeNode(int val = 0) { this.val = val; }
}

// --- P1-3: Inorder, Preorder, Postorder ---
public class TreeTraversals
{
    // RECURSIVE: O(n) time, O(h) space
    public IList<int> Inorder(TreeNode root) { var r = new List<int>(); InRec(root, r); return r; }
    private void InRec(TreeNode n, List<int> r) { if (n == null) return; InRec(n.left, r); r.Add(n.val); InRec(n.right, r); }

    public IList<int> Preorder(TreeNode root) { var r = new List<int>(); PreRec(root, r); return r; }
    private void PreRec(TreeNode n, List<int> r) { if (n == null) return; r.Add(n.val); PreRec(n.left, r); PreRec(n.right, r); }

    public IList<int> Postorder(TreeNode root) { var r = new List<int>(); PostRec(root, r); return r; }
    private void PostRec(TreeNode n, List<int> r) { if (n == null) return; PostRec(n.left, r); PostRec(n.right, r); r.Add(n.val); }

    // ITERATIVE Inorder: Stack-based. Push left until null, pop & process, go right.
    public IList<int> InorderIterative(TreeNode root)
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        var curr = root;
        while (curr != null || stack.Count > 0)
        {
            while (curr != null) { stack.Push(curr); curr = curr.left; }
            curr = stack.Pop(); result.Add(curr.val); curr = curr.right;
        }
        return result;
    }
}

// --- P4: Left View ---
// First node at each level (BFS or DFS tracking level).
public class LeftView
{
    public IList<int> Optimal(TreeNode root)
    {
        var result = new List<int>();
        DFS(root, 0, result);
        return result;
    }
    private void DFS(TreeNode node, int level, List<int> result)
    {
        if (node == null) return;
        if (level == result.Count) result.Add(node.val);
        DFS(node.left, level + 1, result);
        DFS(node.right, level + 1, result);
    }
}

// --- P5: Bottom View --- BFS with horizontal distance. Last node at each HD.
// --- P6: Top View --- BFS with horizontal distance. First node at each HD.
public class TopBottomView
{
    public IList<int> TopView(TreeNode root)
    {
        if (root == null) return new List<int>();
        var map = new SortedDictionary<int, int>();
        var queue = new Queue<(TreeNode node, int hd)>();
        queue.Enqueue((root, 0));
        while (queue.Count > 0)
        {
            var (node, hd) = queue.Dequeue();
            if (!map.ContainsKey(hd)) map[hd] = node.val; // first = top view
            if (node.left != null) queue.Enqueue((node.left, hd - 1));
            if (node.right != null) queue.Enqueue((node.right, hd + 1));
        }
        return new List<int>(map.Values);
    }

    public IList<int> BottomView(TreeNode root)
    {
        if (root == null) return new List<int>();
        var map = new SortedDictionary<int, int>();
        var queue = new Queue<(TreeNode node, int hd)>();
        queue.Enqueue((root, 0));
        while (queue.Count > 0)
        {
            var (node, hd) = queue.Dequeue();
            map[hd] = node.val; // always update = bottom view
            if (node.left != null) queue.Enqueue((node.left, hd - 1));
            if (node.right != null) queue.Enqueue((node.right, hd + 1));
        }
        return new List<int>(map.Values);
    }
}

// --- P7-12: Level Order, Right View, Max Width, Vertical Order, Root-to-Node, 3-in-1 ---
public class MoreTreeProblems
{
    // Level Order: BFS with queue, process level by level.
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int size = queue.Count;
            var level = new List<int>();
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            result.Add(level);
        }
        return result;
    }

    // Right View: DFS visiting right first, or last node at each BFS level.
    public IList<int> RightView(TreeNode root)
    {
        var result = new List<int>();
        DFS(root, 0, result);
        return result;
    }
    private void DFS(TreeNode node, int level, List<int> result)
    {
        if (node == null) return;
        if (level == result.Count) result.Add(node.val);
        DFS(node.right, level + 1, result);
        DFS(node.left, level + 1, result);
    }

    // Max Width: BFS with node indexing. Width = rightIndex - leftIndex + 1.
    public int WidthOfBinaryTree(TreeNode root)
    {
        if (root == null) return 0;
        int maxWidth = 0;
        var queue = new Queue<(TreeNode node, int index)>();
        queue.Enqueue((root, 0));
        while (queue.Count > 0)
        {
            int size = queue.Count, minIdx = queue.Peek().index;
            int first = 0, last = 0;
            for (int i = 0; i < size; i++)
            {
                var (node, idx) = queue.Dequeue();
                int normalizedIdx = idx - minIdx; // prevent overflow
                if (i == 0) first = normalizedIdx;
                if (i == size - 1) last = normalizedIdx;
                if (node.left != null) queue.Enqueue((node.left, 2 * normalizedIdx + 1));
                if (node.right != null) queue.Enqueue((node.right, 2 * normalizedIdx + 2));
            }
            maxWidth = Math.Max(maxWidth, last - first + 1);
        }
        return maxWidth;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Inorder iterative: Push left chain, pop & process, go right.
// - Left/Right View: DFS with level tracking. First/last at each level.
// - Top/Bottom View: BFS with horizontal distance (HD). Map HD → first/last.
// - Max Width: BFS with node indexing (left=2i+1, right=2i+2). Normalize to prevent overflow.
// - Level Order: BFS, process queue level by level using size.
// - Vertical Order: BFS with (HD, level) as key. SortedDictionary.
// ============================================================
