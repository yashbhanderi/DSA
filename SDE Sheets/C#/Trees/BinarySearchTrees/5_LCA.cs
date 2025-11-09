using Trees.BinaryTrees;

namespace Trees.BinarySearchTrees;

public class LCA {

    // Recommended Approach

    // public static TreeNode GetLCA(TreeNode root, TreeNode p, TreeNode q) {
    //     int small = Math.Min(p.val, q.val);
    //     int large = Math.Max(p.val, q.val);
    //     while (root != null) {
    //         if (root.val > large) // p, q belong to the left subtree
    //             root = root.left;
    //         else if (root.val < small) // p, q belong to the right subtree
    //             root = root.right;
    //         else // Now, small <= root.val <= large -> This root is the LCA between p and q
    //             return root;
    //     }
    //     return null;
    // }   
    
    public static TreeNode GetLCA(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null) return null;

        var left = GetLCA(root.left, p, q);
        var right = GetLCA(root.right, p, q);

        var LCANode = left is not null ? left : right is not null ? right : null;

        if(root == p || root == q) {
            return root;
        }

        return LCANode;
    }   

    public static void Run() {
        var root = new TreeNode(10);
        var root1 = new TreeNode(5);
        var root2 = new TreeNode(15);
        var root3 = new TreeNode(1);
        var root4 = new TreeNode(7);
        var root5 = new TreeNode(11);
        var root6 = new TreeNode(17);
        var root7 = new TreeNode(6);
        var root8 = new TreeNode(8);

        root.left = root1;
        root.right = root2;

        root1.left = root3;
        root1.right = root4;

        root2.left = root5;
        root2.right = root6;

        root4.left = root7;
        root4.right = root8;

        var ans = GetLCA(root, root1, root8);
    }
}