namespace Trees.BinaryTrees;

public class ConstructTreeFromPostOrderAndInOrder {

    public static TreeNode constructTree(int[] postorder, int[] inorder) {
        if(postorder.Length == 0 || inorder.Length == 0) return null;

        var rootIndex = Array.IndexOf(inorder, postorder[postorder.Length-1]);

        var leftInorderArray = inorder.Skip(0).Take(rootIndex).ToArray();
        var rightInorderArray = inorder.Skip(rootIndex+1).Take(inorder.Length-1).ToArray();

        var leftPostorderArray = postorder.Skip(0).Take(leftInorderArray.Length).ToArray();
        var rightPostorderArray = postorder.Skip(leftInorderArray.Length).Take(rightInorderArray.Length).ToArray();

        var treeNode = new TreeNode(postorder[postorder.Length-1]);

        treeNode.left = constructTree(leftPostorderArray, leftInorderArray);
        treeNode.right = constructTree(rightPostorderArray, rightInorderArray);

        return treeNode;
    }

    public static TreeNode solve(int[] postorder, int[] inorder) {
        if(postorder.Length == 0 || inorder.Length == 0) return null;

        var root = constructTree(postorder, inorder);

        return root;
    }

    public static void Run() {
        var head = new TreeNode(1);
        var head1 = new TreeNode(2);
        var head2 = new TreeNode(3);
        var head3 = new TreeNode(4);
        var head4 = new TreeNode(5);
        var head5 = new TreeNode(6);
        var head6 = new TreeNode(7);

        head.left = head1;
        head.right = head2;

        head1.left = head3;
        head1.right = head4;

        head2.left = head5;
        head2.right = head6;

        var postorder = new int[] {4,5,2,6,7,3,1};
        var inorder = new int[] {4,2,5,1,6,3,7};

        var treeNode = solve(postorder, inorder);
    }
}