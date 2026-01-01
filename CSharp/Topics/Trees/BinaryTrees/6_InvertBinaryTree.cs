namespace CSharp.Topics.Trees.BinaryTrees;

public class InvertBinaryTree
{
    public static void InvertTree(TreeNode root)
    {
        if (root == null) return;
        
        InvertTree(root.left);
        InvertTree(root.right);
        
        (root.left, root.right) = (root.right, root.left);
    }

    public static void Run()
    {
        var treeNode = new TreeNode(1);
        treeNode.left = new TreeNode(2);
        treeNode.right = new TreeNode(3);
        
        treeNode.left.left = new TreeNode(4);
        treeNode.left.right = new TreeNode(5);
        
        treeNode.right.left = new TreeNode(6);
        treeNode.right.right = new TreeNode(7);

        TreeHelper.PrintPreOrderTraversal(treeNode);
        InvertTree(treeNode);
        Console.WriteLine("-----");
        TreeHelper.PrintPreOrderTraversal(treeNode);
    }
}