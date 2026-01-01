namespace CSharp.Topics.Trees.BinaryTrees;

public class ZigZagLevelOrderTraversal
{
    public static IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> resultList = [];

        if (root is null) return resultList;

        var isLeftToRight = false;
        var mainQueue = new Queue<TreeNode>();
        mainQueue.Enqueue(root);

        while (mainQueue.Count > 0)
        {
            var currentLevelList = new List<int>();
            var nextLevelStack = new Stack<TreeNode>();
            
            while (mainQueue.Count > 0)
            {
                var top = mainQueue.Dequeue();
                var leftNode = top.left;
                var rightNode = top.right;
                
                currentLevelList.Add(top.val);

                if (isLeftToRight)
                {
                    if (leftNode is not null)
                    {
                        nextLevelStack.Push(leftNode);
                    }
                    if (rightNode is not null)
                    {
                        nextLevelStack.Push(rightNode);
                    }
                }
                else
                {
                    if (rightNode is not null)
                    {
                        nextLevelStack.Push(rightNode);
                    }
                    if (leftNode is not null)
                    {
                        nextLevelStack.Push(leftNode);
                    }
                }
            }

            resultList.Add(currentLevelList);
            isLeftToRight = !isLeftToRight;

            while (nextLevelStack.Count > 0)
            {
                mainQueue.Enqueue(nextLevelStack.Pop());
            }
        }

        return resultList;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);
        
        var ans = ZigzagLevelOrder(treeNode);

        foreach (var list in ans)
        {
            Console.WriteLine(string.Join(",", list));
        }
    }
}