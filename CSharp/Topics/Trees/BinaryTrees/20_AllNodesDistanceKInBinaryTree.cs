namespace CSharp.Topics.Trees.BinaryTrees;

public class AllNodesDistanceKInBinaryTree
{
    public static Dictionary<TreeNode, TreeNode> ParentChildNodeMapping = [];
    public static void GenerateParentChildNodeMapping(TreeNode root)
    {
        if (root == null) return;

        if (root.left != null)
        {
            ParentChildNodeMapping[root.left] = root; // Using indexer is safer than .Add()
            GenerateParentChildNodeMapping(root.left);
        }

        if (root.right != null)
        {
            ParentChildNodeMapping[root.right] = root;
            GenerateParentChildNodeMapping(root.right);
        }
    }

    public static IList<int> nodesList = [];
    public static TreeNode targetNode = null;
    public static HashSet<int> visitedNodes = [];
    public static void NodesAtDistanceK(TreeNode root, int k)
    {
        if (root == null || visitedNodes.Contains(root.val)) return;

        if (k == 0)
        {
            if (targetNode == root) return;
            nodesList.Add(root.val);
            return;
        }
        
        visitedNodes.Add(root.val);
        
        if (ParentChildNodeMapping.TryGetValue(root, out var parentNode))
        {
            NodesAtDistanceK(parentNode, k-1);
        }
        
        NodesAtDistanceK(root.left, k-1);
        NodesAtDistanceK(root.right, k-1);
    }
    
    public static IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        if (root is null) return nodesList;
        
        GenerateParentChildNodeMapping(root);

        targetNode = target;
        NodesAtDistanceK(target, k);

        return nodesList;
    }

    public static void Run()
    {
        var treeNode = new TreeNode(1);
        treeNode.left = new TreeNode(2);
        treeNode.right = new TreeNode(3);
        
        treeNode.left.left = new TreeNode(4);
        treeNode.left.right = new TreeNode(5);
        treeNode.right.left = new TreeNode(6);
        treeNode.right.right = new TreeNode(7);
        
        var nodes = DistanceK(treeNode, treeNode, 2);
        Console.WriteLine(string.Join(",", nodes));
    }
}