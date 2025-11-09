namespace Trees.BinaryTrees;

public class GetAllNodesAtKDistance
{
    public static Dictionary<TreeNode, TreeNode> childParentMapping = [];
    public static HashSet<TreeNode> visitedNodes = [];
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

    private static void GetNodes(TreeNode root, int K, List<TreeNode> nodes)
    {
        if (root == null) return;

        if (visitedNodes.Contains(root))
        {
            return;
        }

        if (K == 0)
        {
            nodes.Add(root);
            return;
        }

        visitedNodes.Add(root);

        if (childParentMapping.TryGetValue(root, out var parentNode))
        {
            GetNodes(parentNode, K - 1, nodes);
        }
        GetNodes(root.left, K - 1, nodes);
        GetNodes(root.right, K - 1, nodes);
    }

    private static List<int> GetNodesAtKDistance(TreeNode root, TreeNode target, int K)
    {
        var nodes = new List<TreeNode>();

        GetChildParentMapping(root, childParentMapping);

        GetNodes(target, K, nodes);

        var ans = new List<int>();

        nodes.ForEach(x =>
        {
            ans.Add(x.val);
        });

        return ans;
    }

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

        // head1.left = head3;
        // head1.right = head4;

        head2.left = head5;
        // head2.right = head6;

        // head6.left = new TreeNode(10);

        var ans = GetNodesAtKDistance(head, head5, 3);

        ans.ForEach(x => System.Console.WriteLine(x));
    }
}