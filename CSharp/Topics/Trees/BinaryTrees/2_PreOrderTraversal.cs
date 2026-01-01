namespace CSharp.Topics.Trees.BinaryTrees;

public class PreOrderTraversal
{
    public static IList<int> PreOrder(TreeNode root, List<int> result)
    {
        if(root is null) return result;
        
        result.Add(root.val);
        PreOrder(root.left, result);
        PreOrder(root.right, result);
        
        return result;
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

        var PreOrderTraversal = PreOrder(treeNode, []);

        foreach (var e in PreOrderTraversal)
        {
            Console.WriteLine(e);
        }
    }
}