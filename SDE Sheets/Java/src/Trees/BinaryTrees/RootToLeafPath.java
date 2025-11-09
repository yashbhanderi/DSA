package Trees.BinaryTrees;

import Trees.TreeNode;

import java.util.*;

public class RootToLeafPath {
    
    public static List<List<Integer>> List = new ArrayList<>();
    
    public static void rootToLeafPath(TreeNode root, Stack<Integer> subList) {
        if(root == null) return;
        
        subList.push(root.val);
        
        rootToLeafPath(root.left, subList);
        rootToLeafPath(root.right, subList);

        if(root.left == null && root.right == null) {
            List.add(new ArrayList<>(subList));
            subList.pop();
        }
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

        List<List<Integer>> list = new ArrayList<>();
        rootToLeafPath(head, new Stack<>());
        for(var e: List) {
            for (var ele: e) {
                System.out.print(ele + " ");
            }
            System.out.println();
        }
    }
}
