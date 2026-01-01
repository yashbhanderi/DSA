namespace CSharp.Topics.Trees.BinaryTrees;

public class SymmetricTree
{
    public static bool IsSymmetric(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null) return true;

        if (root1 == null || root2 == null) return false;

        return root1.val == root2.val 
               && IsSymmetric(root1.left, root2.right) 
               && IsSymmetric(root1.right, root2.left);
    }

    public static void Run()
    {
        var treeNode = new TreeNode(1);
        treeNode.left = new TreeNode(2);
        treeNode.right = new TreeNode(3);
        
        treeNode.left.left = new TreeNode(3);
        treeNode.left.right = new TreeNode(4);
        
        treeNode.right.left = new TreeNode(4);
        treeNode.right.right = new TreeNode(3);

        Console.WriteLine(IsSymmetric(treeNode.left, treeNode.right));
    }
}