namespace CSharp.Topics.Trees.BinarySearchTrees;

public class ConvertSortedArrayToBST
{
    public static TreeNode SortedArrayToBST(int[] nums, int left, int right)
    {
        if (left > right) return null;
        
        int mid = left + ((right - left) / 2);
        TreeNode root = new TreeNode(nums[mid]);

        root.left = SortedArrayToBST(nums, left, mid - 1);
        root.right = SortedArrayToBST(nums, mid + 1, right);

        return root;
    }
    
    public static void Run()
    {
        int[] arr = new int[] {-10, -3, 0, 5, 9};

        var treeNode = SortedArrayToBST(arr, 0, arr.Length - 1);

        TreeHelper.PrintPreOrderTraversal(treeNode);
    }
}