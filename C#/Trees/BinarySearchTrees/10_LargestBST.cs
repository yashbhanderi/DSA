using Trees.BinaryTrees;

public class LargestBST {

    public static bool IsBSTUtil(TreeNode node, int min, int max)
    {
        /* an empty tree is BST */
        if (node == null) {
            return true;
        }

        /* false if this node violates the min/max
         * constraints */
        if (node.val < min || node.val > max) {
            return false;
        }

        /* otherwise check the subtrees recursively
        tightening the min/max constraints */
        // Allow only distinct values
        return (
            IsBSTUtil(node.left, min, node.val - 1)
            && IsBSTUtil(node.right, node.val + 1, max));
    }

    public static void GetSize(TreeNode root, ref int cnt) {
        if(root == null) return;

        cnt++;
        GetSize(root.left, ref cnt);
        GetSize(root.right, ref cnt);
    }

    public static int GetHeightOfLargestBST(TreeNode root) {
        if(root == null) return 0;

        int maxHeight = 0;

        if(IsBSTUtil(root, int.MinValue, int.MaxValue)) {
            GetSize(root, ref maxHeight);
        }

        return Math.Max(maxHeight, Math.Max(GetHeightOfLargestBST(root.left), GetHeightOfLargestBST(root.right)));
    }

    public static void Run() {
        var root = new TreeNode(6);
        var root1 = new TreeNode(6);
        var root2 = new TreeNode(2);
        var root3 = new TreeNode(2);
        var root4 = new TreeNode(2);
        var root5 = new TreeNode(1);
        var root6 = new TreeNode(3);

        root.left = root1;
        root.right = root2;

        // root1.left = root3;  
        root1.right = root4;

        root2.left = root5;
        root2.right = root6;

        var ans = GetHeightOfLargestBST(root);
        System.Console.WriteLine(ans);
    }
}