package Trees.BinaryTrees;
import Trees.TreeNode;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class PostOrderTraversal {

    public static List<Integer> postOrderWithIteration(TreeNode head) {
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
            var rootValue = top.val;
            top = top.right;

            while(top != null) {
                stack.push(top);
                top = top.right;
            }
            
            list.add(rootValue);
            top = stack.peek();
        }
        

        return list;
    }
    
    public static List<Integer> postOrder(TreeNode head) {
        var list = new ArrayList<Integer>();
        if(head == null) return list;


        list.addAll(postOrder(head.left));
        list.addAll(postOrder(head.right));
        list.add(head.val);

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

        var list1 = postOrder(head);
        var list2 = postOrderWithIteration(head);

        System.out.println("Postorder traversal - Recursive");
        for(var e: list1) System.out.print(e+", ");

        System.out.println();

        System.out.println("Postorder traversal - Iterative");
        for(var e: list2) System.out.print(e+", ");
    }
}
