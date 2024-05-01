internal class Program
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static TreeNode? CreateTree(int?[] treeArr, int index = 0)
    {
        if (index >= treeArr.Length) return null;

        if (treeArr[index] is null) return null;

        TreeNode node = new TreeNode(
            (int)treeArr[index]!,
            CreateTree(treeArr, index * 2 + 1),
            CreateTree(treeArr, index * 2 + 2)
        );

        return node;
    }

    private static void Main(string[] args)
    {
        int[] preorder = [3, 9, 20, 15, 7];
        int[] inorder = [9, 3, 15, 20, 7];
        TreeNode result = BuildTree(preorder, inorder);
        System.Console.WriteLine();
    }

    public static TreeNode BuildTree(int[] preorder, int[] inorder)
    {

    }
}