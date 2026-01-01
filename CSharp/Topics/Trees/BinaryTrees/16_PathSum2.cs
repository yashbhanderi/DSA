namespace CSharp.Topics.Trees.BinaryTrees;

public class PathSum2
{
    public static IList<IList<int>> resultList = [];
    public static void PathSum(TreeNode root, int targetSum, List<int> list)
    {
        if (root is null) return;
        
        if (root.left is null && root.right is null)
        {
            if (targetSum == 0)
            {
                resultList.Add(new List<int>(list));
            }
        }

        if (root.left is not null)
        {
            list.Add(root.left.val);
            PathSum(root.left, targetSum - root.left.val, list);
            list.RemoveAt(list.Count-1);
        }

        if (root.right is not null)
        {
            list.Add(root.right.val);
            PathSum(root.right, targetSum - root.right.val, list);
            list.RemoveAt(list.Count-1);
        }
    }
    
    public static void Run()
    {
        var arr = new List<int?>() { 5,4,8,11,null,13,4,7,2,null,null,5,1 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        PathSum(treeNode, 22-treeNode.val, [treeNode.val]);

        foreach (var list in resultList)
        {
            Console.WriteLine(string.Join(",", list));
        }
    }
}