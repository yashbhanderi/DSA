namespace CSharp.Topics.Trees.BinaryTrees;

public class BinaryTreeRightSideView
{
    public static IList<int> RightSideView(TreeNode root) 
    {
        List<int> resultList = [];

        if (root is null) return resultList;

        var mainQueue = new Queue<TreeNode>();
        mainQueue.Enqueue(root);

        while (mainQueue.Count > 0)
        {
            var currentLevelList = new List<int>();
            var nextLevelQueue = new Queue<TreeNode>();
            while (mainQueue.Count > 0)
            {
                var top = mainQueue.Dequeue();
                var leftNode = top.left;
                var rightNode = top.right;
                
                currentLevelList.Add(top.val);

                if (leftNode is not null)
                {
                    nextLevelQueue.Enqueue(leftNode);
                }
                if (rightNode is not null)
                {
                    nextLevelQueue.Enqueue(rightNode);
                }
            }

            resultList.Add(currentLevelList.Last());

            while (nextLevelQueue.Count > 0)
            {
                mainQueue.Enqueue(nextLevelQueue.Dequeue());
            }
        }

        return resultList;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 1,2,3,null,5,null,4 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        var result = RightSideView(treeNode);

        Console.WriteLine(string.Join(",", result));
    }
}