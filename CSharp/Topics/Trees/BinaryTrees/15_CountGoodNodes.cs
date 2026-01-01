namespace CSharp.Topics.Trees.BinaryTrees;

public class CountGoodNodes
{
    public static int GoodNodes(TreeNode root, int maxNodeTillHere)
    {
        if (root is null) return 0;

        maxNodeTillHere = Math.Max(maxNodeTillHere, root.val);

        return (root.val >= maxNodeTillHere ? 1 : 0) 
                            + GoodNodes(root.left, maxNodeTillHere)
                            + GoodNodes(root.right, maxNodeTillHere);
    }

    public static void Run()
    {
        var arr = new List<int?>() { 3,1,4,3,null,1,5 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);
        Console.WriteLine(GoodNodes(treeNode, treeNode.val)); 
    }
}