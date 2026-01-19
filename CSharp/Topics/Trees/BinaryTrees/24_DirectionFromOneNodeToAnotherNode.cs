using System.Text;

namespace CSharp.Topics.Trees.BinaryTrees;

public class DirectionFromOneNodeToAnotherNode
{
    //     public string GetDirections(TreeNode root, int startValue, int destValue) {
    //
    //         var pathToStart = new StringBuilder();
    //         var pathToDest = new StringBuilder();
    //
    //         FindPath(root, startValue, pathToStart);
    //         FindPath(root, destValue, pathToDest);
    //
    //         int i = 0;
    //         while (i < pathToStart.Length &&
    //                i < pathToDest.Length &&
    //                pathToStart[i] == pathToDest[i])
    //         {
    //             i++;
    //         }
    //
    //         var result = new StringBuilder();
    //
    //         // remaining path from start -> LCA becomes 'U'
    //         for (int j = i; j < pathToStart.Length; j++)
    //             result.Append('U');
    //
    //         // remaining path from LCA -> destination
    //         for (int j = i; j < pathToDest.Length; j++)
    //             result.Append(pathToDest[j]);
    //
    //         return result.ToString();
    //     }
    //
    //     private bool FindPath(TreeNode root, int target, StringBuilder path)
    //     {
    //         if (root == null) return false;
    //         if (root.val == target) return true;
    //
    //         path.Append('L');
    //         if (FindPath(root.left, target, path)) return true;
    //         path.Length--;
    //
    //         path.Append('R');
    //         if (FindPath(root.right, target, path)) return true;
    //         path.Length--;
    //
    //         return false;
    //     }
    // }
    
    public static string ReverseString(StringBuilder sb)
    {
        var charArray = sb.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static TreeNode LCA(TreeNode root, int p, int q)
    {
        if (root is null) return null;

        if (root.val == p || root.val == q) return root;

        var leftTree = LCA(root.left, p, q);
        var rightTree = LCA(root.right, p, q);

        if (leftTree is not null && rightTree is not null) return root;

        if ((leftTree is not null || rightTree is not null)
            && (root.val == p || root.val == q)) return root;

        if (leftTree is not null) return leftTree;
        if (rightTree is not null) return rightTree;
        return null;
    }

    public static StringBuilder StartToRootPath = new();
    public static StringBuilder RooToDestPath = new();

    public static int GetStartToRootPath(TreeNode root, int startValue)
    {
        if (root is null) return 0;

        if (root.val == startValue)
        {
            return 1;
        }

        var left = GetStartToRootPath(root.left, startValue);
        var right = GetStartToRootPath(root.right, startValue);

        if (left == 1 || right == 1)
        {
            StartToRootPath.Append('U');
            return 1;
        }

        return 0;
    }

    public static int GetRootToDestPath(TreeNode root, int destValue)
    {
        if (root is null) return 0;

        if (root.val == destValue)
        {
            return 1;
        }

        var left = GetRootToDestPath(root.left, destValue);
        var right = GetRootToDestPath(root.right, destValue);

        if (left == 1)
        {
            RooToDestPath.Append('L');
            return 1;
        }
        else if (right == 1)
        {
            RooToDestPath.Append('R');
            return 1;
        }

        return 0;
    }

    public static string GetDirections(TreeNode root, int startValue, int destValue)
    {
        var rootNode = LCA(root, startValue, destValue);
        GetStartToRootPath(rootNode, startValue);
        GetRootToDestPath(rootNode, destValue);

        var rootToDestReversedPath = ReverseString(RooToDestPath); 

        return StartToRootPath.ToString() + rootToDestReversedPath;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 5, 1, 2, 3, null, 6, 4 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        Console.WriteLine(GetDirections(treeNode, 3, 6));
    }
}