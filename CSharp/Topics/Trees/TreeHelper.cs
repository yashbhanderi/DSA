using System.Text;

namespace CSharp.Topics.Trees;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public static class TreeHelper
{
    // Inorder traversal
    public static void PrintInOrderTraversal(TreeNode? root)
    {
        if (root is null)
        {
            return;
        }

        PrintInOrderTraversal(root.left);
        Console.WriteLine(root.val);
        PrintInOrderTraversal(root.right);
    }
    
    // Inorder traversal
    public static void PrintPreOrderTraversal(TreeNode? root)
    {
        if (root is null)
        {
            return;
        }

        Console.WriteLine(root.val);
        PrintInOrderTraversal(root.left);
        PrintInOrderTraversal(root.right);
    }
    
    // Level-order traversal to Generate a Binary Tree
    public static TreeNode BuildBinaryTree(List<int?> arr) {
        if (arr == null || arr.Count == 0 || arr[0] == null) return null;
        
        var root = new TreeNode(arr[0].Value);
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        int i = 1;
        
        while (q.Count > 0 && i < arr.Count) {
            var node = q.Dequeue();
            
            if (i < arr.Count && arr[i] != null) {
                node.left = new TreeNode(arr[i].Value);
                q.Enqueue(node.left);
            }
            i++;
            
            if (i < arr.Count && arr[i] != null) {
                node.right = new TreeNode(arr[i].Value);
                q.Enqueue(node.right);
            }
            i++;
        }
        
        return root;
    }

    public static string PrintLevelOrderTraversal(TreeNode treeNode)
    {
        var ans = new StringBuilder();
        if (treeNode == null) return ans.ToString();
        
        var root = treeNode;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        ans.Append(root.val);
        int i = 1;
        
        while (q.Count > 0) {
            var node = q.Dequeue();
            
            if (node?.left is not null) {
                q.Enqueue(node.left);
                ans.Append("|" + node.left.val);
            }
            else
            {
                ans.Append("|" + "null");
            }
            
            if (node?.right is not null) {
                q.Enqueue(node.right);
                ans.Append("|" + node.right.val);
            }
            else
            {
                ans.Append("|" + "null");
            }
        }
        
        return ans.ToString();
    }
}