namespace Trees.BinaryTrees;

public class FlattenTreeToLinkedList {

    public static void FlattenTree(TreeNode root) {
        if(root == null) return;

        FlattenTree(root.left);
        FlattenTree(root.right);

        if(root.left != null) {
            var rightNode = root.right;
            var leftNode = root.left;

            root.right = leftNode;
            
            while(leftNode.right != null) {
                leftNode = leftNode.right;
            }
            
            leftNode.right = rightNode;

            root.left = null;
        }
    }

    public static void Run() {
var head = new TreeNode(1);
var head1 = new TreeNode(4);
var head2 = new TreeNode(4);
var head3 = new TreeNode(2);
var head4 = new TreeNode(2);
var head5 = new TreeNode(1);
var head6 = new TreeNode(6);
var head7 = new TreeNode(8);
var head8 = new TreeNode(1);
var head9 = new TreeNode(3);

head.left = head1;
head.right = head2;

head1.left = head3;
head1.right = head4;

head3.left = head5;

head4.left = head6;
head4.right = head7;

head6.left = head8;

head7.right = head9;

        FlattenTree(head);
    }
}