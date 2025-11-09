package Trees.BinaryTrees;
import Trees.TreeNode;

import java.util.*;

public class VerticalOrderTraversalOfBinaryTree {
    
    public static void dfs(TreeNode root, int width, int height, TreeMap<Integer, TreeMap<Integer, PriorityQueue<Integer>>> map) {
        
        if(root == null) return;
        
        if(!map.containsKey(width)) {
            map.put(width, new TreeMap<>());
        }
        
        if(!map.get(width).containsKey(height)) {
            map.get(width).put(height, new PriorityQueue<>());
        }
        
        map.get(width).get(height).offer(root.val);
        
        dfs(root.left, width - 1, height + 1, map);
        dfs(root.right, width + 1, height + 1, map);
    }
    
    public static List<List<Integer>> verticalOrderTraversalOfBinaryTree(TreeNode root) {
        List<List<Integer>> list = new ArrayList<>();
        
        TreeMap<Integer, TreeMap<Integer, PriorityQueue<Integer>>> map = new TreeMap<>();
        dfs(root, 0, 0, map);
        
        for(var width: map.keySet()) {
            List<Integer> subList = new ArrayList<>();
            for(var height: map.get(width).keySet()) {
                var queue = map.get(width).get(height);

                while(!queue.isEmpty()) {
                    subList.add(queue.poll());
                }
            }
            list.add(subList);
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

        var list = verticalOrderTraversalOfBinaryTree(head);
        for(var e: list) {
            for (var ele: e) {
                System.out.print(ele + " ");
            }
            System.out.println();
        }
    }

//    public static List<List<Integer>> verticalOrderTraversalOfBinaryTree(TreeNode root) {
//        List<List<Integer>> list = new ArrayList<>();
//
//        if(root == null) return list;
//
//        Queue<TreeNode> queue = new LinkedList<>();
//        Map<Integer, List<Integer>> map = new TreeMap<>();
//        Map<TreeNode, Integer> level = new HashMap<>();
//
//        queue.add(root);
//        map.put(0, List.of(root.val));
//        level.put(root, 0);
//
//        while (!queue.isEmpty()) {
//            var top = queue.poll();
//            var currentLevel = level.get(top);
//
//            if(top.left != null) {
//                List<Integer> levelList = new ArrayList<>();
//
//                if(map.containsKey(currentLevel-1)) {
//                    levelList.addAll(map.get(currentLevel-1));
//                    levelList.add(top.left.val);
//                    map.put(currentLevel-1, levelList);
//                }
//                else {
//                    levelList.add(top.left.val);
//                    map.put(currentLevel-1, levelList);
//                }
//
//                level.put(top.left, currentLevel-1);
//                queue.add(top.left);
//            }
//
//            if(top.right != null) {
//                List<Integer> levelList = new ArrayList<>();
//
//                if(map.containsKey(currentLevel+1)) {
//                    levelList.addAll(map.get(currentLevel+1));
//                    levelList.add(top.right.val);
//                    map.put(currentLevel+1, levelList);
//                }
//                else {
//                    levelList.add(top.right.val);
//                    map.put(currentLevel+1, levelList);
//                }
//
//                level.put(top.right, currentLevel+1);
//                queue.add(top.right);
//            }
//        }
//
//        for(var l: map.values()) {
//            List<Integer> sortedList = new ArrayList<>(l);
//            Collections.sort(sortedList);
//            list.add(sortedList);
//        }
//
//        return list;
//    }
}
