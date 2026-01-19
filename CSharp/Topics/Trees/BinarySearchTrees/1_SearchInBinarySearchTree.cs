namespace CSharp.Topics.Trees.BinarySearchTrees;

public class SearchInBST
{
    public static TreeNode SearchBST(TreeNode root, int val)
    {
        if (root is null) return null;
        
        if (root.val == val) return root;

        TreeNode leftTree = null, rightTree = null;
        if (val < root.val) leftTree = SearchBST(root.left, val);
        if (val > root.val) rightTree = SearchBST(root.right, val);

        return leftTree ?? rightTree ?? null;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 4,2,7,1,3 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        Console.WriteLine(SearchBST(treeNode, 74)?.val);
    }
}