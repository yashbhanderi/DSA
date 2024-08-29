using Trees.BinaryTrees;

namespace Trees.BinarySearchTrees;

public class CheckBST {

    public static HashSet<int> visitedNodes = [];
    public static List<object> IsBST(TreeNode root) {
        if(root == null) return new List<object>{true, int.MaxValue, int.MinValue};

        if(visitedNodes.Contains(root.val)) return new List<object>{false, int.MaxValue, int.MinValue};

        visitedNodes.Add(root.val);

        var leftTree = IsBST(root.left);
        var rightTree = IsBST(root.right);

        var isValid = true;
        
        if((root.left is not null && root.left.val > root.val)
        || (root.right is not null && root.right.val < root.val)
        || (root.val < (int)leftTree[2])
        || (root.val > (int)rightTree[1])
        ) {
            isValid = false;
        }   

        var smallest = (int)leftTree[1];
        var largest = (int)rightTree[2];

        smallest = root.val < smallest ? root.val : smallest; 
        largest = root.val > largest ? root.val : largest; 

        return new List<object> { isValid && (bool)leftTree[0] && (bool)rightTree[0], smallest, largest};
    }

    public static void Run() {
        var root = new TreeNode(10);
        var root1 = new TreeNode(5);
        var root2 = new TreeNode(15);
        var root3 = new TreeNode(1);
        var root4 = new TreeNode(7);
        var root5 = new TreeNode(11);
        var root6 = new TreeNode(17);

        // root.left = root1;
        // root.right = root2;

        // root1.left = root3;
        // root1.right = root4;

        // root2.left = root5;
        // root2.right = root6;

        var ans = IsBST(root);

        System.Console.WriteLine(ans[0]);
    }
}