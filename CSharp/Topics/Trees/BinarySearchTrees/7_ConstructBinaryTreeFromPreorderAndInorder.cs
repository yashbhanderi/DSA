namespace CSharp.Topics.Trees.BinarySearchTrees;

public class ConstructBinaryTreeFromPreorderAndInorder
{
    public static TreeNode BuildTree(List<int> preorder, List<int> inorder)
    {
        if (preorder.Count is 0 || inorder.Count is 0) return null;

        int root = preorder[0];

        List<int> leftPreOrder = [], rightPreOrder = [];
        List<int> leftInOrder = [], rightInOrder = [];

        int i = 1, j = 0;
        for (; i < preorder.Count; i++, j++)
        {
            if (inorder[j] == root)
            {
                j++;
                break;
            }
            
            leftPreOrder.Add(preorder[i]);
            leftInOrder.Add(inorder[j]);
        }

        for (; i < preorder.Count; i++, j++)
        {
            rightPreOrder.Add(preorder[i]);
            rightInOrder.Add(inorder[j]);
        }

        var rootNode = new TreeNode(root);
        rootNode.left = BuildTree(leftPreOrder, leftInOrder);
        rootNode.right = BuildTree(rightPreOrder, rightInOrder);

        return rootNode;
    }

    public static void Run()
    {
        int[] preorder = [3, 9, 20, 15, 7], inorder = [9, 3, 15, 20, 7];
        var treeNode = BuildTree(preorder.ToList(), inorder.ToList());
        
        TreeHelper.PrintPreOrderTraversal(treeNode);
    }
}