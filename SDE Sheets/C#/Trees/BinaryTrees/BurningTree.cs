namespace Trees.BinaryTrees;

public class BurningTree
{
    public static void Run()
    {
        var head = new TreeNode(3);
        var head1 = new TreeNode(5);
        var head2 = new TreeNode(1);
        var head3 = new TreeNode(6);
        var head4 = new TreeNode(2);
        var head5 = new TreeNode(0);
        var head6 = new TreeNode(8);

        head.left = head1;
        head.right = head2;

        head1.left = head3;
        head1.right = head4;

        head2.right = head6;

        head4.left = new TreeNode(10);
        head4.right = new TreeNode(11);

        head6.right = head5;

        head5.right = new TreeNode(13);

        var ans = GetBurningTime(head, 11);

        System.Console.WriteLine(ans);
    }

    public static Dictionary<TreeNode, TreeNode> childParentMapping = new Dictionary<TreeNode, TreeNode>();
    public static HashSet<TreeNode> visitedNodes = [];

    private static int GetBurningTime(TreeNode root, int target) {
        GetChildParentMapping(root, childParentMapping);  

        var burnNode = GetBurnNode(root, target);
        
        int time = 0;
        BurnTree(burnNode, ref time);

        return time;
    }

    private static void BurnTree(TreeNode root, ref int time) {
        if(root == null) return;

        var parentNode = new TreeNode();
        childParentMapping.TryGetValue(root, out parentNode);

        var leftChild = root.left; 
        var rightChild = root.right;

        var isParallelBurnPossible = 0;

        if(parentNode is not null && !visitedNodes.Contains(parentNode)) isParallelBurnPossible++;
        if(leftChild is not null && !visitedNodes.Contains(leftChild)) isParallelBurnPossible++;
        if(rightChild is not null && !visitedNodes.Contains(rightChild)) isParallelBurnPossible++;

        if(!((parentNode is not null && !visitedNodes.Contains(parentNode))
            || (leftChild is not null && !visitedNodes.Contains(leftChild))
            || (rightChild is not null && !visitedNodes.Contains(rightChild))))
        {
            return;
        } 

        time++;
        visitedNodes.Add(root);    
        if(parentNode is not null) visitedNodes.Add(parentNode);    
        if(leftChild is not null) visitedNodes.Add(leftChild);    
        if(rightChild is not null) visitedNodes.Add(rightChild);    

        if(parentNode is not null) BurnTree(parentNode, ref time);
        if(leftChild is not null) BurnTree(leftChild, ref time);
        if(rightChild is not null) BurnTree(rightChild, ref time);

        if(isParallelBurnPossible > 1) time--; 
    }

    private static TreeNode GetBurnNode(TreeNode root, int target) {
        if(root == null) return null;

        if(target == root.val) return root;

        var leftTree = GetBurnNode(root.left, target);
        var rightTree = GetBurnNode(root.right, target);


        return leftTree is not null ? leftTree : rightTree is null ? null : rightTree;
    }

    private static void GetChildParentMapping(TreeNode root, Dictionary<TreeNode, TreeNode> childParentMapping)
    {
        if (root == null) return;

        if (root.left != null)
        {
            childParentMapping.TryAdd(root.left, root);
        }

        if (root.right != null)
        {
            childParentMapping.TryAdd(root.right, root);
        }

        GetChildParentMapping(root.left, childParentMapping);
        GetChildParentMapping(root.right, childParentMapping);
    }
}