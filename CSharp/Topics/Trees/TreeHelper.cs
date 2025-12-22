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
}