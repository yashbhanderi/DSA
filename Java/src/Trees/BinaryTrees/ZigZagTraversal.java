package Trees.BinaryTrees;

import Trees.TreeNode;

import java.util.*;

public class ZigZagTraversal {
    
    public static List<List<Integer>> zigZagTraversal(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList<>();
        Stack<TreeNode> tempStack = new Stack<>();
        List<List<Integer>> list = new ArrayList<>();
        List<Integer> tempList = new ArrayList<>();
        boolean flag = false;

        if(root == null) return list;

        queue.add(root);

        while (!queue.isEmpty()) {
            var top = queue.peek();
            
            if(flag) {
                if(top.right != null) tempStack.add(top.right);
                if(top.left != null) tempStack.add(top.left);
            }
            else {
                if(top.left != null) tempStack.add(top.left);
                if(top.right != null) tempStack.add(top.right);
            }
            
            queue.poll();

            if(queue.isEmpty()) {
                flag = !flag;
                tempList.add(top.val);
                list.add(new ArrayList<>(tempList));
                tempList.clear();

                while (!tempStack.isEmpty()) {
                    queue.add(tempStack.pop());
                }
            }
            else {
                tempList.add(top.val);
            }
        }

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

        var list = zigZagTraversal(head);
        for(var e: list) {
            for (var e1 : e)
                System.out.print(e1 + " ");
            System.out.println();
        }
    }
}
