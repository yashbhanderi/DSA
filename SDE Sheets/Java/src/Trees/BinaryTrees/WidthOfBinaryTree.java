package Trees.BinaryTrees;

import Trees.TreeNode;

import java.util.*;


public class WidthOfBinaryTree {
    
    public static void getWidth(TreeNode root, Integer width, Integer height, Map<Integer, List<Integer>> map) 
    {
        if(root == null) return;
        
        getWidth(root.left, 2*width + 1, height+1, map);

        if(!map.containsKey(height)) {
            map.put(height, Arrays.asList(-1, -1));
        }
        
        var list = map.get(height);
        
        if(list.get(0) == -1) {
            list.set(0, width);
        }
        else {
            list.set(1, width);
        }

        getWidth(root.right, 2*width + 2, height+1, map);
    }
    
    public static int widthOfBinaryTree(TreeNode root) {
        Map<Integer, List<Integer>> map = new HashMap<>();
        
        getWidth(root, 0, 0, map);
        
        int maxWidth = Integer.MIN_VALUE;
        
        for(var e: map.values()) {
            if(e.get(0) != -1 && e.get(1)!=-1) {
                maxWidth = Math.max(e.get(1) - e.get(0) + 1, maxWidth);
            }
        }
        
        return maxWidth;
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
//        head1.right = head4;

//        head2.left = head5;
        head2.right = head6;
        
        head3.left = head4;
        head6.left = head5;

        var width = widthOfBinaryTree(head);
        System.out.println(width);
    }
}
