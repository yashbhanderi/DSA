namespace CSharp.Topics.Trees.BinaryTrees;

public class PostOrderTraversal
{
    public static IList<int> PostOrder(TreeNode root, List<int> result)
    {
        if(root is null) return result;
        
        PostOrder(root.left, result);
        PostOrder(root.right, result);
        result.Add(root.val);
        
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

        var PostOrderTraversal = PostOrder(treeNode, []);

        foreach (var e in PostOrderTraversal)
        {
            Console.WriteLine(e);
        }
    }
}