namespace CSharp.Topics.Trees.BinaryTrees;

public class LowestCommonAncestor
{
    public static TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root is null) return null;

        var leftTree = LCA(root.left, p, q);
        var rightTree = LCA(root.right, p, q);

        if (leftTree is not null && rightTree is not null) return root;

        if (root == p || root == q) return root;
        return null;
    }

    public static void Run()
    {
        var treeNode = new TreeNode(1);
        treeNode.left = new TreeNode(2);
        treeNode.right = new TreeNode(3);
        
        treeNode.left.left = new TreeNode(4);
        treeNode.left.right = new TreeNode(5);
        
        var lcaNode = LCA(treeNode, treeNode.left, treeNode.right);
        Console.WriteLine(lcaNode.val);
    }
}