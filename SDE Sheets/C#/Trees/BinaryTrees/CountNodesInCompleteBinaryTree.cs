namespace Trees.BinaryTrees;

public class CountNodes {

    public static int countNodes(TreeNode root) {
        if(root == null) return 0;

        return 1 + countNodes(root.left) + countNodes(root.right);
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

        System.Console.WriteLine(countNodes(head));
    }
}