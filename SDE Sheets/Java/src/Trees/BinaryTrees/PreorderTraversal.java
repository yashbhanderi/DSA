package Trees.BinaryTrees;
import Trees.TreeNode;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;
import java.util.stream.Stream;

public class PreorderTraversal {

    public static List<Integer> preOrderWithIteration(TreeNode head) {
        var list = new ArrayList<Integer>();
        if(head == null) return list;

        var stack = new Stack<TreeNode>();
        
        stack.push(head);
        
        while (!stack.isEmpty()) {
            
            var top = stack.pop();
            
            list.add(top.val);
            
            if(top.right != null) stack.push(top.right);
            if(top.left != null) stack.push(top.left);
        }

        return list;
    }

    public static List<Integer> preOrder(TreeNode head) {
        var list = new ArrayList<Integer>();
        if(head == null) return list;

        list.add(head.val);

        list.addAll(preOrder(head.left));
        list.addAll(preOrder(head.right));

        return list;
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
        
        var list1 = preOrder(head);
        var list2 = preOrderWithIteration(head);

        System.out.println("Preorder traversal - Recursive");
        for(var e: list1) System.out.print(e+", ");

        System.out.println();
        
        System.out.println("Preorder traversal - Iterative");
        for(var e: list2) System.out.print(e+", ");
    }
}
