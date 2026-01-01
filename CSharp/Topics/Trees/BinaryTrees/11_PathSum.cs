namespace CSharp.Topics.Trees.BinaryTrees;

public class PathSum
{
    public static bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root.left is null && root.right is null)
        {
            if (targetSum == 0) return true;
            else return false;
        }
        
        var isLeftTreeHasPathSum = false;
        if(root.left is not null) {
            isLeftTreeHasPathSum = HasPathSum(root.left, targetSum - root.left.val);
        }
        var isRightTreeHasPathSum = false;
        if(root.right is not null) {
            isRightTreeHasPathSum = HasPathSum(root.right, targetSum - root.right.val);
        }

        return isLeftTreeHasPathSum || isRightTreeHasPathSum;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        Console.WriteLine(HasPathSum(treeNode, 22-treeNode.val));
    }
}