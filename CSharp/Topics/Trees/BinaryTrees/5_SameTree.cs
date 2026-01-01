namespace CSharp.Topics.Trees.BinaryTrees;

public class SameTree
{
    public static bool IsSameTree(TreeNode? treeNode1, TreeNode? treeNode2) {
        if(treeNode1 == null && treeNode2 == null) return true;

        var isCurrentNodeSame = treeNode1?.val == treeNode2?.val;
        
        return isCurrentNodeSame
               && IsSameTree(treeNode1.left, treeNode2.left) 
               && IsSameTree(treeNode1.right, treeNode2.right);
    }
    
    public static void Run()
    {
        var treeNode1 = new TreeNode(1);
        treeNode1.left = new TreeNode(2);
        treeNode1.right = new TreeNode(3);
        
        treeNode1.left.left = new TreeNode(4);
        treeNode1.left.right = new TreeNode(5);
        
        var treeNode2 = new TreeNode(1);
        treeNode2.left = new TreeNode(2);
        treeNode2.right = new TreeNode(3);
        
        treeNode2.left.left = new TreeNode(4);
        treeNode2.left.right = new TreeNode(5);

        Console.WriteLine(IsSameTree(treeNode1, treeNode2));
    }
}