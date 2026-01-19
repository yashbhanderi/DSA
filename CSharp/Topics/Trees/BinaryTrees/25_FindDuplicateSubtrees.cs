using System.Text;

namespace CSharp.Topics.Trees.BinaryTrees;

public class FindDuplicateSubtrees
{
    public static Dictionary<string, TreeNode> Subtrees = [];
    public static HashSet<TreeNode> DuplicateRootNodes = [];
    public static string GenerateAllCombinations(TreeNode root)
    {
        if (root is null) return "N";
        
        var left = GenerateAllCombinations(root.left);
        var right = GenerateAllCombinations(root.right);

        var current = $"{root.val}|{left}|{right}";
        Console.WriteLine(current);
        
        if (Subtrees.TryGetValue(current, out var node))
        {
            DuplicateRootNodes.Add(node);
        }
        else
        {
            Subtrees.Add(current, root);
        }

        return current;
    }
    
    // public static IList<TreeNode> DuplicateSubtrees(TreeNode root) {
    //     
    // }

    public static void Run()
    {
        var arr = new List<int?>() { 2,1,11,11,null,1 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);
        
        GenerateAllCombinations(treeNode);
        Console.WriteLine(string.Join("", DuplicateRootNodes.Select(x => x.val).ToList()));
    }
}