namespace CSharp.Topics.Trees.BinaryTrees;

public class LevelOrderTraversal
{
    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        List<IList<int>> resultList = [];

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

            resultList.Add(currentLevelList);

            while (nextLevelQueue.Count > 0)
            {
                mainQueue.Enqueue(nextLevelQueue.Dequeue());
            }
        }

        return resultList;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        var ans = LevelOrder(treeNode);

        foreach (var list in ans)
        {
            Console.WriteLine(string.Join(",", list));
        }
    }
}