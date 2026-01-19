namespace CSharp.Topics.Trees.BinarySearchTrees;

public class KthSmallestInBST
{
    public static int cnt = 0;
    public static int KthSmallest(TreeNode root, int k) {
        if (root is null) return -1;
        
        var left = KthSmallest(root.left, k);
        cnt++;
        if (cnt == k)
        {
            return root.val;
        }
        var right = KthSmallest(root.right, k);

        if(left != -1) return left;
        if(right != -1) return right;

        return -1;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 3,1,4,null,2 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        Console.WriteLine(KthSmallest(treeNode, 4));
    }
}