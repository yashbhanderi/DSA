namespace CSharp.Topics.Trees.BinarySearchTrees;

public class InsertIntoBinarySearchTree
{
    public static TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root is null) return new TreeNode(val);
        
        if(val < root.val) root.left = InsertIntoBST(root.left, val);
        else if(val > root.val) root.right = InsertIntoBST(root.right, val);

        return root;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 4, 2, 6, null, null, 5, 7 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        InsertIntoBST(treeNode, 11);
    }
}