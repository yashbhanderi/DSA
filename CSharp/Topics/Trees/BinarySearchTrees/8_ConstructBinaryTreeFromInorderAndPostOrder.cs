namespace CSharp.Topics.Trees.BinarySearchTrees;

public class ConstructBinaryTreeFromInorderAndPostOrder
{
    public static TreeNode BuildTree(List<int> postorder, List<int> inorder)
    {
        if (postorder.Count is 0 || inorder.Count is 0) return null;

        int N = inorder.Count;
        int root = postorder[N-1];

        List<int> leftPostOrder = [], rightPostOrder = [];
        List<int> leftInOrder = [], rightInOrder = [];

        int i = 0, j = 0;
        for (; i < N; i++, j++)
        {
            if (inorder[j] == root)
            {
                j++;
                break;
            }
            
            leftPostOrder.Add(postorder[i]);
            leftInOrder.Add(inorder[j]);
        }

        for (; i < N-1; i++, j++)
        {
            rightPostOrder.Add(postorder[i]);
            rightInOrder.Add(inorder[j]);
        }

        var rootNode = new TreeNode(root);
        rootNode.left = BuildTree(leftPostOrder, leftInOrder);
        rootNode.right = BuildTree(rightPostOrder, rightInOrder);

        return rootNode;
    }

    public static void Run()
    {
        int[] postorder = [9,15,7,20,3], inorder = [9, 3, 15, 20, 7];
        Array.Reverse(postorder);
        var treeNode = BuildTree(postorder.ToList(), inorder.ToList());
        
        TreeHelper.PrintPreOrderTraversal(treeNode);
    }
}