using Trees.BinaryTrees;

public class LinkedListInBinaryTree {

    public static bool HasLinkedList(TreeNode root, ListNode head) {
        if(head == null) return true;

        if(root == null || root.val != head.val) return false;

        return (
            HasLinkedList(root.left, head.next) || 
            HasLinkedList(root.right, head.next)
        );
    }

    public static bool IsSubPath(ListNode head, TreeNode root) {
        if(HasLinkedList(root, head)) return true;
        
        if(root == null) return false;

        return (
            IsSubPath(head, root.left) ||
            IsSubPath(head, root.right)
        );
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

        var list = new LinkedList();
        
        LinkedList.InsertAtLast(list, 1);
        LinkedList.InsertAtLast(list, 4);
        LinkedList.InsertAtLast(list, 2);
        LinkedList.InsertAtLast(list, 6);
        LinkedList.InsertAtLast(list, 8);

        var ans = IsSubPath(list.head, head);
        System.Console.WriteLine(ans);
    }
}