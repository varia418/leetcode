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

    public static int CountNodes(TreeNode? root)
    {
        if (root is null) return 0;

        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }

    private static void Main(string[] args)
    {
        int?[] rootArr = [5, 3, 6, 2, 4, null, null, 1];
        TreeNode? root = CreateTree(rootArr);
        int result = KthSmallest(root!, 3);

        Console.WriteLine(result);
    }

    public static int KthSmallest(TreeNode root, int k)
    {
        int numLeftNodes = CountNodes(root.left);

        if (k > numLeftNodes + 1)
        {
            return KthSmallest(root.right!, k - numLeftNodes - 1);
        }
        else if (k < numLeftNodes + 1)
        {
            return KthSmallest(root.left!, k);
        }
        else
        {
            return root.val;
        }
    }
}