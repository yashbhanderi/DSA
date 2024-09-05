using Trees.BinaryTrees;

namespace Trees.BinarySearchTrees;

public class TwoSum {

    public static bool HasTwoSumFound = false;
    public static TreeNode RootNode = null;
    public static TreeNode CurrentNode = null;

    public static bool IsExists(TreeNode root, int val) {
        if(root == null) return false;

        var isExists = false;

        if(root.val < val) {
            isExists = IsExists(root.right, val);
        }   
        else if(root.val > val) {
            isExists = IsExists(root.left, val);
        }
        else {
            if(root != CurrentNode)
                isExists = true;
        }

        return isExists;
    }

    public static bool HasTwoSum(TreeNode root, int sum) {
        if(HasTwoSumFound) return true;

        if(root == null) return false;

        var targetSum = sum - root.val;
        CurrentNode = root;
        var hasTwoSum = IsExists(RootNode, targetSum);

        if(hasTwoSum) {
            return true;
            HasTwoSumFound = true;
        }
        
        var leftTree = HasTwoSum(root.left, sum);
        var rightTree = HasTwoSum(root.right, sum);

        return leftTree || rightTree;
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

        root1.left = root3;
        root1.right = root4;

        root2.left = root5;
        root2.right = root6;

        RootNode = root;
        var ans = HasTwoSum(root, 18);

        System.Console.WriteLine(ans);
    }
}