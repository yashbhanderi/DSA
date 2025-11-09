using Trees.BinaryTrees;

public class InorderSuccessor {

    public static TreeNode PrevNode = null;
    public static TreeNode GetInoderSuccessor(TreeNode root, TreeNode node) {
        if(root == null) return null;

        var leftTree = GetInoderSuccessor(root.left, node);

        if(PrevNode is not null) {
            PrevNode = null;
            return root;
        }

        if(root == node) {
            PrevNode = root;
        }

        var rightTree = GetInoderSuccessor(root.right, node);

        return leftTree ?? rightTree; 
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

        var node = GetInoderSuccessor(root, root6);

        if(node is not null)
            System.Console.WriteLine(node.val);
        else 
            System.Console.WriteLine("NULL");
    }
}