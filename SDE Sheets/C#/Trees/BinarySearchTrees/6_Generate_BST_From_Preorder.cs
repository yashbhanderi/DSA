using Trees.BinaryTrees;

namespace Trees.BinarySearchTrees;

public class GenerateBSTFromPreorder {

    public static TreeNode GenerateBST(int[] preorder) {
        if(preorder.Length == 0) return null;

        var root = new TreeNode(preorder[0]);

        var leftList = preorder.Where(x => x < root.val).ToArray();
        var rightList = preorder.Where(x => x > root.val).ToArray();

        root.left = GenerateBST(leftList);
        root.right = GenerateBST(rightList);

        return root;
    }

    public static void Run() {
        // var root = new TreeNode(10);
        // var root1 = new TreeNode(5);
        // var root2 = new TreeNode(15);
        // var root3 = new TreeNode(1);
        // var root4 = new TreeNode(7);
        // var root5 = new TreeNode(11);
        // var root6 = new TreeNode(17);

        // root.left = root1;
        // root.right = root2;

        // root1.left = root3;
        // root1.right = root4;

        // root2.left = root5;
        // root2.right = root6;

        var preorder = new int[] {8,5,1,7,10,12};

        var root = GenerateBST(preorder);
    }
}