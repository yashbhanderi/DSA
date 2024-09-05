using Trees.BinaryTrees;

public class RecoverBST {

    public static TreeNode Root1 = null;
    public static TreeNode Root2 = null;

    public static TreeNode PrevNode = null;

    public static void GetRecoveredBST(TreeNode root) {
        if(root == null) return;

        GetRecoveredBST(root.left);

        if(PrevNode is null) {
            PrevNode = root;
        }
        else {

            if(root.val < PrevNode.val) {
                if(Root1 is null) 
                    Root1 = PrevNode;
                
                Root2 = root;
            }

            PrevNode = root;
        }

        GetRecoveredBST(root.right);
    }

    public static void Run() {
        var root = new TreeNode(2);
        var root1 = new TreeNode(3);
        var root2 = new TreeNode(1);
        var root3 = new TreeNode(1);
        var root4 = new TreeNode(17);
        var root5 = new TreeNode(11);
        var root6 = new TreeNode(7);

        root.left = root1;
        root.right = root2;

        // root1.left = root3;
        // root1.right = root4;

        // root2.left = root5;
        // root2.right = root6;

        GetRecoveredBST(root);

        if(Root1 is not null && Root2 is not null) {
                (Root1.val, Root2.val) = (Root2.val, Root1.val);
                return;
            }
    }
}