package Trees.BinaryTrees;

import Trees.TreeNode;

public class CheckTreeIsHeightBalanced {

    public static int heightOfBinaryTree(TreeNode root) {
        if(root == null) return 0;

        var leftTreeHeight = heightOfBinaryTree(root.left) + 1;
        var rightTreeHeight = heightOfBinaryTree(root.right) + 1;

        return Math.max(leftTreeHeight, rightTreeHeight);
    }

    public static boolean checkTreeIsHeightBalanced(TreeNode root) {
        if(root == null) return true;

        var leftTreeHeight = heightOfBinaryTree(root.left);
        var rightTreeHeight = heightOfBinaryTree(root.right);

        if(Math.abs(leftTreeHeight - rightTreeHeight) > 1) return false;

        return checkTreeIsHeightBalanced(root.left) && checkTreeIsHeightBalanced(root.right);
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

        System.out.println(checkTreeIsHeightBalanced(root));
    }
}
