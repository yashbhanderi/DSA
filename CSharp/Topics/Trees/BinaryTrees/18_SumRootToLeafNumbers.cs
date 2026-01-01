namespace CSharp.Topics.Trees.BinaryTrees;

public class SumRootToLeafNumbers
{
    public static int totalSum = 0;
    public static void SumNumbers(TreeNode root, string sumTillNow)
    {
        if (root is null) return;
        
        if (root.left is null && root.right is null)
        {
            totalSum += int.Parse(sumTillNow);
            return;
        }

        if (root.left is not null)
        {
            sumTillNow += root.left.val.ToString();
            SumNumbers(root.left, sumTillNow);
            sumTillNow = sumTillNow.Remove(sumTillNow.Length - 1);
        }

        if (root.right is not null)
        {
            sumTillNow += root.right.val.ToString();
            SumNumbers(root.right, sumTillNow);
            sumTillNow = sumTillNow.Remove(sumTillNow.Length - 1);
        }
    }
    
    public static void Run()
    {
        var arr = new List<int?>() { 4,9,0,5,1 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        SumNumbers(treeNode, treeNode.val.ToString());
        Console.WriteLine(totalSum);
    }
}