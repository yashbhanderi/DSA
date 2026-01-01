namespace CSharp.Topics.Trees.BinaryTrees;

public class BinaryTreeMaximumPathSum
{
    public static int ans = int.MinValue;
    public static int MaxPathSum(TreeNode root) {
        if (root is null) return 0;

        var leftTreeSum = MaxPathSum(root.left);
        var rightTreeSum = MaxPathSum(root.right);
        var currentSum = root.val + Math.Max(leftTreeSum, rightTreeSum);

        // Sum of 3 nodes, main node, left node & right node
        ans = Math.Max(ans, root.val + leftTreeSum + rightTreeSum);
        ans = Math.Max(ans, currentSum);
            
        return currentSum;
    }
    
    public static void Run()
    {
        var arr = new List<int?>() { -10,9,20,null,null,15,7 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        MaxPathSum(treeNode);
        Console.WriteLine(ans);
    }
}