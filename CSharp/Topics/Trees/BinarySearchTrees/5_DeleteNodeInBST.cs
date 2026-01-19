namespace CSharp.Topics.Trees.BinarySearchTrees;

public class DeleteNodeInBST
{
    public static TreeNode? FindNodeInBST(TreeNode root, int key)
    {
        if (root is null) return null;

        if (root.val == key) return root;

        TreeNode left = null, right = null;
        if (root.left is not null && key < root.val) left = FindNodeInBST(root.left, key);
        if (root.right is not null && key > root.val) right = FindNodeInBST(root.right, key);

        return left ?? right;
    }
        
    public static TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root is null) return null;

        root.left = DeleteNode(root.left, key);
        root.right = DeleteNode(root.right, key);

        if (root.val == key)
        {
            var rightNode = root.right;
            var leftNode = root.left;

            var smallestNodeInRight = rightNode;
            while (smallestNodeInRight.left != null)
            {
                smallestNodeInRight = smallestNodeInRight.left;
            }

            smallestNodeInRight.left = leftNode;
            return rightNode;
        }

        return root;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 5,3,6,2,4,null,7 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);
    
        TreeHelper.PrintPreOrderTraversal(treeNode);
        
        DeleteNode(treeNode, 3);
        
        TreeHelper.PrintPreOrderTraversal(treeNode);
        
    }
}