package Trees.BinaryTrees;

import Trees.TreeNode;

public class SameTree {
    
    public static boolean isSameTree(TreeNode root1, TreeNode root2) {
        if(root1 == null && root2 == null) return true;
        
        if(root1 == null || root2 == null) return false;
        
        if(root1.val != root2.val) return false;
        
        return isSameTree(root1.left, root2.left) && isSameTree(root1.right, root2.right);
    }
    
    public static void main(String[] args) {
        var head1 = new TreeNode(100);
        var head11 = new TreeNode(200);
        var head21 = new TreeNode(300);
        var head31 = new TreeNode(400);
        var head41 = new TreeNode(500);
        var head51 = new TreeNode(600);
        var head61 = new TreeNode(700);

        head1.left = head11;
        head1.right = head21;

        head11.left = head31;
        head11.right = head41;

        head21.left = head51;
        head21.right = head61;

        var head2 = new TreeNode(100);
        var head12 = new TreeNode(200);
        var head22 = new TreeNode(300);
        var head32 = new TreeNode(400);
        var head42 = new TreeNode(500);
        var head52 = new TreeNode(600);
        var head62 = new TreeNode(700);

        head2.left = head12;
        head2.right = head22;

        head12.left = head32;
        head12.right = head42;

        head22.left = head52;
        head22.right = head62;

        System.out.println("Same tree: "+ isSameTree(head1, head2));
    }
}
