package Trees.BinaryTrees;

import Trees.TreeNode;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class MaximumPathSum {
    
    public static int MaxPathSum = -10000;
    public static int maximumPathSum(TreeNode root) {
        if(root == null) return -10000;

        var leftTreeSum =  maximumPathSum(root.left);
        var rightTreeSum = maximumPathSum(root.right);

        MaxPathSum = Math.max(leftTreeSum, MaxPathSum);
        MaxPathSum = Math.max(rightTreeSum, MaxPathSum);
        MaxPathSum = Math.max(root.val + leftTreeSum + rightTreeSum, MaxPathSum);

        return Math.max(root.val, Math.max(root.val + leftTreeSum, root.val + rightTreeSum));
    }
    
    public static void main(String[] args) {
        var head = new TreeNode(100);
        var head1 = new TreeNode(200);
        var head2 = new TreeNode(300);
//        var head3 = new TreeNode(100);
//        var head4 = new TreeNode(300);
//        var head5 = new TreeNode(-200);
//        var head6 = new TreeNode(-100);

        head.left = head1;
        head.right = head2;
//
//        head1.left = head3;
//        head1.right = head4;
//
//        head2.left = head5;
//        head3.left = head6;

        int sum = (maximumPathSum(head));

        System.out.println(MaxPathSum);
        System.out.println(sum);
    }
}
