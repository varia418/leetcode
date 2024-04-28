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
        TreeNode root = new TreeNode(3,
        new TreeNode(1,
            new TreeNode(3),
            null),
        new TreeNode(4,
            new TreeNode(1),
            new TreeNode(5)));

        int result = GoodNodes(root);
        Console.WriteLine(result);
    }

    public static int GoodNodes(TreeNode root, int max = int.MinValue)
    {
        if (root is null) return 0;

        int result = 0;

        if (root.val >= max)
        {
            result++;
            max = root.val;
        }

        result += GoodNodes(root.left, max) + GoodNodes(root.right, max);

        return result;
    }
}