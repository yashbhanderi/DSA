package Trees.BinaryTrees;

import Common.Common;
import Trees.TreeNode;

public class DiameterOfBinaryTree {
    
    public static int diameter = 0;
    
    public static void diameterOfBinaryTree(TreeNode root) {
        if(root == null) return;
        
        diameterOfBinaryTree(root.left);
        diameterOfBinaryTree(root.right);
        
        diameter = Math.max(diameter, Common.heightOfBinaryTree(root.left) + Common.heightOfBinaryTree(root.right));
    }
    
    public static void main(String[] args) {
        var root = new TreeNode(100);
        var head = new TreeNode(100);
        var head1 = new TreeNode(200);
        var head2 = new TreeNode(300);
        var head3 = new TreeNode(400);
        var head4 = new TreeNode(500);
        var head5 = new TreeNode(600);
        var head6 = new TreeNode(700);

        head.left = head1;
        head.right = head2;

        head1.left = head3;
        head1.right = head4;

        head2.left = head5;
        head2.right = head6;

        diameterOfBinaryTree(head);

        System.out.println("Diameter of given binary tree: "+ diameter);
    }
}
