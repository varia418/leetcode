namespace InvertTree
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

    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            TreeNode leftNode = root.left;
            root.left = root.right;
            root.right = leftNode;
        }
    }
}