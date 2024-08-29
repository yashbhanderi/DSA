namespace Trees.BinaryTrees;

public class ConstructTreeFromPreOrderAndInOrder {

    public static TreeNode constructTree(int[] preoder, int[] inorder) {
        if(preoder.Length == 0 || inorder.Length == 0) return null;

        var rootIndex = Array.IndexOf(inorder, preoder[0]);

        var leftInorderArray = inorder.Skip(0).Take(rootIndex).ToArray();
        var rightInorderArray = inorder.Skip(rootIndex+1).Take(inorder.Length-1).ToArray();

        var leftPreorderArray = preoder.Skip(1).Take(leftInorderArray.Length).ToArray();
        var rightPreorderArray = preoder.Skip(leftInorderArray.Length+1).Take(rightInorderArray.Length+1).ToArray();

        var treeNode = new TreeNode(preoder[0]);

        treeNode.left = constructTree(leftPreorderArray, leftInorderArray);
        treeNode.right = constructTree(rightPreorderArray, rightInorderArray);

        return treeNode;
    }

    public static TreeNode solve(int[] preoder, int[] inorder) {
        if(preoder.Length == 0 || inorder.Length == 0) return null;

        var root = constructTree(preoder, inorder);

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

        var preorder = new int[] {1,2,4,5,3,6,7};
        var inorder = new int[] {4,2,5,1,6,3,7};

        var treeNode = solve(preorder, inorder);
    }
}