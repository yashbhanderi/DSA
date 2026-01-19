using System.Text;

namespace CSharp.Topics.Trees.BinaryTrees;

public class SerializeAndDeserializeBinaryTree
{
    // Encodes a tree to a single string.
    public static string Serialize(TreeNode treeNode) {
        var ans = new StringBuilder();
        if (treeNode == null) return ans.ToString();
        
        var root = treeNode;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        ans.Append(root.val);
        int i = 1;
        
        while (q.Count > 0) {
            var node = q.Dequeue();
            
            if (node?.left is not null) {
                q.Enqueue(node.left);
                ans.Append("|" + node.left.val);
            }
            else
            {
                ans.Append("|" + "null");
            }
            
            if (node?.right is not null) {
                q.Enqueue(node.right);
                ans.Append("|" + node.right.val);
            }
            else
            {
                ans.Append("|" + "null");
            }
        }
        
        return ans.ToString();
    }
    
    // Decodes your encoded data to tree.
    public static TreeNode Deserialize(string data)
    {
        if (string.IsNullOrEmpty(data)) return null;
        
        var arr = new List<int?>();
        foreach (var item in data.Split("|"))
        {
            if(item.Equals("null", StringComparison.OrdinalIgnoreCase)) arr.Add(null);
            else arr.Add(int.Parse(item));
        }
        if (arr == null || arr.Count == 0 || arr[0] == null) return null;
        
        var root = new TreeNode(arr[0].Value);
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        int i = 1;
        
        while (q.Count > 0 && i < arr.Count) {
            var node = q.Dequeue();
            
            if (i < arr.Count && arr[i] != null) {
                node.left = new TreeNode(arr[i].Value);
                q.Enqueue(node.left);
            }
            i++;
            
            if (i < arr.Count && arr[i] != null) {
                node.right = new TreeNode(arr[i].Value);
                q.Enqueue(node.right);
            }
            i++;
        }
        
        return root;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 1,2,3,null,null,4,5 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        Console.WriteLine(TreeHelper.PrintLevelOrderTraversal(treeNode));

        var deserializedTree = Deserialize(Serialize(treeNode));
        
        Console.WriteLine(TreeHelper.PrintLevelOrderTraversal(deserializedTree));
    }
}