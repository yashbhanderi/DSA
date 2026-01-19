using System.Text;

namespace CSharp.Topics.Trees.BinaryTrees;

public class HouseRobber3
{
    public static int Rob(TreeNode root) {
        if (root is null) return 0;
        
        var mainQueue = new Queue<TreeNode>();
        mainQueue.Enqueue(root);
        var ans1 = 0;
        var ans2 = 0;
        var flag = true;

        while (mainQueue.Count > 0)
        {
            var money = 0;
            var nextLevelQueue = new Queue<TreeNode>();
            while (mainQueue.Count > 0)
            {
                var top = mainQueue.Dequeue();
                var leftNode = top.left;
                var rightNode = top.right;
                money += top.val;
                
                if (leftNode is not null)
                {
                    nextLevelQueue.Enqueue(leftNode);
                }
                if (rightNode is not null)
                {
                    nextLevelQueue.Enqueue(rightNode);
                }
            }

            if (flag) ans2 += money;
            else ans1 += money;
            
            flag = !flag;

            while (nextLevelQueue.Count > 0)
            {
                mainQueue.Enqueue(nextLevelQueue.Dequeue());
            }
        }
        
        return Math.Max(ans1, ans2);
    }

    public static void Run()
    {
        var arr = new List<int?>() { 3,2,3,null,3,null,1 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        Console.WriteLine(Rob(treeNode));
    }
}