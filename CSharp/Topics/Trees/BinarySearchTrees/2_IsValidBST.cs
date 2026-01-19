namespace CSharp.Topics.Trees.BinarySearchTrees;

public class IsValidBinarySearchTree
{
    public static (bool isValid, int? min, int? max) IsValidBST(TreeNode root)
    {
        if (root is null)
            return (true, null, null);

        var left = IsValidBST(root.left);
        var right = IsValidBST(root.right);

        if (!left.isValid || !right.isValid)
            return (false, null, null);

        if (left.max.HasValue && root.val <= left.max.Value)
            return (false, null, null);

        if (right.min.HasValue && root.val >= right.min.Value)
            return (false, null, null);

        int min = left.min.HasValue ? Math.Min(left.min.Value, root.val) : root.val;
        int max = right.max.HasValue ? Math.Max(right.max.Value, root.val) : root.val;

        return (true, min, max);
    }

    public static void Run()
    {
        var arr = new List<int?>() { 5, 4, 6, null, null, 3, 7 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        Console.WriteLine(IsValidBST(treeNode).Item1);
    }
}