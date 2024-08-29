package Trees.BinaryTrees;
import Trees.TreeNode;
import java.util.*;

public class BottomViewOfBinaryTree {
    
    public static List<Integer> bottomViewOfBinaryTree(TreeNode root) {
        var list = new ArrayList<Integer>();
        
        if(root == null) return list;
        
        Queue<TreeNode> queue = new LinkedList<>();
        Map<Integer, TreeNode> map = new TreeMap<>();
        Map<TreeNode, Integer> level = new HashMap<>();
        
        queue.add(root);
        map.put(0, root);
        level.put(root, 0);
        
        while (!queue.isEmpty()) {
            var top = queue.poll();
            var currentLevel = level.get(top);
            
            if(top.left != null) {
                map.put(currentLevel-1, top.left);
                level.put(top.left, currentLevel-1);
                queue.add(top.left);
            }

            if(top.right != null) {
                map.put(currentLevel+1, top.right);
                level.put(top.right, currentLevel+1);
                queue.add(top.right);
            }
        }
        
        for(var e: map.values()) {
            list.add(e.val);
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

        var list = bottomViewOfBinaryTree(head);
        for(var e: list) {
            System.out.print(e + " ");
        }
    }
}
