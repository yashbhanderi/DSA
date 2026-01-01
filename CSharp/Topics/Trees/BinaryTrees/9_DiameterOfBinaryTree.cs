namespace CSharp.Topics.Trees.BinaryTrees;

public class DiameterOfBinaryTree
{
    public static int MaxDiameter = 0;
    public static int GetHeightOfBinaryTree(TreeNode root)
    {
        if (root is null) return 0;

        var leftTreeHeight = GetHeightOfBinaryTree(root.left);
        var rightTreeHeight = GetHeightOfBinaryTree(root.right);

        MaxDiameter = Math.Max(MaxDiameter, leftTreeHeight + rightTreeHeight);

        return 1 + Math.Max(leftTreeHeight, rightTreeHeight);
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

        GetHeightOfBinaryTree(treeNode);
        Console.WriteLine(MaxDiameter);
    }
}