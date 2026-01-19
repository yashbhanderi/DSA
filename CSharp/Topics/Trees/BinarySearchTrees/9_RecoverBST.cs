namespace CSharp.Topics.Trees.BinarySearchTrees;

public class RecoverBST
{
    public static TreeNode node1 = null, node2 = null, prevNode = null;
    public static void IsValidBST(TreeNode root)
    {
        if (root is null) return;
        
        IsValidBST(root.left);

        if(prevNode is not null)
        {
            if (root.val <= prevNode.val)
            {
                if (node1 is null)
                {
                    node1 = prevNode;
                }
                node2 = root;
            }
        }
        prevNode = root;
        
        IsValidBST(root.right);
    }
    
    public static void RecoverTree(TreeNode root) {
        IsValidBST(root);
        (node1.val, node2.val) = (node2.val, node1.val);
        Console.WriteLine($"NODE 1 - {node1.val} | NODE 2 - {node2.val}");
    }

    public static void Run()
    {
        var arr = new List<int?>() { 3,null,2,null,1 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        RecoverTree(treeNode);
    }
}