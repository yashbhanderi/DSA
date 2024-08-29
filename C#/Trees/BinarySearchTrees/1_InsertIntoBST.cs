using Trees.BinaryTrees;

namespace Trees.BinarySearchTrees;

public class InsertIntoBST {

    public static TreeNode InsertNode(TreeNode root, int target) {
        if(root == null) return new TreeNode(target);

        if(target < root.val) {
            var node = InsertNode(root.left, target);

            if(node is not null) {
                root.left = node;
            }

        } 
        else if(target > root.val) {
            var node = InsertNode(root.right, target);
            if(node is not null) {
                root.right = node;
            }
        }

        return null;
    }

    public static void preOrder(TreeNode root) {
        if(root==null) return;

        System.Console.Write(root.val + " ");

        preOrder(root.left);
        preOrder(root.right);
    }


    public static void Run() {
        var root = new TreeNode(10);
        var root1 = new TreeNode(5);
        var root2 = new TreeNode(15);
        var root3 = new TreeNode(1);
        var root4 = new TreeNode(7);
        var root5 = new TreeNode(11);
        var root6 = new TreeNode(17);

        root.left = root1;
        root.right = root2;

        root1.left = root3;
        root1.right = root4;

        root2.left = root5;
        root2.right = root6;

        preOrder(root);
        
        var ans = InsertNode(root, 8);

        System.Console.WriteLine();

        preOrder(root);
    }
}