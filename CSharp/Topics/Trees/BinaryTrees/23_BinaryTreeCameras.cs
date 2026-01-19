namespace CSharp.Topics.Trees.BinaryTrees;

public class BinaryTreeCameras
{
    public static int cameraCount = 0;

    public static int MinCameraNeeded(TreeNode root)
    {
        if (root is null) return 1;

        var left = MinCameraNeeded(root.left);
        var right = MinCameraNeeded(root.right);

        if (left == -1 || right == -1)
        {
            cameraCount++;
            return 0;
        }
        if (left == 0 || right == 0)
        {
            return 1;
        }
        return -1;
    }

    public static int MinCameraCover(TreeNode root)
    {
        if (MinCameraNeeded(root) == -1)
        {
            cameraCount++;
        }
        return cameraCount;
    }

    public static void Run()
    {
        var arr = new List<int?>() { 1, 2, 3, null, 4, null, 5 };
        var treeNode = TreeHelper.BuildBinaryTree(arr);

        Console.WriteLine(MinCameraCover(treeNode));
    }
}