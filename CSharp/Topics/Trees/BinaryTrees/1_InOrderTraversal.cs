namespace CSharp.Topics.Trees.BinaryTrees;

public class InOrderTraversal
{

    public static IList<int> InOrder(TreeNode root, List<int> result)
    {
        if(root is null) return result;
        
        InOrder(root.left, result);
        result.Add(root.val);
        InOrder(root.right, result);
        
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

        var inOrderTraversal = InOrder(treeNode, []);

        foreach (var e in inOrderTraversal)
        {
            Console.WriteLine(e);
        }
    }
}