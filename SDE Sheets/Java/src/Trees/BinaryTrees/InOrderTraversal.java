package Trees.BinaryTrees;
import Trees.TreeNode;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class InOrderTraversal {

    public static List<Integer> inOrderWithIteration(TreeNode head) {
            var list = new ArrayList<Integer>();
            if(head == null) return list;
    
            var stack = new Stack<TreeNode>();
    
            var top = head;
            
            while(top != null || !stack.empty()) {
                
                while(top != null) {
                    
                    stack.push(top);     
                    top = top.left;
                }
                
                top = stack.pop();
                list.add(top.val);
                
                top = top.right;
            }
    
            return list;
    }
    
    public static List<Integer> inOrder(TreeNode head) {
        var list = new ArrayList<Integer>();
        if(head == null) return list;


        list.addAll(inOrder(head.left));
        list.add(head.val);
        list.addAll(inOrder(head.right));

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

        var list1 = inOrder(head);
        var list2 = inOrderWithIteration(head);

        System.out.println("Inorder traversal - Recursive");
        for(var e: list1) System.out.print(e+", ");

        System.out.println();

        System.out.println("Inorder traversal - Iterative");
        for(var e: list2) System.out.print(e+", ");
    }
}
