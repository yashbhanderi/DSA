package Trees.BinaryTrees;

import Trees.TreeNode;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.Stack;

public class BoundaryTraversal {
    
    public static void LeafNodes(TreeNode root, List<Integer> list) {
        if(root == null) return;
        
        LeafNodes(root.left, list);
        LeafNodes(root.right, list);

        if(root.left == null && root.right == null) {
            list.add(root.val);
        }
    }
    
    public static void LeftBoundaryNodes(TreeNode root, List<Integer> list) {
        if(root == null) return;
        
        if(root.left != null) {
            list.add(root.val);
            LeftBoundaryNodes(root.left, list);
        }
        else if(root.right != null) {
            list.add(root.val);
            LeftBoundaryNodes(root.right, list);
        }
    }

    public static void RightBoundaryNodes(TreeNode root, List<Integer> list) {
        if(root == null) return;
        
        if(root.right != null) {
            RightBoundaryNodes(root.right, list);
            list.add(root.val); 
        }
        else if(root.left != null) {
            RightBoundaryNodes(root.left, list);
            list.add(root.val); 
        }
    }
    
    public static List<Integer> boundaryTraversal(TreeNode root) {
        List<Integer> list = new ArrayList<>();
        
        list.add(root.val);
        
        LeftBoundaryNodes(root.left, list);
        
        LeafNodes(root.left, list);
        LeafNodes(root.right, list);
        
        RightBoundaryNodes(root.right, list);
        return list;
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

//        head1.left = head3;
//        head1.right = head4;
//
//        head2.left = head5;
//        head2.right = head6;

        var list = boundaryTraversal(head);
        for(var e: list) {
            System.out.print(e + " ");
        }
    }
}
