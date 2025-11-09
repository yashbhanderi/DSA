package Trees.BinaryTrees;

import Trees.TreeNode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class SymmetricTree {

    public static List<Integer> inOrder(TreeNode head) {
        List<Integer> list = new ArrayList<>(List.of(-1));
        if(head == null) return list;
        
        list.addAll(inOrder(head.left));
        list.add(head.val);
        list.addAll(inOrder(head.right));

        return list;
    }

    public static List<Integer> postOrder(TreeNode head) {
        List<Integer> list = new ArrayList<>(List.of(-1));
        if(head == null) return list;
        
        list.addAll(postOrder(head.right));
        list.add(head.val);
        list.addAll(postOrder(head.left));

        return list;
    }


    public static boolean isSymmetric(TreeNode root) {
        if(root == null) return true;
        
        var inOrderTraversal = inOrder(root.left);
        var postOrderTraversal = postOrder(root.right);

        System.out.println(inOrderTraversal);
        System.out.println(postOrderTraversal);
        
        return inOrderTraversal.equals(postOrderTraversal);
    }
    
    public static void main(String[] args) {
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

        System.out.println(isSymmetric(head));
    }
}
