using Trees.BinaryTrees;

namespace Trees.BinarySearchTrees;

public class KthSmallest {

    public static int Count = 0;
    public static int KthSmallestValue = 0;
    public static void GetKthSmallest(TreeNode root, int k) {
        if(root == null) return;

        GetKthSmallest(root.left, k);

        Count++;
        if(Count == k) {
           KthSmallestValue = root.val;
        }

        GetKthSmallest(root.right, k);
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

        GetKthSmallest(root, 7);
        System.Console.WriteLine(KthSmallestValue);
    }
}