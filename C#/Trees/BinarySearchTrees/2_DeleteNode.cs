using Trees.BinaryTrees;

namespace Trees.BinarySearchTrees;

public class DeleteFromBST {
    public static TreeNode GetSmallestNode(TreeNode root) {
        if(root == null) return null;

        var leftTree = GetSmallestNode(root.left);

        if(leftTree is not null) return leftTree;

        return root;
    }

    public static TreeNode DeleteNode(TreeNode root, int target) {
        if(root==null) return null;

        if(target < root.val) {
            var leftTree = DeleteNode(root.left, target);

            if(leftTree == null) root.left = null;
        }
        else if(target > root.val) {
            var rightTree = DeleteNode(root.right, target);

            if(rightTree == null) root.right = null;
        }
        else {
            var rightNode = root.right;
            var leftNode = root.left;

            if(leftNode is not null && rightNode is null) {
                root.right = leftNode.right;
                root.val = leftNode.val;
                leftNode.right = null;

                var toBeLeftNode = leftNode.left;
                leftNode.left = null;

                root.left = toBeLeftNode;

                return root;
            }
            else if(leftNode is null && rightNode is not null) {
                root.left = rightNode.left;
                root.val = rightNode.val;
                rightNode.left = null;

                var toBeRightNode = rightNode.right;
                rightNode.right = null;

                root.right = toBeRightNode;
                
                return root;
            }
            else if(leftNode is not null && rightNode is not null) {
                var smallestRightNode = GetSmallestNode(rightNode);

                smallestRightNode.left = leftNode;
                root.val = rightNode.val;

                var toBeLeftNode = rightNode.left;
                var toBeRightNode = rightNode.right;

                root.left = toBeLeftNode;
                root.right = toBeRightNode;

                return root;
            }   
            else {
                return null;
            }
        }

        return root;
    }

    public static void preOrder(TreeNode root) {
        if(root==null) return;

        System.Console.Write(root.val + " ");

        preOrder(root.left);
        preOrder(root.right);
    }


    public static void Run() {
        var root = new TreeNode(10);
        var root1 = new TreeNode(5);
        var root2 = new TreeNode(15);
        var root3 = new TreeNode(1);
        var root4 = new TreeNode(7);
        var root5 = new TreeNode(11);
        var root6 = new TreeNode(17);

        root.left = root1;
        root.right = root2;

        // root1.left = root3;
        root1.right = root4;

        root2.left = root5;
        root2.right = root6;

        preOrder(root);
        
        var ans = DeleteNode(root, 10);

        System.Console.WriteLine();

        preOrder(ans);
    }
}