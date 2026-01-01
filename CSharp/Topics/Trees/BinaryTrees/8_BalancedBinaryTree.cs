namespace CSharp.Topics.Trees.BinaryTrees;

public class BalancedBinaryTree
{
    public static int MaxDepth(TreeNode root) {
        if(root is null) return 0;
        
        var leftSubTreeHeight = MaxDepth(root.left);
        var rightSubTreeHeight = MaxDepth(root.right);
        
        return 1 + Math.Max(leftSubTreeHeight, rightSubTreeHeight);
    }
    
    public static bool IsBalanced(TreeNode root)
    {
        if (root == null) return true;

        var leftHeight = MaxDepth(root.left);
        var rightHeight = MaxDepth(root.right);

        return (leftHeight - rightHeight <= 1) && IsBalanced(root.left) && IsBalanced(root.right);
    }

    public static void Run()
    {
        var treeNode = new TreeNode(1);
        treeNode.left = new TreeNode(2);
        treeNode.right = new TreeNode(3);
        
        treeNode.left.left = new TreeNode(3);
        treeNode.left.right = new TreeNode(4);
        
        treeNode.left.left = new TreeNode(4);
        treeNode.right.right = new TreeNode(3);

        Console.WriteLine(IsBalanced(treeNode));
    }
}