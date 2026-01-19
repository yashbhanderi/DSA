namespace CSharp.Topics.Trees.BinaryTrees;

public class FlattenBinaryTreeToLinkedList
{
    public static void Flatten(TreeNode root)
    {
        if (root is null) return;
        
        Flatten(root.left);
        Flatten(root.right);

        if (root.left is not null)
        {
            var right = root.right;
            var left = root.left;
            var rightMostNodeInLeft = root.left;

            while (rightMostNodeInLeft?.right is not null)
            {
                rightMostNodeInLeft = rightMostNodeInLeft.right;
            }

            root.left = null;
            root.right = left;
            rightMostNodeInLeft.right = right;
        }
    }

    public static void Run()
    {
        var arr = new List<int?>() { 1,2,5,3,4,null,6 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);  
        
        Flatten(treeNode);
    }
}