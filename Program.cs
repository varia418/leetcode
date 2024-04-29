internal class Program
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    private static void Main(string[] args)
    {
        // TreeNode root = new TreeNode(2,
        //     new TreeNode(2),
        //     new TreeNode(2));

        // TreeNode root = new TreeNode(3,
        //     new TreeNode(1,
        //         new TreeNode(0),
        //         new TreeNode(2)),
        //     new TreeNode(5,
        //         new TreeNode(4),
        //         new TreeNode(6)));

        TreeNode root = new TreeNode(-2147483648, new TreeNode(-2147483648), null);

        bool result = IsValidBST(root);
        System.Console.WriteLine(result);
    }

    public static bool IsValidBST(TreeNode? root, long? min = long.MinValue, long? max = long.MaxValue)
    {
        if (root == null) return true;

        if (root.val > max || root.val < min)
        {
            return false;
        }

        return IsValidBST(root.left, min, root.val - 1) && IsValidBST(root.right, root.val + 1, max);
    }
}