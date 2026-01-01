namespace CSharp.Topics.Trees.BinaryTrees;

public class MergeTwoBinaryTrees
{
    public static TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 is null || root2 is null) return null;

        var leftNode = MergeTrees(root1?.left, root2?.left);
        var rightNode = MergeTrees(root1?.right, root2?.right);
        
        var newNode = new TreeNode((root1?.val ?? 0) + (root2?.val ?? 0));
        newNode.left = leftNode;
        newNode.right = rightNode;

        return newNode;
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
        
        var treeNode1 = new TreeNode(1);
        treeNode1.left = new TreeNode(2);
        treeNode1.right = new TreeNode(3);
        
        treeNode1.left.left = new TreeNode(4);
        treeNode1.left.right = new TreeNode(5);
        
        treeNode1.right.left = new TreeNode(6);
        treeNode1.right.right = new TreeNode(7);

        var mergedTree = MergeTrees(treeNode, treeNode1);
        
        TreeHelper.PrintPreOrderTraversal(mergedTree);
    }
}