namespace CSharp.Topics.Trees.BinaryTrees;

public class MaximumDepthOfBinaryTree
{
    public static int MaxDepth(TreeNode root) {
        if(root is null) return 0;
        
        var leftSubTreeHeight = MaxDepth(root.left);
        var rightSubTreeHeight = MaxDepth(root.right);
        
        return 1 + Math.Max(leftSubTreeHeight, rightSubTreeHeight);
    }
    
    public static void Run()
    {
        var treeNode = new TreeNode(1);
        treeNode.left = new TreeNode(2);
        treeNode.right = new TreeNode(3);
        
        treeNode.left.left = new TreeNode(4);
        treeNode.left.right = new TreeNode(5);

        Console.WriteLine(MaxDepth(treeNode));
    }
}